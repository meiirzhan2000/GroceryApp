using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True");

        string[] customerData;

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
                    this.MasterPageFile = "~/VisitorsPage.Master";
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
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"];
                string image = Request.QueryString["image"];
                string name = Request.QueryString["name"];
                string price = Request.QueryString["price"];
                string description = Request.QueryString["description"];
                string classId = Request.QueryString["classId"];

                productNameLabel.InnerText = name;
                priceLabel.InnerText = price;
                descriptionLabel.InnerText = description;
                productImage.ImageUrl = image;
                skuLabel.Text = GetCategoryNameById(classId);
                using (con)
                {
                    con.Open();
                    string selectEverything = "select * from Product WHERE product_class=@productClass";
                    using (var command = new SqlCommand(selectEverything, con))
                    {
                        command.Parameters.AddWithValue("@productClass", classId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var rows = new List<string[]>();
                            while (reader.Read())
                            {
                                // Create an array to hold the column values for each row
                                string[] rowData = new string[reader.FieldCount];

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    // Explicitly cast the column values to string
                                    rowData[i] = reader[i].ToString();
                                }

                                // Add the array to the list
                                rows.Add(rowData);
                                if(customerData != null)
                                {
                                    DesignBuilder.addProductItem(my, rowData[8], (rowData[1] + ", " + rowData[6] + "KG"), rowData[2], rowData[5], rowData[0], rowData[3], rowData[6], customerData[0]);
                                }
                                else
                                {
                                    DesignBuilder.addProductItem(my, rowData[8], (rowData[1] + ", " + rowData[6] + "KG"), rowData[2], rowData[5], rowData[0], rowData[3], rowData[6]);
                                }
                            }
                            reader.Close();
                        }
                    }
                }
                addBrowseMoreProductsSection();
                con.Close();
            }
        }

        private string GetCategoryNameById(string id)
        {
            string categoryName = "Class: None";

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True"))
            {
                using (var command = new SqlCommand("SELECT name FROM Product_Category WHERE id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    connection.Close();

                    if (result != null)
                    {
                        categoryName = result.ToString();
                    }
                }
            }

            return categoryName;
        }

        public void addBrowseMoreProductsSection()
        {
            Panel browseMorePanel = new Panel();
            browseMorePanel.CssClass = "col-12 text-center";
            my.Controls.Add(browseMorePanel);

            HyperLink browseMoreLink = new HyperLink
            {
                CssClass = "btn btn-primary rounded-pill py-3 px-5",
                Text = "Browse More Products"
            };
            browseMoreLink.NavigateUrl = "Products.aspx";
            browseMorePanel.Controls.Add(browseMoreLink);
        }
    }
}