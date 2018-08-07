<%@ Page Title="Country Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CountryMaster.aspx.cs" Inherits="CapacityPlanning.CountryMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Manage Country</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <div class="row">
        <div class="form-group form-inline col-lg-12">
            <asp:DropDownList ID="RegionList" AppendDataBoundItems="true" runat="server" CssClass="form-control"
                DataTextField="RegionName" DataValueField="RegionID" OnSelectedIndexChanged="RegionList_SelectedIndexChanged" AutoPostBack="True" required>
                <asp:ListItem Value="">--Select Region--</asp:ListItem>

            </asp:DropDownList>
            <asp:TextBox ID="CountryNameTextBox" placeholder="Enter Country" CssClass="form-control" runat="server" required></asp:TextBox>

            <asp:Button ID="CountryAddButton" runat="server" Text="Add Country " CssClass="btn btn-md btn-success" OnClick="CountryAddButton_Click" />
        </div>

        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Country Details
                </div>
                <!-- /.panel-heading -->

                <div class="panel-body">
                    <div class="dataTable_wrapper">
                        <asp:GridView ID="gvCountry" Width="100%" runat="server" DataKeyNames="CountryMasterID" CellPadding="8" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                            CssClass="table table-striped table-bordered table-hove" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                            OnRowDeleting="delete"
                            OnRowCancelingEdit="canceledit"
                            OnRowUpdating="update" EmptyDataText="No records to show" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">

                            <Columns>
                                <asp:BoundField ReadOnly="true" DataField="CountryMasterID" HeaderText="Country ID" />
                                <asp:BoundField ReadOnly="true" DataField="CPT_RegionMaster.RegionName" HeaderText="Region Name" />
                                <asp:BoundField DataField="CountryName" HeaderText="Country Name" />


                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ButtonEdit" runat="server" ImageUrl="~/images/user_edit.png" CommandName="Edit" formnovalidate />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/images/yes.png" Width="25px" Height="25px" ID="ButtonUpdate" runat="server" CommandName="Update" formnovalidate />
                                        <asp:ImageButton ImageUrl="~/images/cross-red.png" Width="25px" Height="25px" ID="ButtonCancel" runat="server" Text="Cancel" CommandName="Cancel" formnovalidate />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/trash.png" HeaderText="" />--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/images/trash.png"
                                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this Account?');"
                                            AlternateText="Delete" formnovalidate />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
