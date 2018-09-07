<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CapacityPlanning.ChangePassword" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Change Password :: Capacity Planning</title>
    
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="images/1.png" rel="shortcut icon" type="image/x-icon" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
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
                    <p class="login-box-msg"><strong> Change Password </strong></p>
                    <div class="form-group has-feedback">
                        <asp:TextBox ID="txtPass" TextMode="Password" CssClass="form-control" placeholder="New Password" MaxLength="15" runat="server"></asp:TextBox>
                        <span class="fa fa-user form-control-feedback"></span><span><font color="red"></font></span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtPass"
                                    ErrorMessage="Password can't be blank !" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtPass"
                                    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$" ErrorMessage="Password length should be between 8-15 character and should include one 
                                    special, atleast one uppercase, one lowercase character and one number !" />
                    </div>

                    <div class="form-group has-feedback">
                        <asp:TextBox ID="txtConfirm" CssClass="form-control" TextMode="Password" placeholder="Confirm Password" MaxLength="15" runat="server"></asp:TextBox>
                        <span class="fa fa-lock form-control-feedback"></span><span><font color="red"></font></span>
                        
                    </div>
                    
                    <div class="row">
                        <div class="col-12 text-right">
                            <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button CssClass="btn btn-success signup" ID="btnSave" runat="server" Text="Save" OnClick="UpdatePassword" />
                            <asp:Button CssClass="btn btn-danger signup" ID="btnCancel" runat="server" Text="Cancel" OnClick="Cancel" CausesValidation="false" />
                            
                            
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
