using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class Contact : System.Web.UI.Page
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

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("footer").Visible = false;

            alertMessage.Visible = false;
        }

        protected void name_TextChanged(object sender, EventArgs e)
        {

        }

        protected void email_TextChanged(object sender, EventArgs e)
        {

        }

        protected void subject_TextChanged(object sender, EventArgs e)
        {

        }

        protected void form_TextChanged(object sender, EventArgs e)
        {

        }

        protected void submitMessage(object sender, EventArgs e)
        {
            if (name.Text.Length != 0 && email.Value.Length != 0 && subject.Value.Length != 0 && message.Value.Length != 0)
            {
                string insertQuery = "INSERT INTO [Contact] VALUES (@Email, @Subject, @Name, @Message)";
                using (con)
                {
                    using (SqlCommand com = new SqlCommand(insertQuery, con))
                    {
                        com.Parameters.AddWithValue("@Email", email.Value.ToString());
                        com.Parameters.AddWithValue("@Subject", subject.Value.ToString());
                        com.Parameters.AddWithValue("@Name", name.Text.ToString());
                        com.Parameters.AddWithValue("@Message", message.Value.ToString());

                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                }

                alertMessage.Visible = true;
                name.Text = "";
                subject.Value = "";
                email.Value = "";
                message.Value = "";
                var timer = new System.Timers.Timer(10000);

            }
        }
    }
}