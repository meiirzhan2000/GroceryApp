using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class About : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}