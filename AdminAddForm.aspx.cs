using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class AdminAddForm : System.Web.UI.Page
    {
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            alertMessage.Visible = false;
            if (!Page.IsPostBack)
            {
                DataLoad();
            }
        }

        public void DataLoad()
        {
            fname.Text = "";
            sname.Text = "";
            userEmail.Text = "";
            userPassword.Text = "";
        }

        protected void reset()
        {
            name1.InnerText = "First Name";
            name2.InnerText = "Second Name";
            password.InnerText = "Password";
            email.InnerText = "Email";
            name1.Attributes["Class"] = "text-dark";
            name2.Attributes["Class"] = "text-dark";
            password.Attributes["Class"] = "text-dark";
            email.Attributes["Class"] = "text-dark";
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            reset();
            string passwordCheker = Checker.passwordChecker(userPassword.Text);
            string nameChecker1 = Checker.name(fname.Text, "First");
            string nameChecker2 = Checker.name(sname.Text, "Second");
            string emailChecker = Checker.emailChecker(userEmail.Text);
            string checkPhone = Checker.phone(uPhone.Text.Trim());
            if (nameChecker1 != null)
            {
                name1.InnerText = nameChecker1;
                name1.Attributes["Class"] = "text-danger";
            }
            else if (nameChecker2 != null)
            {
                name2.InnerText = nameChecker2;
                name2.Attributes["Class"] = "text-danger";
            }
            else if (emailChecker != null)
            {
                email.InnerText = emailChecker;
                email.Attributes["Class"] = "text-danger";
            }
            else if (checkPhone != null)
            {
                phone.InnerText = checkPhone;
                phone.Attributes["Class"] = "text-danger";
            }
            else if (passwordCheker != null)
            {
                password.InnerText = passwordCheker;
                password.Attributes["Class"] = "text-danger";
            }
            else
            {
                string conStr = ConfigurationManager.ConnectionStrings["GroData"].ConnectionString;
                SqlConnection con = new SqlConnection(conStr);
                string insert = "INSERT INTO [Customer] (email, password, first_name, second_name, active, phone, when_created, user_type, image) VALUES (@Email, @Password, @FirstName, @SecondName, @Active, @Phone, @WhenCreated, @UserType, @Image)";
                using (SqlCommand connectionIns = new SqlCommand(insert, con))
                {
                    connectionIns.Parameters.AddWithValue("@Email", userEmail.Text.Trim());
                    connectionIns.Parameters.AddWithValue("@Password", userPassword.Text.Trim());
                    connectionIns.Parameters.AddWithValue("@FirstName", fname.Text.Trim());
                    connectionIns.Parameters.AddWithValue("@SecondName", sname.Text.Trim());
                    connectionIns.Parameters.AddWithValue("@Active", 1);
                    connectionIns.Parameters.AddWithValue("@Phone", uPhone.Text.Trim());
                    connectionIns.Parameters.AddWithValue("@UserType", "admin");
                    connectionIns.Parameters.AddWithValue("@WhenCreated", DateTime.UtcNow);
                    connectionIns.Parameters.AddWithValue("@Image", "None");

                    con.Open();
                    connectionIns.ExecuteNonQuery();
                    con.Close();
                    DataLoad();
                    alertMessage.Attributes["Class"] = "alert alert-success alert-dismissible fade show";
                    alertText.InnerText = "Profile Successfully Updated!";
                    alertMessage.Visible = true;
                }
            }
        }
    }
}