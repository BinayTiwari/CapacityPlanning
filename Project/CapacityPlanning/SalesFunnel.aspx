<%@ Page Title="Sales Funnel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesFunnel.aspx.cs" Inherits="CapacityPlanning.SalesFunnel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Sales Funnel</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>
    <div class="row">


        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    100 K =
                    <asp:Label ID="lblManDays" runat="server"></asp:Label>
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div id="myDIV" style="display: block;" runat="server">
                        <div class="dataTable_wrapper table-responsive">


                            <table class="table table-striped table-bordered table-hover" id="dataTables1">
                                <thead>
                                    <tr>
                                        <th>Role</th>
                                        <th>Requirement</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptSells" runat="server">
                                        <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td><%# Container.DataItem.ToString() %></td>
                                                <td>
                                                    <asp:TextBox ID="txtRequired" runat="server" required></asp:TextBox></td>
                                            </tr>
                                        </ItemTemplate>

                                    </asp:Repeater>

                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div id="Div" style="display: none;" runat="server">
                        <div class="dataTable_wrapper table-responsive">


                            <table class="table table-striped table-bordered table-hover" id="dataTables12">
                                <thead>
                                    <tr>
                                        <th>Role</th>
                                        <th>Parts</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RptShow" runat="server">
                                        <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td><%#Eval("RoleName")%></td>
                                                <td>
                                                    <asp:Label ID="lbl" runat="server" Text='<%#Eval("Percentage")%>'></asp:Label></td>
                                            </tr>
                                        </ItemTemplate>

                                    </asp:Repeater>

                                </tbody>
                            </table>
                        </div>
                    </div>
                    <!-- /.table-responsive -->
                    <br />
                    <div class="form-group">
                        <asp:Button ID="btnCalculate" Style="float: right;" class="btn btn-success btn-md" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
                    </div>

                </div>
                <!-- /.panel-body -->
            </div>


            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
