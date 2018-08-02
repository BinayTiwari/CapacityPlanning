<%@ Page Title="Resource Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResourceMaster.aspx.cs" Inherits="CapacityPlanning.ResourceMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-10">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>

                <li class="breadcrumb-item active" aria-current="page">Resource Master</li>
            </ol>
        </nav>

        <div class="row">
            <div class="col-md-12">
                <div class="panel-heading">
                    <div class="panel-title">Resource Master </div>

                    <a href="AddEmployee.aspx" style="float: right;" class="btn btn-success btn-md">Add New Employee
                    </a>
                </div>
                <br />
                <br />
                <div class="content-box-large">
                    <asp:GridView ID="gvResource" Width="100%" runat="server" DataKeyNames="EmployeeMasterID" CellPadding="8" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                        CssClass="pager rows header1 mygrdContent" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                        OnRowDeleting="delete"
                        OnRowCancelingEdit="canceledit"
                        OnRowUpdating="update" BackColor="White" BorderColor="#919191" BorderStyle="Inset" EmptyDataText="No records to show" Font-Size="Medium" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Names="Calibri" Font-Overline="False" ForeColor="#003300" GridLines="Horizontal">

                        <AlternatingRowStyle BackColor="#F9F9F9" CssClass="table table-striped" />

                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" Height="40" Width="40" runat="server"
                                        ImageUrl="~/images/user.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EmployeeMasterId" HeaderText="Employee ID" />
                            <asp:BoundField DataField="EmployeetName" HeaderText="Name" />
                            <asp:BoundField DataField="mgrName" HeaderText="Reporting Manager" />
                            <asp:BoundField DataField="BaseLocation" HeaderText="Location" />
                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnView" runat="server" ImageUrl="images/info.png" CommandName="ViewProfile"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClick="View_Resource_Master" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="images/user_edit.png" CommandName="EditButton" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/images/trash.png"
                                        CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this Account?');"
                                        AlternateText="Delete" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" />


                        <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" CssClass="pagination-ys" />


                        <PagerSettings Mode="NumericFirstLast" NextPageImageUrl="~/images/126490.png" PageButtonCount="5" />


                        <PagerStyle HorizontalAlign="Right" />


                        <SelectedRowStyle BorderStyle="Inset" />


                    </asp:GridView>


                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    
                   <asp:GridView ID="GridView2" Width="100%" runat="server" DataKeyNames="EmployeeMasterID" CellPadding="8" 
                        CssClass="pager rows header1 mygrdContent">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" Height="40" Width="40" runat="server"
                                        ImageUrl="~/images/user.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EmployeeMasterId" HeaderText="Employee ID" />
                            <asp:BoundField DataField="EmployeetName" HeaderText="Name" />
                            <asp:BoundField DataField="ReportingManagerID" HeaderText="Reporting Manager" />
                            <asp:BoundField DataField="BaseLocation" HeaderText="Location" />
                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                        </Columns>
                        <FooterStyle BackColor="White" />
                        <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" CssClass="pagination-ys" />
                        <PagerSettings Mode="NumericFirstLast" NextPageImageUrl="~/images/126490.png" PageButtonCount="5" />
                        <PagerStyle HorizontalAlign="Right" />
                       <SelectedRowStyle BorderStyle="Inset" />
                    </asp:GridView>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>

    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>

</asp:Content>
