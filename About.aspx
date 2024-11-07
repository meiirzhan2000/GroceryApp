<%@ Page Title="" Language="C#" MasterPageFile="~/VisitorsPage.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="GroceryApp.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- About Start -->
    <div class="container-fluid page-header mb-5 wow fadeIn" data-wow-delay="0.1s">
    <div class="container">
        <h1 class="display-3 mb-3 animated slideInDown">
            About Us</h1>
        <nav aria-label="breadcrumb animated slideInDown">
            <ol class="breadcrumb mb-0">
                <li class="breadcrumb-item"><a class="text-body" href="#">Home</a></li>
                <li class="breadcrumb-item text-dark active" aria-current="page">About Us</li>
            </ol>
        </nav>
    </div>
</div>

<div class="container-xxl pb-5">
    <div class="container pb-5">
        <div class="row g-5 align-items-center">
            <div class="col-lg-6 wow fadeIn" data-wow-delay="0.1s">
                <div class="about-img position-relative overflow-hidden p-5 pe-0">
                    <img class="img-fluid w-100" src="img/about.jpg">
                </div>
            </div>
            <div class="col-lg-6 wow fadeIn" data-wow-delay="0.5s">
                <h1 class="display-5 mb-4">Shopping experience with our premium selection of top-tier products</h1>
                <p class="mb-4">Embark on a culinary journey with our grocery store, where excellence meets affordability. Indulge in the finest produce, curated for discerning tastes. Our commitment to quality ensures each item transforms your meals into masterpieces.</p>
                <p><i class="fa fa-check text-primary me-3"></i>Freshness at Your Doorstep</p>
                <p><i class="fa fa-check text-primary me-3"></i>Time-Saving Convenience</p>
                <p><i class="fa fa-check text-primary me-3"></i>Exclusive Online Discounts</p>
            </div>
        </div>
    </div>
</div>
<!-- About End -->
</asp:Content>
