<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="onlineGrocery.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Asset/Lib/Bootstrap/css/bootstrap.min.css" />
</head>
<body>
    <div class="container-fluid">
        <div class="row" style="height: 90px"></div>
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6 shadow-lg rounded-start">
                <div class="row m-5">
                    <div class="col-md-4">
                        <img src="../Asset/Images/Angsa Shop.png" class="img-fluid" />
                    </div>
                    <div class="col-md-8">
                        <form runat="server">
                            <h1 style="color: #ffb2bf">Login</h1>
                            <div class="mb-3">
                                <label for="Email" class="form-label">Email address</label>
                                <input type="email" class="form-control" id="Email" runat="server" required="required" />
                            </div>
                            <div class="mb-4">
                                <label for="Password" class="form-label">Password</label>
                                <input type="password" class="form-control" id="Password" runat="server" required="required" />
                            </div>
                            <div class="mb-3 d-grid">
                                <label id="msg" runat="server" class="text-danger"></label>
                                <br />
                                <br />
                                <asp:Button Text="   Login   " Class="btn btn-block" Style="background-color: #ffb2bf; color: white" runat="server" ID="LoginBtn" OnClick="LoginBtn_Click" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <div class="col-md-3"></div>
        </div>
    </div>

</body>
</html>
