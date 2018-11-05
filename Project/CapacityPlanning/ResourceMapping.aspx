<%@ Page Title="ResourceMapping" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResourceMapping.aspx.cs" Inherits="CapacityPlanning.ResourceMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Resource Allocation</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>
    <div class="row">


        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                   Resource Allocation
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
                                    <th>Opportunity Type</th>
                                    <th>Requested By </th>

                                   
                                    <th></th>
                                      <th></th>


                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptResourceMapping" runat="server" OnItemDataBound="rptResourceMapping_ItemDataBound">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td>
                                                <asp:Label ID="Request" Text='<%#Eval("RequestId")%>' runat="server" /></td>
                                            <td><%#Eval("DateOfCreation", "{0:MMM dd yyyy}")%> </td>
                                            <td><%#string.Concat(Eval("AccountName"),"-", Eval("CityName"))%></td>
                                            <td><%#Eval("ProcessName") %></td>
                                            <td><%#Eval("OpportunityType")%></td>
                                            <td><%#Eval("EmployeetName")%></td>
                                           
                                            <td class="center"><a href="ViewResourceMapping.aspx?RequestId=<%#Eval("RequestId")%>">
                                                <ul><i class="fa fa-fw" aria-hidden="true" title="View"></i></ul></a></td>
                                            <td>
                                               
                                                <asp:Button ID="btnMap" Class="btn btn-success btn-md" runat="server" Text="Map"
                                                    AccountName='<%#string.Concat(Eval("AccountName"),"-", Eval("CityName"))%>' 
                                                    ProcessName='<%#Eval("ProcessName") %>' CommandArgument='<%#Eval("RequestID")%>' OnClick="btnMap_Click" /> </td>
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

    <%--<asp:Button ID="btnSave" Style="float: right;" class="btn btn-success btn-md" runat="server" Text="Save" OnClick="btnSave_Click" />--%>
</asp:Content>
