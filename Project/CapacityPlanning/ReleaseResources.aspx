<%@ Page Title="Release Resources" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReleaseResources.aspx.cs" Inherits="CapacityPlanning.ReleaseResources" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Release Resources</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>

    <div class="row">



        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper table-responsive">


                        <table class="table table-striped table-bordered table-hover" id="dataTables">
                            <thead>
                                <tr>

                                    <th>ID</th>
                                    <th>Name</th>
                                    <th>Account</th>
                                    <th>Process</th>
                                    <th>Start Date </th>
                                    <th>End Date</th>
                                    <th>Release</th>


                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptResourceRelease" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">

                                            <td><%#Eval("EmployeeMasterID")%> </td>
                                            <td><%#Eval("EmployeetName")%> </td>
                                            <td><%#Eval("AccountName")%></td>
                                            <td><%#Eval("ProcessName")%></td>
                                            <td><%#Eval("StartDate", "{0:MMM dd yyyy}")%></td>
                                            <td><%#Eval("EndDate", "{0:MMM dd yyyy}")%></td>

                                            <td class="center-block">

                                                <ul>
                                                    <asp:LinkButton ID="releaseButton" OnClientClick="return confirm('Do you want to Release this Employee?');"
                                                        OnClick="releaseButton_Click" acName ='<%#Eval("AccountName")%>' prName='<%#Eval("ProcessName")%>'
                                                        AlocationID ='<%#Eval("AllocationID") %>' runat="server"><i class="fa fa-sign-in" aria-hidden="true" title="Release"></i></asp:LinkButton>

                                                </ul>
                                            </td>




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
