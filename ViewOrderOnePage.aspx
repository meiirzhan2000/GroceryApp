<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="ViewOrderOnePage.aspx.cs" Inherits="GroceryApp.ViewOrderOnePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .track-line {
            height: 2px !important;
            background-color: #488978;
            opacity: 1;
        }

        .dot {
            height: 10px;
            width: 10px;
            margin-left: 3px;
            margin-right: 3px;
            margin-top: 0px;
            background-color: #488978;
            border-radius: 50%;
            display: inline-block;
        }

        .big-dot {
            height: 25px;
            width: 25px;
            margin-left: 0px;
            margin-right: 0px;
            margin-top: 0px;
            background-color: #488978;
            border-radius: 50%;
            display: inline-block;
        }

            .big-dot i {
                font-size: 12px;
            }

        .card-stepper {
            z-index: 0;
        }

        .star-rating {
            font-size: 0;
            white-space: nowrap;
            display: inline-block;
            width: 250px;
            height: 50px;
            overflow: hidden;
            position: relative;
            background: url('data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IiB3aWR0aD0iMjBweCIgaGVpZ2h0PSIyMHB4IiB2aWV3Qm94PSIwIDAgMjAgMjAiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDIwIDIwIiB4bWw6c3BhY2U9InByZXNlcnZlIj48cG9seWdvbiBmaWxsPSIjREREREREIiBwb2ludHM9IjEwLDAgMTMuMDksNi41ODMgMjAsNy42MzkgMTUsMTIuNzY0IDE2LjE4LDIwIDEwLDE2LjU4MyAzLjgyLDIwIDUsMTIuNzY0IDAsNy42MzkgNi45MSw2LjU4MyAiLz48L3N2Zz4=');
            background-size: contain;
            i

        {
            opacity: 0;
            position: absolute;
            left: 0;
            top: 0;
            height: 100%;
            width: 20%;
            z-index: 1;
            background: url('data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IiB3aWR0aD0iMjBweCIgaGVpZ2h0PSIyMHB4IiB2aWV3Qm94PSIwIDAgMjAgMjAiIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDIwIDIwIiB4bWw6c3BhY2U9InByZXNlcnZlIj48cG9seWdvbiBmaWxsPSIjRkZERjg4IiBwb2ludHM9IjEwLDAgMTMuMDksNi41ODMgMjAsNy42MzkgMTUsMTIuNzY0IDE2LjE4LDIwIDEwLDE2LjU4MyAzLjgyLDIwIDUsMTIuNzY0IDAsNy42MzkgNi45MSw2LjU4MyAiLz48L3N2Zz4=');
            background-size: contain;
        }

        input {
            -moz-appearance: none;
            -webkit-appearance: none;
            opacity: 0;
            display: inline-block;
            width: 20%;
            height: 100%;
            margin: 0;
            padding: 0;
            z-index: 2;
            position: relative;
            &:hover + i, &:checked + i

        {
            opacity: 1;
        }

        }

        i ~ i {
            width: 40%;
        }

            i ~ i ~ i {
                width: 60%;
            }

                i ~ i ~ i ~ i {
                    width: 80%;
                }

                    i ~ i ~ i ~ i ~ i {
                        width: 100%;
                    }

        }

        //JUST COSMETIC STUFF FROM HERE ON. THESE AREN'T THE DROIDS YOU ARE LOOKING FOR: MOVE ALONG.

        //just styling for the number
        .choice {
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            text-align: center;
            padding: 20px;
            display: block;
        }

        //reset, center n shiz (don't mind this stuff)
        *, ::after, ::before{
          height: 100%;
          padding:0;
          margin:0;
          box-sizing: border-box;
          text-align: center;  
          vertical-align: middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="vh-100 mb-2">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div id="alertMessage" runat="server" class="alert alert-success alert-dismissible fade show" role="alert">
                    <h4 id="alertText" runat="server" class="alert-heading">The Review submitted successfully!</h4>
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
                <div class="col">
                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col" class="h5">Products</th>
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
                                                <p class="mb-0" style="font-weight: 500;"><%# Eval("Quantity") %></p>
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

                    <div class="card card-stepper mb-3" style="border-radius: 10px;">
                        <div class="card-body p-4">

                            <div class="d-flex justify-content-between align-items-center">
                                <div class="d-flex flex-column">
                                    <span class="lead fw-normal" runat="server" id="expDel">expected delivery date </span>
                                    <span class="text-muted small" runat="server" id="ordersDate">by DHFL on 21 Jan, 2020</span>
                                </div>
                                <div>
                                    <div class="d-flex align-items-center">
                                        <div class="dropdown">
                                            <button class="btn btn-primary btn-sm dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                                Order Actions
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li><a class="dropdown-item" data-bs-toggle="modal" data-bs-target="#getHelp" href="#">Get Help</a></li>
                                                <li><a class="dropdown-item" runat="server" id="reviewCheck" data-bs-toggle="modal" data-bs-target="#reviewModal" href="#">Review</a></li>
                                                <li><a class="dropdown-item" data-bs-toggle="modal" data-bs-target="#cancelOrder" runat="server" onclick="" href="#">Cancel Order</a></li>
                                                <li><a class="dropdown-item">Close</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="my-4">

                            <div class="d-flex flex-row justify-content-between align-items-center align-content-center">
                                <span class="dot"></span>
                                <hr class="flex-fill track-line">
                                <span runat="server" id="st1" class="dot"></span>
                                <hr class="flex-fill track-line">
                                <span runat="server" id="st2" class="dot"></span>
                                <hr class="flex-fill track-line">
                                <span runat="server" id="st3" class="dot">
                                    <i class="fa fa-check text-white"></i></span>
                            </div>

                            <div class="d-flex flex-row justify-content-between align-items-center">
                                <div class="d-flex flex-column align-items-start">
                                    <span>Order placed</span>
                                </div>
                                <div class="d-flex flex-column justify-content-center"><span>Panding</span></div>
                                <div class="d-flex flex-column align-items-center">
                                    <span>Out for
                  delivery</span>
                                </div>
                                <div class="d-flex flex-column align-items-end"><span>Delivered</span></div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="modal fade" id="getHelp" tabindex="-1" aria-labelledby="getHelpLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Get Help</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="col">
                        <div class="mb-4">
                            <label for="TextArea" class="form-label w-100">How can we help you?</label>
                            <textarea id="TextArea" runat="server" class="form-control" rows="3" placeholder="Add your comment"></textarea>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <asp:Button type="button" CssClass="btn btn-primary" runat="server" OnClick="submitHelp" Text="Submit" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="reviewModal" tabindex="-1" aria-labelledby="reviewModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Review</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="col">
                        <div class="mb-4">
                            <label for="star-rating" class="form-label w-100">On a scale of 1 to 5 stars, how satisfied were you with the quality of the products received?</label>
                            <span class="star-rating">
                                <input type="radio" name="rating" value="1"><i></i>
                                <input type="radio" name="rating" value="2"><i></i>
                                <input type="radio" name="rating" value="3"><i></i>
                                <input type="radio" name="rating" value="4"><i></i>
                                <input type="radio" name="rating" value="5"><i></i>
                            </span>
                        </div>
                        <div class="mb-4">
                            <label for="star-rating" class="form-label w-100">Did the grocery order meet your expectations?</label>
                            <span class="star-rating">
                                <input type="radio" name="rating1" value="1"><i></i>
                                <input type="radio" name="rating1" value="2"><i></i>
                                <input type="radio" name="rating1" value="3"><i></i>
                                <input type="radio" name="rating1" value="4"><i></i>
                                <input type="radio" name="rating1" value="5"><i></i>
                            </span>
                        </div>
                        <div class="mb-4">
                            <label for="star-rating" class="form-label w-100">How satisfied were you with the delivery time for your grocery order?</label>
                            <span class="star-rating">
                                <input type="radio" name="rating2" value="1"><i></i>
                                <input type="radio" name="rating2" value="2"><i></i>
                                <input type="radio" name="rating2" value="3"><i></i>
                                <input type="radio" name="rating2" value="4"><i></i>
                                <input type="radio" name="rating2" value="5"><i></i>
                            </span>
                        </div>
                        <div class="mb-4">
                            <label for="star-rating" class="form-label w-100">Overall, how satisfied are you with the value for money of your grocery order?</label>
                            <span class="star-rating">
                                <input type="radio" name="rating3" value="1"><i></i>
                                <input type="radio" name="rating3" value="2"><i></i>
                                <input type="radio" name="rating3" value="3"><i></i>
                                <input type="radio" name="rating3" value="4"><i></i>
                                <input type="radio" name="rating3" value="5"><i></i>
                            </span>
                        </div>
                        <div class="mb-4">
                            <label for="TextArea" class="form-label w-100">Please tell us how we can improve the service.</label>
                            <textarea id="TextArea1" runat="server" class="form-control" rows="3" placeholder="Add your comment"></textarea>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <asp:Button type="button" CssClass="btn btn-primary" runat="server" OnClick="submitFeedback" Text="Submit" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="cancelOrder" tabindex="-1" aria-labelledby="cancelOrderLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Cancel Order</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="col">
                        <div class="mb-4">
                            <label for="TextArea" class="form-label w-100">Please add the reason why are you trying to cancel the order</label>
                            <textarea id="TextArea2" runat="server" class="form-control" rows="3" placeholder="Add your comment"></textarea>
                        </div>
                        <div class="mb-4">
                            <label for="cancelReason" class="form-label w-100">Select a reason for cancellation:</label>
                            <select id="cancelReason" runat="server" class="form-select">
                                <option value="Item out of stock">Wrong Address</option>
                                <option value="Change in plans">Change in plans</option>
                                <option value="Found better deal elsewhere">Found better deal elsewhere</option>
                                <option value="Shipping delay">Shipping delay</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <asp:Button type="button" CssClass="btn btn-primary" runat="server" OnClick="cancelSubmit" Text="Submit" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
