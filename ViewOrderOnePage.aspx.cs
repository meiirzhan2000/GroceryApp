using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static GroceryApp.ShoppingCart1;

namespace GroceryApp
{
    public partial class ViewOrderOnePage : System.Web.UI.Page
    {
        string[] customerData;
        int projectId;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            customerData = (string[])Session["customerData"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                projectId = Int32.Parse(Request.QueryString["projectId"]);
                string idr = Request.QueryString["pastOrCurrent"];
                reviewCheck.Visible = idr == "past" ? true : false;
                LoadOrderDetails(projectId);
                List <CartItem> cartItems = GetCartItemsFromDatabase(projectId);
                alertMessage.Visible = false;
                itemRepeater.DataSource = cartItems;
                itemRepeater.DataBind();

                var footer = Master.FindControl("footerSlideContainer");

                if (footer != null)
                {
                    footer.Visible = false;
                }
            }
        }

        protected void ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        }

        private void LoadOrderDetails(int projectId)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";
            string query = @"SELECT OrderDate, RequiredDate, Status FROM [Order] WHERE id = @ProjectId";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Set the order date
                            DateTime orderDate = Convert.ToDateTime(reader["OrderDate"]);
                            ordersDate.InnerText = "Order Date: " + orderDate.ToString("dd MMM, yyyy");

                            // Set the expected delivery date
                            DateTime requiredDate = Convert.ToDateTime(reader["RequiredDate"]);
                            expDel.InnerText = "Expected Delivery Date: " + requiredDate.ToString("dd MMM, yyyy");

                            // Set the status
                            string status = reader["Status"].ToString();

                            switch (status)
                            {
                                case "Pending":
                                    st1.Attributes["class"] = "d-flex justify-content-center align-items-center big-dot dot";
                                    break;
                                case "Out for delivery":
                                    st2.Attributes["class"] = "d-flex justify-content-center align-items-center big-dot dot";
                                    break;
                                case "Delivered":
                                    st3.Attributes["class"] = "d-flex justify-content-center align-items-center big-dot dot";
                                    break;
                                default:
                                    st3.Attributes["class"] = "d-flex justify-content-center align-items-center big-dot dot";
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private List<CartItem> GetCartItemsFromDatabase(int projectId)
        {
            List<CartItem> cartItems = new List<CartItem>();

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string customerId = customerData[0];

                string query = @"SELECT P.product_name, P.brand_name, P.product_class, P.price, P.image, P.id AS ProductId, OP.quantity
                 FROM Product P
                 INNER JOIN Order_Product OP ON P.id = OP.productID
                 INNER JOIN [Order] O ON OP.OrderID = O.id
                 WHERE O.customerID = @CustomerId AND O.id = @ProjectId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);
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
                                Price = Convert.ToDecimal(reader["price"]) * Convert.ToInt32(reader["Quantity"]),
                                ImageUrl = reader["image"].ToString(),
                                ProductId = reader["ProductId"].ToString(),
                            };

                            cartItems.Add(item);
                        }
                    }
                    con.Close();
                }
            }

            return cartItems;
        }

        protected void submitFeedback(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";
            alertMessage.Attributes["class"] = "alert alert-success alert-dismissible fade show";
            string ratingValue = Request.Form["rating"];
            string ratingValue1 = Request.Form["rating1"];
            string ratingValue2 = Request.Form["rating2"];
            string ratingValue3 = Request.Form["rating3"];
            string comment = TextArea1.Value.Trim();
            projectId = Int32.Parse(Request.QueryString["projectId"]);
            string checkQuery = @"SELECT COUNT(*) FROM Feedback WHERE orderId = @orderId";
            using (SqlConnection checkCon = new SqlConnection(connectionString))
            {
                checkCon.Open();
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, checkCon))
                {
                    checkCmd.Parameters.AddWithValue("@orderId", projectId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Feedback exists, update it
                        string updateQuery = @"UPDATE Feedback SET quality_prod = @quality_prod, 
                                                        expectations = @expectations, 
                                                        del_time = @del_time, 
                                                        value = @value, 
                                                        comment = @comment 
                                       WHERE orderId = @orderId";

                        using (SqlConnection updateCon = new SqlConnection(connectionString))
                        {
                            updateCon.Open();
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, updateCon))
                            {
                                updateCmd.Parameters.AddWithValue("@orderId", projectId);
                                updateCmd.Parameters.AddWithValue("@quality_prod", ratingValue);
                                updateCmd.Parameters.AddWithValue("@expectations", ratingValue1);
                                updateCmd.Parameters.AddWithValue("@del_time", ratingValue2);
                                updateCmd.Parameters.AddWithValue("@value", ratingValue3);
                                updateCmd.Parameters.AddWithValue("@comment", string.IsNullOrEmpty(comment) ? "none" : comment);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        alertText.InnerText = "Feedback updated successfully!";
                        alertMessage.Visible = true;
                    }
                    else
                    {
                        // Feedback does not exist, insert new feedback
                        string insertQuery = @"INSERT INTO Feedback(orderId, quality_prod, expectations, del_time, value, comment) 
                                       VALUES(@orderId, @quality_prod, @expectations, @del_time, @value, @comment )";

                        using (SqlConnection insertCon = new SqlConnection(connectionString))
                        {
                            insertCon.Open();
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, insertCon))
                            {
                                insertCmd.Parameters.AddWithValue("@orderId", projectId);
                                insertCmd.Parameters.AddWithValue("@quality_prod", ratingValue);
                                insertCmd.Parameters.AddWithValue("@expectations", ratingValue1);
                                insertCmd.Parameters.AddWithValue("@del_time", ratingValue2);
                                insertCmd.Parameters.AddWithValue("@value", ratingValue3);
                                insertCmd.Parameters.AddWithValue("@comment", string.IsNullOrEmpty(comment) ? "none" : comment);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        alertText.InnerText = "Feedback added successfully!";
                        alertMessage.Visible = true;
                    }
                }
            }
        }

        protected void submitHelp(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";
            string comment = TextArea.Value.Trim(); 

            if (string.IsNullOrEmpty(comment))
            {
                alertText.InnerText = "Please include something before submitting!";
                alertMessage.Attributes["class"] = "alert alert-warning alert-dismissible fade show";
                alertMessage.Visible = true;
                return;
            }

            int orderId = Int32.Parse(Request.QueryString["projectId"]);

            string alertMessageIn = "";

            string checkQuery = @"SELECT COUNT(*) FROM Help_Order WHERE orderId = @orderId";
            using (SqlConnection checkCon = new SqlConnection(connectionString))
            {
                checkCon.Open();
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, checkCon))
                {
                    checkCmd.Parameters.AddWithValue("@orderId", orderId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Record exists, update it
                        string updateQuery = @"UPDATE Help_Order SET comment = @comment WHERE orderId = @orderId";

                        using (SqlConnection updateCon = new SqlConnection(connectionString))
                        {
                            updateCon.Open();
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, updateCon))
                            {
                                updateCmd.Parameters.AddWithValue("@orderId", orderId);
                                updateCmd.Parameters.AddWithValue("@comment", comment);
                                int rowsAffected = updateCmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    alertMessageIn = "Help request updated successfully!";
                                }
                            }
                        }
                    }
                    else
                    {
                        // Record does not exist, insert new record
                        string insertQuery = @"INSERT INTO Help_Order (comment, orderId) VALUES (@comment, @orderId)";

                        using (SqlConnection insertCon = new SqlConnection(connectionString))
                        {
                            insertCon.Open();
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, insertCon))
                            {
                                insertCmd.Parameters.AddWithValue("@comment", comment);
                                insertCmd.Parameters.AddWithValue("@orderId", orderId);
                                int rowsAffected = insertCmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    alertMessageIn = "Help request submitted successfully!";
                                }
                            }
                        }
                    }
                }
            }

            alertText.InnerText = alertMessageIn;
            alertMessage.Attributes["class"] = "alert alert-success alert-dismissible fade show";
            alertMessage.Visible = true;
        }

        protected void cancelSubmit(object sender, EventArgs e)
        {
            string selectedReason = cancelReason.Value;
            string comment = TextArea2.Value.Trim();

            if (string.IsNullOrEmpty(comment))
            {
                alertText.InnerText = "Please include something before submitting!";
                alertMessage.Attributes["class"] = "alert alert-warning alert-dismissible fade show";
                alertMessage.Visible = true;
                return;
            }

            int orderId = Int32.Parse(Request.QueryString["projectId"]);

            string query = "SELECT COUNT(*) FROM Cancel_Reason WHERE orderId = @orderId";

            string insertQuery = "INSERT INTO Cancel_Reason (reason, comment, orderId) VALUES (@reason, @comment, @orderId)";
            string updateQuery = "UPDATE Cancel_Reason SET reason = @reason, comment = @comment WHERE orderId = @orderId";

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    int existingRecordsCount = (int)cmd.ExecuteScalar();

                    if (existingRecordsCount > 0)
                    {
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                        {
                            updateCmd.Parameters.AddWithValue("@reason", selectedReason);
                            updateCmd.Parameters.AddWithValue("@comment", comment);
                            updateCmd.Parameters.AddWithValue("@orderId", orderId);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                        {
                            insertCmd.Parameters.AddWithValue("@reason", selectedReason);
                            insertCmd.Parameters.AddWithValue("@comment", comment);
                            insertCmd.Parameters.AddWithValue("@orderId", orderId);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            alertText.InnerText = "The cancellation request has been set to the admin, we will contact you soon";
            alertMessage.Attributes["class"] = "alert alert-success alert-dismissible fade show";
            alertMessage.Visible = true;
        }
    }
}