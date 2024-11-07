using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class AdminManageOrders : System.Web.UI.Page
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

        public void ClearAllData()
        {
            productName.Text = "";
            price.Text = "";
            brandName.Text = "";
            description.Text = "";
            orderStatus.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                using (con)
                {
                    con.Open();
                    cmd = new SqlCommand("Update [Order] Set Status=@status Where id = @ID", con);
                    cmd.Parameters.AddWithValue("@status", orderStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID", productName.Text);
                    cmd.ExecuteNonQuery();
                      
                    con.Close();
                    DataLoad();
                    ClearAllData();
                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            productName.Text = GridView1.SelectedRow.Cells[1].Text;
            price.Text = GridView1.SelectedRow.Cells[3].Text;
            description.Text = GridView1.SelectedRow.Cells[4].Text;
            brandName.Text = GridView1.SelectedRow.Cells[5].Text;
            orderStatus.SelectedValue = GridView1.SelectedRow.Cells[7].Text;
        }
    }
}