<%@ Page Title="Resource Demand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResourceDemand.aspx.cs" Inherits="CapacityPlanning.ResourceDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-10">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Resource Demand</li>
            </ol>
        </nav>

        <div class="row">
            <div class="col-md-12">
                <div class="panel-heading">
                    <div class="panel-title">Resource Demand </div>
                    <asp:Button ID="ResourceDemandAddButton" runat="server" Text="Add Resource Demand" Style="float: right;" CssClass="btn btn-md btn-success"
                        PostBackUrl="AddResourceDemand.aspx" />
                </div>
                <br />
                <br />
                <div class="content-box-large">
                    <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="RequestId" OnPageIndexChanging="OnPageIndexChanging"
                        PageSize="10" CssClass="pager rows header1 mygrdContent" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                        OnRowCommand="GridView1_RowCommand" OnRowDeleting="delete" OnRowCancelingEdit="canceledit" OnRowUpdating="update"
                        BackColor="White" BorderColor="White" EmptyDataText="N/A" Font-Size="Medium" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                        Font-Names="Calibri" Font-Overline="False" ForeColor="#003300" GridLines="Horizontal">

                        <AlternatingRowStyle BackColor="#F9F9F9" CssClass="table table-striped" />
                        <Columns>
                            <asp:BoundField DataField="RequestId" ReadOnly="true" HeaderText="RequestID" />
                            <asp:BoundField DataField="AccountName" HeaderText="Account" />
                            <asp:BoundField DataField="CountryName" HeaderText="Country" />
                            <asp:BoundField DataField="CityName" HeaderText="City" />
                            <asp:BoundField DataField="OpportunityType" HeaderText="Opportunity Type" />
                            <asp:BoundField DataField="SalesStageName" HeaderText="Sales Stage" />
                            <asp:BoundField DataField="ProcessName" HeaderText="Process Name" />
                            <asp:BoundField DataField="StatusName" HeaderText="Demand Status"/>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnView" runat="server" ImageUrl="images/info.png" CommandName="View"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClick="View_Resource_Demand" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="images/user_edit.png" CommandName="EditButton"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/images/trash.png" CommandName="Delete"
                                        OnClientClick="return confirm('Are you sure you want to delete this Request Demand?');" AlternateText="Delete" />
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

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    Modal Body
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>

    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
</asp:Content>
