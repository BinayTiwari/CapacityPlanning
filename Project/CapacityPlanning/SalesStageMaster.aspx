<%@ Page Title="Sales Stage Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesStageMaster.aspx.cs" Inherits="CapacityPlanning.SalesStageMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-10">
        <div class="content-box-header panel-heading" style="color: white; background-color: #07838a">
            <div class="panel-title ">Sales Stage Master</div>
        </div>

        <div class="content-box-large">
            <div class="form-group form-inline">
                <asp:TextBox ID="SalesStageNameTextBox" placeholder="SalesStage" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Button ID="SalesStageAddButton" runat="server" Text="Add SalesStage " CssClass="btn btn-md btn-success" OnClick="SalesStageAddButton_Click" />
            </div>
            <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="SalesStageMasterID" CellPadding="8" OnPageIndexChanging="OnPageIndexChanging" PageSize="5"
                CssClass="pager rows header1 mygrdContent" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                OnRowDeleting="delete"
                OnRowCancelingEdit="canceledit"
                OnRowUpdating="update" BackColor="White" BorderColor="#919191" BorderStyle="Inset" EmptyDataText="No records to show" Font-Size="Medium" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Names="Calibri" Font-Overline="False" ForeColor="#003300" GridLines="Horizontal">
                <AlternatingRowStyle BackColor="#F9F9F9" CssClass="table table-striped" />

                <Columns>
                    <asp:BoundField DataField="SalesStageMasterID" ReadOnly="true" HeaderText="SalesStage ID" />
                    <asp:BoundField DataField="SalesStageName" HeaderText="SalesStage" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ButtonEdit" runat="server" ImageUrl="~/images/user_edit.png" CommandName="Edit" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/images/yes.png" Width="25px" Height="25px" ID="ButtonUpdate" runat="server" CommandName="Update" />
                            <asp:ImageButton ImageUrl="~/images/cross-red.png" Width="25px" Height="25px" ID="ButtonCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/trash.png" HeaderText="" />--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/images/trash.png"
                                CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this Account?');"
                                AlternateText="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <FooterStyle BackColor="#DADEE5" />
                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />
                <PagerSettings Mode="NumericFirstLast" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
