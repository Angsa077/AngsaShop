<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="onlineGrocery.View.Admin.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-8">
                <br />
                <img src="../../Asset/Images/product.png"/ height="90">
                <h4 style="color:#ffb2bf">Manage Products</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2 style="color:#ffb2bf">Products Details</h2>
                <div class="mb-3">
                    <label for="productName" class="form-label">Product Name</label>
                    <input type="text" class="form-control" id="productName" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="productCategory" class="form-label">Product Category</label>
                    <asp:DropDownList ID="productCategory" class="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="productPrice" class="form-label">Product Price</label>
                    <input type="text" class="form-control" id="productPrice" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="productQuantity" class="form-label">Product Quantity</label>
                    <input type="text" class="form-control" id="productQuantity" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="productPhoto" class="form-label">Photo</label>
                    <input type="file" class="form-control" id="productPhoto" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="productExpDate" class="form-label">Expiration Date</label>
                    <input type="date" class="form-control" id="productExpDate" runat="server" />
                </div>
                <label id="msg" runat="server" class="text-danger"></label>
                <br />
                <br />
                <asp:Button Text="   Save   " Class="btn" Style="background-color: #ffb2bf; color: white" runat="server" ID="SaveBtn" OnClick="SaveBtn_Click" />
                <asp:Button Text="   Edit   " Class="btn btn-warning" Style="color: white" runat="server" ID="EditBtn" OnClick="EditBtn_Click" />
                <asp:Button Text="   Delete   " Class="btn btn-danger" runat="server" ID="DeleteBtn" OnClick="DeleteBtn_Click" />
                <asp:Button Text="   Clear   " Class="btn btn-secondary" runat="server" ID="ClearBtn" OnClick="ClearBtn_Click" />
                <br />
                <br />
            </div>
            <div class="col-md-8">
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
</asp:Content>
