<%@ Page Title="Role Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoleMaster.aspx.cs" Inherits="CapacityPlanning.RoleMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Manage Role</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>

    <div class="row">
        <div class="form-group form-inline col-lg-12">
            <asp:TextBox ID="RoleNameTextBox" placeholder="Role" CssClass="form-control" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="RoleAddButton" runat="server" Text="Add Role" CssClass="btn btn-md btn-success" OnClick="RoleAddButton_Click" />
        </div>
        &nbsp;&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidatorRole" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="RoleNameTextBox"
            ValidationExpression="^[A-Za-z][A-Za-z ]+$" ErrorMessage="*Only Alphabets are allowed." />
        &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorRole" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="RoleNameTextBox"
            ErrorMessage="*Only Alphabets are allowed." />

        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Role Details
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper">
                        <asp:GridView ID="gvRole" runat="server" DataKeyNames="RoleMasterID" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                            CssClass="table table-striped table-bordered table-hover" AllowPaging="True" OnRowEditing="edit" ShowFooter="false"
                            AutoGenerateColumns="False" OnRowDeleting="delete" OnRowCancelingEdit="canceledit"
                            OnRowUpdating="update" EmptyDataText="No records to show" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="RoleMasterID" HeaderText="Role ID" />
                                <asp:BoundField DataField="RoleName" ControlStyle-CssClass="form-control" HeaderText="Role" />
                                <asp:TemplateField HeaderText="Show">
                                    <ItemTemplate>
                                        <%#Eval("Show_in_Dropdown")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlShow" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">False</asp:ListItem>
                                            <asp:ListItem Value="1">True</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ButtonEdit" runat="server" CssClass="center-block" ImageUrl="~/images/22.png"
                                            CommandName="Edit" CausesValidation="false" formnovalidate />
                                    </ItemTemplate>
                                    
                                    <EditItemTemplate>
                                        
                                        <asp:ImageButton ImageUrl="~/images/yes.png" Width="25px" Height="25px" ID="ButtonUpdate" runat="server"
                                            CommandName="Update" CausesValidation="false" formnovalidate />
                                        <asp:ImageButton ImageUrl="~/images/cross-red.png" Width="25px" Height="25px" ID="ButtonCancel"
                                            runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" formnovalidate />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/trash.png" HeaderText="" />--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="DeleteButton" runat="server" CssClass="center-block" ImageUrl="~/images/11.png"
                                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this Account?');"
                                            AlternateText="Delete" CausesValidation="false" formnovalidate />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>


                    </div>
                    <!-- /.table-responsive -->

                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
