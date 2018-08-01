<%@ Page Title="City Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CityMaster.aspx.cs" Inherits="CapacityPlanning.CityMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-10">
        <div class="content-box-header panel-heading" style="color: white; background-color: #07838a">
            <div class="panel-title ">City Master</div>
        </div>
        
        <div class="content-box-large">
            <div class="form-group form-inline">
            <asp:DropDownList ID="RegionList" AppendDataBoundItems="true" runat="server" CssClass="form-control"
                DataTextField="RegionName" DataValueField="RegionID" AutoPostBack="True" OnSelectedIndexChanged="RegionList_SelectedIndexChanged1" required>
                <asp:ListItem Value="">--Select Region--</asp:ListItem>

            </asp:DropDownList>
            <asp:DropDownList ID="CountryList" AppendDataBoundItems="true" runat="server" CssClass="form-control" 
                DataTextField="CountryName" DataValueField="CountryID" OnSelectedIndexChanged="CountryList_SelectedIndexChanged" AutoPostBack="True" required >
                <asp:ListItem Value="">--Select Country--</asp:ListItem>

            </asp:DropDownList>
            <asp:TextBox ID="CityNameTextBox" placeholder="Enter City" CssClass="form-control" runat="server"  required AutoPostBack="True"></asp:TextBox>

            <asp:Button ID="CityAddButton" runat="server" Text="Add City " CssClass="btn btn-md btn-success" OnClick="CityAddButton_Click" />
        </div>
            <asp:GridView ID="gvCity" Width="100%" runat="server" DataKeyNames="CityID" CellPadding="8" OnPageIndexChanging="OnPageIndexChanging" PageSize="5"
                CssClass="pager rows header1 mygrdContent" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                OnRowDeleting="delete"
                OnRowCancelingEdit="canceledit"
                OnRowUpdating="update" BackColor="White" BorderColor="#919191" BorderStyle="Inset" EmptyDataText="No records to show" Font-Size="Medium" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Names="Calibri" Font-Overline="False" ForeColor="#003300" GridLines="Horizontal">


                <AlternatingRowStyle BackColor="#F9F9F9" CssClass="table table-striped" />


                <Columns>
                    <asp:BoundField ReadOnly="true" DataField="CityID" HeaderText="City ID" />
                   <asp:BoundField ReadOnly="true" DataField="CPT_RegionMaster.RegionName" HeaderText="Region" />
                    <asp:BoundField ReadOnly="true" DataField="CPT_CountryMaster.CountryName" HeaderText="Country" />
                    <asp:BoundField DataField="CityName" HeaderText="City" />
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


                <FooterStyle BackColor="#DADEE5" />


                <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />


                <PagerSettings Mode="NumericFirstLast" />

                <PagerStyle HorizontalAlign="Right" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
