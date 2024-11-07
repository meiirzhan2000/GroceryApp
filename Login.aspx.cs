using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace GroceryApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Session["customerData"] = null;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            logOut();
            if (!Page.IsPostBack)
            {
                alertMessage.Visible = false;
            }
        }

        protected void logOut()
        {

            if (Session["customerData"] != null)
            {
                Session.Remove("customerData");
            }
            if (Session["addressCustomer"] != null)
            {
                Session.Remove("addressCustomer");
            }
        }

        protected void clean()
        {
            email.Text = "";
            password.Text = "";
        }

        protected void reset()
        {
            emailText.InnerText = "Email";
            passwordText.InnerText = "Password";
            emailText.Attributes["Class"] = "text-dark";
            passwordText.Attributes["Class"] = "text-dark";
        }

        protected bool checker()
        {
            string checkPassword = Checker.passwordChecker(password.Text.Trim());
            if (email.Text.Length < 5)
            {
                emailText.InnerText = "Please include your Email Address";
                emailText.Attributes["Class"] = "text-danger";
                return false;
            }

            else if (checkPassword != null)
            {
                passwordText.InnerText = checkPassword;
                passwordText.Attributes["Class"] = "text-danger";
                return false;
            }
            return true;
        }

        protected void signInButton(object sender, EventArgs e)
        {
            reset();
            if(checker() == false)
            {
                return;
            }
            string conStr = ConfigurationManager.ConnectionStrings["GroData"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            string checkerEmailAndPassword = "select count(*) from [Customer] where email = @Email and password = @Password ";
            using (SqlCommand connectionIns = new SqlCommand(checkerEmailAndPassword, con))
            {
                connectionIns.Parameters.AddWithValue("@Email", email.Text.Trim());
                connectionIns.Parameters.AddWithValue("@Password", password.Text.Trim());
                con.Open();
                int count = Convert.ToInt32(connectionIns.ExecuteScalar().ToString());
                con.Close();
                if (count == 1)
                {
                    connectionIns.Dispose();
                    if (userType(con) != true)
                    {
                        Response.Redirect("VisitorlandingPage.aspx");
                        clean();
                        addContent(con);

                    }
                    else
                    {
                        clean();
                        addContent(con);
                        Response.Redirect("AdminLandingPage.aspx");
                    }
                }
                else
                {
                    alertMessage.Visible = true;
                }
            }
        }

        bool userType(SqlConnection con)
        {
            String sqlTypeChecker = "select * from [Customer] where email = @Email";
            using (SqlCommand connectionIns = new SqlCommand(sqlTypeChecker, con))
            {
                connectionIns.Parameters.AddWithValue("@Email", email.Text.Trim());
                con.Open();
                SqlDataReader dataReader = connectionIns.ExecuteReader();
                while (dataReader.Read())
                {
                    string[] CustomerData = new string[] { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(8) };
                    Session["customerData"] = CustomerData;
                    bool findType = string.Compare(dataReader.GetString(7).Trim(), "admin") == 0;
                    con.Close();
                    return findType;
                }
                con.Close();
                return false;
            }
        }

        private void addContent(SqlConnection con)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            if (email.Text.Length != 0)
            {
                string insert = "Insert into [Activity] (date, activity, email) values(@Date, @Type, @Email)";
                using (SqlCommand connectionIns = new SqlCommand(insert, con))
                {
                    connectionIns.Parameters.AddWithValue("@Date", dateTime.ToString("dd/MM/yyyy"));
                    connectionIns.Parameters.AddWithValue("@Type", "Login");
                    connectionIns.Parameters.AddWithValue("@Email", email.Text.Trim());
                    con.Open();
                    connectionIns.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}