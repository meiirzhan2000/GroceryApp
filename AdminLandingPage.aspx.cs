using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class AdminLandingPage : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            string[] customerData = (string[])Session["customerData"];
            if (!IsPostBack)
            {
                if (customerData == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> d = retriveDates("UpdAddress");
            Dictionary<string, int> d1 = retriveDates("Update");
            Dictionary<string, int> d2 = retriveDates("Registration");
            foreach (var key2 in d)
            {
                Debug.Print("Visit the Website Keys : " + key2.Key + " values: " + key2.Value);
            }
            foreach (var key2 in d1)
            {
                Debug.Print("Login : " + key2.Key + " values: " + key2.Value);
            }
            foreach (var key2 in d2)
            {
                Debug.Print("Visit the Website Keys : " + key2.Key + " values: " + key2.Value);
            }
            var arrayOfAllKeys = d.Keys.ToArray();
            DisplayStatistics();
            if (arrayOfAllKeys.Length > 0)
            {
                string chartData = "";
                string views = "";
                string labels = "";
                string chartData2 = "";
                string views2 = "";
                string labels2 = "";
                string chartData3 = "";
                string views3 = "";
                string labels3 = "";

                chartData += "<script>";
                chartData2 += "<script>";
                chartData3 += "<script>";

                foreach (var key in d)
                {
                    views += key.Value + ",";
                    labels += "\"" + key.Key + "\",";
                }

                foreach (var key1 in d1)
                {
                    views2 += key1.Value + ",";
                    labels2 += "\"" + key1.Key + "\",";
                }

                foreach (var key2 in d2)
                {
                    views3 += key2.Value + ",";
                    labels3 += "\"" + key2.Key + "\",";
                }

                views = views.Substring(0, views.Length - 1);
                labels = labels.Substring(0, labels.Length - 1);
                views2 = views2.Substring(0, views2.Length - 1);
                labels2 = labels2.Substring(0, labels2.Length - 1);
                views3 = views3.Substring(0, views3.Length - 1);
                labels3 = labels3.Substring(0, labels3.Length - 1);

                chartData += " chartLabels = [" + labels + "]; chartData = [" + views + "]";
                chartData2 += " chartLabel2 = [" + labels2 + "]; chartDat2 = [" + views2 + "]";
                chartData3 += " chartLabel = [" + labels3 + "]; chartDat = [" + views3 + "]";

                chartData += "</script>";
                chartData2 += "</script>";
                chartData3 += "</script>";

                ltChartData.Text = chartData;
                Literal1.Text = chartData2;
                Literal2.Text = chartData3;
            }
        }

        private void DisplayStatistics()
        {
            int totalSales = CalculateTotalSales();
            int profits = CalculateProfit(totalSales, 0.20); 
            int numberOfOrders = GetNumberOfOrders();
            int numberOfUsers = GetNumberOfRegisteredUsers();

            profit.InnerHtml = $"${totalSales}";
            sales.InnerHtml = $"${profits}";
            registed.InnerHtml = numberOfUsers.ToString();
            orders.InnerHtml = numberOfOrders.ToString();

        }

        private int GetNumberOfOrders()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM [Order]";
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    count = (int)cmd.ExecuteScalar();
                }
            }
            return count;
        }

        private int GetNumberOfRegisteredUsers()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM Customer"; 
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    count = (int)cmd.ExecuteScalar();
                }
            }
            return count;
        }

        private int CalculateTotalSales()
        {
            int sales = 0;
            string query = "SELECT SUM(p.price * op.quantity) FROM Order_Product op INNER JOIN Product p ON op.productID = p.id";
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    sales = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return sales;
        }

        private int CalculateProfit(int totalSales, double profitPercentage)
        {
            return (int)(totalSales * profitPercentage);
        }

        private Dictionary<string, int> retriveDates(string typeOfActivityName)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True");
            var lastSixMonths = Enumerable.Range(1, 6).Select(i => DateTime.Now.AddMonths(i - 6).ToString("MM/yyyy"));
            string[] Months = new string[7];
            int b = 0;
            Dictionary<string, int> d = new Dictionary<string, int>();
            foreach (var monthAndYear in lastSixMonths)
            {
                Months[b] = monthAndYear.ToString();
                d.Add(Months[b++], 0);
            }
            using (con)
            {
                con.Open();
                string selectEverything = "select * from Activity where activity = '" + typeOfActivityName + "'";
                using (var command = new SqlCommand(selectEverything, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var rows = new List<string[]>();
                        while (reader.Read())
                        {
                            string[] rowData = new string[reader.FieldCount];

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                rowData[i] = reader[i].ToString();
                                if (i == 1)
                                {
                                    string newFormat = DateTime.ParseExact(rowData[i], "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/yyyy");
                                    if (d.ContainsKey(newFormat))
                                    {
                                        d[newFormat] = d[newFormat] + 1;
                                    }
                                }
                            }
                            rows.Add(rowData);
                        }
                        reader.Close();
                    }
                }
            }
            con.Close();
            return d;
        }
    }
}