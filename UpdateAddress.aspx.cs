using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GroceryApp
{
    public partial class UpdateAddress : System.Web.UI.Page
    {
        string[] addressData;
        string[] customerData;
        string addressUpdate;

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
            addressUpdate = Request.QueryString["addressUpdate"];
            if (!string.IsNullOrEmpty(addressUpdate) && addressUpdate.ToLower() == "true")
            {
                panel1.Controls.Add(new LiteralControl("<div class=\"row\">"));
                panel1.Controls.Add(new LiteralControl("<div class=\"col\">"));
                panel1.Controls.Add(new LiteralControl("<nav aria-label=\"breadcrumb\" class=\"bg-light rounded-3 p-3 mb-4\">"));
                panel1.Controls.Add(new LiteralControl("<ol class=\"breadcrumb mb-0\">"));
                panel1.Controls.Add(new LiteralControl("<li class=\"breadcrumb-item\"><a href=\"ShoppingCart.aspx\">Shopping Cart</a></li>"));
                panel1.Controls.Add(new LiteralControl("<li class=\"breadcrumb-item active\" aria-current=\"page\">Update Address</li>"));
                panel1.Controls.Add(new LiteralControl("</ol>"));
                panel1.Controls.Add(new LiteralControl("</nav>"));
                panel1.Controls.Add(new LiteralControl("</div>"));
                panel1.Controls.Add(new LiteralControl("</div>"));
            }
            else
            {
                panel1.Controls.Add(new LiteralControl("<div class=\"row\">"));
                panel1.Controls.Add(new LiteralControl("<div class=\"col\">"));
                panel1.Controls.Add(new LiteralControl("<nav aria-label=\"breadcrumb\" class=\"bg-light rounded-3 p-3 mb-4\">"));
                panel1.Controls.Add(new LiteralControl("<ol class=\"breadcrumb mb-0\">"));
                panel1.Controls.Add(new LiteralControl("<li class=\"breadcrumb-item\"><a href=\"UserProfile.aspx\">Profile Page</a></li>"));
                panel1.Controls.Add(new LiteralControl("<li class=\"breadcrumb-item\"><a href=\"ProfileUpdate.aspx\">Update Profile</a></li>"));
                panel1.Controls.Add(new LiteralControl("<li class=\"breadcrumb-item active\" aria-current=\"page\">Update Address</li>"));
                panel1.Controls.Add(new LiteralControl("</ol>"));
                panel1.Controls.Add(new LiteralControl("</nav>"));
                panel1.Controls.Add(new LiteralControl("</div>"));
                panel1.Controls.Add(new LiteralControl("</div>"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                alertMessage.Visible = false;
                addressData = (string[])Session["addressCustomer"];
                if (addressData != null)
                {
                    DataLoad();
                }
            }
        }

        protected void DataLoad()
        {
            stateU.Text = addressData[0];
            cityU.Text = addressData[1];
            postcodeU.Text = addressData[2];
            address.Text = addressData[3];
        }

        protected bool checker()
        {
            string postcodeCheck = Checker.checkAddress(postcodeU.Text.Trim());
            string addressCheck = Checker.checkPostcode(address.Text.Trim());
            if (postcodeCheck != null)
            {
                alert(postcodeCheck, "alert, alert-danger alert-dismissible fade show");
                return false;
            }
            else if (addressCheck != null)
            {
                alert(addressCheck, "alert, alert-danger alert-dismissible fade show");
                return false;
            }
            return true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checker() == false)
            {
                return;
            }
            string conStr = ConfigurationManager.ConnectionStrings["GroData"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            string updateAddress = @"
                    MERGE INTO Address AS Target 
                    USING (SELECT @Email AS Email) AS Source 
                    ON Target.Email = Source.Email 
                    WHEN MATCHED THEN 
                        UPDATE SET Target.city = @City, Target.state = @State, Target.address = @Address, Target.postcode = @Postcode 
                    WHEN NOT MATCHED THEN 
                        INSERT (email, city, state, postcode, address) VALUES (@Email, @City, @State, @Postcode, @Address);
                ";
            using (SqlCommand connectionIns = new SqlCommand(updateAddress, con))
            {
                connectionIns.Parameters.AddWithValue("@Email", customerData[0]);
                connectionIns.Parameters.AddWithValue("@Address", address.Text.Trim());
                connectionIns.Parameters.AddWithValue("@Postcode", postcodeU.Text.Trim());
                connectionIns.Parameters.AddWithValue("@City", cityU.Text.Trim());
                connectionIns.Parameters.AddWithValue("@State", stateU.Text.Trim());
                con.Open();
                connectionIns.ExecuteNonQuery();
                con.Close();
            }
            if (!string.IsNullOrEmpty(addressUpdate) && addressUpdate.ToLower() == "true")
            {
                Response.Redirect("ShoppingCart.aspx");
            }
            addContent(con);
            addressData = new string[] { stateU.Text.Trim(), cityU.Text.Trim(), postcodeU.Text.Trim(), address.Text.Trim() };
            Session["addressCustomer"] = new string[] { stateU.Text.Trim(), cityU.Text.Trim(), postcodeU.Text.Trim(), address.Text.Trim() };
            DataLoad();
            alert("Address Successfully Updated!", "alert alert-success alert-dismissible fade show");
        }

        protected void alert(string text, string classType)
        {
            alertMessage.Attributes["Class"] = classType;
            alertText.InnerText = text;
            alertMessage.Visible = true;
        }

        private void addContent(SqlConnection con)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            if (customerData[0] != null)
            {
                string insert = "Insert into [Activity] (date, activity, email) values(@Date, @Type, @Email)";
                using (SqlCommand connectionIns = new SqlCommand(insert, con))
                {
                    connectionIns.Parameters.AddWithValue("@Date", dateTime.ToString("dd/MM/yyyy"));
                    connectionIns.Parameters.AddWithValue("@Type", "UpdAddress");
                    connectionIns.Parameters.AddWithValue("@Email", customerData[0]);
                    con.Open();
                    connectionIns.ExecuteNonQuery();
                    con.Close();
                }
            }

        }
    }
}