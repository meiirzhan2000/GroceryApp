<%@ Page Title="" Language="C#" MasterPageFile="~/VisitorsPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GroceryApp.Register" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container py-5 h-100" style="margin-top: 100px;">
                    <div id="alertMessage" runat="server" class="alert alert-success alert-dismissible fade show" role="alert">
            <h4 id="alertText" runat="server" class="alert-heading">Registered Successfully!</h4>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col col-xl-10">
                    <div class="card" style="border-radius: 1rem;">
                        <div class="row g-0">
                            <div class="col-md-8 col-lg-8 d-flex align-items-center p-3">
                                <div class="card-body">
                                    <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Sign Up</h5>
                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="firstName" type="text" runat="server" CssClass="form-control mb-3" style="border-radius: 7px" placeholder="Place firstName here"></asp:TextBox>
                                        <label id="name1" runat="server" class="text-dark" for="firstName">First Name</label>
                                    </div>

                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="secondName" type="text" runat="server" CssClass="form-control mb-3" style="border-radius: 7px" placeholder="Place secondName here"></asp:TextBox>
                                        <label id="name2" runat="server" class="text-dark" for="secondName">Second Name</label>
                                    </div>

                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="uEmail" type="email" runat="server" CssClass="form-control mb-3" style="border-radius: 7px" placeholder="Place email here"></asp:TextBox>
                                        <label id="email" runat="server" class="text-dark"  for="uEmail">Email</label>
                                    </div>

                                    <div class="input-group mb-3">
                                         <span class="input-group-text" style="border-radius: 7px">+60</span>
                                         <div class="form-floating">
                                            <asp:TextBox ID="uPhone" type="text" runat="server" CssClass="form-control" style="border-radius: 7px; margin-left: 5px;" oninput="restrictToNumeric(this)" placeholder="Place email here"></asp:TextBox>
                                            <label id="phone" runat="server" class="text-dark"  for="uPhone">Phone</label>
                                        </div>
                                    </div>

                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="uPassword" type="password" runat="server" CssClass="form-control mb-3" style="border-radius: 7px" placeholder="Place password here"></asp:TextBox>
                                        <label id="password" runat="server" class="text-dark" for="uPassword">Password</label>
                                    </div>

                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="cuPassword" type="password" runat="server" CssClass="form-control mb-3" style="border-radius: 7px" placeholder="Place Confirmation of the Password here"></asp:TextBox>
                                        <label id="confPas" runat="server" class="text-dark" for="cuPassword">Confirm Password</label>
                                    </div>

                                    <div class="d-flex justify-content-around align-items-center mb-3">
                                        <div class="form-check">
                                            <label class="form-check-label" for="form1Example3"> By Completing Registration, I agreed to <a class="btn-link" data-bs-toggle="modal" data-bs-target="#exampleModal">Terms of service</a></label>
                                        </div>
                                    </div>
                                    <div class="d-grid">
                                        <asp:Button ID="signUp" runat="server" CssClass="btn btn-dark btn-lg btn-block" style="border-radius: 7px" OnClick="register_button" Text="Sing Up" type="submit" />
                                    </div>

                                    <p class="text-center text-muted mt-3 mb-0">Existing User ? <a href="Login.aspx"
                                        class="fw-bold text-body"><u>Login here</u></a></p>
                                </div>
                            </div>
                            <div class="col-md-4 col-lg-4 d-none d-md-block">
                                <img src="Uploads/young-asian-woman-shopping-grocery-cart-from-supermarket__1_-removebg-preview.png" class="img-fluid rounded-start" alt="Sample image" style="border-radius: 1rem 0 0 1rem;"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                <h1 class="modal-title fs-5" id="exampleModalLabel">Terms of service</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
These terms and conditions govern your use of this website; by using this website, you accept these terms and conditions in full. If you disagree with these terms and conditions or any part of these terms and conditions, you must not use this website.

Unless otherwise stated, we or our licensors own the intellectual property rights in the website and material on the website. Subject to the license below, all these intellectual property rights are reserved. You may view, download for caching purposes only, and print pages from the website for your own personal use, subject to the restrictions set out below and elsewhere in these terms and conditions.

You must not use this website in any way that causes, or may cause, damage to the website or impairment of the availability or accessibility of the website; or in any way which is unlawful, illegal, fraudulent or harmful, or in connection with any unlawful, illegal, fraudulent or harmful purpose or activity. You must not use this website to copy, store, host, transmit, send, use, publish or distribute any material which consists of (or is linked to) any spyware, computer virus, Trojan horse, worm, keystroke logger, rootkit or other malicious computer software. You must not conduct any systematic or automated data collection activities (including without limitation scraping, data mining, data extraction and data harvesting) on or in relation to this website without our express written consent.

Access to certain areas of this website is restricted. We reserve the right to restrict access to areas of this website, or indeed this entire website, at our discretion. If we provide you with a user ID and password to enable you to access restricted areas of this website or other content or services, you must ensure that the user ID and password are kept confidential. We may disable your user ID and password in our sole discretion without notice or explanation.

We may revise these terms and conditions from time-to-time. Revised terms and conditions will apply to the use of this website from the date of the publication of the revised terms and conditions on this website. Please check this page regularly to ensure you are familiar with the current version.

These terms and conditions constitute the entire agreement between you and us in relation to your use of this website and supersede all previous agreements in respect of your use of this website.

These terms and conditions will be governed by and construed in accordance with the laws of Malaysia, and any disputes relating to these terms and conditions will be subject to the exclusive jurisdiction of the courts of Malaysia.

The full name of our company is Fresh. You can contact us by email to tp062986@mail.apu.edu.my.
                </div>
                <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
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

