<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="GroceryApp.ShoppingCart1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="h-100 h-custom" style="margin-top: 150px;">
        <div class="container h-100 py-5">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div id="alertMessageFor" runat="server" class="alert alert-danger alert-dismissible fade show" role="alert">
                    <h4 id="alertText" runat="server" class="alert-heading">Please add your address in the profile page before proceeding</h4>
                    <asp:Button type="button" CssClass="btn-close" runat="server" OnClick="closeAlert" aria-label="Close" />
                </div>
                <div class="col">
                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col" class="h5">Shopping Bag</th>
                                    <th scope="col">Quantity</th>
                                    <th scope="col">Price</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="itemRepeater" runat="server" OnItemCommand="ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row">
                                                <div class="d-flex align-items-center">
                                                    <img src='<%# Eval("ImageUrl") %>' class="img-fluid rounded-3"
                                                        style="width: 120px;" alt="Book">
                                                    <div class="flex-column ms-4">
                                                        <p class="mb-2"><%# Eval("Title") %></p>
                                                        <p class="mb-0"><%# Eval("Author") %></p>
                                                    </div>
                                                </div>
                                            </th>
                                            <td class="align-middle">
                                                <div class="d-flex flex-row">
                                                    <asp:Button CssClass="btn btn-link px-2" ID="btnDecrease" runat="server" CommandName="Decrease" Text="-" CommandArgument='<%# Container.ItemIndex %>' />
                                                    <input id="form1" min="0" name="quantity" value='<%# Eval("Quantity") %>'
                                                        type="number" runat="server" class="form-control form-control-sm" style="width: 50px;" />
                                                    <asp:Button CssClass="btn btn-link px-2" ID="btnIncrease" runat="server" CommandName="Increase" Text="+" CommandArgument='<%# Container.ItemIndex %>' />
                                                </div>
                                            </td>
                                            <td class="align-middle">
                                                <p class="mb-0" style="font-weight: 500;">RM<%# Eval("Price") %></p>
                                            </td>
                                            <td class="align-middle">
                                                <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ProductId") %>' Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                    <div class="card shadow-2-strong mb-5 mb-lg-0" style="border-radius: 16px;">
                        <div class="card-body p-4">
                            <h1 class="modal-title fs-5 pb-3" id="exampleModalLabel">Order Confirmation</h1>

                            <div class="cs-form mb-3">
                                <label for="txtConfirmationDate" class="form-label">Delivery Date: </label>
                                <input type="date" id="txtConfirmationDate" runat="server" class="form-control" name="trip-start" value="2018-07-22" min="2018-01-01" max="2018-12-31" />
                            </div>
                            <div class="cs-form mb-3">
                                <label for="appt" class="form-label">Delivery Time: </label>
                                <input type="time" id="appt" class="form-control" runat="server" name="appt" min="09:00" value="09:00" max="18:00" />
                                <small>Delivery hours are 9am to 6pm</small>
                            </div>
                            <div class="mb-4">
                                <label for="TextArea" class="form-label w-100">Additional Comments:</label>
                                <textarea id="TextArea" runat="server" class="form-control" rows="3" placeholder="Add your comment"></textarea>
                            </div>
                        </div>
                        <div class="row mx-3">
                            <div class="col-md-6 col-lg-4 col-xl-3 mb-4 mb-md-0">
                                <div class="d-flex flex-row pb-3">
                                    <div class="d-flex align-items-center pe-2">
                                        <input class="form-check-input" type="radio" name="radioNoLabel" id="radioNoLabel1v" runat="server"
                                            value="" aria-label="..." checked />
                                    </div>
                                    <div class="rounded border w-100 p-3">
                                        <p class="d-flex align-items-center mb-0">
                                            <i class="fab fa-cc-mastercard fa-2x text-dark pe-2"></i>Credit
                        Card
                                        </p>
                                    </div>
                                </div>
                                <div class="d-flex flex-row pb-3">
                                    <div class="d-flex align-items-center pe-2">
                                        <input class="form-check-input" type="radio" name="radioNoLabel" id="radioNoLabel2v" runat="server"
                                            value="" aria-label="..." />
                                    </div>
                                    <div class="rounded border w-100 p-3">
                                        <p class="d-flex align-items-center mb-0">
                                            <i class="fab fa-cc-visa fa-2x fa-lg text-dark pe-2"></i>Debit Card
                                        </p>
                                    </div>
                                </div>
                                <div class="d-flex flex-row">
                                    <div class="d-flex align-items-center pe-2">
                                        <input class="form-check-input" type="radio" name="radioNoLabel" id="radioNoLabel3v" runat="server"
                                            value="" aria-label="..." />
                                    </div>
                                    <div class="rounded border w-100 p-3">
                                        <p class="d-flex align-items-center mb-0">
                                            <i class="fab fa-cc-paypal fa-2x fa-lg text-dark pe-2"></i>PayPal
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-lg-4 col-xl-6">
                                <div class="row">
                                    <div class="col-12 col-xl-6">
                                        <div class="form-outline mb-4 mb-xl-5">
                                            <input type="text" runat="server" id="typeName" class="form-control form-control-lg" siez="17"
                                                placeholder="John Smith" />
                                            <label class="form-label" for="typeName">Name on card</label>
                                        </div>

                                        <div class="form-outline mb-4 mb-xl-5">
                                            <input type="text" runat="server" id="typeExp" class="form-control form-control-lg" placeholder="MM/YY"
                                                size="5" minlength="5" maxlength="5" />
                                            <label class="form-label" for="typeExp">Expiration</label>
                                        </div>
                                    </div>
                                    <div class="col-12 col-xl-6">
                                        <div class="form-outline mb-4 mb-xl-5">
                                            <input type="text" runat="server" id="typeText" class="form-control form-control-lg" siez="17"
                                                placeholder="1111 2222 3333 4444" minlength="19" maxlength="19" />
                                            <label class="form-label" for="typeText">Card Number</label>
                                        </div>

                                        <div class="form-outline mb-4 mb-xl-5">
                                            <input type="password" runat="server" id="typeText1" class="form-control form-control-lg"
                                                placeholder="&#9679;&#9679;&#9679;" size="1" minlength="3" maxlength="3" />
                                            <label class="form-label" for="typeText">Cvv</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-xl-3 mb-2">
                                <div class="d-flex justify-content-between" style="font-weight: 500;">
                                    <p class="mb-2">Subtotal:</p>
                                    <p class="mb-2" runat="server" id="lblSubtotal">RM23.49</p>
                                </div>

                                <div class="d-flex justify-content-between" style="font-weight: 500;">
                                    <p class="mb-2">Shipping:</p>
                                    <p class="mb-2" runat="server" id="lblShipping">RM2.99</p>
                                </div>

                                <div class="d-flex justify-content-between" style="font-weight: 500;">
                                    <p class="mb-0">Address: </p>
                                    <p class="mb-0" runat="server" id="orderAddress"></p>
                                </div>

                                <hr class="my-4">

                                <div class="d-flex justify-content-between mb-4" style="font-weight: 500;">
                                    <p class="mb-2">Total (tax included)</p>
                                    <p class="mb-2" runat="server" id="lblTotal">RM26.48</p>
                                </div>
                                <asp:Button type="button" runat="server" CssClass="btn btn-primary btn-lg btn-block" Style="border-radius: 7px" Text="Check Out" OnClick="Unnamed2_Click" />
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </section>
</asp:Content>
