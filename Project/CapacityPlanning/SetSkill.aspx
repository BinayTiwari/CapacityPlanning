<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetSkill.aspx.cs" Inherits="CapacityPlanning.SetSkill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Design/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Design/css/metisMenu.min.css" rel="stylesheet" />
    <link href="Design/css/startmin.css" rel="stylesheet" />
    <link href="Design/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script src="Design/js/jquery.min.js"></script>
    <script src="Design/js/bootstrap.min.js"></script>
    <script src="Design/js/metisMenu.min.js"></script>
    <script src="Design/js/startmin.js"></script>
    <title>SetSkill</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row center-block">
            <div class="col-lg-12">
                <h1 class="page-header">Skill Set</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>

        <div class="row center-block">

            <div class="col-lg-12">
                <div class="panel panel-default">

                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <label>Please enter your Employee ID<span style="color: red;"> *</span></label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="EmpID" runat="server" MaxLength="6" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorfirstNameTextBox" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="EmpID"
                                ValidationExpression="^[0-9]{5,6}$" ErrorMessage="Invalid Employee ID !" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="EmpID"
                                ErrorMessage="Employee ID Required !" />
                            <asp:Label ID="lblEmpID" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                        </div>
                        <br />
                        <br />
                        <div class="row center-block">
                            
                            <div class="row center-block">
                                <label style="color:green"><span style="color: red;">*</span>Please select the skills  on which you have the expertise:</label>
                            </div>
                            <div class="row center-block">
                                <br />
                                <div class="col-md-12">
                                    <asp:DataList ID="dtlSkills" runat="server" RepeatColumns="3" RepeatDirection="horizontal">
                                        <ItemTemplate>
                                            <div class="col-lg-12">
                                                <asp:CheckBox ID="chkSkill" SkillID='<%#Eval("SkillsMasterID") %>'
                                                    OnCheckedChanged="chkSkill_CheckedChanged" runat="server" />

                                                <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                            </div>
                                        </ItemTemplate>

                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <!-- /.table-responsive -->
                        <div class="row ">
                            <div class="col-md-2 pull-right">
                                <asp:Button ID="Submit" runat="server" CssClass="btn btn-success" Text="Submit"
                                     OnClick="UpdateEmpSkills" ></asp:Button>
                            </div>
                            <%--<div class="col-md-2 pull-right">
                                <asp:Button ID="Cancel" runat="server" CssClass="btn btn-danger" Text="Cancel" PostBackUrl="~/Login.aspx"
                                    CausesValidation="false"></asp:Button>
                            </div>--%>
                        </div>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
    </form>
</body>
</html>
