using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace GroceryApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Session["customerData"] = null;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                alertMessage.Visible = false;
            }
        }

        protected bool checker()
        {
            string checkName = Checker.name(firstName.Text.Trim(), "First");
            string checkSecondName = Checker.name(secondName.Text.Trim(), "Second");
            string checkPassword = Checker.passwordChecker(uPassword.Text.Trim());
            string checkEmail = Checker.emailChecker(uEmail.Text.Trim());
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
            else if (checkEmail != null)
            {
                email.InnerText = checkEmail;
                email.Attributes["Class"] = "text-danger";
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

        protected void register_button(object sender, EventArgs e)
        {
            reset();
            if (checker() == false)
            {
                return;
            }
            string conStr = ConfigurationManager.ConnectionStrings["GroData"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            string insert = "INSERT INTO [Customer] (email, password, first_name, second_name, active, phone, when_created, user_type," +
                " image) VALUES (@Email, @Password, @FirstName, @SecondName, @Active, @Phone, @WhenCreated, @UserType, @Image)";
            using (SqlCommand connectionIns = new SqlCommand(insert, con))
            {
                connectionIns.Parameters.AddWithValue("@Email", uEmail.Text.Trim());
                connectionIns.Parameters.AddWithValue("@Password", uPassword.Text.Trim());
                connectionIns.Parameters.AddWithValue("@FirstName", firstName.Text.Trim());
                connectionIns.Parameters.AddWithValue("@SecondName", secondName.Text.Trim());
                connectionIns.Parameters.AddWithValue("@Active", 1);
                connectionIns.Parameters.AddWithValue("@Phone", uPhone.Text.Trim());
                connectionIns.Parameters.AddWithValue("@UserType", "Customer");
                connectionIns.Parameters.AddWithValue("@WhenCreated", DateTime.UtcNow);
                connectionIns.Parameters.AddWithValue("@Image", "None");

                con.Open();
                connectionIns.ExecuteNonQuery();
                con.Close();
            }
            addContent(con);
            clean();
            reset();
            alertMessage.Visible = true;
        }

        protected void clean()
        {
            uEmail.Text = "";
            uPassword.Text = "";
            firstName.Text = "";
            secondName.Text = "";
            cuPassword.Text = "";
            uPhone.Text = "";
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
                    connectionIns.Parameters.AddWithValue("@Type", "Registration");
                    connectionIns.Parameters.AddWithValue("@Email", uEmail.Text.Trim());
                    con.Open();
                    connectionIns.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}