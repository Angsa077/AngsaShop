<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="onlineGrocery.View.Admin.WebForm1" %>
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
                    <input type="text" class="form-control" id="categoryName"/>
                </div>
                <div class="mb-3">
                    <label for="categoryRemarks" class="form-label">Category Remarks</label>
                    <input type="text" class="form-control" id="categoryRemarks"/>
                </div>
                <br /><br /><br />
                <asp:Button Text="   Save   " Class="btn" style="background-color:#ffb2bf; color:white" runat="server" />
                <asp:Button Text="   Edit   " Class="btn btn-warning" style="color:white" runat="server" />
                <asp:Button Text="   Delete   " Class="btn btn-danger" runat="server" />
            </div>
            <div class="col-md-8">
                <%--Table Here--%>
            </div>
        </div>
    </div>
</asp:Content>
