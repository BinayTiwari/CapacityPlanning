<%@ Page Title="New Joiners" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewJoiners.aspx.cs" Inherits="CapacityPlanning.NewJoiners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>

            <li class="breadcrumb-item active" aria-current="page">New Joiners</li>
        </ol>
    </nav>
    <div class="col-md-10">
        <div class="row">
            <div class="col-md-12">
                <div class="content-box-large">
                    <div class="panel-heading">
                        <div class="panel-title">New Joiners </div>
                        <a href="AddNewJoiner.aspx" style="float: right;" class="btn btn-success btn-md">Add New Joiner</a>
                    </div>
                    <br />
                    <br />
                    <div class="content-box-large">
                        <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="NewJoinerID" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                            CssClass="pager rows header1 mygrdContent" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand"
                            OnRowDeleting="delete"
                            OnRowCancelingEdit="canceledit"
                            OnRowUpdating="update" BackColor="White" BorderColor="White" EmptyDataText="N/A" Font-Size="Medium" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Names="Calibri" Font-Overline="False" ForeColor="#003300" GridLines="Horizontal">
                            <AlternatingRowStyle BackColor="#F9F9F9" CssClass="table table-striped" />
                            <Columns>
                                <asp:BoundField DataField="NewJoinerID" HeaderText="ID" />
                                <asp:BoundField DataField="FirstName" HeaderText="Name" />
                                <asp:BoundField DataField="DesignationName" HeaderText="Designation" />
                                <asp:BoundField DataField="JoiningDate" HeaderText="Date of Joining" />
                                <asp:BoundField DataField="Location" HeaderText="BaseLocation" />
                                <asp:BoundField DataField="Experience" HeaderText="Experience" />
                                <asp:BoundField DataField="Skills" HeaderText="Skills" />
                                <asp:BoundField DataField="AccountName" HeaderText="Account" />
                                <asp:BoundField DataField="InterviewedBy" HeaderText="Interviewed By" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="images/user_edit.png" CommandName="EditButton" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/images/trash.png"
                                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this Account?');"
                                            AlternateText="Delete" />
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>

                            <FooterStyle BackColor="White" />


                            <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />


                            <PagerSettings Mode="NumericFirstLast" NextPageImageUrl="~/images/126490.png" PageButtonCount="5" />


                            <RowStyle Font-Names="Calibri" />


                            <SelectedRowStyle BorderStyle="Inset" />


                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
