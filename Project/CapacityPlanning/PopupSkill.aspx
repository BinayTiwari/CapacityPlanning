<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopupSkill.aspx.cs" Inherits="CapacityPlanning.PopupSkill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select Skill</title>
    <link href="Design/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Design/css/metisMenu.min.css" rel="stylesheet" />
    <link href="Design/css/startmin.css" rel="stylesheet" />
    <link href="Design/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script src="Design/js/jquery.min.js"></script>
    <script src="Design/js/bootstrap.min.js"></script>
    <script src="Design/js/metisMenu.min.js"></script>
    <script src="Design/js/startmin.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row center-block">
            <div class="col-lg-12">
                <h1 class="page-header">Skill Priority</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">

                    <div class="panel-heading">
                        All Blocked Resources
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">

                        <div class="dataTable_wrapper table-responsive">


                            <table class="table table-striped table-bordered table-hover" id="dataTables">
                                <thead>
                                    <tr>
                                        <th>Primary Skill</th>
                                        <th></th>
                                        <th>Secondary Skill</th>
                                        <th></th>
                                        <th>Ternary Skill</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptSkillSelect" runat="server">
                                        <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td>
                                                    <asp:Label ID="lblPrimary" runat="server" Text='<%#Eval("SkillName")%>'></asp:Label></td>
                                                <td>
                                                    <asp:CheckBox ID="chkPrimary" skillName='<%#Eval("SkillName")%>' SkillId='<%#Eval("SkillID")%>' runat="server" /></td>
                                                <td>
                                                    <asp:Label ID="lblSecondary" runat="server" Text='<%#Eval("SkillName")%>'></asp:Label></td>
                                                <td>
                                                    <asp:CheckBox ID="chkSecondary" skillName='<%#Eval("SkillName")%>' SkillId='<%#Eval("SkillID")%>' runat="server" /></td>
                                                <td>
                                                    <asp:Label ID="lblTernary" runat="server" Text='<%#Eval("SkillName")%>'></asp:Label></td>
                                                <td>
                                                    <asp:CheckBox ID="chkTernary" skillName='<%#Eval("SkillName")%>' SkillId='<%#Eval("SkillID")%>' runat="server" /></td>


                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <div class="pull-right">
                                <asp:Button ID="btnSubmit" Class="btn btn-success btn-md" runat="server" Text="Submit"
                                    OnClick="btnSubmit_Click" OnClientClick="return confirm('Are you sure?');" />
                            </div>
                        </div>
                        <!-- /.table-responsive -->
                        <br />


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
