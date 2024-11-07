using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class FeedbackAdmin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True");
        SqlCommand cmd;

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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime notificationDate = DateTime.Now;
            if (id.Text != "")
            {
                using (con)
                {
                    con.Open();
                    cmd = new SqlCommand("Insert Into Notification (header_meesage, description, imageURL, date, status, order_id) Values(@Header_meesage, @Description, @ImageURL, @Date, @Status, @Order_id)", con);
                    cmd.Parameters.AddWithValue("@Description", Comment.Text);
                    cmd.Parameters.AddWithValue("@Header_meesage", "Message From Admin");
                    cmd.Parameters.AddWithValue("@ImageURL", "https://cdn-icons-png.flaticon.com/512/4682/4682662.png");
                    cmd.Parameters.AddWithValue("@Date", notificationDate);
                    cmd.Parameters.AddWithValue("@Status", 0);
                    cmd.Parameters.AddWithValue("@Order_id", GridView1.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DataLoad();
                    ClearAllData();
                }
            }
        }

        public void ClearAllData()
        {
            id.Text = "";
            Comment.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            id.Text = GridView1.SelectedRow.Cells[1].Text;
        }
    }
}