<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Skills.aspx.cs" Inherits="CapacityPlanning.Skills" %>

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
    <title>Skill</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row center-block">
            <div class="col-lg-12">
                <h1 class="page-header">Skill Set</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>

        <div id="DvSkill" class="row center-block" style="display: block;" runat="server">

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
                                <label style="color: green"><span style="color: red;">*</span>Please select the skills  on which you have the expertise:</label>
                            </div>
                            <br />

                            <div class="row center-block">
                                <label>RPA Tools:</label>
                            </div>
                            <div class="row center-block">
                                <br />                                
                                    <asp:DataList ID="dtlRPA" runat="server">
                                        <ItemTemplate>                                   
                                                <div class="col-md-7" style="float:left;">
                                                    <asp:CheckBox ID="chkRPA" SkillID='<%#Eval("SkillsMasterID") %>'
                                                        OnCheckedChanged="chkSkill_CheckedChanged" runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>
                                                
                                                <div class="col-md-5" style="float:right;">
                                                    <asp:DropDownList ID="ddlRating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <br />
                                                <br />
                                           
                                        </ItemTemplate>
                                    </asp:DataList>                               
                            </div>
                            <br />
                            <br />

                            <div class="row center-block">
                                <label>Programming Languages:</label>
                            </div>
                            <div class="row center-block">
                                <br />                                
                                    <asp:DataList ID="dtlLangPrg" runat="server" style="float:left;">
                                        <ItemTemplate>                                   
                                                <div class="col-md-7">
                                                    <asp:CheckBox ID="chkRPA" SkillID='<%#Eval("SkillsMasterID") %>'
                                                        OnCheckedChanged="chkSkill_CheckedChanged" runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>
                                                
                                                <div class="col-md-5" style="float:right;">
                                                    <asp:DropDownList ID="ddlRating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <br />
                                                <br />
                                           
                                        </ItemTemplate>
                                    </asp:DataList>                               
                            </div>
                            <br />
                            <br />

                            <div class="row center-block">
                                <label>Microsoft Technologies:</label>
                            </div>
                            <div class="row center-block">
                                <br />                                
                                    <asp:DataList ID="dtlMS" runat="server">
                                        <ItemTemplate>                                   
                                                <div class="col-md-7" style="float:left;">
                                                    <asp:CheckBox ID="chkRPA" SkillID='<%#Eval("SkillsMasterID") %>'
                                                        OnCheckedChanged="chkSkill_CheckedChanged" runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>
                                                
                                                <div class="col-md-5" style="float:right;">
                                                    <asp:DropDownList ID="ddlRating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <br />
                                                <br />
                                           
                                        </ItemTemplate>
                                    </asp:DataList>                               
                            </div>
                            <br />
                            <br />

                            <div class="row center-block">
                                <label>Framework:</label>
                            </div>
                            <div class="row center-block">
                                <br />                                
                                    <asp:DataList ID="dtlFrk" runat="server">
                                        <ItemTemplate>                                   
                                                <div class="col-md-7" style="float:left;">
                                                    <asp:CheckBox ID="chkRPA" SkillID='<%#Eval("SkillsMasterID") %>'
                                                        OnCheckedChanged="chkSkill_CheckedChanged" runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>
                                                
                                                <div class="col-md-5" style="float:right;">
                                                    <asp:DropDownList ID="ddlRating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <br />
                                                <br />
                                           
                                        </ItemTemplate>
                                    </asp:DataList>                               
                            </div>
                            <br />
                            <br />

                            <div class="row center-block">
                                <label>Databases:</label>
                            </div>
                            <div class="row center-block">
                                <br />                                
                                    <asp:DataList ID="dtlDB" runat="server">
                                        <ItemTemplate>                                   
                                                <div class="col-md-7" style="float:left;">
                                                    <asp:CheckBox ID="chkRPA" SkillID='<%#Eval("SkillsMasterID") %>'
                                                        OnCheckedChanged="chkSkill_CheckedChanged" runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>
                                                
                                                <div class="col-md-5" style="float:right;">
                                                    <asp:DropDownList ID="ddlRating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <br />
                                                <br />
                                           
                                        </ItemTemplate>
                                    </asp:DataList>                               
                            </div>
                            <br />
                            <br />

                            <div class="row center-block">
                                <label>Other:</label>
                            </div>
                            <div class="row center-block">
                                <br />                                
                                    <asp:DataList ID="dtlOther" runat="server">
                                        <ItemTemplate>                                   
                                                <div class="col-md-7" style="float:left;">
                                                    <asp:CheckBox ID="chkRPA" SkillID='<%#Eval("SkillsMasterID") %>'
                                                        OnCheckedChanged="chkSkill_CheckedChanged" runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>
                                                
                                                <div class="col-md-5" style="float:right;">
                                                    <asp:DropDownList ID="ddlRating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <br />
                                                <br />
                                           
                                        </ItemTemplate>
                                    </asp:DataList>                               
                            </div>
                            <br />
                            <br />
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <!-- /.table-responsive -->
                        <div class="row ">
                            <div class="col-md-2 pull-right">
                                <asp:Button ID="Submit" runat="server" CssClass="btn btn-success" Text="Submit"
                                    OnClick="UpdateEmpSkills"></asp:Button>
                            </div>

                        </div>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
    </form>
    <div id="myDIV" class="center-block" style="display: none; text-align: center" runat="server">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <h1 style="color: green">Thank You!<br />
            Your Skills has been successfully submitted</h1>
    </div>
</body>
</html>
