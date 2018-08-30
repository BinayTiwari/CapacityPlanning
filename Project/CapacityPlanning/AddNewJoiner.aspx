<%@ Page Title="Add New Joiner" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewJoiner.aspx.cs" Inherits="CapacityPlanning.AddNewJoiner" %>

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
                                <label>Full Name<span style="color:red;"> *</span></label>
                                <asp:TextBox ID="firstNameTextBox" CssClass="form-control" placeholder="Name" runat="server" required></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorfirstNameTextBox" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="firstNameTextBox"
                                ValidationExpression="^[A-Za-z][A-Za-z0-9. ]*$" ErrorMessage="*Only Alphabets are allowed." />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="firstNameTextBox"
                                ErrorMessage="*Only Alphabets are allowed." />
                            </div>

                            <div class="col-lg-6">
                                <label>Skill<span style="color:red;"> *</span></label>
                                <asp:DropDownList ID="skillListDD" class="form-control" runat="server" SelectionMode="Multiple"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSkill" runat="server" ControlToValidate="skillListDD" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Skill !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Designation<span style="color:red;"> *</span></label>
                                <asp:DropDownList ID="listDesignation" AppendDataBoundItems="true" CssClass="form-control" runat="server" required>
                                    <asp:ListItem>--Select Designation--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorlistDesignation" runat="server" ControlToValidate="listDesignation" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Designation !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                             </div>
                                <div class="col-lg-6">
                                    <label>Date of Joining<span style="color:red;"> *</span></label>
                                    <asp:TextBox ID="dojTextBox" TextMode="Date" CssClass="form-control" runat="server" required></asp:TextBox>

                                </div>

                            </div>
                        
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Base Location<span style="color:red;"> *</span></label>
                                <asp:TextBox ID="baseLocationTextBox" Placeholder="Base Location" CssClass="form-control" runat="server" required></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="baseLocationTextBox"
                                ValidationExpression="^[A-Za-z][A-Za-z0-9. ]*$" ErrorMessage="*Only Alphabets are allowed." />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="baseLocationTextBox"
                                ErrorMessage="*Only Alphabets are allowed." />
                                </div>
                                <div class="col-lg-6">
                                      <label>Previous Experience<span style="color:red;"> *</span></label>
                                    <asp:TextBox ID="expTextBox" Placeholder="Experience" CssClass="form-control" runat="server" required></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="expTextBox"
                                ValidationExpression="^[0-9. ]*$" ErrorMessage="*Only Alphabets are allowed." />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="expTextBox"
                                ErrorMessage="*Only Numbers are allowed." />
                                </div>

                            
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Account<span style="color:red;"> *</span></label>
                                <asp:DropDownList ID="accountDropDownList" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="">--Select Account--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatoraccountDropDownList" runat="server" ControlToValidate="accountDropDownList" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Account !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6">
                                    <label>Interviewed By<span style="color:red;"> *</span></label>
                                    <asp:TextBox ID="interviewedTextBox" Placeholder="Interviewed By" CssClass="form-control" runat="server" required></asp:TextBox>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="interviewedTextBox"
                                ValidationExpression="^[A-Za-z][A-Za-z0-9. ]*$" ErrorMessage="*Only Alphabets are allowed." />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="interviewedTextBox"
                                ErrorMessage="*Only Alphabets are allowed." />
                                </div>
                            

                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-sm-3 pull-right">
                            <div class="col-sm-2s pull-right">
                                <asp:Button ID="UnDoButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" CausesValidation="false" formnovalidate />
                            </div>
                            <div class="col-sm-2s pull-left">
                                <asp:Button ID="NewJoinerButton" Style="float: right;" CssClass="btn btn-success btn-md" OnClick="NewJoinerButton_Click" runat="server" Text="Save" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
