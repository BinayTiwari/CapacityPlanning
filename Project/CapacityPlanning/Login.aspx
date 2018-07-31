<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapacityPlanning.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login :: Capacity Planning</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body class="login-bg">


    <br />
    <br />
    <form runat="server" method="post">
        <div class="page-content container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-wrapper">
                        <div class="box">
                            <div class="content-wrap">

                                <img style="outline: 0;" src="images/logo.png"  />


                                <div class="social">
                                </div>
                                <br />
                                <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" placeholder="E-mail address" runat="server" required title="Three letter country code"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" placeholder="Password" runat="server" required></asp:TextBox>
                                <div class="action">
                                    <asp:Button CssClass="btn btn-primary signup" ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
