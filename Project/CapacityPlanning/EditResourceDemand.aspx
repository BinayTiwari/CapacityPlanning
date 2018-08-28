<%@ Page Title="Edit Resource Demand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditResourceDemand.aspx.cs" Inherits="CapacityPlanning.EditResourceDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Resource Demand</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Edit Resource Demand Status
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Opportunity Type</label>
                                <asp:DropDownList ID="OpportunityID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="col-lg-6">
                                <label>Region</label>
                                <asp:DropDownList ID="RegionMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="RegionMasterID_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Account</label>
                                <asp:DropDownList ID="AccountMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-6">
                                <label>Sales Stage</label>
                                <asp:DropDownList ID="SalesStageMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Process Name</label>
                                <asp:TextBox ID="processName" runat="server" CssClass="form-control" placeholder="Process Name"></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <label>Status</label>
                                <asp:DropDownList ID="StatusMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Priority</label>
                                <asp:DropDownList ID="PriorityID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="dataTable_wrapper">
                <asp:GridView ID="GridviewResourceDetail" runat="server" ShowFooter="True"
                    CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"
                    OnRowCreated="GridviewResourceDetail_RowCreated">
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="#" />
                        <asp:TemplateField HeaderText="Resource Type">
                            <ItemTemplate>
                                <asp:DropDownList ID="ResourceTypeID" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No of resources" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="NoOfResources" Text='<%# Bind("NoOfResources") %>' TextMode="Number" placeholder='No of Resources' CssClass="form-control" runat="server" required></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Skills" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:DropDownList ID="SkillID" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="StartDate" runat="server" Text='<%# Bind("StartDate","{0:dd-MM-yyyy}") %>' CssClass="form-control" required></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End Date" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="EndDate" Text='<%# Bind("EndDate","{0:dd-MM-yyyy}") %>' runat="server" CssClass="form-control" required></asp:TextBox>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Button ID="ButtonAdd" runat="server" CssClass="btn btn-primary" Text="Add New Row" OnClick="ButtonAdd_Click" />
                            </FooterTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-danger btn-md" Text="Remove" OnClick="LinkButton1_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="panel-body">
            <div class="col-md-12 panel-info">
                <div class="row">
                    <div class="content-box-large box-with-header">
                        <br />
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="col-sm-2 pull-right">
                                    <asp:Button ID="cancel" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" formnovalidate />
                                </div>
                                <div>
                                    <asp:Button ID="save" runat="server" CssClass="pull-right btn-success btn btn-default" Text="Update" OnClick="Update_Resource_Demand" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
