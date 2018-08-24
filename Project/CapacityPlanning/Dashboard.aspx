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
                    </div>
                </div>
                <div class="panel-footer">
                    <span class="pull-left">Designation Vs Resources</span>
                    <span class="pull-right">
                        <asp:Button ID="btnClick" CssClass="fa" Text="&#xf0a9;" OnClick="btnClick_Click" runat="server" /></span>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-green">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-table fa-5x"></i>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">Manager Vs Reporter</span>
                        <span class="pull-right">
                            <asp:Button ID="btnClick1" CssClass="fa" Text="&#xf0a9;" OnClick="btnClick1_Click" runat="server" /></span>

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
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">Account Vs Resources</span>
                        <span class="pull-right">
                            <asp:Button ID="btnClick2" CssClass="fa" Text="&#xf0a9;" OnClick="btnClick2_Click" runat="server" /></span>

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
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">Capacity Vs Demand</span>
                        <span class="pull-right">
                            <asp:Button ID="btnClick3" CssClass="fa" Text="&#xf0a9;" OnClick="btnClick3_Click" runat="server" /></span>

                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>

    </div>
    <!-- /.row -->


    <div id="graphBlock" style="display: block;" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header text-center">Graphs and Charts</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Role V/S Capacity
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="flot-chart">
                            <div class="flot-chart-content" id="flot-line-chart">
                                <asp:Chart ID="RoleCap" runat="server" Width="1000px" Height="400px">
                                    <Series>
                                        <asp:Series ToolTip="Value of X:#VALX;   Value of Y:#VALY" Name="Series1" Font="Verdana">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisX LineColor="DarkGray">
                                                <MajorGrid LineColor="LightGray" />
                                            </AxisX>
                                            <AxisY LineColor="DarkGray">
                                                <MajorGrid LineColor="LightGray" />
                                            </AxisY>
                                            <Area3DStyle Enable3D="false" WallWidth="5" LightStyle="Realistic"></Area3DStyle>
                                        </asp:ChartArea>
                                    </ChartAreas>


                                </asp:Chart>
                            </div>
                        </div>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
            <div class="col-lg-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Designation V/S No. of Resources
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="flot-chart">
                            <div class="flot-chart-content" id="flot-pie-chart">

                                <asp:Chart ID="myChart" runat="server" Height="400px" Width="450px">
                                    <Series>
                                        <asp:Series ToolTip="Value of X:#VALX;   Value of Y:#VALY" Name="Series1" Font="Verdana">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisX LineColor="DarkGray">
                                                <MajorGrid LineColor="LightGray" />
                                            </AxisX>
                                            <AxisY LineColor="DarkGray">
                                                <MajorGrid LineColor="LightGray" />
                                            </AxisY>
                                            <Area3DStyle Enable3D="True" WallWidth="5" LightStyle="Realistic"></Area3DStyle>
                                        </asp:ChartArea>
                                    </ChartAreas>

                                    <Legends>
                                        <asp:Legend>
                                        </asp:Legend>
                                    </Legends>
                                </asp:Chart>


                            </div>
                        </div>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-6 -->
            <div class="col-lg-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Reporting Manager V/S No. of Reporters
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="flot-chart">
                            <div class="flot-chart-content" id="flot-line-chart-multi">

                                <asp:Chart ID="MgrVSRpt" runat="server" Height="400px" Width="450px">
                                    <Series>
                                        <asp:Series ToolTip="Value of X:#VALX;   Value of Y:#VALY" Name="Series1" Font="Verdana">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisX LineColor="DarkGray">
                                                <MajorGrid LineColor="LightGray" />
                                            </AxisX>
                                            <AxisY LineColor="DarkGray">
                                                <MajorGrid LineColor="LightGray" />
                                            </AxisY>
                                            <Area3DStyle Enable3D="false" WallWidth="5" LightStyle="Realistic"></Area3DStyle>
                                        </asp:ChartArea>
                                    </ChartAreas>


                                </asp:Chart>

                            </div>
                        </div>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-6 -->
            <div class="col-lg-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Role V/S Demand
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="flot-chart">
                            <div class="flot-chart-content" id="flot-line-chart-moving">


                                <asp:Chart ID="RoleDem" runat="server" Height="400px" Width="450px">
                                    <Series>
                                        <asp:Series ToolTip="Value of X:#VALX;   Value of Y:#VALY" Name="Series1" Font="Verdana">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisX LineColor="DarkGray">
                                                <MajorGrid LineColor="LightGray" />
                                            </AxisX>
                                            <AxisY LineColor="DarkGray">
                                                <MajorGrid LineColor="LightGray" />
                                            </AxisY>
                                            <Area3DStyle Enable3D="false" WallWidth="5" LightStyle="Realistic"></Area3DStyle>
                                        </asp:ChartArea>
                                    </ChartAreas>


                                </asp:Chart>

                            </div>
                        </div>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-6 -->
            <div class="col-lg-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Designation V/S No. of Resources
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="flot-chart">
                            <div class="flot-chart-content" id="flot-bar-chart">
                                <asp:Chart ID="myChartBar" runat="server" Height="400px" Width="400px">
                                    <Series>
                                        <asp:Series ToolTip="Value of X:#VALX;   Value of Y:#VALY" Name="Series1" Font="Verdana">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisX LineColor="DarkGray">
                                                <MajorGrid LineColor="LightGray" />
                                            </AxisX>
                                            <AxisY LineColor="DarkGray">
                                                <MajorGrid LineColor="LightGray" />
                                            </AxisY>
                                            <Area3DStyle Enable3D="false" WallWidth="5" LightStyle="Realistic"></Area3DStyle>
                                        </asp:ChartArea>
                                    </ChartAreas>

                                   
                                </asp:Chart>
                            </div>
                        </div>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-6 -->
           
            <!-- /.col-lg-6 -->
        </div>
        <!-- /.row -->
    </div>
    <div id="DsVsRes" style="display: none;" runat="server">
        <div class="col-lg-12">
                <h1 class="page-header text-center">Designation V/S No. of Resources</h1>
            </div>
        <div class="panel-body" >
            <div class="row">
                <div class="col-md-5">
                    <div class="dataTable_wrapper" style="overflow-y:scroll; height:400px">


                        <table class="table table-striped table-bordered table-hover" id="dataTable111s">
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
                </div>

                <!-- /.table-responsive -->


                <div class="col-md-3">
                    <asp:Chart ID="myChart1" runat="server" Height="400px" Width="600px">
                        <Series>
                            <asp:Series ToolTip="Value of X:#VALX;   Value of Y:#VALY" Name="Series1" Font="Verdana">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX LineColor="DarkGray">
                                    <MajorGrid LineColor="LightGray" />
                                </AxisX>
                                <AxisY LineColor="DarkGray">
                                    <MajorGrid LineColor="LightGray" />
                                </AxisY>
                                <Area3DStyle Enable3D="True" WallWidth="5" LightStyle="Realistic"></Area3DStyle>
                            </asp:ChartArea>
                        </ChartAreas>

                        <Legends>
                            <asp:Legend>
                            </asp:Legend>
                        </Legends>
                    </asp:Chart>
                </div>

            </div>
        </div>


    </div>
    <!-- designation vs resources -->
    <div id="RMVsR" style="display: none;" runat="server">
        <div class="col-lg-12">
                <h1 class="page-header text-center">Reporting Manager V/S No. of Reporters</h1>
            </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <div class="dataTable_wrapper" style="overflow-y:scroll; height:400px">


                        <table class="table table-striped table-bordered table-hover" id="dataTable1s">
                            <thead>
                                <tr>
                                    <th>Sr. No.</th>
                                    <th>Reporting Managers</th>
                                    <th>No. of Reporter</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptRMVsR" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td>
                                                <%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
                                            </td>
                                            <td>
                                                <%#Eval("ReportingManager")%>
                                            </td>
                                            <td>
                                                <%#Eval("NoOfReporter")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>

                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>
                </div>
                <!-- /.table-responsive -->

                <div class="col-md-3">
                    <asp:Chart ID="MgrVSRpt1" runat="server" Height="500px" Width="700px">
                        <Series>
                            <asp:Series ToolTip="Value of X:#VALX;   Value of Y:#VALY" Name="Series1" Font="Verdana">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX LineColor="DarkGray">
                                    <MajorGrid LineColor="LightGray" />
                                </AxisX>
                                <AxisY LineColor="DarkGray">
                                    <MajorGrid LineColor="LightGray" />
                                </AxisY>
                                <Area3DStyle Enable3D="false" WallWidth="5" LightStyle="Realistic"></Area3DStyle>
                            </asp:ChartArea>
                        </ChartAreas>


                    </asp:Chart>
                </div>



            </div>
        </div>
    </div>
    <!-- Reporting managers vs reporters -->
    <div id="AccVsNoR" style="display: none;" runat="server">
        <div class="panel-body">

            <div class="dataTable_wrapper" >


                <table class="table table-striped table-bordered table-hover" id="dataTable2s">
                    <thead>
                        <tr>
                            <th>Sr. No.</th>
                            <th>Account Name</th>
                            <th>Bussiness Analyst</th>
                            <th>SA</th>
                            <th>Technical Consultant</th>
                            <th>Technical Manager</th>
                            <th>QA</th>
                            <th>QA-Technical Manager</th>
                            <th>QA-Tech Lead</th>
                            <th>PM</th>
                            <th>Grand Total</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptAccVsNoR" runat="server">
                            <ItemTemplate>
                                <tr class="odd gradeX">
                                    <td>
                                        <%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
                                    </td>
                                    <td>
                                        <%#Eval("AccountName")%>
                                    </td>
                                    <td>
                                        <%#Eval("NoOfReporter")%>
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
    <!-- Account vs No of resources -->
    <div id="CapVsResDem" style="display: none;" runat="server">
        <div class="col-lg-12">
                <h1 class="page-header text-center">Capacity V/S Demand</h1>
            </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <div class="dataTable_wrapper">


                        <table class="table table-striped table-bordered table-hover" id="dataTable3s">
                            <thead>
                                <tr>
                                    <th>Sr. No.</th>
                                    <th>Role</th>
                                    <th>Demand</th>


                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptCapVsDem" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td>
                                                <%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
                                            </td>
                                            <td>
                                                <%#Eval("role")%>
                                            </td>
                                            <td>
                                                <%#Eval("noOfRes")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>

                                </asp:Repeater>

                            </tbody>
                        </table>
                    </div>
                </div>

                <div class="col-md-3">
                    <asp:Chart ID="RoleDem1" runat="server" Height="500px" Width="700px">
                        <Series>
                            <asp:Series ToolTip="Value of X:#VALX;   Value of Y:#VALY" Name="Series1" Font="Verdana">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX LineColor="DarkGray">
                                    <MajorGrid LineColor="LightGray" />
                                </AxisX>
                                <AxisY LineColor="DarkGray">
                                    <MajorGrid LineColor="LightGray" />
                                </AxisY>
                                <Area3DStyle Enable3D="false" WallWidth="5" LightStyle="Realistic"></Area3DStyle>
                            </asp:ChartArea>
                        </ChartAreas>


                    </asp:Chart>
                </div>

            </div>
            <hr />

            <div class="row">
                <div class="col-md-4">
                    <div class="dataTable_wrapper" style="overflow-y:scroll; height:400px">
                        <table class="table table-striped table-bordered table-hover" id="dataTable4s">
                            <thead>
                                <tr>
                                    <th>Sr. No.</th>
                                    <th>Role</th>
                                    <th>Capacity</th>


                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptCpt" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td>
                                                <%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
                                            </td>
                                            <td>
                                                <%#Eval("Role_Name")%>
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


                </div>
                <!-- graph here -->
                <!-- /.table-responsive -->



                <div class="col-md-3">
                    <asp:Chart ID="RoleCap1" runat="server" Height="500px" Width="700px">
                        <Series>
                            <asp:Series ToolTip="Value of X:#VALX;   Value of Y:#VALY" Name="Series1" Font="Verdana">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX LineColor="DarkGray">
                                    <MajorGrid LineColor="LightGray" />
                                </AxisX>
                                <AxisY LineColor="DarkGray">
                                    <MajorGrid LineColor="LightGray" />
                                </AxisY>
                                <Area3DStyle Enable3D="false" WallWidth="5" LightStyle="Realistic"></Area3DStyle>
                            </asp:ChartArea>
                        </ChartAreas>


                    </asp:Chart>
                </div>
            </div>
        </div>
    </div>
    <!-- Capacity Vs Resource Demand -->
</asp:Content>
