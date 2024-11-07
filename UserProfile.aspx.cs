using MailKit.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GroceryApp
{
    public partial class UserProfile : System.Web.UI.Page
    {
        string[] customerData;
        string type;

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
                    Response.Redirect("Login.aspx");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                customerData = (string[])Session["customerData"];
                if (customerData != null)
                {
                    DataLoad();
                    updateTabs();

                }
            }
        }

        protected void updateTabs()
        {
            tab1.Attributes.Add("class", "nav-link px-4");
            tab2.Attributes.Add("class", "nav-link px-4");
            tab3.Attributes.Add("class", "nav-link px-4");
            type = Request.QueryString["type"];
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "history":
                        link.InnerText = "History";
                        LoadOrderData(false);
                        tab2.Attributes["class"] += " active";
                        break;
                    case "feedback":
                        link.InnerText = "Feedback";
                        LoadFeedbackData();
                        tab3.Attributes["class"] += " active";
                        break;
                    case "notification":
                        link.InnerText = "Notification";
                        generateNotifications();
                        tab4.Attributes["class"] += " active";
                        break;
                    default:
                        link.InnerText = "Orders";
                        LoadOrderData(true);
                        tab1.Attributes["class"] += " active";
                        break;
                }
            }
            else
            {
                link.InnerText = "Orders";
                LoadOrderData(true);
                tab1.Attributes["class"] += " active";
            }
        }

        protected void LoadFeedbackData()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";
            string query = "SELECT * FROM Feedback WHERE orderId IN (SELECT id FROM [Order] WHERE customerID = @CustomerId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerData[0]);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int orderId = Convert.ToInt32(reader["orderId"]);
                            int qualityProd = Convert.ToInt32(reader["quality_prod"]);
                            int expectations = Convert.ToInt32(reader["expectations"]);
                            int deliveryTime = Convert.ToInt32(reader["del_time"]);
                            int value = Convert.ToInt32(reader["value"]);
                            string comment = reader["comment"].ToString();

                            string htmlContent = $@"
                        <div class='card'>
                            <div class='card-body'>
                                <h5 class='card-title'>Order Number: {orderId}</h5>
                                <p class='card-text'>Commentary: {comment}</p>
                            </div>
                            <ul class='list-group list-group-flush'>
                                <li class='list-group-item'>Quality of Products: ({qualityProd}/5)</li>
                                <li class='list-group-item'>Meeting Expectations: ({expectations}/5)</li>
                                <li class='list-group-item'>Delivery Time: ({deliveryTime}/5)</li>
                                <li class='list-group-item'>Value for Money: ({value}/5)</li>
                            </ul>
                            <div class='card-body'>
                             <a href = 'ViewOrderOnePage.aspx?projectId={orderId}&pastOrCurrent=past' class='card-link'>View Order</a>
                            </div>
                        </div>";
                            allprojects.Controls.Add(new LiteralControl(htmlContent));
                        }
                    }
                }
            }
            
        }

        protected void generateNotifications()
        {
            string customerid = customerData[0];

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";
            string query = @"
    SELECT N.Id, N.header_meesage, N.description, N.imageURL, N.date, O.id, N.status
    FROM Notification N
    INNER JOIN [Order] O ON N.order_id = O.id
    WHERE O.customerID = @CustomerId
    ORDER BY N.date DESC";

            string updateQuery = "UPDATE Notification SET status = 1 WHERE Id = @NotificationId";
            List<int> notificationIdsToUpdate = new List<int>();


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerid);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int notificationId = reader.GetInt32(0);
                            string headerMessage = reader.GetString(1);
                            string description = reader.GetString(2);
                            string imageURL = reader.GetString(3);
                            DateTime date = reader.GetDateTime(4);
                            int orderId = reader.GetInt32(5);
                            Boolean notificationStatus = reader.GetBoolean(6);

                            // Format the date
                            string formattedDate = (DateTime.Now - date).TotalMinutes < 1 ? "Just now" : $"{(int)(DateTime.Now - date).TotalMinutes} mins ago";

                            if ((DateTime.Now - date).TotalHours <= 1)
                            {
                                notificationIdsToUpdate.Add(notificationId);
                            }

                            // Append the HTML content for each notification
                            if (!notificationStatus)
                            {
                                string htmlContent = $@"
                        <div class='notification-ui_dd-content'>
                            <div class='notification-list notification-list--unread'>
                                <div class='notification-list_content'>
                                    <div class='notification-list_img'>
                                        <img src='https://cdn-icons-png.flaticon.com/512/6134/6134346.png' alt='user'>
                                    </div>
                                    <div class='notification-list_detail'>
                                        <p><b>Meiirzhan Baitangatov</b> {headerMessage}</p>
                                        <p class='text-muted'>{description}</p>
                                        <p class='text-muted'><small>{formattedDate}</small></p>
                                    </div>
                                </div>
                                <div class='notification-list_feature-img'>
                                    <img src='{imageURL}' alt='Confirm - Free ui icons'/>
                                </div>
                            </div>
                        </div>";
                                allprojects.Controls.Add(new LiteralControl(htmlContent));
                            }
                        }
                    }
                }
                foreach (int notificationId in notificationIdsToUpdate)
                {
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                    {
                        updateCmd.Parameters.AddWithValue("@NotificationId", notificationId);
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        protected void LoadOrderData(bool delOrHistory)
        {
            string status1;
            string status2;
            if (delOrHistory)
            {
                status1 = "Pending";
                status2 = "Delivery";
            }
            else
            {
                status1 = "Cancel";
                status2 = "Delivered";
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\database.mdf;Integrated Security=True";
            string query = @"
        SELECT O.OrderDate, O.id AS OrderNumber, SUM(P.price * OP.quantity) AS TotalPrice, O.Status 
        FROM [dbo].[Order] O 
        INNER JOIN [dbo].[Order_Product] OP ON O.id = OP.OrderID
        INNER JOIN [dbo].[Product] P ON OP.productID = P.id
        WHERE O.customerID = @CustomerId AND O.Status = @status1 OR O.Status = @status2
        GROUP BY O.OrderDate, O.id, O.Status";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerData[0]);
                    cmd.Parameters.AddWithValue("@status1", status1);
                    cmd.Parameters.AddWithValue("@status2", status2);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string date = reader["OrderDate"].ToString();
                            string orderNumber = reader["OrderNumber"].ToString();
                            string totalPrice = reader["TotalPrice"].ToString();
                            string status = reader["Status"].ToString();

                            GenerateProjectItem(date, orderNumber, totalPrice, status, delOrHistory);
                        }
                    }
                }
            }
        }

        protected void switchButton(object sender, ImageClickEventArgs e)
        {
            tab1.Attributes.Add("class", "nav-link px-4");
            tab2.Attributes.Add("class", "nav-link px-4");
            tab3.Attributes.Add("class", "nav-link px-4 active");
        }

        protected void DataLoad()
        {
            emailText.InnerText = customerData[0];
            name.InnerText = customerData[1] + " " + customerData[2];
            if (customerData[5] != "none")
            {
                userImage.Src = customerData[5];
            }
            // secondName.Text = customerData[2];
            // uPassword.Text = customerData[3];
            phoneText.InnerText = customerData[4];
        }


        private void GenerateProjectItem(string date, string orderNumber, string price, string status, bool checker)
        {
            string textPic = checker == true ? "current" : "past";

            string stringInnerHtml;
            string textColor;

            switch (status)
            {
                case "Pending":
                    stringInnerHtml = "<span class='badge bg-warning p-2 team-status'>" + status + "</span>";
                    textColor = "text-warning";
                    break;
                case "Cancel":
                    stringInnerHtml = "<span class='badge bg-danger p-2 team-status'>" + status + "</span>";
                    textColor = "text-danger";
                    break;
                case "Delivery":
                    stringInnerHtml = "<span class='badge bg-info p-2 team-status'>" + status + "</span>";
                    textColor = "text-info";
                    break;
                case "Delivered":
                    stringInnerHtml = "<span class='badge bg-success p-2 team-status'>" + status + "</span>";
                    textColor = "text-success";
                    break;
                default:
                    stringInnerHtml = "<span class='badge bg-primary p-2 team-status'>" + status + "</span>";
                    textColor = "text-primary";
                    break;
            }

            // Create a new HTML div element
            HtmlGenericControl projectItem = new HtmlGenericControl("div");
            projectItem.Attributes["class"] = "col-md-6";
            projectItem.ID = "project-items-" + orderNumber; // Assuming orderNumber is unique

            // Create card div
            HtmlGenericControl card = new HtmlGenericControl("div");
            card.Attributes["class"] = "card";
            projectItem.Controls.Add(card);

            // Create card body div
            HtmlGenericControl cardBody = new HtmlGenericControl("div");
            cardBody.Attributes["class"] = "card-body";
            card.Controls.Add(cardBody);

            // Create flex container for date and dropdown
            HtmlGenericControl flexContainer = new HtmlGenericControl("div");
            flexContainer.Attributes["class"] = "d-flex mb-3";
            cardBody.Controls.Add(flexContainer);

            // Date part
            HtmlGenericControl dateDiv = new HtmlGenericControl("div");
            dateDiv.Attributes["class"] = "flex-grow-1 align-items-start";
            flexContainer.Controls.Add(dateDiv);

            HtmlGenericControl dateHeader = new HtmlGenericControl("div");
            dateHeader.InnerHtml = "<h6 class='mb-0 text-muted'><i class='mdi mdi-circle-medium " + textColor + " fs-3 align-middle'></i><span class='team-date'>" + date + "</span></h6>";
            dateDiv.Controls.Add(dateHeader);

            // Dropdown part
            HtmlGenericControl dropdownDiv = new HtmlGenericControl("div");
            dropdownDiv.Attributes["class"] = "dropdown ms-2";
            flexContainer.Controls.Add(dropdownDiv);

            HtmlGenericControl dropdownToggle = new HtmlGenericControl("a");
            dropdownToggle.Attributes["class"] = "dropdown-toggle font-size-16 text-muted";
            dropdownToggle.Attributes["href"] = "#";
            dropdownToggle.Attributes["data-bs-toggle"] = "dropdown";
            dropdownToggle.Attributes["aria-haspopup"] = "true";
            dropdownToggle.Attributes["aria-expanded"] = "false";
            dropdownToggle.InnerHtml = "<i class='mdi mdi-dots-horizontal'></i>";
            dropdownDiv.Controls.Add(dropdownToggle);

            HtmlGenericControl dropdownMenu = new HtmlGenericControl("div");
            dropdownMenu.Attributes["class"] = "dropdown-menu dropdown-menu-end";
            dropdownDiv.Controls.Add(dropdownMenu);

            // Add dropdown items
            dropdownMenu.InnerHtml = "<a class='dropdown-item' href='ViewOrderOnePage.aspx?projectId=" + orderNumber + "&pastOrCurrent=" + textPic + "'>View</a>" +
                "<div class='dropdown-divider'></div>" +
                "<a class='dropdown-item delete-item' ' href='javascript: void(0);'>Cancel</a>";

            // Add order number and price
            HtmlGenericControl orderDiv = new HtmlGenericControl("div");
            orderDiv.Attributes["class"] = "mb-4";
            cardBody.Controls.Add(orderDiv);

            orderDiv.InnerHtml = "<h5 class='mb-1 font-size-17 team-title'>Order Number: " + orderNumber + "</h5>" +
                "<p class='text-muted mb-0 team-description'>Price: " + price + "</p>";

            // Add status
            HtmlGenericControl statusDiv = new HtmlGenericControl("div");
            statusDiv.Attributes["class"] = "d-flex";
            cardBody.Controls.Add(statusDiv);

            HtmlGenericControl badgeSpan = new HtmlGenericControl("span");
            badgeSpan.Attributes["class"] = "align-self-end";

            badgeSpan.InnerHtml = stringInnerHtml;

            statusDiv.Controls.Add(badgeSpan);

            allprojects.Controls.Add(projectItem);
        }



        protected void btnUploadImage_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}