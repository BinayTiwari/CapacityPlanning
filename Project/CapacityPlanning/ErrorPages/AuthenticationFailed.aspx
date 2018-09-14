<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthenticationFailed.aspx.cs" Inherits="CapacityPlanning.ErrorPages.AuthenticationFailed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Design/css/bootstrap.min.css" rel="stylesheet" />
    <title>Authentication Failed</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div class="col-md-12">
                    <div class="text-center">
                    <asp:HyperLink runat="server" CssClass="center-block" NavigateUrl="~/Dashboard.aspx" Text=""><h3 >Back to Dashboard</h3></asp:HyperLink>
                    </div>
                    <img class="center-block" style="margin-top: 80px" src="../images/authfail.jpg" />
                </div>

            </div>

        </div>
    </form>
</body>
</html>
