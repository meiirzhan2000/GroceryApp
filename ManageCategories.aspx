<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="ManageCategories.aspx.cs" Inherits="GroceryApp.ManageCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">

<div class="pagetitle">
  <h1>Dashboard</h1>
  <nav>
    <ol class="breadcrumb">
      <li class="breadcrumb-item"><a href="AdminLandingPage.aspx">Home</a></li>
      <li class="breadcrumb-item active">Manage Categories</li>
    </ol>
  </nav>
</div>
    <section class="section dashboard" style="background-color: #f6f9ff;">
        <div class="card-body">
            <div class="row d-flex justify-content-center">
                <div class="col-lg-8">
                    <div class="form-group mb-4">
                        <asp:TextBox ID="id" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                        <label class="form-label" for="id">Product ID</label>
                    </div>
                    <div class="form-group mb-4">
                        <asp:TextBox ID="name" CssClass="form-control" runat="server"></asp:TextBox>
                        <label class="form-label" for="name">Name</label>
                    </div>
                    <div class="form-group mb-4">
                        <asp:TextBox ID="description" CssClass="form-control" runat="server"></asp:TextBox>
                        <label class="form-label" for="description">Description</label>
                    </div>
                    <div class="row">
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
        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
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
    <asp:SqlDataSource ID="products" runat="server" ConnectionString="<%$ ConnectionStrings:GroData %>" SelectCommand="SELECT * FROM [Product_Category]"></asp:SqlDataSource>
        </main>
</asp:Content>

