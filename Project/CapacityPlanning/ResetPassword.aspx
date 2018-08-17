<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="CapacityPlanning.ResetPassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset Password</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" class="PlaneinnercontainerBio">
                <tr>
                    <td style="width: 394px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 394px">
                        <strong>E-Mail</strong> :&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtAccountRecovery" runat="server" CssClass="Formlong"></asp:TextBox><br />
                        <br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 394px" align="left">
                        <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 394px" align="center">
                        <asp:Button ID="btnAccountRecovery" runat="server" Text="Send Account Recovery"
                            OnClick="btnAccountRecovery_Click" align="center" /><br />
                        <br />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
