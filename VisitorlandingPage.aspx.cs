using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = System.Web.UI.WebControls.Image;

namespace GroceryApp
{
    public partial class VisitorlandingPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\database.mdf;Integrated Security=True");

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

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            customerData = (string[])Session["customerData"];
        }
    }
}