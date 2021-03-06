﻿<%@ Page Title="Deploy Resources" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeployResources.aspx.cs" Inherits="CapacityPlanning.DeployResources" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Deploy Resources</h1>
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
                                    <th>Sr. No.</th>                                    
                                    <th>Resource Name</th>
                                    <th>Account Name</th>
                                    <th>Process Name</th>
                                    <th>Requested BY</th>
                                     <th>Start Date </th>
                                    <th>End Date </th>                                
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptDeployResources" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%></td>                                            
                                            <td><%#Eval("EmployeetName")%></td>
                                            <td><%#string.Concat(Eval("AccountName"))%></td>
                                            <td><%#Eval("ProcessName") %></td>
                                            <td><%#Eval("Requested_By") %></td>
                                            <td><%#Eval("StartDate", "{0:d}")%> </td>
                                            <td><%#Eval("EndDate", "{0:d}")%> </td>
                                            
                                                                                      
                                            <td class="center"><a href="ViewResourceMapping.aspx?RequestId=<%#Eval("RequestId")%>">
                                                <ul><i class="fa fa-fw" aria-hidden="true" title="View"></i></ul>
                                            </a></td>
                                            <td class="center">
                                                <asp:Button ID="btnDeploy" Class="btn btn-success btn-md" runat="server" Text="Deploy"
                                                    AllocationID='<%#Eval("AllocationID")%>' CommandArgument='<%#Eval("EmployeeMasterID")%>'
                                                    acName ='<%#Eval("AccountName")%>' prName='<%#Eval("ProcessName")%>' RequesterEmail='<%#Eval("RequesterEmail")%>'
                                                    StartDate ='<%#Eval("StartDate","{0:d}") %>' EndDate ='<%#Eval("EndDate","{0:d}") %>'
                                                    OnClick="DeployResource" OnClientClick="return confirm('Do you want to deploy this Employee?');"/>
                                            </td>
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
