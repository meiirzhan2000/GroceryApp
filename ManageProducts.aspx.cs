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
    public partial class ManageProducts : System.Web.UI.Page
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
            using (con)
            {
                con.Open();
                cmd = new SqlCommand("Insert Into Product (product_name, price, product_class, brand_name, description, weight, promises, image) Values(@ProductName, @Price, @ProductClass, @BrandName, @Description, @Weight, @Promises, @Image)", con);
                cmd.Parameters.AddWithValue("@ProductName", productName.Text);
                cmd.Parameters.AddWithValue("@Price", price.Text);
                cmd.Parameters.AddWithValue("@ProductClass", productClass);
                cmd.Parameters.AddWithValue("@BrandName", brandName.Text.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@Description", description.Text);
                cmd.Parameters.AddWithValue("@Weight", weight.Text);
                cmd.Parameters.AddWithValue("@Promises", promises.Text);
                cmd.Parameters.AddWithValue("@Image", image.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                DataLoad();
                ClearAllData();
            }
        }

        public void ClearAllData()
        {
            productName.Text = "";
            price.Text = "";
            productClass.SelectedValue = productClass.Items[0].ToString();
            brandName.Text = "";
            description.Text = "";
            weight.Text = "";
            promises.Text = "";
            image.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                using (con)
                {
                    con.Open();
                    cmd = new SqlCommand("Delete from Product where id=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", GridView1.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DataLoad();
                    ClearAllData();
                }
            }
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                using (con)
                {
                    string selectedName = productClass.SelectedValue;

                    con.Open();

                    using (cmd = new SqlCommand("SELECT id FROM Product_Category WHERE name = @Name", con))
                    {
                        cmd.Parameters.AddWithValue("@Name", selectedName);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int categoryId = Convert.ToInt32(result);
                            cmd = new SqlCommand("Update Product Set product_name=@ProductName, price=@Price, image=@Image, product_class=@ProductClass, brand_name=@BrandName, description=@Description, weight=@Weight, promises=@Promises  Where id = @ID", con);
                            cmd.Parameters.AddWithValue("@ProductName", productName.Text);
                            cmd.Parameters.AddWithValue("@Price", price.Text);
                            cmd.Parameters.AddWithValue("@ProductClass", categoryId);
                            cmd.Parameters.AddWithValue("@BrandName", brandName.Text.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@Description", description.Text);
                            cmd.Parameters.AddWithValue("@Weight", weight.Text);
                            cmd.Parameters.AddWithValue("@Promises", promises.Text);
                            cmd.Parameters.AddWithValue("@Image", image.Text);
                            cmd.Parameters.AddWithValue("@ID", GridView1.SelectedRow.Cells[1].Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
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
            productName.Text = GridView1.SelectedRow.Cells[2].Text;
            price.Text = GridView1.SelectedRow.Cells[3].Text;
            productClass.SelectedValue = GridView1.SelectedRow.Cells[4].Text;
            brandName.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[5].Text);
            description.Text = GridView1.SelectedRow.Cells[6].Text;
            weight.Text = GridView1.SelectedRow.Cells[7].Text;
            promises.Text = GridView1.SelectedRow.Cells[8].Text;
            image.Text = GridView1.SelectedRow.Cells[9].Text;
        }
    }
}