<%@ Page Title="Allocate Resource" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Allocate_Resource.aspx.cs" Inherits="CapacityPlanning.Allocate_Resource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        function ToggleDiv(Flag) {
            if (Flag == "first") {
                document.getElementById('myDIV').style.display = 'block';
                //document.getElementById('dvSecondDiv').style.display = 'none';
            }
            else {
                document.getElementById('myDIV').style.display = 'none';
                //document.getElementById('dvSecondDiv').style.display = 'block';
            }
        }
    </script>
    <div class="col-md-10">

        <div class="row">

            <div class="col-lg-12">
                <h1 class="page-header">Resource Allocation</h1>
            </div>
            <!-- /.col-lg-12 -->

        </div>
        <div class="row">


            <div class="col-lg-12">

                <div class="panel panel-default">

                    <div class="panel-heading">
                        Resource Allocation for Request ID :
                        <asp:Label ID="lblResourceAllocation" runat="server" Text='<%#Eval("RequestID") %>'></asp:Label>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">

                        <div class="dataTable_wrapper">


                            <table class="table table-striped table-bordered table-hover" id="dataTables">
                                <thead>
                                    <tr>
                                        <th>Request Id</th>
                                        <th>Role</th>
                                        <th>Skills</th>
                                        <th>NoOfResources</th>
                                        <th>StartDate</th>
                                        <th>EndDate</th>
                                        <th></th>


                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptResourceAllocation" runat="server" OnItemDataBound="rptResourceAllocation_ItemDataBound">
                                        <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td><%#Eval("RequestId")%></td>
                                                <td><%#Eval("RoleName")%> </td>
                                                <td><%#Eval("SkillsName")%></td>
                                                <td><%#Eval("NoOfResources")%></td>
                                                <td><%#Eval("StartDate","{0:d}")%></td>
                                                <td><%#Eval("EndDate","{0:d}") %></td>
                                                <td>
                                                    <asp:Button ID="btnAlign" Class="btn btn-success btn-md" runat="server" Text="Align" CommandArgument='<%#Eval("RoleName")%>' OnClick="btnAllocate_Resource_Click" /></td>

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
    </div>
    <div id="myDIV" style="display: none;" runat="server">
        <div class="col-md-10">

            <div class="row">

                <div class="col-lg-12">
                    <h1 class="page-header">Suggestion</h1>
                </div>
                <!-- /.col-lg-12 -->

            </div>
            <div class="row">


                <div class="col-lg-12">

                    <div class="panel panel-default">

                        <div class="panel-heading">
                            Suggestion for Request ID :
                        <asp:Label ID="lblSuggestions" runat="server" Text='<%#Eval("RequestID") %>'></asp:Label>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">

                            <div class="dataTable_wrapper">


                                <table class="table table-striped table-bordered table-hover" id="dataTables2">
                                    <thead>
                                        <tr>
                                            <th>Name</th>
                                            <th>Available From</th>
                                            <th>Available Till</th>
                                            <th>Align</th>
                                          


                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptSuggestions" runat="server" OnItemDataBound="rptSuggestions_ItemDataBound">
                                            <ItemTemplate>
                                                <tr class="odd gradeX">
                                                    <td>
                                                        <%#DataBinder.Eval(Container,"DataItem.EmployeetName")%>
                                                    </td>
                                                    <td>
                                                        <%#DataBinder.Eval(Container,"DataItem.StartDate","{0:d}")%>
                                                    </td>
                                                    <td>
                                                        <%#DataBinder.Eval(Container,"DataItem.EndDate","{0:d}")%>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkRequired" Text="Align" EmployeeName='<%#Eval("EmployeetName") %>' EndDate='<%#Eval("EndDate","{0:d}")%>' StartDate='<%#Eval("StartDate","{0:d}")%>' OnCheckedChanged="chkRequired_CheckedChanged" runat="server" />
                                                    </td>

                                                </tr>
                                            </ItemTemplate>

                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>
                            <!-- /.table-responsive -->
                            <br />
                            <br />
                            <asp:Button ID="btnSave" Style="float: left;" class="btn btn-success btn-md" runat="server" Text="Save"  OnClick="btnSave_Click" />
                            <br />
                            <br />
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
        </div>
    </div>
</asp:Content>
