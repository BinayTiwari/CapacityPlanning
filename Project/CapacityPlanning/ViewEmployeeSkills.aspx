﻿<%@ Page Title="View Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewEmployeeSkills.aspx.cs" Inherits="CapacityPlanning.ViewEmployeeSkills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">View Employee Skills</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div id="SkillDiv" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Select Skill to See Employee List
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="row form-group">
                            <div class="dataTable_wrapper table-responsive">
                                <div class="row center-block">
                                    <label>&nbsp;&nbsp;RPA Tools:</label>
                                </div>
                                <div class="row center-block">
                                    <br />
                                    <asp:Repeater ID="rptRPA" runat="server">
                                        <ItemTemplate>
                                            <div class="row center-block">
                                                <div class="col-md-5">
                                                    <asp:CheckBox ID="chkRPA" SkillID='<%#Eval("SkillsMasterID") %>' Skillname='<%#Eval("SkillsName") %>'
                                                        runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>

                                                <div class="col-md-2">
                                                    <asp:DropDownList ID="ddlRPARating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">Select Rating</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <br />
                                                <br />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <br />
                                <br />

                                <div class="row center-block">
                                    <label>&nbsp;&nbsp;Programming Languages:</label>
                                </div>
                                <div class="row center-block">
                                    <br />
                                    <asp:Repeater ID="rptLangPrg" runat="server">
                                        <ItemTemplate>
                                            <div class="row center-block">
                                                <div class="col-md-5">
                                                    <asp:CheckBox ID="chkLangPrg" SkillID='<%#Eval("SkillsMasterID") %>' Skillname='<%#Eval("SkillsName") %>'
                                                        runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>

                                                <div class="col-md-2">
                                                    <asp:DropDownList ID="ddlLangPrgRating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">Select Rating</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <br />
                                                <br />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <br />
                                <br />

                                <div class="row center-block">
                                    <label>&nbsp;&nbsp;Microsoft Technologies:</label>
                                </div>
                                <div class="row center-block">
                                    <br />
                                    <asp:Repeater ID="rptMS" runat="server">
                                        <ItemTemplate>
                                            <div class="row center-block">
                                                <div class="col-md-5">
                                                    <asp:CheckBox ID="chkMS" SkillID='<%#Eval("SkillsMasterID") %>' Skillname='<%#Eval("SkillsName") %>'
                                                        runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>

                                                <div class="col-md-2">
                                                    <asp:DropDownList ID="ddlMSRating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">Select Rating</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <br />
                                                <br />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <br />
                                <br />

                                <div class="row center-block">
                                    <label>&nbsp;&nbsp;Framework:</label>
                                </div>
                                <div class="row center-block">
                                    <br />
                                    <asp:Repeater ID="rptFrk" runat="server">
                                        <ItemTemplate>
                                            <div class="row center-block">
                                                <div class="col-md-5">
                                                    <asp:CheckBox ID="chkFrk" SkillID='<%#Eval("SkillsMasterID") %>' Skillname='<%#Eval("SkillsName") %>'
                                                        runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>

                                                <div class="col-md-2">
                                                    <asp:DropDownList ID="ddlFrkRating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">Select Rating</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <br />
                                                <br />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <br />
                                <br />

                                <div class="row center-block">
                                    <label>&nbsp;&nbsp;Databases:</label>
                                </div>
                                <div class="row center-block">
                                    <br />
                                    <asp:Repeater ID="rptDB" runat="server">
                                        <ItemTemplate>
                                            <div class="row center-block">
                                                <div class="col-md-5">
                                                    <asp:CheckBox ID="chkDB" SkillID='<%#Eval("SkillsMasterID") %>' Skillname='<%#Eval("SkillsName") %>'
                                                        runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>

                                                <div class="col-md-2">
                                                    <asp:DropDownList ID="ddlDBRating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">Select Rating</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <br />
                                                <br />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <br />
                                <br />

                                <div class="row center-block">
                                    <label>&nbsp;&nbsp;Other:</label>
                                </div>
                                <div class="row center-block">
                                    <br />
                                    <asp:Repeater ID="rptOther" runat="server">
                                        <ItemTemplate>
                                            <div class="row center-block">
                                                <div class="col-md-5">
                                                    <asp:CheckBox ID="chkOther" SkillID='<%#Eval("SkillsMasterID") %>' Skillname='<%#Eval("SkillsName") %>'
                                                        runat="server" />
                                                    <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                                </div>

                                                <div class="col-md-2">
                                                    <asp:DropDownList ID="ddlOtherRating" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">Select Rating</asp:ListItem>
                                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                                        <asp:ListItem Value="4"> 4 </asp:ListItem>
                                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <br />
                                                <br />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <br />
                                <br />

                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
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
                            <asp:Button ID="btnShow" runat="server" CssClass="btn-success btn btn-default" Text="Show Employees"
                                OnClick="InsertEmpSkills" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="EmployeeDiv" style="display: none;" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label ID="lblSkill" runat="server" Text=""></asp:Label>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="row form-group">
                            <div class="dataTable_wrapper table-responsive">
                                <table class="table table-striped table-bordered table-hover" id="dataTables">
                                    <thead>
                                        <tr>
                                            <th>EmployeeID</th>
                                            <th>Employee Name</th>
                                            <th>Skill</th>
                                            <th>Rating</th>
                                            <th>Cerificate</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptEmployeeList" runat="server" OnItemDataBound="rptEmployeeList_ItemDataBound">
                                            <ItemTemplate>
                                                <tr class="odd gradeX">
                                                    <td><%#Eval("EmployeeMasterID")%></td>
                                                    <td><%#Eval("EmployeetName")%></td>
                                                    <td><%#Eval("SkillsName")%></td>
                                                    <td><%#Eval("Rating")%></td>
                                                    <td>
                                                        <asp:Label ID="lblCerti" runat="server" Text=""></asp:Label>
                                                        
                                                        <asp:Button ID="btnViewCerti" runat="server" Text="View" Visible="false"
                                                            CssClass="btn btn-success" CertiPath='<%#Eval("Certificate")%>' OnClick="btnViewCertificate" />
                                                    </td>
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
    </div>

</asp:Content>

