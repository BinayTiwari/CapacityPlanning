﻿<%@ Page Title="Add Resource Demand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddResourceDemand.aspx.cs" Inherits="CapacityPlanning.AddResourceDemand" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Resource Request</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Add Resource Request
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Opportunity Type<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="OpportunityID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpportunity" runat="server" ControlToValidate="OpportunityID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Opportunity !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-lg-6">
                                <label>Region<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="RegionMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="RegionMasterID_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRegion" runat="server" ControlToValidate="RegionMasterID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Region !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Account<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="AccountMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" ControlToValidate="AccountMasterID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select an Account !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-6">
                                <label>Sales Stage<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="SalesStageMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSalesStage" runat="server" ControlToValidate="SalesStageMasterID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Sales Stage !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <label>Process Name<span style="color: red;"> *</span></label>
                            <asp:TextBox ID="processName" runat="server" MaxLength="50" CssClass="form-control" placeholder="Process Name"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorProcessName" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="processName"
                                ValidationExpression="^[A-Za-z][A-Za-z0-9-(), ]*$" ErrorMessage="Invalid Process Name !" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorProcess" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="processName"
                                ErrorMessage="Invalid Process Name !" />
                        </div>
                    </div>
                </div>
                <!-- /.col-lg-6 (nested) -->
            </div>

            <div class="dataTable_wrapper">
                <asp:GridView ID="GridviewResourceDetail" runat="server" ShowFooter="true" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" OnRowCreated="GridviewResourceDetail_RowCreated">
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="#" />
                        <asp:TemplateField HeaderText="Resource Type *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:DropDownList ID="ResourceTypeID" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorResourceType" runat="server" ControlToValidate="ResourceTypeID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Resource Type !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No of resources *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="NoOfResources" TextMode="Number" max="50" placeholder='No of Resources' min="0" CssClass="form-control" runat="server" step="0.25"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNoOfResources" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="NoOfResources"
                                    ErrorMessage="No of Resources can't be blank !" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Primary Skills *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
<%--                                <asp:ListBox ID="SkillID1" CssClass="form-control" AppendDataBoundItems="true" SelectionMode="Multiple" runat="server"></asp:ListBox>--%>
                                <asp:DropDownList ID="ddlPrimary" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlPrimary" runat="server" ControlToValidate="ddlPrimary" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Skill !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Secondry Skills *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
<%--                                <asp:ListBox ID="SkillID1" CssClass="form-control" AppendDataBoundItems="true" SelectionMode="Multiple" runat="server"></asp:ListBox>--%>
                                <asp:DropDownList ID="ddlSecondry" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlSecondry" runat="server" ControlToValidate="ddlSecondry" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Skill !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ternary Skills *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
<%--                                <asp:ListBox ID="SkillID1" CssClass="form-control" AppendDataBoundItems="true" SelectionMode="Multiple" runat="server"></asp:ListBox>--%>
                                <asp:DropDownList ID="ddlTernary" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlTernary" runat="server" ControlToValidate="ddlTernary" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Skill !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Start Date *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="StartDate" TextMode="Date" runat="server" CssClass="form-control" onkeypress="return false;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorStartDate" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="StartDate"
                                    ErrorMessage="Start Date can't be blank !" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End Date *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="EndDate" TextMode="Date" runat="server" CssClass="form-control" onkeypress="return false;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEndDate" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="EndDate"
                                    ErrorMessage="End Date can't be blank !" />
                                <asp:CompareValidator ID="CompareValidatorDtae" ForeColor="Red"
                                    runat="server" ControlToValidate="StartDate" ControlToCompare="EndDate"
                                    Operator="LessThanEqual" Type="Date" SetFocusOnError="true" ErrorMessage="Start date must be less than End date !"></asp:CompareValidator>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />

                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-danger btn-md" Text="Remove" OnClick="LinkButton1_Click" CausesValidation="false" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="ButtonAdd" runat="server" CssClass="btn btn-primary btn-md" Text="Add Row" OnClick="ButtonAdd_Click" />
                            </FooterTemplate>
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
                    <div class="row pull-right">
                        <asp:Button ID="save" runat="server" CssClass="btn-success btn btn-default" Text="Save" OnClick="Add_Resource_Demand" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="cancel" runat="server" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    

    


</asp:Content>

