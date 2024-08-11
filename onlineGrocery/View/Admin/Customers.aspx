<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="onlineGrocery.View.Admin.Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-8">
                <img src="../../Asset/Images/product.png" height="90">
                <h4 style="color: #ffb2bf">Manage Customers</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2 style="color: #ffb2bf">Customers Details</h2>
                <div class="mb-3">
                    <label for="CustomerName" class="form-label">Name</label>
                    <input type="text" class="form-control" id="CustomerName" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="CustomerEmail" class="form-label">Email</label>
                    <input type="email" class="form-control" id="CustomerEmail" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="CustomerPhone" class="form-label">Phone</label>
                    <input type="text" class="form-control" id="CustomerPhone" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="CustomerAddress" class="form-label">Address</label>
                    <input type="text" class="form-control" id="CustomerAddress" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="CustomerPhoto" class="form-label">Photo</label>
                    <input type="file" class="form-control" id="CustomerPhoto" runat="server" />
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
                <asp:GridView runat="server" class="table table-hover" ID="CustomerGV" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="CustomerGV_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Role" HeaderText="Role" />
                        <asp:ImageField DataImageUrlField="Photo" HeaderText="Photo" ControlStyle-Width="50px" ControlStyle-Height="50px" ControlStyle-CssClass="rounded-circle" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
