using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class ManageCategories : System.Web.UI.Page
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
            if(id.Text != "")
            {
                using (con)
                {
                    con.Open();
                    cmd = new SqlCommand("Insert Into Product_Category (name, description) Values(@Name, @Description)", con);
                    cmd.Parameters.AddWithValue("@Description", description.Text);
                    cmd.Parameters.AddWithValue("@Name", name.Text);
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
            name.Text = "";
            description.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (id.Text != "")
            {
                using (con)
                {
                    con.Open();
                    cmd = new SqlCommand("Delete from Product_Category where id=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", id.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DataLoad();
                    ClearAllData();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
                using (con)
                {
                    con.Open();
                    cmd = new SqlCommand("Update Product_Category Set name=@Name, description=@Description Where id=@ID", con);
                    cmd.Parameters.AddWithValue("@Name", name.Text);
                    cmd.Parameters.AddWithValue("@Description", description.Text);
                    cmd.Parameters.AddWithValue("@ID", id.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DataLoad();
                    ClearAllData();
                }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAllData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            description.Text = GridView1.SelectedRow.Cells[2].Text;
            name.Text = GridView1.SelectedRow.Cells[1].Text;
            id.Text = GridView1.SelectedRow.Cells[3].Text;
        }
    }
}