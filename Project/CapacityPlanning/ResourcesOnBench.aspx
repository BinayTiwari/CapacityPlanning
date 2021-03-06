﻿<%@ Page Title="ResourcesOnBench" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResourcesOnBench.aspx.cs" Inherits="CapacityPlanning.ResourcesOnBench" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Resources On Bench </h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <div class="row">

        <asp:Button ID="backButton" runat="server" CssClass="btn btn-primary pull-right" Text="&#8617; Back" PostBackUrl="~/Dashboard.aspx"></asp:Button>
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Resources On Bench
 
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
                            <th>Employee Name</th>
                            <th>Designation Name</th>
                            <th>Previous/Next Account</th>
                            <th>Previous/Next Project</th>
                            <th>Aligned With</th>
                            <th>Release Date</th>
                            <th>On Bench(days)</th>
                            <th>Status</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptDsVsRes" runat="server">
                            <ItemTemplate>
                                <tr id="trID" runat="server" class="odd gradeX">
                                    <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%></td>
                                    <td><%#Eval("EmployeetName")%></td>
                                    <td><%#Eval("DesignationName")%></td>
                                    <td><%#Eval("AccountName")%></td>
                                    <td><%#Eval("ProcessName")%></td>
                                    <td><%#Eval("ReportingManager")%></td>
                                    <td><%#Eval("EndDate")%></td>
                                    <td><asp:Label ID="lblOnBench" runat="server" Text='<%#string.Concat(Eval("OnBench"))%>'></asp:Label></td>
                                    <td><asp:Label ID="lblStatus" runat="server" Text='<%#Eval("StatusVal")%>'></asp:Label></td>
                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
