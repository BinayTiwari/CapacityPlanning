<%@ Page Title="Allocate Resource" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Allocate_Resource.aspx.cs" Inherits="CapacityPlanning.Allocate_Resource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Resource Allocation</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>
    <div class="row">
        <asp:Button ID="btnBack" Text="&#8617;  Back" runat="server" CssClass="btn btn-primary pull-right" PostBackUrl="ResourceMapping.aspx" />

        <div class="col-lg-12">
            <strong>Account : &nbsp;</strong>
                <asp:Label ID="lblAccount" runat="server" Text=""></asp:Label><br />
              <strong>  Process : &nbsp;  </strong><asp:Label ID="lblProcessName" runat="server" Text=""></asp:Label><br />
            <br />
            <div class="panel panel-default">

                <div class="panel-heading">
                    Allocate Resources for Request ID :
                      <asp:Label ID="lblResourceAllocation" runat="server" Text='<%#Eval("RequestID") %>'></asp:Label>
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper table-responsive">


                        <table class="table table-striped table-bordered table-hover" id="dataTables1">
                            <thead>
                                <tr>
                                    <%--<th>ID</th>
                                    <th>Request Id</th>--%>
                                    <th>Role</th>
                                    <th>Skills</th>
                                    <th>No of Resources</th>
                                    <%--<th>Requested By</th>--%>
                                    <th>Allocated</th>
                                    <th>Start Date</th>
                                    <th>End Date</th>
                                    <th></th>

                                    <th></th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptResourceAllocation" runat="server" OnItemDataBound="rptResourceAllocation_ItemDataBound">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <%--<td><asp:Label ID="lbId" runat="server" Text='<%#Eval("RequestDetailID")%>' /></td>
                                            <td><asp:Label ID="RequestId" runat="server" Text='<%#Eval("RequestId")%>' /></td>--%>
                                            <td>
                                                <asp:Label ID="RoleName" runat="server" Text='<%#Eval("RoleName")%>' /></td>
                                            <td>
                                                <asp:Label ID="SkillsName" runat="server" Text='<%#Eval("Skills")%>' /></td>
                                            <td>
                                                <asp:Label ID="lblNoOfResources" runat="server" Text='<%#Eval("NoOfResources")%>' /></td>
                                            <%--<td><asp:Label ID="Label1" runat="server" Text='<%#Eval("RequestedBy")%>' /></td>--%>
                                            <td>
                                                <asp:Label ID="Allocated" runat="server" Text='<%#Eval("Allocated")%>' /></td>
                                            <td>
                                                <asp:Label ID="StartDate" runat="server" Text='<%#Eval("StartDate", "{0:MMM dd yyyy}")%>' /></td>
                                            <td>
                                                <asp:Label ID="EndDate" runat="server" Text='<%#Eval("EndDate", "{0:MMM dd yyyy}")%>' /></td>
                                            <td class="center"><a href="ViewResourceMapping.aspx?RequestId=<%#Eval("RequestID")%>">
                                                <ul><i class="fa fa-fw" aria-hidden="true" title="View"></i></ul>
                                            </a></td>


                                            <td>
                                                <%-- <asp:Button ID="btnAlign" Class="btn btn-success btn-md" runat="server" Text="Align" SkillsName='<%#Eval("SkillsName") %>' StartDate='<%#Eval("StartDate","{0:d}")%>' EndDate='<%#Eval("EndDate","{0:d}")%>' CommandArgument='<%#Eval("RoleMasterID")%>' OnClick="btnAllocate_Resource_Click" />--%>
                                                <asp:Button ID="btnAlign" CssClass="btn btn-success btn-md" runat="server" Text="Align" CommandArgument='<%#Eval("RequestDetailID")%>' OnClick="btnAllocate_Resource_Click" />
                                            </td>

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

    <div class="row">
        <div class="col-lg-12">

            <div class="panel panel-default">
                <div id="myDIV" style="display: none;" runat="server">
                    <div class="row">


                        <div class="col-lg-12">

                            <div class="panel panel-default">

                                <div class="panel-heading">
                                    Suggestion for Request ID :
                        <asp:Label ID="lblSuggestions" runat="server" Text='<%#Eval("RequestID") %>'></asp:Label>

                                </div>
                                <br />
                                <div class="pull-right">

                                    <b>Start Date:</b>
                                    <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;
                                       <b>End Date:</b>
                                    <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>&nbsp;&nbsp;

                                        <asp:Button ID="btnPreviousWeek" runat="server" CssClass="btn btn-success btn-md" Text="&#8678; Availability in Previous Week" OnClick="btnPreviousWeek_Click" />
                                    &nbsp;
                                       <asp:Button ID="btnNext" runat="server" CssClass="btn btn-success btn-md" Text=" Availability in Next Week &#8680;" OnClick="btnNext_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
              
                                </div>
                                <br />
                                <br />
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <asp:Label ID="lblShowMsg" CssClass="text-center" runat="server"></asp:Label>
                                    <div class="dataTable_wrapper">


                                        <table class="table table-striped table-bordered table-hover" id="dataTables">
                                            <thead>
                                                <tr>
                                                    <th>Name</th>
                                                    <%--<th>Designation</th>--%>
                                                    <th>Account</th>
                                                    <th>Previous/Current Assignment</th>
                                                    <%--<th>Requested by</th>--%>
                                                    <th>Release Date</th>
                                                    <th>Is Released ?</th>
                                                    <th>Utilization</th>
                                                    <th>Align</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptSuggestions" runat="server" OnItemDataBound="rptSuggestions_ItemDataBound">
                                                    <ItemTemplate>
                                                        <tr class="odd gradeX">
                                                            <td><%#DataBinder.Eval(Container,"DataItem.EmployeetName")%> </td>
                                                            <%--<td><%#DataBinder.Eval(Container,"DataItem.Designation")%></td>--%>
                                                            <td><%#DataBinder.Eval(Container,"DataItem.AccountName")%></td>
                                                            <td><%#DataBinder.Eval(Container,"DataItem.ProcessName")%> </td>
                                                            <%--<td><%#DataBinder.Eval(Container,"DataItem.Owner")%></td>--%>
                                                            <td><%#DataBinder.Eval(Container,"DataItem.EndDate","{0:d}")%></td>
                                                            <td><%#DataBinder.Eval(Container,"DataItem.IsReleased")%></td>
                                                            <td><%#string.Concat(Eval("utilization"),"%")%></td>

                                                            <td>
                                                                <asp:CheckBox ID="chkRequired" EmployeeMasterID='<%#Eval("EmployeeMasterID") %>' OnCheckedChanged="chkRequired_CheckedChanged" runat="server" />
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
                                    <div class="pull-right">
                                        <asp:Button ID="btnSave" Style="float: left;" CssClass="btn btn-success btn-md" runat="server" Text="Save Changes" OnClick="btnSave_Click" />
                                    </div>

                                    <div class="pull-left">
                                        <asp:Button ID="UnDO" Style="float: right;" class="btn btn-success btn-md" runat="server" Text="Undo Changes" OnClick="UnDO_Click" />
                                    </div>
                                    <br />
                                    <br />
                                </div>
                            </div>

                            <!-- /.panel-body -->
                        </div>

                        <!-- /.panel -->
                    </div>
                    <!-- /.col-lg-12 -->
                </div>

            </div>
        </div>
    </div>
    <script type="text/javascript">
        function FunctionDisable() {
            var numberOfChecked = $('input:checkbox:checked').length;
            var bc = document.getElementById('MainContent_rptResourceAllocation_Allocated_0').innerText;
            var allocated = parseInt(bc);
            var ab = document.getElementById('MainContent_rptResourceAllocation_lblNoOfResources_0').innerText;
            var NoOfResources = parseInt(ab);
            if (bc === "0")
                allocated = 0;
            NoOfResources = NoOfResources - allocated;
            if (numberOfChecked === NoOfResources) {
                $('input:checkbox').attr('disabled', true);


            }
        }


    </script>
</asp:Content>
