<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="FeedbackAdmin.aspx.cs" Inherits="GroceryApp.FeedbackAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">

<div class="pagetitle">
  <h1>Dashboard</h1>
  <nav>
    <ol class="breadcrumb">
      <li class="breadcrumb-item"><a href="AdminLandingPage.aspx">Home</a></li>
      <li class="breadcrumb-item active">Manage Feedbacks</li>
    </ol>
  </nav>
</div>
    <section class="section dashboard" style="background-color: #f6f9ff;">
        <div class="card-body">
            <div class="row d-flex justify-content-center">
                <div class="col-lg-8">
                    <div class="form-group mb-4">
                        <asp:TextBox ID="id" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                        <label class="form-label" for="id">Feedback ID</label>
                    </div>
                    <div class="form-group mb-4">
                        <asp:TextBox ID="Comment" CssClass="form-control" runat="server"></asp:TextBox>
                        <label class="form-label" for="comment">Comment</label>
                    </div>
                    <div class="form-outline mb-4">
                        <div class="d-grid">
                            <asp:Button ID="btnAdd" CssClass="btn btn-success" runat="server" Text="Send Response" OnClick="btnAdd_Click" />
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
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="products" style="margin-bottom: 0px;" CssClass="w-100" DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" InsertVisible="False" ReadOnly="True" />
        <asp:BoundField DataField="orderId" HeaderText="orderId" SortExpression="orderId" />
        <asp:BoundField DataField="quality_prod" HeaderText="quality_prod" SortExpression="quality_prod" />
        <asp:BoundField DataField="expectations" HeaderText="expectations" SortExpression="expectations" />
        <asp:BoundField DataField="del_time" HeaderText="del_time" SortExpression="del_time" />
        <asp:BoundField DataField="value" HeaderText="value" SortExpression="value" />
        <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
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
    <asp:SqlDataSource ID="products" runat="server" ConnectionString="<%$ ConnectionStrings:GroData %>" SelectCommand="SELECT * FROM [Feedback]"></asp:SqlDataSource>
        </main>
</asp:Content>
