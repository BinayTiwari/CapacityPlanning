﻿<%@ Page Title="ViewResourceDemand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewResourceDemand.aspx.cs" Inherits="CapacityPlanning.ViewResourceDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Resource Demand </h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <div class="row">
        <asp:Button ID="btnBack" Text="&#8617; Back" runat="server" CssClass="btn btn-primary pull-right"
            OnClientClick="JavaScript:window.history.back(1);return false;" />
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Resource Demand Detail 
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Request ID</label>
                                <asp:Label ID="reqID" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-lg-6">
                                <label>Process Name</label>
                                <asp:Label ID="proccName" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Opportunity Type</label>

                                <asp:DropDownList ID="oppTypeDD" CssClass="form-control" runat="server" Enabled="false"></asp:DropDownList>
                            </div>


                            <div class="col-lg-6">
                                <label>Region Name</label>
                                <asp:DropDownList ID="regionNameDD" CssClass="form-control" runat="server" Enabled="false"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Account Name</label>

                                <asp:DropDownList ID="accNameDD" CssClass="form-control" runat="server" Enabled="false"></asp:DropDownList>
                            </div>

                            <div class="col-lg-6">
                                <label>Sales Stage</label>

                                <asp:DropDownList ID="salesStageDD" CssClass="form-control" runat="server" Enabled="false"></asp:DropDownList>
                            </div>
                        </div>

                       
                    </div>

                    <div class="form-group">
                         <div class="row">
                            <div class="col-lg-6">
                                <label>Status</label>
                                <asp:DropDownList ID="StatusMasterID" AppendDataBoundItems="true" Enabled="false" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <!-- /.col-lg-6 (nested) -->
                </div>
            </div>
        </div>
    </div>


    <table class="table table-striped table-bordered table-hover" id="dataTables1">
        <thead>
            <tr>
                <th>Resource Type</th>
                <th>No of Resources </th>
                <th>Skills</th>
                <th>Start Date</th>
                <th>End Date</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptResourceDetails" runat="server">
                <ItemTemplate>
                    <tr class="odd gradeX">
                        <td><%#Eval("RoleName")%></td>
                        <td><%#Eval("NoOfResources")%> </td>
                        <td><%#Eval("SkillsName")%></td>
                        <td><%#Eval("StartDate", "{0:d}") %></td>
                        <td><%#Eval("EndDate", "{0:d}")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
