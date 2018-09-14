<%@ Page Title="All Tickets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllTickets.aspx.cs" Inherits="CapacityPlanning.AllTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Tickets</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>
    <div class="row">


        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    All Tickets
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper table-responsive">


                        <table class="table table-striped table-bordered table-hover" id="dataTables">
                            <thead>
                                <tr>
                                    <th>Request Id</th>
                                    <th>Request Date </th>
                                    <th>Account Name</th>
                                    <th>Process Name</th>
                                    <th>Requested By</th>
                                    <th>Opportunity Type</th>
                                    <th>Sales Stage </th>
                                    <th>Status </th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptResourceAllTickets" runat="server" >
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td>
                                                <asp:Label ID="Request" Text='<%#Eval("RequestId")%>' runat="server" /></td>
                                            <td><%#Eval("DateOfCreation", "{0:d}")%> </td>
                                            <td><%#string.Concat(Eval("AccountName"),"-", Eval("CityName"))%></td>
                                             <td><%#Eval("ProcessName") %></td>
                                            <td><%#Eval("EmployeetName") %></td>
                                            <td><%#Eval("OpportunityType")%></td>
                                            <td><%#Eval("SalesStageName")%></td>
                                            <td><%#Eval("StatusName")%></td>


                                            <td class="center"><a href="ViewResourceMapping.aspx?RequestId=<%#Eval("RequestId")%>">
                                                <ul><i class="fa fa-fw" aria-hidden="true" title="View"></i></ul>
                                            </a></td>
                                        </tr>
                                    </ItemTemplate>

                                </asp:Repeater>

                            </tbody>
                        </table>
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

</asp:Content>
