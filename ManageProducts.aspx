<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="GroceryApp.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">

<div class="pagetitle">
  <h1>Dashboard</h1>
  <nav>
    <ol class="breadcrumb">
      <li class="breadcrumb-item"><a href="AdminLandingPage.aspx">Home</a></li>
      <li class="breadcrumb-item active">Manage Products</li>
    </ol>
  </nav>
</div>
    <section class="section dashboard" style="background-color: #f6f9ff;">
        <div class="card-body">
            <div class="row d-flex justify-content-center">
                <div class="col-lg-8">
                    <div class="row">
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:TextBox ID="productName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="form-label" for="productName">Product Name</label>
                            </div>
                        </div>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:TextBox ID="price" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="form-label" for="price">Price</label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group mb-4">
                        <asp:TextBox ID="description" CssClass="form-control" runat="server"></asp:TextBox>
                        <label class="form-label" for="description">Product Description</label>
                    </div>
                    <div class="row">
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:TextBox ID="brandName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="form-label" for="brandName">Brand</label>
                            </div>
                        </div>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:TextBox ID="weight" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="form-label" for="weight">Weight</label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group mb-4">
                        <asp:TextBox ID="promises" CssClass="form-control" runat="server"></asp:TextBox>
                        <label class="form-label" for="promises">Promise To The Customers</label>
                    </div>
                    <div class="row">
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:DropDownList ID="productClass" class="btn btn-secondary dropdown-toggle" runat="server"
                                        DataSourceID="ProductCategoryId" DataTextField="name" DataValueField="name"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="ProductCategoryId" runat="server" ConnectionString="<%$ ConnectionStrings:GroData %>" SelectCommand="SELECT [id], [name] FROM [Product_Category]"></asp:SqlDataSource>
                                </div>
                                <label class="form-label" for="productClass">Product Category</label>
                            </div>
                        </div>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:TextBox ID="image" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="form-label" for="image">Image URL</label>
                            </div>
                        </div>
                        <div class="col-md-4 mb-3">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 mb-3">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:Button ID="btnDelete" CssClass="btn btn-warning" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 mb-3">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:Button ID="btnUpdate" CssClass="btn btn-info" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-outline mb-4">
                        <div class="d-grid">
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel Operation" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="products" style="margin-bottom: 0px;" CssClass="w-100" DataKeyNames="id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" />
        <asp:BoundField DataField="product_name" HeaderText="product_name" SortExpression="product_name" />
        <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
        <asp:BoundField DataField="product_class" HeaderText="product_class" SortExpression="product_class" />
        <asp:BoundField DataField="brand_name" HeaderText="brand_name" SortExpression="brand_name" />
        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
        <asp:BoundField DataField="weight" HeaderText="weight" SortExpression="weight" />
        <asp:BoundField DataField="promises" HeaderText="promises" SortExpression="promises" />
        <asp:BoundField DataField="image" HeaderText="image" SortExpression="image" />
    </Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#6B696B" Font-Bold="True" Font-Size="Large" ForeColor="White" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" Font-Size="Large" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="products" runat="server" ConnectionString="<%$ ConnectionStrings:GroData %>"
    SelectCommand="SELECT P.id, P.product_name, P.price, PC.name AS product_class, P.brand_name, P.description, P.weight, P.promises, P.image
                   FROM Product P
                   INNER JOIN Product_Category PC ON P.id = PC.id">
</asp:SqlDataSource>
        </main>
</asp:Content>
