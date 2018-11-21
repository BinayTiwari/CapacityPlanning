<%@ Page Title="Manage Menus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageMenus.aspx.cs" Inherits="CapacityPlanning.ManageMenus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Manage Menus</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Manage Menus according to Roles
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="row form-group">
                        <div class="dataTable_wrapper table-responsive">
                            <table class="table table-striped table-bordered table-hover" id="dataTables">
                                <thead>
                                    <tr>
                                        <th>Menu</th>
                                        <th>Account Manager</th>
                                        <th>Administrator</th>
                                        <th>Governance</th>
                                        <th>Head Business Analyst</th>
                                        <th>Head of Delivery</th>
                                        <th>Human Resource</th>
                                        <th>PMO</th>
                                        <th>Project Manager</th>
                                        <th>Requestor</th>
                                        <th>Solution Head</th>                                        
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptMenus" runat="server" OnItemDataBound="rptMenus_ItemDataBound">
                                        <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td><%#Eval("MenuName")%></td>
                                                <td><asp:CheckBox ID="chkAccMgr" MenuID='<%#Eval("MenuID") %>' RoleID="8" runat="server" /></td>
                                                <td><asp:CheckBox ID="ChkAdmin" MenuID='<%#Eval("MenuID") %>' RoleID="4" runat="server" /></td>
                                                <td><asp:CheckBox ID="ChkGovernance" MenuID='<%#Eval("MenuID") %>' RoleID="26" runat="server" /></td>
                                                <td><asp:CheckBox ID="ChkHeadBA" MenuID='<%#Eval("MenuID") %>' RoleID="20" runat="server" /></td>
                                                <td><asp:CheckBox ID="ChkHeadDelivery" MenuID='<%#Eval("MenuID") %>' RoleID="5" runat="server" /></td>
                                                <td><asp:CheckBox ID="ChkHR" MenuID='<%#Eval("MenuID") %>' RoleID="1" runat="server" /></td>
                                                <td><asp:CheckBox ID="ChkPMO" MenuID='<%#Eval("MenuID") %>' RoleID="16" runat="server" /></td>
                                                <td><asp:CheckBox ID="ChkPM" MenuID='<%#Eval("MenuID") %>' RoleID="6" runat="server" /></td>
                                                <td><asp:CheckBox ID="ChkRequestor" MenuID='<%#Eval("MenuID") %>' RoleID="15" runat="server" /></td>
                                                <td><asp:CheckBox ID="ChkSolHead" MenuID='<%#Eval("MenuID") %>' RoleID="25" runat="server" /></td>
                                                
                                            </tr>
                                        </ItemTemplate>

                                    </asp:Repeater>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div class="panel-body">
        <div class="col-md-12 panel-info">
            <div class="row">
                <div class="content-box-large box-with-header">
                    <br />
                    <div class="row pull-right">
                        <asp:Button ID="save" runat="server" CssClass="btn-success btn btn-default" Text="Save" OnClick="InsertMenuMapping"/>                       
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

