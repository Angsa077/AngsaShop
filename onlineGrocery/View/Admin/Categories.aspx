<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="onlineGrocery.View.Admin.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-8">
                <br />
                <img src="../../Asset/Images/product.png"/ height="90">
                <h4 style="color:#ffb2bf">Manage Categories</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2 style="color:#ffb2bf">Categories Details</h2>
                <div class="mb-3">
                    <label for="categoryName" class="form-label">Category Name</label>
                    <input type="text" class="form-control" id="categoryName" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="categoryRemarks" class="form-label">Category Remarks</label>
                    <input type="text" class="form-control" id="categoryRemarks" runat="server" />
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
                <asp:GridView runat="server" class="table table-hover" ID="CategoryGV" AutoGenerateSelectButton="True" OnSelectedIndexChanged="CategoryGV_SelectedIndexChanged">

                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
