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
                        <h1 class="page-header"> Resource Allocation</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                     
                </div>
         <div class="row">
                
                       
                    <div class="col-lg-12">
                      
                        <div class="panel panel-default">
                                        
                            <div class="panel-heading">
                               Resource Allocation for Request ID : <asp:Label ID="lblResourceAllocation" runat="server" Text=""></asp:Label>
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
                                                <th> </th>
                                                
                                              
                                            </tr>
                                        </thead>
                                        <tbody>
                                             <asp:Repeater ID="rptResourceAllocation" runat="server">
                                <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td><%#Eval("RequestId")%></td>
                                                <td><%#Eval("RoleName")%> </td>
                                                <td><%#Eval("NoOfResources")%></td>
                                                <td><%#Eval("Skill")%></td>
                                                <td><%#Eval("StartDate")%></td>
                                                <td><asp:Button ID="btnAlign" Class="btn btn-success btn-md"  runat="server" Text="Align"  /></td>
                                                                                           
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
            <div class="col-md-12">
                <div class="content-box-header panel-heading" style="color: white; background-color: #07838a">
                    <div class="panel-title ">Priortize/ Allocate Resource</div>


                </div>

                <div class="content-box-large">
                    <asp:GridView ID="gdvAllocateResources" Width="100%" runat="server" OnPageIndexChanging="OnPageIndexChanging"
                        CssClass="pager rows header1 mygrdContent" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="White" EmptyDataText="N/A" Font-Size="Medium" OnSelectedIndexChanged="gdvAllocateResources_SelectedIndexChanged" Font-Names="Calibri" Font-Overline="False" ForeColor="#003300" GridLines="Horizontal" OnRowDataBound="gdvAllocateResources_RowDataBound">

                        <AlternatingRowStyle BackColor="#F9F9F9" CssClass="table table-striped" />

                        <Columns>

                            <asp:BoundField DataField="RoleName" ReadOnly="true" HeaderText="Resource Type" />
                            <asp:BoundField DataField="NoOfResources" HeaderText="Resources" />
                            <asp:BoundField DataField="SkillsName" HeaderText="Skills" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="EndDate" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="StatusName" HeaderText="Status" />
                            <asp:BoundField DataField="PriorityName" HeaderText="Priority" />
                            <%--<asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-md" HeaderText="Align" ShowHeader="True" Text="Align" />--%>
                            <%--OnClientClick="ToggleDiv('first');return false;"--%>
                            <asp:TemplateField HeaderText="Align">
                                <ItemTemplate>
                                     <%--<asp:ImageButton ID="btnView" runat="server" ImageUrl="images/info.png" CommandName="AlignRes"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClick="View_Resource_Master" />--%>
                                    <asp:Button ID="btnAlign" Class="btn btn-success btn-md" Style="float: left;" runat="server" Text="Align" CommandArgument='<%#Eval("RoleName")%>'  OnClick="btnAllocate_Resource_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--CommandArgument='<%#Eval("RequestID")%>'--%>
                        </Columns>

                        <FooterStyle BackColor="White" />

                        <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />

                        <PagerSettings Mode="NumericFirstLast" NextPageImageUrl="~/images/126490.png" PageButtonCount="5" />

                        <RowStyle Font-Names="Calibri" />

                        <SelectedRowStyle BorderStyle="Inset" />

                    </asp:GridView>


                </div>
                <div id="myDIV" style="display: none;" runat="server">
                    <div class="row">

                        <div class="panel-heading">
                            <div class="content-box-header panel-heading" style="color: white; background-color: #07838a">
                                <div class="panel-title ">Suggestions</div>


                            </div>
                            <div class="content-box-large">
                                <table class="table table-striped">
                                    <asp:Repeater ID="Repeat" runat="server">

                                        <HeaderTemplate>

                                            <tr>

                                                <th>Name
                                                </th>
                                                <th>Available From
                                                </th>
                                                <th>Available Till
                                                </th>
                                                <th>Align
                                                </th>

                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
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
                                                <asp:CheckBox ID="chkRequired" Text="Align"  OnCheckedChanged="btnSave_Click" runat="server" />
                                            </td>

                                        </ItemTemplate>
                                        <SeparatorTemplate>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                        </SeparatorTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                            <br />
                            <br />
                            <asp:Button ID="btnSave" Style="float: left;" class="btn btn-success btn-md" runat="server" Text="Save"  OnClick="btnSave_Click" />
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
