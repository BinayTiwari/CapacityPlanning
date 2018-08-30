<%@ Page Title="Resource Demand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResourceDemand.aspx.cs" Inherits="CapacityPlanning.ResourceDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Resource Demand</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <div class="row">
        <div style="float: right;">
            <asp:Button ID="ResourceDemandAddButton" runat="server" Text="Add Resource Demand" class="btn btn-primary"
                PostBackUrl="AddResourceDemand.aspx" />
        </div>

        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Resource Demand Status
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="dataTable_wrapper">
                        <table class="table table-striped table-bordered table-hover" id="dataTables">
                            <thead>
                                <tr>
                                    <th>Request Id</th>
                                    <th>Request Date </th>
                                    <th>Opportunity Type</th>
                                    <th>Account Name</th>
                                    <th>Process Name</th>
                                    
                                    <th>Sales Stage </th>
                                    <th>Status </th>
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptResourcedemand" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td><%#Eval("RequestId")%></td>
                                            <td><%#Eval("DateOfCreation", "{0:d}")%> </td>
                                            <td><%#Eval("OpportunityType")%></td>
                                            <td><%#string.Concat(Eval("AccountName"),"-", Eval("CityName"))%></td>
                                            <td><%#Eval("ProcessName")%></td>
                                            
                                            <td><%#Eval("SalesStageName")%></td>
                                            <td><%#Eval("StatusName")%></td>
                                            <td class="center"><a href="ViewResourceDemand.aspx?RequestId=<%#Eval("RequestId")%>">
                                                <ul><i class="fa fa-fw" aria-hidden="true" title="View"></i></ul></a></td>
                                            <td class="center"><a href="EditResourceDemand.aspx?RequestId=<%#Eval("RequestId")%>">
                                                <ul><i class="fa fa-fw" aria-hidden="true" title="Edit"></i></ul></a></td>
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
