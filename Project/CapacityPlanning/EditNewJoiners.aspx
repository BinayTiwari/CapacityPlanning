<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditNewJoiners.aspx.cs" Inherits="CapacityPlanning.EditNewJoiners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <div class="col-lg-12">
        <h1 class="page-header">Manage New Joiner</h1>
    </div>
    <!-- /.col-lg-12 -->

    <div class="row">

        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Add New Joiner
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Full Name<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="firstNameTextBox" CssClass="form-control" MaxLength="50" placeholder="Name" runat="server" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorfirstNameTextBox" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="firstNameTextBox"
                                    ValidationExpression="^[A-Za-z][A-Za-z. ]*$" ErrorMessage="Invalid Name !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="firstNameTextBox"
                                    ErrorMessage="Invalid Name !" />
                            </div>

                            <div class="col-lg-6">
                                <label>Skill<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="skillListDD" class="form-control" runat="server" SelectionMode="Multiple"></asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorSkill" runat="server" ControlToValidate="skillListDD" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Skill !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Designation<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="listDesignation" AppendDataBoundItems="true" CssClass="form-control" runat="server" >
                                    
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorlistDesignation" runat="server" ControlToValidate="listDesignation" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Designation !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-6">
                                <label>Date of Joining(MM/DD/YYYY)<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="dojTextBox" ToolTip="Date of joining" MaxLength="10" CssClass="form-control" runat="server" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="dojTextBox"
                                    ErrorMessage="Date of Joining can't be blank !" />
                            </div>

                        </div>

                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Base Location<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="baseLocationTextBox" Placeholder="Base Location" CssClass="form-control" runat="server" ></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="baseLocationTextBox"
                                    ValidationExpression="^[A-Za-z][A-Za-z0-9. ]*$" ErrorMessage="Invalid Base Location !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="baseLocationTextBox"
                                    ErrorMessage="Invalid Base Location !" />
                            </div>
                            <div class="col-lg-6">
                                <label>Previous Experience<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="expTextBox" Placeholder="Experience" TextMode="Number" min="0" step="0.01" max="100" CssClass="form-control" runat="server" ></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="expTextBox"
                                    ValidationExpression="^[0-9. ]*$" ErrorMessage="Only Numbers are allowed !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="expTextBox"
                                    ErrorMessage="Only Numbers are allowed !" />
                            </div>


                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Account<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="accountDropDownList" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="">--Select Account--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatoraccountDropDownList" runat="server" ControlToValidate="accountDropDownList" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select an Account !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-lg-6">
                                <label>Interviewed By<span style="color: red;"> *</span></label>

                                <asp:TextBox ID="interviewedTextBox" Placeholder="Interviewed By" MaxLength="50" CssClass="form-control" runat="server" ></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="interviewedTextBox"
                                    ValidationExpression="^[A-Za-z][A-Za-z./ ]*$" ErrorMessage="Invalid Interviewer Name !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="interviewedTextBox"
                                    ErrorMessage="Invalid Interviewer Name !" />
                            </div>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-sm-3 pull-right">
                            <div class="col-sm-2s pull-right">
                                <%--<asp:Button ID="UnDoButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" CausesValidation="false" formnovalidate />--%>
                                <asp:Button ID="backButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel"
            OnClientClick="JavaScript:window.history.back(1);return false;"></asp:Button>
                            </div>
                        </div>
                        <div class="col-sm-2s pull-right">
                            <asp:Button ID="NewJoinerButton" Style="float: right;" CssClass="btn btn-success btn-md" OnClick="NewJoinerButton_Click" runat="server" Text="Save" />
                        </div>
                    </div>

                </div>
        </div>
    </div>

</asp:Content>
