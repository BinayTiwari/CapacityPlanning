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
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>

                <li class="breadcrumb-item active" aria-current="page">Allocate Resources</li>
            </ol>
        </nav>

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
                                    <asp:Button ID="btnAlign" Class="btn btn-success btn-md" Style="float: left;" runat="server" Text="Align"  OnClick="btnAllocate_Resource_Click" />
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
                <div id="myDIV" style="display: none;">
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
                                                <asp:CheckBox Text="Align" ID="chkRequired" runat="server" />
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
                            <asp:Button ID="btnSave" Style="float: left;" class="btn btn-success btn-md" runat="server" Text="Save" />
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
