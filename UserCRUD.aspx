<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="UserCRUD.aspx.cs" Inherits="GroceryApp.UserCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">

    <div class="pagetitle">
      <h1>Dashboard</h1>
      <nav>
        <ol class="breadcrumb">
          <li class="breadcrumb-item"><a href="AdminLandingPage.aspx">Home</a></li>
          <li class="breadcrumb-item active">Manage Users</li>
        </ol>
      </nav>
    </div>
        <section class="section dashboard" style="background-color: #f6f9ff;">
        <div id="alertMessage" runat="server" class="alert alert-success alert-dismissible fade show" visible="false" role="alert">
            <h4 id="alertText" runat="server" class="alert-heading"></h4>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        <div class="card-body">
            <div class="row d-flex justify-content-center">
                <div class="col-lg-8">
                    <div class="row">
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:TextBox ID="email" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="form-label" for="email">Email</label>
                            </div>
                        </div>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:TextBox ID="phone" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="form-label" for="phone">Phone</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:TextBox ID="firstName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="form-label" for="firstName">First Name</label>
                            </div>
                        </div>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:TextBox ID="secondName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <label class="form-label" for="secondName">Second Name</label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group mb-4">
                        <asp:TextBox ID="password" CssClass="form-control" runat="server"></asp:TextBox>
                        <label class="form-label" for="password">Password</label>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:DropDownList ID="active" class="btn btn-secondary dropdown-toggle" runat="server">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>0</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <label class="form-label" for="active">Active</label>
                            </div>
                        </div>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <div class="d-grid">
                                    <asp:TextBox ID="createdAt" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                                <label class="form-label" for="createdAt">Created at</label>
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
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="email" DataSourceID="UsersTable" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="width: 100%;">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="email" HeaderText="email" ReadOnly="True" SortExpression="email" />
        <asp:BoundField DataField="first_name" HeaderText="first_name" SortExpression="first_name" />
        <asp:BoundField DataField="second_name" HeaderText="second_name" SortExpression="second_name" />
        <asp:BoundField DataField="when_created" HeaderText="when_created" SortExpression="when_created" />
        <asp:CheckBoxField DataField="active" HeaderText="active" SortExpression="active" />
        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
        <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
        <asp:BoundField DataField="user_type" HeaderText="user_type" SortExpression="user_type" />
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
    <asp:SqlDataSource ID="UsersTable" runat="server" ConnectionString="<%$ ConnectionStrings:GroData %>" SelectCommand="SELECT * FROM [Customer]"></asp:SqlDataSource>
        </main>
</asp:Content>
