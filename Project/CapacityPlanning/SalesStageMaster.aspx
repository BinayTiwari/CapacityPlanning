﻿<%@ Page Title="SalesStage Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesStageMaster.aspx.cs" Inherits="CapacityPlanning.SalesStageMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Manage Sales Stage</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>

    <div class="row">
        <div class="form-group form-inline col-lg-12">
            <asp:TextBox ID="SalesStageNameTextBox" placeholder="SalesStage" CssClass="form-control" runat="server" required></asp:TextBox>

            <asp:Button ID="SalesStageAddButton" runat="server" Text="Add SalesStage" CssClass="btn btn-md btn-success" OnClick="SalesStageAddButton_Click" />
        </div>

        <asp:RegularExpressionValidator ID="RegularExpressionValidatorSalesStage" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="SalesStageNameTextBox"
            ValidationExpression="^[A-Za-z][A-Za-z ]+$" ErrorMessage="*Only Alphabets are allowed." />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSalesStage" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="SalesStageNameTextBox" 
    ErrorMessage="*Only Alphabets are allowed." />
        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Sales Stage Details
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper">
                        <asp:GridView ID="gvSalesStage" runat="server" DataKeyNames="SalesStageMasterID" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                            CssClass="table table-striped table-bordered table-hover" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                            OnRowDeleting="delete"
                            OnRowCancelingEdit="canceledit"
                            OnRowUpdating="update" EmptyDataText="No records to show" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="SalesStageMasterID" HeaderText="SalesStage ID" />
                                <asp:BoundField DataField="SalesStageName" HeaderText="SalesStage" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ButtonEdit" runat="server" CssClass="center-block" ImageUrl="~/images/22.png" CausesValidation="false" CommandName="Edit" formnovalidate />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/images/yes.png" Width="25px" Height="25px" ID="ButtonUpdate" runat="server" CommandName="Update" CausesValidation="false" formnovalidate />
                                        <asp:ImageButton ImageUrl="~/images/cross-red.png" Width="25px" Height="25px" ID="ButtonCancel" runat="server" Text="Cancel" CausesValidation="false" CommandName="Cancel" formnovalidate />
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
