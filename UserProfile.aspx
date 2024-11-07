<%@ Page Title="" Language="C#" MasterPageFile="~/VisitorsPage.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="GroceryApp.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Assets/Css/profile.css" />
    <style>
        @import url(https://fonts.googleapis.com/css?family=Roboto:300,400,700&display=swap);

        .section-50 {
            padding: 50px 0;
        }

        .m-b-50 {
            margin-bottom: 50px;
        }

        .dark-link {
            color: #333;
        }

        .heading-line {
            position: relative;
            padding-bottom: 5px;
        }

            .heading-line:after {
                content: "";
                height: 4px;
                width: 75px;
                background-color: #29B6F6;
                position: absolute;
                bottom: 0;
                left: 0;
            }

        .notification-ui_dd-content {
            margin-bottom: 30px;
        }

        .notification-list {
            display: -webkit-box;
            display: -ms-flexbox;
            display: flex;
            -webkit-box-pack: justify;
            -ms-flex-pack: justify;
            justify-content: space-between;
            padding: 20px;
            margin-bottom: 7px;
            background: #fff;
            -webkit-box-shadow: 0 3px 10px rgba(0, 0, 0, 0.06);
            box-shadow: 0 3px 10px rgba(0, 0, 0, 0.06);
        }

        .notification-list--unread {
            border-left: 2px solid #29B6F6;
        }

        .notification-list .notification-list_content {
            display: -webkit-box;
            display: -ms-flexbox;
            display: flex;
        }

            .notification-list .notification-list_content .notification-list_img img {
                height: 48px;
                width: 48px;
                border-radius: 50px;
                margin-right: 20px;
            }

            .notification-list .notification-list_content .notification-list_detail p {
                margin-bottom: 5px;
                line-height: 1.2;
            }

        .notification-list .notification-list_feature-img img {
            height: 48px;
            width: 48px;
            border-radius: 5px;
            margin-left: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/MaterialDesign-Webfont/7.2.96/css/materialdesignicons.min.css" integrity="sha512-LX0YV/MWBEn2dwXCYgQHrpa9HJkwB+S+bnBpifSOTO1No27TqNMKYoAn6ff2FBh03THAzAiiCwQ+aPX+/Qt/Ow==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <div class="container mt-4">
        <div class="row" style="margin-top: 150px;">
            <div class="col-xl-8">
                <div class="card">
                    <div class="card-body pb-0">
                        <div class="row align-items-center">
                            <div class="col-md-3">
                                <div class="text-center border-end">
                                    <img runat="server" id="userImage" src="https://cdn.pixabay.com/photo/2016/01/03/00/43/upload-1118929_960_720.png" alt="avatar"
                                        class="rounded-circle img-fluid" style="width: 130px;">
                                    <h4 runat="server" id="name" class="text-primary font-size-20 mt-3 mb-2">Undefined</h4>
                                    <a class="font-size-13 mb-0" href="ProfileUpdate.aspx">Edit Profile</a>
                                </div>
                            </div>
                            <!-- end col -->
                            <div class="col-md-9">
                                <div class="ms-3">
                                    <div>
                                        <h4 class="card-title mb-2">Profile</h4>
                                        <p class="mb-0 text-muted">Address: Chia Car Service, Jalan PJS 11/7, Bandar Sunway, Petaling Jaya, Selangor</p>
                                    </div>
                                    <div class="row my-4">
                                        <div class="col-md-12">
                                            <div>
                                                <p class="text-muted mb-2 fw-medium">
                                                    <i runat="server" id="emailText" class="mdi mdi-email-outline me-2"></i>
                                                </p>
                                                <p class="text-muted fw-medium mb-0">
                                                    <i runat="server" id="phoneText" class="mdi mdi-phone-in-talk-outline me-2"></i>
                                                </p>
                                            </div>
                                        </div>
                                        <!-- end col -->
                                    </div>
                                    <!-- end row -->

                                    <ul class="nav nav-tabs nav-tabs-custom border-bottom-0 mt-3 nav-justfied" role="tablist">
                                        <li class="nav-item" role="presentation">
                                            <a runat="server" id="tab1" class="nav-link px-4 active" href="UserProfile.aspx" target="__blank">
                                                <span class="d-block d-sm-none"><i class="fas fa-home"></i></span>
                                                <span class="d-none d-sm-block">Orders</span>
                                            </a>
                                        </li>
                                        <!-- end li -->
                                        <li class="nav-item" role="presentation">
                                            <a runat="server" id="tab2" class="nav-link px-4" href="UserProfile.aspx?type=history" target="__blank">
                                                <span class="d-block d-sm-none"><i class="mdi mdi-menu-open"></i></span>
                                                <span class="d-none d-sm-block">History</span>
                                            </a>
                                        </li>
                                        <!-- end li -->
                                        <li class="nav-item" role="presentation">
                                            <a runat="server" id="tab3" class="nav-link px-4 " href="UserProfile.aspx?type=feedback" target="__blank">
                                                <span class="d-block d-sm-none"><i class="mdi mdi-account-group-outline"></i></span>
                                                <span class="d-none d-sm-block">Feedback</span>
                                            </a>
                                        </li>
                                        <!-- end li -->
                                        <li class="nav-item" role="presentation">
                                            <a runat="server" id="tab4" class="nav-link px-4 " href="UserProfile.aspx?type=notification" target="__blank">
                                                <span class="d-block d-sm-none"><i class="mdi mdi-account-group-outline"></i></span>
                                                <span class="d-none d-sm-block">Notification</span>
                                            </a>
                                        </li>
                                        <!-- end li -->
                                    </ul>
                                    <!-- end ul -->
                                </div>
                            </div>
                            <!-- end col -->
                        </div>
                        <!-- end row -->
                    </div>
                    <!-- end card body -->
                </div>
                <!-- end card -->

                <div class="card">
                    <div class="tab-content p-4">
                        <div class="tab-pane active show" id="projects-tab" role="tabpanel">
                            <div class="d-flex align-items-center">
                                <div class="flex-1">
                                    <h4 id="link" runat="server" class="card-title mb-4">Orders</h4>
                                </div>
                            </div>

                            <div class="row" runat="server" id="allprojects">
                            </div>
                            <!-- end row -->
                        </div>
                        <!-- end tab pane -->
                    </div>
                </div>
                <!-- end card -->
            </div>
            <!-- end col -->

            <div class="col-xl-4">
                <div class="card">
                    <div class="card-body">
                        <div class="pb-2">
                            <h4 class="card-title mb-3">Regulations</h4>
                            <p>Regulations for convenience stores aim to ensure operational compliance, safety, and customer satisfaction. These regulations cover various aspects such as food safety standards, hygiene practices, employee training, alcohol and tobacco sales regulations, zoning laws, fire safety codes, and signage requirements. Compliance with health codes regarding food storage, preparation, and handling is crucial.</p>
                        </div>
                        <hr>
                    </div>
                    <!-- end cardbody -->
                </div>
                <!-- end card -->

            </div>
            <!-- end col -->
        </div>
    </div>
</asp:Content>
