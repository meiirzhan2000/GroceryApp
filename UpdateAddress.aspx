<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="UpdateAddress.aspx.cs" Inherits="GroceryApp.UpdateAddress" %>
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
                            <div runat="server" id="panel1">

            </div>

                <div class="col col-xl-10">
                    <div class="card" style="border-radius: 1rem;">
                        <div class="row g-0">
                            <h5 class="text-center fw-normal mt-3 " style="letter-spacing: 1px;">Edit Address</h5>
                            <div class="d-grid px-4 mb-3">
                                <label id="Label3" runat="server" class="text-dark mb-1" for="address">Address</label>
                                <asp:TextBox ID="address" runat="server" CssClass="form-control" TextMode="MultiLine" lines="10" placeholder="Provide Your Address"></asp:TextBox>
                            </div>
                           <div class="col-md-4 col-4 d-flex align-items-center px-4">
                                <div class="form-group" style="width: 100%;">
                                <label id="Label2" runat="server" class="text-dark mb-1" for="stateU">State</label>
                                <asp:DropDownList ID="stateU" CssClass="form-select form-select-lg" runat="server" DataSourceID="States" DataTextField="StateName" DataValueField="StateName">
                                    </asp:DropDownList>
                                <asp:SqlDataSource ID="States" runat="server" ConnectionString="<%$ ConnectionStrings:GroData %>" SelectCommand="SELECT [StateName] FROM [States]"></asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="col-md-4 col-4 d-flex align-items-center">
                                <div class="form-group" style="width: 100%;">
                                    <label id="Label1" runat="server" class="text-dark mb-1" for="cityU">City</label>
                                    <asp:DropDownList ID="cityU" CssClass="form-select form-select-lg" runat="server" DataSourceID="Cities" DataTextField="CityName" DataValueField="CityName">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="Cities" runat="server" ConnectionString="<%$ ConnectionStrings:GroData %>" SelectCommand="SELECT [CityName] FROM [Cities]"></asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="col-md-4 col-4 d-flex align-items-center px-4">
                                <div class="form-group" style="width: 100%;">
                                    <label id="postcode" runat="server" class="text-dark mb-1" for="postcodeU">Postcode</label>
                                    <asp:TextBox ID="postcodeU" type="text" runat="server" CssClass="form-control form-control-lg" oninput="restrictToNumeric(this)" placeholder="05699"></asp:TextBox>
                                </div>
                            </div>
                            <div class="d-grid p-3 mt-3">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-dark btn-lg btn-block" Text="Update Address" type="submit" OnClick="Button1_Click" />
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
