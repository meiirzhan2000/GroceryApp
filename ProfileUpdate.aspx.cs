using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class ProfileUpdate : System.Web.UI.Page
    {
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
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                alertMessage.Visible = false;
                customerData = (string[])Session["customerData"];
                if (customerData != null)
                {
                    DataLoad();
                }
            }
        }
        protected void DataLoad()
        {
            uEmail.Text = customerData[0];
            firstName.Text = customerData[1];
            secondName.Text = customerData[2];
            uPassword.Text = customerData[3];
            uPhone.Text = customerData[4];
        }
        protected bool checker()
        {
            string checkName = Checker.name(firstName.Text.Trim(), "First");
            string checkSecondName = Checker.name(secondName.Text.Trim(), "Second");
            string checkPassword = Checker.passwordChecker(uPassword.Text.Trim());
            string checkPhone = Checker.phone(uPhone.Text.Trim());
            if (checkName != null)
            {
                name1.InnerText = checkName;
                name1.Attributes["Class"] = "text-danger";
                return false;
            }
            else if (checkSecondName != null)
            {
                name2.InnerText = checkSecondName;
                name2.Attributes["Class"] = "text-danger";
                return false;
            }
            else if (string.Compare(uPassword.Text, cuPassword.Text) != 0)
            {
                confPas.InnerText = "Password Does Not Match";
                confPas.Attributes["Class"] = "text-danger";
                return false;
            }
            else if (checkPhone != null)
            {
                phone.InnerText = checkPhone;
                phone.Attributes["Class"] = "text-danger";
                return false;
            }
            else if (checkPassword != null)
            {
                password.InnerText = checkPassword;
                password.Attributes["Class"] = "text-danger";
                return false;
            }
            return true;
        }

        protected void update_button(object sender, EventArgs e)
        {
            reset();
            if (checker() == false)
            {
                return;
            }
            string conStr = ConfigurationManager.ConnectionStrings["GroData"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            string updateProfile = "UPDATE [Customer] SET password=@Password, first_name=@FirstName, second_name=@SecondName, phone=@Phone, image=@image WHERE email = @Email";
            using (SqlCommand connectionIns = new SqlCommand(updateProfile, con))
            {
                connectionIns.Parameters.AddWithValue("@Email", uEmail.Text.Trim());
                connectionIns.Parameters.AddWithValue("@Password", uPassword.Text.Trim());
                connectionIns.Parameters.AddWithValue("@FirstName", firstName.Text.Trim());
                connectionIns.Parameters.AddWithValue("@SecondName", secondName.Text.Trim());
                connectionIns.Parameters.AddWithValue("@Phone", uPhone.Text.Trim());
                if (ProfileImage.HasFile)
                {
                    string imagePath = "~/Uploads/" + Path.GetFileName(ProfileImage.FileName);
                    ProfileImage.SaveAs(Server.MapPath(imagePath));
                    connectionIns.Parameters.AddWithValue("@image", imagePath);
                    customerData = new string[] { uEmail.Text.Trim(), firstName.Text.Trim(), secondName.Text.Trim(), uPassword.Text.Trim(), uPhone.Text.Trim(), imagePath };
                }
                else
                {
                    connectionIns.Parameters.AddWithValue("@image", "none");
                    customerData = new string[] { uEmail.Text.Trim(), firstName.Text.Trim(), secondName.Text.Trim(), uPassword.Text.Trim(), uPhone.Text.Trim(), "none" };
                }
 
                con.Open();
                connectionIns.ExecuteNonQuery();
                con.Close();
            }
            addContent(con);
            Session["customerData"] = customerData;
            DataLoad();
            alert();
        }

        protected void alert()
        {
            alertMessage.Attributes["Class"] = "alert alert-success alert-dismissible fade show";
            alertText.InnerText = "Profile Successfully Updated!";
            alertMessage.Visible = true;
        }
        protected void reset()
        {
            name1.InnerText = "First Name";
            name2.InnerText = "Second Name";
            email.InnerText = "Email";
            password.InnerText = "Password";
            confPas.InnerText = "Confirm Password";
            phone.InnerText = "Phone";
            name1.Attributes["Class"] = "text-dark";
            name2.Attributes["Class"] = "text-dark";
            email.Attributes["Class"] = "text-dark";
            password.Attributes["Class"] = "text-dark";
            confPas.Attributes["Class"] = "text-dark";
            phone.Attributes["Class"] = "text-dark";
        }


        private void addContent(SqlConnection con)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            if (uEmail.Text.Length != 0)
            {
                string insert = "Insert into [Activity] (date, activity, email) values(@Date, @Type, @Email)";
                using (SqlCommand connectionIns = new SqlCommand(insert, con))
                {
                    connectionIns.Parameters.AddWithValue("@Date", dateTime.ToString("dd/MM/yyyy"));
                    connectionIns.Parameters.AddWithValue("@Type", "Update");
                    connectionIns.Parameters.AddWithValue("@Email", uEmail.Text.Trim());
                    con.Open();
                    connectionIns.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

    }
}