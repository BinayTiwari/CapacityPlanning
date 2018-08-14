<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CapacityPlanning.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Dashboard</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-bar-chart fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <%--<div class="huge">26</div>
                                        <div>New Comments!</div>--%>
                        </div>
                    </div>
                </div>
                <%--<a href="#">--%>
                    <div class="panel-footer" onclick="abcd">
                        <span class="pull-left">Designation Vs No. Of Resources</span>
                        <span class="pull-right"><asp:Button ID="btnClick" CssClass="fa" Text="&#xf0a9;" OnClick="btnClick_Click" runat="server" />
                            <%--<i class="fa fa-arrow-circle-right"></i>--%></span>

                        <div class="clearfix"></div>
                    </div>
            <%--    </a>--%>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-green">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-table fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <%--<div class="huge">12</div>--%>
                            <%--<div>Designation Vs No. Of Resources</div>--%>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">Reporting Manager Vs Reporter</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>

                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-yellow">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-th-list fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <%--<div class="huge">124</div>
                                        <div>New Orders!</div>--%>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">Account V/S No. of Resources</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>

                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-red">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-book fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <%--<div class="huge">13</div>
                                        <div>Support Tickets!</div>--%>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">Capacity V/S Resource Demand</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>

                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>
    </div>
    <!-- /.row -->
    <div id="DsVsRes" style="display: none;" runat="server">
        <div class="panel-body">

            <div class="dataTable_wrapper">


                <table class="table table-striped table-bordered table-hover" id="dataTables2">
                    <thead>
                        <tr>
                            <th>Sr. No.</th>
                            <th>Designation</th>
                            <th>No. of Resources</th>
                            
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
                                        <%#Eval("Designation_Name")%>
                                    </td>
                                    <td>
                                         <%#Eval("NoOfResources")%>
                                    </td>
                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
            <!-- /.table-responsive -->
        </div>

    </div>

</asp:Content>
