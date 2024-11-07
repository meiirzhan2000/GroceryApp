using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace GroceryApp
{
    public partial class ShoppingCart1 : System.Web.UI.Page
    {
        string[] customerData;
        string addressCheck;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            string[] customerData = (string[])Session["customerData"];
            if (!IsPostBack)
            {
                if (customerData != null)
                {
                    this.MasterPageFile = "~/Customer.Master";
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            customerData = (string[])Session["customerData"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime currentDate = DateTime.Today;
                txtConfirmationDate.Attributes["min"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                txtConfirmationDate.Attributes["max"] = DateTime.Now.AddMonths(2).ToString("yyyy-MM-dd");
                txtConfirmationDate.Attributes["value"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                alertMessageFor.Visible = false;
                BindRepeater();
                Debug.WriteLine($"Customer Data: {string.Join(", ", customerData)}");
            }
        }

        protected void BindRepeater()
        {
            List<CartItem> cartItems = GetCartItemsFromDatabase();
            addressCheck = checkAddress();
            if (addressCheck == null)
            {
                orderAddress.InnerHtml = "<a href='UpdateAddress.aspx?addressUpdate=true'>Add Address</a>";
            }
            else
            {
                orderAddress.InnerText = addressCheck;
            }

            decimal totalCost = cartItems.Sum(item => item.Price * item.Quantity);
            decimal shippingCost = CalculateShippingCost(cartItems.Count);

            lblSubtotal.InnerText = totalCost.ToString("C");
            lblShipping.InnerText = shippingCost.ToString("C");
            lblTotal.InnerText = (totalCost + shippingCost).ToString("C");

            itemRepeater.DataSource = cartItems;
            itemRepeater.DataBind();
        }

        protected void ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Increase" || e.CommandName == "Decrease")
            {
                int index = e.Item.ItemIndex;

                int currentQuantity = int.Parse(((HtmlInputGenericControl)e.Item.FindControl("form1")).Value);

                if (e.CommandName == "Increase")
                {
                    currentQuantity++;
                }
                else if (e.CommandName == "Decrease")
                {
                    if (currentQuantity > 0)
                    {
                        currentQuantity--;
                    }
                }

                ((HtmlInputGenericControl)e.Item.FindControl("form1")).Value = currentQuantity.ToString();

                UpdateDatabase(index, currentQuantity);

                BindRepeater();
            }
        }
        protected void UpdateDatabase(int index, int newQuantity)
        {
            string customerId = customerData[0];
            string productId = ((Label)itemRepeater.Items[index].FindControl("lblProductId")).Text;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (newQuantity == 0)
                {
                    // If quantity is 0, delete the item from the database
                    string deleteQuery = "DELETE FROM Cart_Item WHERE ProductID = @ProductId AND CustomerEmail = @CustomerId";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                    {
                        deleteCmd.Parameters.AddWithValue("@ProductId", productId);
                        deleteCmd.Parameters.AddWithValue("@CustomerId", customerId);
                        con.Open();
                        deleteCmd.ExecuteNonQuery();
                    }
                    BindRepeater();
                }
                else
                {
                    // If quantity is not 0, update the quantity in the database
                    string updateQuery = "UPDATE Cart_Item SET Quantity = @NewQuantity " +
                                         "WHERE ProductID = @ProductId AND CustomerEmail = @CustomerId";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                    {
                        updateCmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
                        updateCmd.Parameters.AddWithValue("@ProductId", productId);
                        updateCmd.Parameters.AddWithValue("@CustomerId", customerId);
                        con.Open();
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
        }


        protected string checkAddress()
        {
            string selectQuery = "SELECT * FROM Address WHERE email = @Email";
            bool addressExists = false;

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True"))
            {
                con.Open();
                using (var command = new SqlCommand(selectQuery, con))
                {
                    command.Parameters.AddWithValue("@Email", customerData[0]);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        if (reader.HasRows)
                        {
                            // Address exists
                            addressExists = true;

                            while (reader.Read())
                            {
                                return "\t" + reader.GetString(1) + " " + reader.GetString(4) + " " + reader.GetString(3) + " " + reader.GetInt32(2).ToString();
                            }
                        }
                        else
                        {
                            // Address does not exist
                            addressExists = false;
                            return null;
                        }
                    }
                }
                con.Close();
            }
            return null;
        }

        private string FindSelected()
        {
            if(radioNoLabel1v.Checked == true)
            {
                return "Credit Card";
            }
            else if(radioNoLabel2v.Checked == true)
            {
                return "Debit Card";
            }
            else if(radioNoLabel3v.Checked == true)
            {
                return "PayPal";
            }
            else
            {
                return null;
            }
        }

        private decimal CalculateShippingCost(int itemCount)
        {
            int shippingCostPerGroup = 1;
            int itemsPerGroup = 3;

            int shippingGroups = itemCount / itemsPerGroup;
            decimal shippingCost = shippingGroups * shippingCostPerGroup;

            return shippingCost;
        }

        public class CartItem
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
            public string ProductId {  get; set; }
        }

        protected void closeAlert(object sender, EventArgs e)
        {
            alertMessageFor.Visible = false;
            Debug.WriteLine($"Customer 234");
        }


        private List<CartItem> GetCartItemsFromDatabase()
        {
            List<CartItem> cartItems = new List<CartItem>();

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string customerId = customerData[0];

                string query = @"SELECT P.product_name, P.brand_name, P.product_class, P.price, P.image, P.id, CI.Quantity
                                 FROM Product P
                                 INNER JOIN Cart_Item CI ON P.id = CI.ProductID
                                 WHERE CI.CustomerEmail = @CustomerId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CartItem item = new CartItem
                            {
                                Title = reader["product_name"].ToString(),
                                Author = reader["brand_name"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Price = Convert.ToDecimal(reader["price"]),
                                ImageUrl = reader["image"].ToString(),
                                ProductId = reader["id"].ToString(),
                            };

                            cartItems.Add(item);
                        }
                    }
                    con.Close();
                }
            }

            return cartItems;
        }

        private string check_credit_info()
        {
            if (string.IsNullOrEmpty(typeName.Value))
            {
                return "Name on card is required.";
            }

            // Check if expiration is empty or does not match the MM/YY format
            if (string.IsNullOrEmpty(typeExp.Value) || !Regex.IsMatch(typeExp.Value, @"^(0[1-9]|1[0-2])\/[0-9]{2}$"))
            {
                return "Expiration must be in the format MM/YY.";
            }

            // Check if card number is empty or does not match the 16-digit format
            if (string.IsNullOrEmpty(typeText.Value) || !Regex.IsMatch(typeText.Value, @"^\d{4} \d{4} \d{4} \d{4}$"))
            {
                return "Card number must be in the format xxxx xxxx xxxx xxxx.";
            }

            // Check if CVV is empty or does not match the 3-digit format
            if (string.IsNullOrEmpty(typeText1.Value))
            {
                return "CVV must be a 3-digit number.";
            }
            return "";

        }

        private void DeleteCartItems()
        {
            string customerId = customerData[0];
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";

            string deleteQuery = "DELETE FROM Cart_Item WHERE CustomerEmail = @CustomerId";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void CreateOrderAndOrderProducts()
        {
            DateTime selectedDate = DateTime.ParseExact(txtConfirmationDate.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime selectedTime = DateTime.ParseExact(appt.Value, "HH:mm", CultureInfo.InvariantCulture);

            selectedDate = selectedDate.AddHours(selectedTime.Hour);
            selectedDate = selectedDate.AddMinutes(selectedTime.Minute);

            DateTime requiredDate = selectedDate;

            DateTime shippingDate = selectedDate.AddHours(-2);

            string customerId = customerData[0];
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";

            int orderId;
            string insertOrderQuery = "INSERT INTO [Order] (customerID, OrderDate, RequiredDate, ShippedDate, Status, Comments) VALUES (@CustomerId, @OrderDate, @RequiredDate, @ShippedDate, @Status, @Comments); SELECT SCOPE_IDENTITY();";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(insertOrderQuery, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@RequiredDate", requiredDate);
                    cmd.Parameters.AddWithValue("@ShippedDate", shippingDate);
                    cmd.Parameters.AddWithValue("@Status", "Pending");
                    cmd.Parameters.AddWithValue("@Comments", TextArea.Value.Length != 0 ? TextArea.Value : "None");
                    con.Open();
                    orderId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            List<CartItem> cartItems = GetCartItemsFromDatabase();
            foreach (var item in cartItems)
            {
                string insertOrderProductQuery = "INSERT INTO Order_Product (OrderID, productID, quantity) VALUES (@OrderId, @ProductId, @Quantity);";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(insertOrderProductQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            string headerMessage = "has confirmed your order";
            string description = "Your order has been successfully confirmed! Please make sure that the order details are correct.";
            string imageURL = "https://cdn-icons-png.flaticon.com/512/4682/4682662.png";
            DateTime notificationDate = DateTime.Now;

            string insertNotificationQuery = @"
        INSERT INTO Notification (header_meesage, description, imageURL, date, status, order_id) 
        VALUES (@HeaderMessage, @Description, @ImageURL, @Date, @Status, @OrderId)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(insertNotificationQuery, con))
                {
                    cmd.Parameters.AddWithValue("@HeaderMessage", headerMessage);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@ImageURL", imageURL);
                    cmd.Parameters.AddWithValue("@Date", notificationDate);
                    cmd.Parameters.AddWithValue("@Status", 0);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


            DeleteCartItems();
            BindRepeater();

            alertText.InnerText = "Order has been added successfully.";
            alertMessageFor.Attributes["class"] = "alert alert-success alert-dismissible fade show";
            alertMessageFor.Visible = true;
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"Customer Data12: {string.Join(", ", customerData)}");
            string paymentMethod = FindSelected();
            string check_info = check_credit_info();
            addressCheck = checkAddress();
            List<CartItem> cartItems = GetCartItemsFromDatabase();
            if (cartItems.Count == 0)
            {
                alertText.InnerText = "Your cart is empty. Please add items before proceeding.";
                alertMessageFor.Attributes["class"] = "alert alert-warning alert-dismissible fade show";
                alertMessageFor.Visible = true;
                return;
            }

            if (paymentMethod != null)
            {
                if (addressCheck != null)
                {
                    if (check_info != "")
                    {
                        alertText.InnerText = check_info;
                        alertMessageFor.Attributes["class"] = "alert alert-danger alert-dismissible fade show";
                        alertMessageFor.Visible = true;
                    }
                    else
                    {
                        CreateOrderAndOrderProducts();
                    }
                }
                else
                {
                    alertText.InnerText = "Please add your address in the profile page before proceeding";
                    alertMessageFor.Attributes["class"] = "alert alert-danger alert-dismissible fade show";
                    alertMessageFor.Visible = true;

                }
            }
            else
            {
                alertText.InnerText = "Please select a payment method.";
                alertMessageFor.Attributes["class"] = "alert alert-warning alert-dismissible fade show";
                alertMessageFor.Visible = true;
            }
        }
    }
}