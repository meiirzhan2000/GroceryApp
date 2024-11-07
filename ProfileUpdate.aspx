<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="ProfileUpdate.aspx.cs" Inherits="GroceryApp.ProfileUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="background-color: #eee;">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100" style="margin-top: 100px;">
                <div id="alertMessage" runat="server" class="alert alert-success alert-dismissible fade show" role="alert">
                    <h4 id="alertText" runat="server" class="alert-heading">Registered Successfully!</h4>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
                   <div class="row">
    <div class="col">
        <nav aria-label="breadcrumb" class="bg-light rounded-3 p-3 mb-4">
            <ol class="breadcrumb mb-0">
                <li class="breadcrumb-item"><a href="UserProfile.aspx">Profile Page</a></li>
                <li class="breadcrumb-item active" aria-current="page">Update Profile</li>
            </ol>
        </nav>
    </div>
</div> 
                <div class="col col-xl-10">
                    <div class="card" style="border-radius: 1rem;">
                        <div class="row g-0">
                            <h5 class="text-center fw-normal mt-3 " style="letter-spacing: 1px;">Update Personal Data</h5>
                            <div class="col-md-6 col-lg-6 d-flex align-items-center px-3">
                                <div class="card-body">

                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="firstName" type="text" runat="server" CssClass="form-control mb-3" placeholder="Place firstName here"></asp:TextBox>
                                        <label id="name1" runat="server" class="text-dark" for="firstName">First Name</label>
                                    </div>

                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="uEmail" type="email" runat="server" CssClass="form-control mb-3" placeholder="Place email here" Enabled="False"></asp:TextBox>
                                        <label id="email" runat="server" class="text-dark" for="uEmail">Email</label>
                                    </div>


                                    <div class="form-floating">
                                        <asp:TextBox ID="uPassword" type="password" runat="server" CssClass="form-control" placeholder="Place password here"></asp:TextBox>
                                        <label id="password" runat="server" class="text-dark" for="uPassword">Password</label>
                                    </div>


                                </div>
                            </div>
                            <div class="col-md-6 col-lg-6 d-flex align-items-center px-3">
                                <div class="card-body">
                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="secondName" type="text" runat="server" CssClass="form-control mb-3" placeholder="Place secondName here"></asp:TextBox>
                                        <label id="name2" runat="server" class="text-dark" for="secondName">Second Name</label>
                                    </div>
                                    <div class="input-group mb-3">
                                        <span class="input-group-text">+60</span>
                                        <div class="form-floating">
                                            <asp:TextBox ID="uPhone" type="text" runat="server" CssClass="form-control" oninput="restrictToNumeric(this)" placeholder="Place email here"></asp:TextBox>
                                            <label id="phone" runat="server" class="text-dark" for="uPhone">Phone</label>
                                        </div>
                                    </div>

                                    <div class="form-floating">
                                        <asp:TextBox ID="cuPassword" type="password" runat="server" CssClass="form-control" placeholder="Place Confirmation of the Password here"></asp:TextBox>
                                        <label id="confPas" runat="server" class="text-dark" for="cuPassword">Confirm Password</label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 col-12 d-flex align-items-center px-4 mb-1">
                                <div class="form-group" style="width: 100%;">
                                    <label id="Label4" runat="server" class="text-dark mb-1" for="DropDownList1">Upload Profile Image</label>
                                    <asp:FileUpload ID="ProfileImage" CssClass="form-control form-control-lg" runat="server" />
                                </div>
                            </div>
                            <div class="d-grid p-3 mt-3">
                                <asp:Button ID="signUp" runat="server" CssClass="btn btn-dark btn-lg btn-block" OnClick="update_button" Text="Update Profile" type="submit" />
                            </div>
                            <div class="d-grid p-3 mb-3">
                                <a class="btn btn-dark btn-lg btn-block" href="UpdateAddress.aspx">View Address</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script>
        const myModal = document.getElementById('myModal')
        const myInput = document.getElementById('myInput')

        myModal.addEventListener('shown.bs.modal', () => {
            myInput.focus()
        })

        function restrictToNumeric(input) {
            input.value = input.value.replace(/[^0-9]/g, '');
        }
    </script>
</asp:Content>
