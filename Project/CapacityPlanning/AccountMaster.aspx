<%@ Page Title="Account Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountMaster.aspx.cs" Inherits="CapacityPlanning.AccountMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Manage Account</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>

    <div class="row">
        <div class="form-group form-inline col-lg-12">
            <asp:DropDownList ID="RegionList" AppendDataBoundItems="true" runat="server" CssClass="form-control"
                AutoPostBack="True" OnSelectedIndexChanged="RegionList_SelectedIndexChanged1">
            </asp:DropDownList>

            <asp:DropDownList ID="CountryList" AppendDataBoundItems="true" runat="server" CssClass="form-control"
                OnSelectedIndexChanged="CountryList_SelectedIndexChanged" AutoPostBack="True" >
            </asp:DropDownList>

            <asp:DropDownList ID="CityList" AppendDataBoundItems="true" runat="server" CssClass="form-control" AutoPostBack="true"
                OnSelectedIndexChanged="CityList_SelectedIndexChanged">
            </asp:DropDownList>


            <asp:TextBox ID="AccountNameTextBox" placeholder="Account Name" CssClass="form-control" runat="server" required></asp:TextBox>
            <asp:Button ID="AccountAddButton" runat="server" Text="Add Account" CssClass="btn btn-md btn-success" OnClick="AccountAddButton_Click" />

        </div>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidatorAccount" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="AccountNameTextBox"
            ValidationExpression="^[A-Za-z][A-Za-z ]+$" ErrorMessage="*Only Alphabets are allowed." />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="AccountNameTextBox" 
    ErrorMessage="*Only Alphabets are allowed." />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server" ControlToValidate="CityList" ForeColor="Red" Display="Dynamic"
            ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>

        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Account Details
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper">
                        <asp:GridView ID="gvAccount" runat="server" DataKeyNames="AccountMasterID" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                            CssClass="table table-striped table-bordered table-hover" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                            OnRowDeleting="delete"
                            OnRowCancelingEdit="canceledit"
                            OnRowUpdating="update" EmptyDataText="No records to show" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="AccountMasterID" HeaderText="Account ID" />
                                <asp:BoundField ReadOnly="true" DataField="CPT_CityMaster.CityName" HeaderText="City Name" />
                                <asp:BoundField DataField="AccountName" HeaderText="Account Name" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ButtonEdit" runat="server" CssClass="center-block" ImageUrl="~/images/22.png" CommandName="Edit" CausesValidation="false" formnovalidate />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/images/yes.png" Width="25px" Height="25px" ID="ButtonUpdate" runat="server" CommandName="Update" CausesValidation="false" formnovalidate />
                                        <asp:ImageButton ImageUrl="~/images/cross-red.png" Width="25px" Height="25px" ID="ButtonCancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" formnovalidate />
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


                            <PagerSettings Mode="NumericFirstLast" NextPageImageUrl="~/images/126490.png" PageButtonCount="5" />

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
