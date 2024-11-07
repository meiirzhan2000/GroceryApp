<%@ Page Title="" Language="C#" MasterPageFile="~/VisitorsPage.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="GroceryApp.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid page-header mb-5 wow fadeIn" data-wow-delay="0.1s">
    <div class="container">
        <h1 class="display-3 mb-3 animated slideInDown">
            Product Details</h1>
        <nav aria-label="breadcrumb animated slideInDown">
            <ol class="breadcrumb mb-0">
                <li class="breadcrumb-item"><a class="text-body" href="#">Home</a></li>
                <li class="breadcrumb-item"><a class="text-body" href="Products.aspx">Products</a></li>
                <li class="breadcrumb-item text-dark active" aria-current="page">Product Details</li>
            </ol>
        </nav>
    </div>
</div>
    <section class="pb-5">
            <div class="container px-4 px-lg-5">
                <div class="row gx-4 gx-lg-5 align-items-center">
                    <div class="col-md-6"><asp:Image ID="productImage" runat="server" CssClass="card-img-top mb-5 mb-md-0" AlternateText="Product Image" /></div>
                    <div class="col-md-6">
                        <div class="small mb-1"><asp:Label ID="skuLabel" runat="server" CssClass="mb-1" /></div>
                        <h1 class="display-5 fw-bolder" id="productNameLabel" runat="server">Shop item template</h1>
                        <div class="fs-5 mb-5">
                            <span id="priceLabel" runat="server"></span>
                        </div>
                        <p class="lead" id="descriptionLabel" runat="server">Lorem ipsum dolor sit amet consectetur adipisicing elit. Praesentium at dolorem quidem modi. Nam sequi consequatur obcaecati excepturi alias magni, accusamus eius blanditiis delectus ipsam minima ea iste laborum vero?</p>
                        <div class="d-flex">
                            <input class="form-control text-center me-3" id="inputQuantity" type="num" value="1" style="max-width: 3rem" />
                            <button class="btn btn-outline-dark flex-shrink-0" type="button">
                                <i class="bi-cart-fill me-1"></i>
                                Add to cart
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="py-5">
        <div class="container px-4 px-lg-5 mt-5">
            <h2 class="fw-bolder mb-4">Related products</h2>
                <div class="row g-4" id="my" runat="server">

                </div>
            </div>
        </section>
</asp:Content>
