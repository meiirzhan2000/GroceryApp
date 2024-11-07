<%@ Page Title="" Language="C#" MasterPageFile="~/VisitorsPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="GroceryApp.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid page-header mb-5 wow fadeIn" data-wow-delay="0.1s">
    <div class="container">
        <h1 class="display-3 mb-3 animated slideInDown">
            Contact Us</h1>
        <nav aria-label="breadcrumb animated slideInDown">
            <ol class="breadcrumb mb-0">
                <li class="breadcrumb-item"><a class="text-body" href="#">Home</a></li>
                <li class="breadcrumb-item text-dark active" aria-current="page">Contact Us</li>
            </ol>
        </nav>
    </div>
</div>
<section class="vh-100">
    <div class="container">
        <div id="alertMessage" runat="server" class="alert alert-success" role="alert">
            <h4 class="alert-heading">Form Submitted Successfully!</h4>
            <p>We will contact you via email soon!</p>
            <hr>
            <p class="mb-0">Thank you for using our services.</p>
        </div>
        <p class="text-center w-responsive mx-auto mb-5">Do you have any questions? Please do not hesitate to contact us directly. Our team will come back to you within
            a matter of hours to help you.</p>
        <div class="row justify-content-md-center"">
            <div class="col-md-9 mb-md-0 d-grid">
                <div class="row justify-content-end">
                    <div class="col-md-5">
                        <div class="md-form">
                            <asp:TextBox ID="name" type="text" runat="server" CssClass="form-control" placeholder="Place Your Name" required OnTextChanged="name_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <div class="md-form">
                            <input type="email" id="email" runat="server" name="email" placeholder="Place Your Email" class="form-control" required OnTextChanged="email_TextChanged"/>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-end">
                    <div class="col-md-10">
                        <div class="md-form">
                            <input type="text" id="subject" runat="server" name="subject" class="form-control" placeholder="Place Your Subject" required OnTextChanged="subject_TextChanged">
                        </div>
                    </div>
                </div>
                <div class="row justify-content-end">
                    <div class="col-md-10">
                        <div class="md-form">
                            <textarea type="text" id="message" runat="server" placeholder="Add Your Message" name="message" rows="2" class="form-control md-textarea" required OnTextChanged="form_TextChanged"></textarea>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-end">
                    <div class="col-md-10">
                        <div class="d-grid">
                            <asp:Button ID="SendMessage" runat="server" CssClass="btn btn-dark btn-lg btn-block" OnClick="submitMessage" Text="Submit" type="submit" />
                        </div>
                    </div>
                </div>
                <div class="status"></div>
            </div>

            <div class="col-md-3 text-center">
                <ul class="list-unstyled">
                    <li><i class="fas fa-map-marker-alt fa-2x"></i>
                        <p>Kuala Lumpur, Technology Park Malaysia</p>
                    </li>

                    <li><i class="fas fa-phone mt-4 fa-2x"></i>
                        <p>+ 01 172 205 717</p>
                    </li>

                    <li><i class="fas fa-envelope mt-4 fa-2x"></i>
                        <p>TP062986@mail.apu.edu.my</p>
                    </li>
                </ul>
            </div>

            </div>
            
        </div>
</section>
</asp:Content>
