using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class AdminPage : System.Web.UI.MasterPage
    {
        string[] customerData;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            customerData = (string[])Session["customerData"];
            if (!IsPostBack)
            {
                if (customerData == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            customerData = (string[])Session["customerData"];
        }
    }
}