using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class Products : System.Web.UI.Page
    {

        string[] customerData;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            customerData = (string[])Session["customerData"];
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
            if (!IsPostBack)
            {
                category.DataBind();
                category.Items.Insert(0, new ListItem("-- Select Category --", ""));
            }
            ApplyFilters();

        }

        private void ApplySearchFilter(string searchItem)
        {
            my.Controls.Clear();

            string selectQuery = $"SELECT * FROM Product WHERE product_name LIKE '%{searchItem}%'";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True"))
            {
                con.Open();
                using (var command = new SqlCommand(selectQuery, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string[] rowData = new string[reader.FieldCount];

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                rowData[i] = reader[i].ToString();
                            }

                            DesignBuilder.addProductItem(my, rowData[8], (rowData[1] + ", " + rowData[6] + "KG"), rowData[2], rowData[5], rowData[0], rowData[3], rowData[6], customerData[0]);
                        }
                    }
                }
                con.Close();
            }
        }

        private void resetFunction()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True"))
            {
                con.Open();
                string selectEverything = "select * from Product";
                using (var command = new SqlCommand(selectEverything, con))
                {
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
                            DesignBuilder.addProductItem(my, rowData[8], (rowData[1] + ", " + rowData[6] + "KG"), rowData[2], rowData[5], rowData[0], rowData[3], rowData[6], customerData[0]);
                        }
                        reader.Close();
                    }
                }
                con.Close();
            }
        }

        private void ApplyFilters()
        {
            string startPrice = start.Text;
            string endPrice = end.Text;
            string sortByValue = sortBy.SelectedValue;
            string categoryValue = category.SelectedValue;

            string selectQuery = "SELECT * FROM Product WHERE 1=1";
            if (Request.QueryString["search"] != null)
                {
                    string searchItem = Request.QueryString["search"];

                selectQuery = "SELECT * FROM Product WHERE product_name LIKE @searchItem";
                }

            if (Request.QueryString["start"] != null)
            {
                selectQuery += " AND price >= @startPrice";
            }

            if (Request.QueryString["end"] != null)
            {
                selectQuery += " AND price <= @endPrice";
            }

            if (Request.QueryString["category"] != null)
            {
                selectQuery += " AND product_class = @categoryId";
            }

            if (Request.QueryString["sortBy"] != null)
            {
                switch (sortByValue)
                {
                    case "1":
                        selectQuery += " ORDER BY price ASC";
                        break;
                    case "2":
                        selectQuery += " ORDER BY price DESC";
                        break;
                }
            }

        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True")) {
            con.Open();
                using (SqlCommand command = new SqlCommand(selectQuery, con))
                {
                    if (Request.QueryString["search"] != null)
                    {
                        command.Parameters.AddWithValue("@searchItem", $"%{Request.QueryString["search"]}%");
                    }

                    if (Request.QueryString["start"] != null)
                    {
                        command.Parameters.AddWithValue("@startPrice", Request.QueryString["start"]);
                    }

                    if (Request.QueryString["end"] != null)
                    {
                        command.Parameters.AddWithValue("@endPrice", Request.QueryString["end"]);
                    }

                    if (Request.QueryString["category"] != null)
                    {
                        int val = GetCategoryIdByName(Request.QueryString["category"]);
                        if(val != -1)
                        {
                            command.Parameters.AddWithValue("@categoryId", val);
                        }
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        my.Controls.Clear();

                        while (reader.Read())
                        {
                            string[] rowData = new string[reader.FieldCount];

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                rowData[i] = reader[i].ToString();
                            }
                            if (customerData != null)
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
                con.Close();
            }

        }

        private int GetCategoryIdByName(string categoryName)
        {
            int categoryId = -1;

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True"))
            {
                using (var command = new SqlCommand("SELECT id FROM Product_Category WHERE name = @CategoryName", connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    connection.Close();

                    if (result != null)
                    {
                        int.TryParse(result.ToString(), out categoryId);
                    }
                }
            }

            return categoryId;
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
            browseMoreLink.NavigateUrl = "Login.aspx";
            browseMorePanel.Controls.Add(browseMoreLink);
        }

        private bool AreFiltersApplied()
        {
            return !string.IsNullOrEmpty(Request.QueryString["search"]) ||
                   !string.IsNullOrEmpty(start.Text) ||
                   !string.IsNullOrEmpty(end.Text) ||
                   !string.IsNullOrEmpty(sortBy.SelectedValue) ||
                   !string.IsNullOrEmpty(category.SelectedValue);
        }

        protected void applyButton_Click(object sender, EventArgs e)
        {
            string searchItem = !string.IsNullOrEmpty(Request.QueryString["search"]) ? Request.QueryString["search"] : null;
            string startPrice = !string.IsNullOrEmpty(start.Text) ? start.Text : null;
            string endPrice = !string.IsNullOrEmpty(end.Text) ? end.Text : null;
            string sortByValue = !string.IsNullOrEmpty(sortBy.SelectedValue) ? sortBy.SelectedValue : null;
            string categoryValue = !string.IsNullOrEmpty(category.SelectedValue) ? category.SelectedValue : null;

            if (AreFiltersApplied())
            {
                Response.Redirect($"Products.aspx?{(searchItem != null ? $"search={Server.UrlEncode(searchItem)}&" : "")}" +
                                  $"{(startPrice != null ? $"start={Server.UrlEncode(startPrice)}&" : "")}" +
                                  $"{(endPrice != null ? $"end={Server.UrlEncode(endPrice)}&" : "")}" +
                                  $"{(sortByValue != null ? $"sortBy={Server.UrlEncode(sortByValue)}&" : "")}" +
                                  $"{(categoryValue != null ? $"category={Server.UrlEncode(categoryValue)}" : "")}");
                ApplyFilters();
            }
            else
            {
                Response.Redirect("Products.aspx");
            }
        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }
    }
}