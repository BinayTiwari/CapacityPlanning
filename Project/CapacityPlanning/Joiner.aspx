<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Joiner.aspx.cs" Inherits="CapacityPlanning.Joiner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">New Joiners</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>
    
    <div class="row">
        


        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    New Joiner List
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper">


                        <table class="table table-striped table-bordered table-hover" id="dataTables">
                            <thead>
                                <tr>

                                    <th>ID </th>
                                    <th>Name</th>

                                    <th>Designation</th>
                                    <th>Joining Date</th>

                                    <th>Location </th>
                                    <th>Experience (In Years)</th>
                                    <th>Skill</th>
                                    <th>Account</th>

                                   

                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptNewJoiner" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">


                                            <td><%#Eval("NewJoinerID")%> </td>
                                            <td><%#Eval("Name")%> </td>
                                            <td><%#Eval("CPT_DesignationMaster.DesignationName")%></td>
                                            <td><%#Eval("JoiningDate", "{0:d}")%> </td>
                                            <td><%#Eval("Location")%></td>
                                            <td><%#Eval("Experience")%></td>
                                            <td><%#Eval("CPT_SkillsMaster.SkillsName")%></td>
                                            <td><%#Eval("CPT_AccountMaster.AccountName")%></td>

                                           


                                        </tr>
                                    </ItemTemplate>

                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>
                    <!-- /.table-responsive -->

                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
