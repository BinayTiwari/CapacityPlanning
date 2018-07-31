<%@ Page Title="Account Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountMaster.aspx.cs" Inherits="CapacityPlanning.AccountMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-10">
        <div class="content-box-header panel-heading" style="color: white; background-color: #07838a">
            <div class="panel-title ">Account Master</div>
        </div>



        <div class="content-box-large">
            <div class="form-group form-inline">
                <asp:TextBox ID="AccountNameTextBox" placeholder="Account Name" CssClass="form-control" runat="server" required></asp:TextBox>

                <asp:Button ID="AccountAddButton" runat="server" Text="Add Account" CssClass="btn btn-md btn-success" OnClick="AccountAddButton_Click" CausesValidation="False" />
            </div>
            <asp:GridView ID="gvAccount" Width="100%" runat="server" DataKeyNames="AccountMasterID" CellPadding="8" OnPageIndexChanging="OnPageIndexChanging" PageSize="5"
                CssClass="pager rows header1 mygrdContent" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                OnRowDeleting="delete"
                OnRowCancelingEdit="canceledit"
                OnRowUpdating="update" BackColor="White" BorderColor="#919191" BorderStyle="Inset" EmptyDataText="No records to show" Font-Size="Medium" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Names="Calibri" Font-Overline="False" ForeColor="#003300" GridLines="Horizontal">


                <AlternatingRowStyle BackColor="#F9F9F9" CssClass="table table-striped" />


                <Columns>
                    <asp:BoundField ReadOnly="True" DataField="AccountMasterID" HeaderText="Account ID" />
                    <asp:BoundField DataField="AccountName" HeaderText="Account Name" />

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


                <FooterStyle BackColor="White" />


                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />


                <PagerSettings Mode="NumericFirstLast" NextPageImageUrl="~/images/126490.png" PageButtonCount="5" />


                <SelectedRowStyle BorderStyle="Inset" />

                <PagerStyle HorizontalAlign="Right" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
