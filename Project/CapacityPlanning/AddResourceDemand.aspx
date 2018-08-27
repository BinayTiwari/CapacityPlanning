<%@ Page Title="Add Resource Demand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddResourceDemand.aspx.cs" Inherits="CapacityPlanning.AddResourceDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Add Resource Demand</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Add Resource Demand
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <asp:DropDownList ID="OpportunityID" AppendDataBoundItems="true" CssClass="form-control" runat="server">

                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpportunity" runat="server" ControlToValidate="OpportunityID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-lg-6">
                                <asp:DropDownList ID="RegionMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="RegionMasterID_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRegion" runat="server" ControlToValidate="RegionMasterID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <asp:DropDownList ID="AccountMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" ControlToValidate="AccountMasterID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="SalesStageMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSalesStage" runat="server" ControlToValidate="SalesStageMasterID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <asp:TextBox ID="processName" runat="server" CssClass="form-control" placeholder="Process Name" required></asp:TextBox>
                        </div>
                    </div>
                </div>
                <!-- /.col-lg-6 (nested) -->
            </div>

            <div class="dataTable_wrapper">
                <asp:GridView ID="GridviewResourceDetail" runat="server" ShowFooter="true" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" OnRowCreated="GridviewResourceDetail_RowCreated">
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="#" />
                        <asp:TemplateField HeaderText="Resource Type">
                            <ItemTemplate>
                                <asp:DropDownList ID="ResourceTypeID" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorResourceType" runat="server" ControlToValidate="ResourceTypeID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No of resources" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="NoOfResources" TextMode="Number" placeholder='No of Resources' CssClass="form-control" runat="server" required></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Skills" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:DropDownList ID="SkillID" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSkill" runat="server" ControlToValidate="SkillID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="StartDate" TextMode="Date" runat="server" CssClass="form-control" required></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End Date" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="EndDate" TextMode="Date" runat="server" CssClass="form-control" required></asp:TextBox>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Button ID="ButtonAdd" runat="server" CssClass="btn btn-primary" Text="Add New Row" OnClick="ButtonAdd_Click"/>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-danger btn-md" Text="Remove" OnClick="LinkButton1_Click" CausesValidation="false" formnovalidate/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
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
                                <asp:Button ID="cancel" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" CausesValidation="false" formnovalidate />
                            </div>
                            <div>
                                <asp:Button ID="save" runat="server" CssClass="pull-right btn-success btn btn-default" Text="Add Demand" OnClick="Add_Resource_Demand"  />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>

