<%@ Page Title="City Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CityMaster.aspx.cs" Inherits="CapacityPlanning.CityMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Manage City</h1>
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
            <asp:TextBox ID="CityNameTextBox" placeholder="Enter City" CssClass="form-control" runat="server" required AutoPostBack="True"></asp:TextBox>

            <asp:Button ID="CityAddButton" runat="server" Text="Add City " CssClass="btn btn-md btn-success" OnClick="CityAddButton_Click" />
        </div>

        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRegion" runat="server" ControlToValidate="RegionList" ForeColor="Red" Display="Dynamic"
            ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCountry" runat="server" ControlToValidate="CountryList" ForeColor="Red" Display="Dynamic"
            ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>

        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    City Details
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper">
                        <asp:GridView ID="gvCity" Width="100%" runat="server" DataKeyNames="CityID" CellPadding="8" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                            CssClass="table table-striped table-bordered table-hover" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                            OnRowDeleting="delete"
                            OnRowCancelingEdit="canceledit"
                            OnRowUpdating="update" EmptyDataText="No records to show" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">

                            <Columns>
                                <asp:BoundField ReadOnly="true" DataField="CityID" HeaderText="City ID" />
                                <asp:BoundField ReadOnly="true" DataField="CPT_RegionMaster.RegionName" HeaderText="Region" />
                                <asp:BoundField ReadOnly="true" DataField="CPT_CountryMaster.CountryName" HeaderText="Country" />
                                <asp:BoundField DataField="CityName" HeaderText="City" />
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
                                        <asp:ImageButton ID="DeleteButton" runat="server" CssClass="center-block" ImageUrl="~/images/11.png" CausesValidation="false"
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
