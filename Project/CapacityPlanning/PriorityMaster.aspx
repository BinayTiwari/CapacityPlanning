﻿<%@ Page Title="Priority Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PriorityMaster.aspx.cs" Inherits="CapacityPlanning.PriorityMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Manage Priority</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>

    <div class="row">
        <div class="form-group form-inline col-lg-12">
            <asp:TextBox ID="PriorityNameTextBox" placeholder="Priority" CssClass="form-control" runat="server" required></asp:TextBox>

            <asp:Button ID="PriorityAddButton" runat="server" Text="Add Priority" CssClass="btn btn-md btn-success" OnClick="PriorityAddButton_Click" />
        </div>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPriority" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="PriorityNameTextBox"
            ValidationExpression="^[A-Za-z][A-Za-z ]+$" ErrorMessage="*Only Alphabets are allowed." />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPriority" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="PriorityNameTextBox" 
    ErrorMessage="*Only Alphabets are allowed." />

        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Priority Details
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper">
                        <asp:GridView ID="gvPriority" runat="server" DataKeyNames="PriorityID" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                            CssClass="table table-striped table-bordered table-hover" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                            OnRowDeleting="delete"
                            OnRowCancelingEdit="canceledit"
                            OnRowUpdating="update" EmptyDataText="No records to show" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="PriorityID" HeaderText="Priority ID" />
                                <asp:BoundField DataField="PriorityName" HeaderText="Priority" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ButtonEdit" CausesValidation="false" runat="server" CssClass="center-block" ImageUrl="~/images/22.png" CommandName="Edit" formnovalidate />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/images/yes.png" CausesValidation="false" Width="25px" Height="25px" ID="ButtonUpdate" runat="server" CommandName="Update" formnovalidate />
                                        <asp:ImageButton ImageUrl="~/images/cross-red.png" CausesValidation="false" Width="25px" Height="25px" ID="ButtonCancel" runat="server" Text="Cancel" CommandName="Cancel" formnovalidate />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/trash.png" HeaderText="" />--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="DeleteButton" CssClass="center-block" runat="server" ImageUrl="~/images/11.png"
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
