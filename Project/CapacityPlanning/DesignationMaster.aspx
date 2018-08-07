<%@ Page Title="Designation Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DesignationMaster.aspx.cs" Inherits="CapacityPlanning.DesignationMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Manage Designation</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>

    <div class="row">
        <div class="form-group form-inline col-lg-12">
            <asp:TextBox ID="DesignationNameTextBox" placeholder="Designation Name" CssClass="form-control" runat="server" required></asp:TextBox>

            <asp:Button ID="DesignationAddButton" runat="server" Text="Add Designation" CssClass="btn btn-md btn-success" OnClick="DesignationAddButton_Click" CausesValidation="False" />
        </div>


        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Designation Details
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper">
                        <asp:GridView ID="gvDesignation" runat="server" DataKeyNames="DesignationMasterID" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                            CssClass="table table-striped table-bordered table-hover" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                            OnRowDeleting="delete"
                            OnRowCancelingEdit="canceledit"
                            OnRowUpdating="update" EmptyDataText="No records to show" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="DesignationMasterID" HeaderText="Designation ID" />
                                <asp:BoundField DataField="DesignationName" HeaderText="Designation Name" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ButtonEdit" runat="server" CssClass="center-block" ImageUrl="~/images/22.png" CommandName="Edit" formnovalidate />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/images/yes.png" Width="25px" Height="25px" ID="ButtonUpdate" runat="server" CommandName="Update" formnovalidate />
                                        <asp:ImageButton ImageUrl="~/images/cross-red.png" Width="25px" Height="25px" ID="ButtonCancel" runat="server" Text="Cancel" CommandName="Cancel" formnovalidate />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/trash.png" HeaderText="" />--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="DeleteButton" runat="server" CssClass="center-block" ImageUrl="~/images/11.png"
                                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this Account?');"
                                            AlternateText="Delete" formnovalidate />
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
