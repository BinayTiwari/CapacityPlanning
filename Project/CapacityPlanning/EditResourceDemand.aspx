<%@ Page Title="Edit Resource Demand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditResourceDemand.aspx.cs" Inherits="CapacityPlanning.EditResourceDemand" %>

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
                    Edit Resource Request Status
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
                                    ErrorMessage="Please select Opportunity!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-lg-6">
                                <label>Region<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="RegionMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="RegionMasterID_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRegion" runat="server" ControlToValidate="RegionMasterID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Region!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>

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
                                    ErrorMessage="Please select Account!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-6">
                                <label>Sales Stage<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="SalesStageMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSalesStage" runat="server" ControlToValidate="SalesStageMasterID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Sales Stage!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Process Name<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="processName" runat="server" MaxLength="50" CssClass="form-control" placeholder="Process Name"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorProcessName" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="processName"
                                    ValidationExpression="^[A-Za-z][A-Za-z0-9-(), ]+$" ErrorMessage="Invalid Process Name !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="processName"
                                    ErrorMessage="Invalid Process Name !" />
                            </div>
                            <div class="col-lg-6">
                                <label>Status<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="StatusMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorStatus" runat="server" ControlToValidate="StatusMasterID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Status!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>


                </div>
            </div>

            <div class="dataTable_wrapper">
                <asp:GridView ID="GridviewResourceDetail" runat="server" ShowFooter="True"
                    CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <%--<asp:BoundField DataField="RowNumber" HeaderText="#" />--%>
                        <asp:TemplateField HeaderText="Resource Type *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:DropDownList ID="ResourceTypeID" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorResourceType" runat="server" ControlToValidate="ResourceTypeID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Resource Type!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No of resources *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="NoOfResources" Text='<%# Bind("NoOfResources") %>' TextMode="Number" max="50" min="0" placeholder='No of Resources' CssClass="form-control" step="0.5" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNoOfResources" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="NoOfResources"
                                    ErrorMessage="No of Resources can't be blank !" />
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Skills *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:DropDownList ID="SkillID" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSkill" runat="server" ControlToValidate="SkillID" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Skill !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Start Date *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="StartDate" runat="server" Text='<%# Bind("StartDate","{0:yyyy-MM-dd}") %>' TextMode="Date" onkeypress="return false;" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorStartDate" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="StartDate"
                                    ErrorMessage="Start Date can't be blank !" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End Date *" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:TextBox ID="EndDate" Text='<%# Bind("EndDate","{0:yyyy-MM-dd}") %>' TextMode="Date" runat="server" onkeypress="return false;" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEndDate" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="EndDate"
                                    ErrorMessage="End Date can't be blank !" />
                                <asp:CompareValidator ID="CompareValidatorDate" ForeColor="Red"
                                    runat="server" ControlToValidate="StartDate" ControlToCompare="EndDate"
                                    Operator="LessThanEqual" Type="Date" ErrorMessage="Start date must be less than End date."></asp:CompareValidator>
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
                                    <asp:Button ID="cancel" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" CausesValidation="false" OnClick="UnDoButton_Click" />
                                    
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
