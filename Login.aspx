<%@ Page Title="" Language="C#" MasterPageFile="~/VisitorsPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GroceryApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe" crossorigin="anonymous"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container py-5 h-100" style="margin-top: 100px;">
                    <div id="alertMessage" runat="server" class="alert alert-danger alert-dismissible fade show" role="alert">
            <h4 id="alertText" runat="server" class="alert-heading">The Email Or Password is not correct</h4>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col col-xl-10">
                    <div class="card" style="border-radius: 1rem;">
                        <div class="row g-0">
                            <div class="col-md-6 col-lg-5 d-none d-md-block">
                                <img src="Uploads/asian-delivery-man-wearing-red-uniform-holding-fresh-food-basket-isolated-white-wall-removebg-preview.png" class="img-fluid rounded-start" alt="Sample image"/>
                            </div>
                            <div class="col-md-6 col-lg-7 d-flex align-items-center p-3">
                                <div class="card-body">
                                    <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Sign into your account</h5>

                                    <div class="form-floating mb-4">
                                        <asp:TextBox ID="email" type="email" runat="server" CssClass="form-control mb-4" style="border-radius: 7px" placeholder="Place email here"></asp:TextBox>
                                        <label id="emailText" runat="server" class="text-dark"  for="email">Email</label>
                                    </div>

                                    <div class="form-floating mb-4">
                                        <asp:TextBox ID="password" type="password" runat="server" CssClass="form-control mb-4" style="border-radius: 7px" placeholder="Place password here"></asp:TextBox>
                                        <label id="passwordText" runat="server" class="text-dark" for="password">Password</label>
                                    </div>


                                    <div class="d-grid">
                                        <asp:Button ID="signIn" runat="server" CssClass="btn btn-dark btn-lg btn-block" style="border-radius: 7px" OnClick="signInButton" Text="Sign In" />
                                    </div>

                                    <p class="text-center text-muted mt-5 mb-0">
                                        New User? <a href="Register.aspx"
                                        class="fw-bold text-body"><u>Sign Up here</u></a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

