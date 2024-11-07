using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GroceryApp.ShoppingCart1;

namespace GroceryApp
{
    public partial class VisitorsPage : System.Web.UI.MasterPage
    {

        string[] customerData;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            customerData = (string[])Session["customerData"];
        }

        public void SetCartItemCount()
        {
            int totalItemCount = GetCartItemsFromDatabase();

            if (totalItemCount > 0)
            {
                cartItemCount.InnerText = totalItemCount.ToString();
                cartItemCount.Visible = true;
            }
            else
            {
                cartItemCount.Visible = false;
            }
        }

        private int GetCartItemsFromDatabase()
        {
            List<CartItem> cartItems = new List<CartItem>();

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (customerData == null || customerData.Length == 0)
                {
                    return 0;
                }

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

            return cartItems.Count;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            SetCartItemCount();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchItem = search.Text;

            Response.Redirect($"Products.aspx?search={Server.UrlEncode(searchItem)}");
        }
    }
}