﻿<%@ Page Title="Open Resource Requests" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OpenResourceRequests.aspx.cs" Inherits="CapacityPlanning.OpenResourceRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Open Resource Request </h1>
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
            <div class="dataTable_wrapper table-responsive">

                <table class="table table-striped table-bordered table-hover" id="dataTables">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Request ID</th>
                            <th>Opportunity Type</th>
                            <th>Account Name</th>
                            <th>Process Name</th>
                            <th>Role Name</th>
                            <th>Skill</th>
                            <th>Requested By</th>
                            <th>Start Date</th>
                            <th>End Date</th>
                            <th>No Of Resources</th>
                            <th>Allocated</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptAccountWiseResources" runat="server">
                            <ItemTemplate>
                                <tr class="odd gradeX">
                                    <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%></td>
                                    <td><%#Eval("RequestID")%></td>
                                    <td><%#Eval("OpportunityType")%></td>
                                    <td><%#Eval("AccountName")%></td>
                                    <td><%#Eval("ProcessName") %></td>
                                    <td><%#Eval("RoleName")%></td>
                                    <td><%#Eval("SkillsName")%></td>
                                    <td><%#Eval("RequestedBy")%></td>
                                    <td><%#Eval("StartDate", "{0:MMM dd yyyy}")%></td>
                                    <td><%#Eval("EndDate", "{0:MMM dd yyyy}")%></td>
                                    <td><%#Eval("NoOfResources")%></td>
                                    <td><%#Eval("Allocated")%></td>


                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
