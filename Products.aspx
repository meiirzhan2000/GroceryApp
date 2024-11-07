<%@ Page Title="" Language="C#" MasterPageFile="~/VisitorsPage.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="GroceryApp.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="panel1" runat="server"><ContentTemplate>
    <div class="container-fluid page-header mb-5 wow fadeIn" data-wow-delay="0.1s">
        <div class="container">
            <h1 class="display-3 mb-3 animated slideInDown">
                Products</h1>
            <nav aria-label="breadcrumb animated slideInDown">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a class="text-body" href="#">Home</a></li>
                    <li class="breadcrumb-item text-dark active" aria-current="page">Products</li>
                </ol>
            </nav>
        </div>
    </div>

    <div class="container-xxl py-5">
        <div class="container">
            <div class="row g-0 gx-5 align-items-end">
                <div class="col-lg-6">
                    <div class="section-header text-start mb-5 wow fadeInUp" data-wow-delay="0.1s" style="max-width: 500px;">
                        <h1 class="display-5 mb-3">Our Products</h1>
                        <p>Tempor ut dolore lorem kasd vero ipsum sit eirmod sit. Ipsum diam justo sed rebum vero dolor duo.</p>
                    </div>
                </div>
            </div>
            <div class="row g-0 gx-5 mb-3 align-items-end">
               <div class="col-md-7 col-12 d-md-flex align-items-center" data-wow-delay="0.1s">
                   <div class="form-group p-2">
                        <asp:DropDownList ID="sortBy" runat="server" class="form-select" style="border-radius: 7px"  aria-label=".form-select-sm example">
                          <asp:ListItem value="">Select Price</asp:ListItem>
                          <asp:ListItem value="1">Price: Low to High</asp:ListItem>
                          <asp:ListItem value="2">Price: High to Low</asp:ListItem>
                        </asp:DropDownList>
                       </div>
                    <div class="form-group p-2">
                    <asp:TextBox ID="start" type="number" runat="server" CssClass="form-control" style="border-radius: 7px" placeholder="Min Price"></asp:TextBox>
                    </div>
                    <div class="form-group p-2 ">
                    <asp:TextBox ID="end" type="number" runat="server" CssClass="form-control px-1" style="border-radius: 7px" placeholder="Max Price"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5 col-12 d-md-flex align-items-center mt-md-0 mt-3">
                     <div class="form-group p-2">
                 <asp:DropDownList ID="category" CssClass="form-select" style="border-radius: 7px" runat="server" DataSourceID="categories" DataTextField="name" DataValueField="name">
</asp:DropDownList>
<asp:SqlDataSource ID="categories" runat="server" ConnectionString="<%$ ConnectionStrings:GroData %>" SelectCommand="SELECT [name] FROM [Product_Category]"></asp:SqlDataSource>
 </div>
 <asp:Button ID="applyButton" runat="server" type="button" Text="Apply" CssClass="btn btn-success p-1 me-1 " style="border-radius: 7px" OnClick="applyButton_Click"></asp:Button>
<asp:Button ID="reset" runat="server" type="button" Text="Reset" CssClass="btn btn-secondary p-1 ms-1" style="border-radius: 7px" OnClick="resetButton_Click"></asp:Button>
                </div>
            </div>
            <div class="tab-content">
                <div id="tab-1" class="tab-pane fade show p-0 active">
                    <div class="row g-4" id="my" runat="server">
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
        </ContentTemplate></asp:UpdatePanel>
    <!-- Product End -->
</asp:Content>
