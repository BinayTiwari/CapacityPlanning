<%@ Page Title="Resources On Projects" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TotalStrengths.aspx.cs" Inherits="CapacityPlanning.TotalStrengths" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Resources On Projects </h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <div class="row">

        <asp:Button ID="backButton" runat="server" CssClass="btn btn-primary pull-right" Text="&#8617; Back" PostBackUrl="~/Dashboard.aspx"></asp:Button>
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Resources On Projects
 
                </div>
                <!-- /.panel-heading -->

            </div>
        </div>
        <div class="col-lg-12">
            <div class="dataTable_wrapper">


                <table class="table table-striped table-bordered table-hover" id="dataTables">
                    <thead>
                        <tr>
                            <th>Sr. No.</th>
                            <th>Employee ID</th>
                            <th>Employee Name</th>
                            <th>Designation</th>
                            <th>Account Name</th>
                            <th>Process</th>
                            <th>Start Date</th>
                            <th>End Date</th>



                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptDsVsRes" runat="server">
                            <ItemTemplate>
                                <tr class="odd gradeX">
                                    <td>
                                        <%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
                                    </td>
                                    <td>
                                        <%#Eval("EmployeeMasterID")%>
                                    </td>
                                    <td>
                                        <%#Eval("EmployeetName")%>
                                    </td>
                                    <td><%#Eval("DesignationName")%></td>
                                    <td><%#Eval("AccountName")%></td>
                                    <td><%#Eval("ProcessName")%></td>
                                    <td><%#Eval("StartDate")%></td>
                                    <td><%#Eval("EndDate")%></td>


                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
