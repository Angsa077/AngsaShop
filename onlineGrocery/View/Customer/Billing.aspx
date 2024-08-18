<%@ Page Title="" Language="C#" MasterPageFile="~/View/Customer/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="onlineGrocery.View.Customer.Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="row">
                    <div class="col">
                        <br />
                        <div class="mb-3">
                            <label for="productName" class="form-label">Product Name</label>
                            <input type="text" class="form-control" id="productName" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label for="productPrice" class="form-label">Product Price</label>
                            <input type="text" class="form-control" id="productPrice" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label for="productQuantity" class="form-label">Product Quantity</label>
                            <input type="text" class="form-control" id="productQuantity" runat="server" />
                        </div>
                    </div>
                    <div class="col">
                        <img src="../../Asset/Images/product.png"/ height="90">
                        <br /> <br /> <br /> <br />
                        <label id="msg" runat="server" class="text-danger"></label>
                        <br />
                        <asp:Button Text="   Checkout   " Class="btn" Style="background-color: #ffb2bf; color: white" runat="server" ID="CheckoutBtn" OnClick="CheckoutBtn_Click" />
                        <asp:Button Text="   Clear   " Class="btn btn-secondary" runat="server" ID="ClearBtn" OnClick="ClearBtn_Click" />
                        <br /> <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView runat="server" class="table table-hover" ID="ProductGV" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ProductGV_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Category" HeaderText="Category" />
                                <asp:BoundField DataField="Price" HeaderText="Price" />
                                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                <asp:ImageField DataImageUrlField="Photo" HeaderText="Photo" ControlStyle-Width="50px" ControlStyle-Height="50px" ControlStyle-CssClass="rounded" />
                                <asp:BoundField DataField="ExpDate" HeaderText="ExpDate" />
                                <asp:BoundField DataField="InsertedDatetime" HeaderText="InsertedDatetime" />
                                <asp:BoundField DataField="UpdatedDatetime" HeaderText="UpdatedDatetime" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="row">
                    <div class="col-3"></div>
                    <div class="col">
                        <h1 class="pl-2" style="color:#ffb2bf">Customer Bill</h1>
                    </div>
                </div>
                <div class="row">
                    <asp:GridView runat="server" class="table table-hover" ID="BillGV" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="BillGV_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                                <asp:BoundField DataField="Date" HeaderText="Date" />
                                <asp:BoundField DataField="NameProduct" HeaderText="NameProduct" />
                                <asp:BoundField DataField="Nominal" HeaderText="Nominal" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                <asp:BoundField DataField="Total" HeaderText="Total" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:BoundField DataField="InsertedDatetime" HeaderText="InsertedDatetime" />
                                <asp:BoundField DataField="UpdatedDatetime" HeaderText="UpdatedDatetime" />
                            </Columns>
                        </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
