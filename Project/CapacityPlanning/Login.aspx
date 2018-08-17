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
    <link href="images/1.png" rel="shortcut icon" type="image/x-icon" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <link href="css/main.css" rel="stylesheet" />

</head>
<body class="login">
    <form runat="server" accept-charset="utf-8" method="post">
        <div class="login_wrapper">
            <div class="login-box">
                <div class="login-logo">
                    <img src="images/logo.png" width="250" height="100" alt="" />
                </div>
                <div class="login-box-body">
                    <p class="login-box-msg">Sign in to your account</p>
                    <div class="form-group has-feedback">
                        <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" placeholder="E-mail address" runat="server" required ></asp:TextBox>
                        <span class="fa fa-user form-control-feedback"></span><span><font color="red"></font></span>
                    </div>

                    <div class="form-group has-feedback">
                        <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" placeholder="Password" runat="server" required></asp:TextBox>
                        <span class="fa fa-lock form-control-feedback"></span><span><font color="red"></font></span>
                    </div>
                    <div class="icheckbox_square-blue" aria-checked="false" aria-disabled="false">
                        <input type="checkbox" name="remember" value="" id="remember" />
                        Remember me
                    </div>
                    <div>
                     <a href="../ResetPassword.aspx">Can't access your account?</a>   
                        </div>


                    <div class="row">
                        <div class="col-12 text-right">
                            <asp:Button CssClass="btn btn-primary signup" ID="Button1" runat="server" Text="Login" OnClick="loginButton_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
