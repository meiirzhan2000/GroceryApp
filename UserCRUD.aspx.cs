using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GroceryApp
{
    public partial class UserCRUD : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True");
        SqlCommand command;

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
        protected void DataLoad()
        {
            if (Page.IsPostBack)
            {
                GridView1.DataBind();
            }
        }

        protected bool checker()
        {
            string checkName = Checker.name(firstName.Text.Trim(), "First");
            string checkSecondName = Checker.name(secondName.Text.Trim(), "Second");
            string checkPassword = Checker.passwordChecker(password.Text.Trim());
            string checkEmail = Checker.emailChecker(email.Text.Trim());
            string checkPhone = Checker.phone(phone.Text.Trim());
            if (checkName != null)
            {
                alert(checkName, "alert, alert-danger alert-dismissible fade show");
                return false;
            }
            else if (checkSecondName != null)
            {
                alert(checkSecondName, "alert, alert-danger alert-dismissible fade show");
                return false;
            }
            else if (checkEmail != null)
            {
                alert(checkEmail, "alert, alert-danger alert-dismissible fade show");
                return false;
            }
            else if (checkPhone != null)
            {
                alert(checkPhone, "alert, alert-danger alert-dismissible fade show");
                return false;
            }
            else if (checkPassword != null)
            {
                alert(checkPassword, "alert, alert-danger alert-dismissible fade show");
                return false;
            }
            return true;
        }

        protected void alert(string text, string classType)
        {
            alertMessage.Attributes["Class"] = classType;
            alertText.InnerText = text;
            alertMessage.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (checker())
            {
                using (connection)
                {
                    connection.Open();
                    command = new SqlCommand("Insert Into Customer (email, first_name, second_name, when_created, active, password, phone, user_type) Values(@Email, @FirstName, @SecondName, @CreateAt, @Active, @Password, @Phone, @UserType)", connection);
                    command.Parameters.AddWithValue("@Email", email.Text);
                    command.Parameters.AddWithValue("@FirstName", firstName.Text);
                    command.Parameters.AddWithValue("@CreateAt", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@SecondName", secondName.Text);
                    command.Parameters.AddWithValue("@Password", password.Text);
                    command.Parameters.AddWithValue("@Phone", phone.Text);
                    command.Parameters.AddWithValue("@UserType", "Customer");
                    command.Parameters.AddWithValue("@Active", active.SelectedValue);
                    command.ExecuteNonQuery();
                    connection.Close();
                    DataLoad();
                    ClearAllData();
                    alert("Customer Successfully Added!", "alert alert-success alert-dismissible fade show");
                }
            }
        }

        public void ClearAllData()
        {
            email.Text = "";
            password.Text = "";
            firstName.Text = "";
            secondName.Text = "";
            active.SelectedValue = active.Items[0].ToString();
            phone.Text = "";
            createdAt.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                command = new SqlCommand("Delete from Customer where email=@Email", connection);
                command.Parameters.AddWithValue("@Email", email.Text.Trim());
                command.ExecuteNonQuery();
                connection.Close();
                DataLoad();
                ClearAllData();
                alert("Customer Successfully Deleted!", "alert alert-success alert-dismissible fade show");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (connection)
            {
                connection.Open();
                command = new SqlCommand("Update Customer Set first_name=@FirstName, second_name=@SecondName, active=@Active, password=@Password, phone=@Phone Where email = @Email", connection);
                command.Parameters.AddWithValue("@FirstName", firstName.Text.Trim());
                command.Parameters.AddWithValue("@SecondName", secondName.Text.Trim());
                command.Parameters.AddWithValue("@Active", active.SelectedValue);
                command.Parameters.AddWithValue("@Password", password.Text.Trim());
                command.Parameters.AddWithValue("@Phone", phone.Text.Trim());
                command.Parameters.AddWithValue("@Email", email.Text.Trim());
                command.ExecuteNonQuery();
                connection.Close();
                DataLoad();
                ClearAllData();
                alert("Customer Successfully Updated!", "alert alert-success alert-dismissible fade show");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            email.Text = GridView1.SelectedRow.Cells[1].Text;
            firstName.Text = GridView1.SelectedRow.Cells[2].Text;
            secondName.Text = GridView1.SelectedRow.Cells[3].Text;
            createdAt.Text = GridView1.SelectedRow.Cells[4].Text;
            active.SelectedValue = GridView1.SelectedRow.Cells[5].Text;
            password.Text = GridView1.SelectedRow.Cells[6].Text;
            phone.Text = GridView1.SelectedRow.Cells[7].Text;
        }
    }
}