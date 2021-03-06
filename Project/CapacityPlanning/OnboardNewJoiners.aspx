﻿<%@ Page Title="Onboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnboardNewJoiners.aspx.cs" Inherits="CapacityPlanning.OnboardNewJoiners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h1 class="page-header">Onboard New Joiner</h1>
    </div>
    <!-- /.col-lg-12 -->

    <div class="row">

        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Add New Employee
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Employee Name<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="fName" runat="server" MaxLength="50" CssClass="form-control" placeholder="Employee"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorfirstNameTextBox" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="fName"
                                    ValidationExpression="^[A-Za-z][A-Za-z. ]*$" ErrorMessage="Invalid Employee Name !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="fName"
                                    ErrorMessage="Invalid Employee Name !" />
                            </div>

                            <div class="col-lg-6">
                                <label>Employee ID<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="empIdText" runat="server" TextMode="Number" step="1" min="10000" max="100000" CssClass="form-control" placeholder="Employee ID"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="empIdText"
                                    ValidationExpression="^[0-9]+$" ErrorMessage="*Invalid Employee ID !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="empIdText"
                                    ErrorMessage="Invalid Employee ID !" />
                                <asp:Label ID="lblEmpID" runat="server" ForeColor="Red"></asp:Label>
                            </div>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Email<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="mail" runat="server" MaxLength="100" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="mail"
                                    ErrorMessage="Email can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="mail"
                                    ValidationExpression="^\w.+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" ErrorMessage="Invalid Email !" />
                            </div>
                            <div class="col-lg-6">
                                <label>Password<span style="color: red;"> *</span></label>
                                <asp:TextBox TextMode="Password" ID="pass" MaxLength="15" CssClass="form-control" runat="server" placeholder="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="pass"
                                    ErrorMessage="Password can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="pass"
                                    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$" ErrorMessage="Password length should be between 8-15 character and should include one 
                                    special, atleast one uppercase, one lowercase character and one number !" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Reporting Manager<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="RManagerDropDownList" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRManager" runat="server" ControlToValidate="RManagerDropDownList" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Reporting Manager !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-lg-6">
                                <label>Base Location<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="bLocation" runat="server" MaxLength="50" CssClass="form-control" placeholder="Base Location"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="bLocation"
                                    ValidationExpression="^[A-Za-z][A-Za-z-. ]*$" ErrorMessage="Invalid Base Location !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="bLocation"
                                    ErrorMessage="Invalid Base Location !" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Designation<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="listDesignation" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDesignation" runat="server" ControlToValidate="listDesignation" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Designation !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-lg-6">
                                <label>Mobile No.<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="phone" runat="server" MaxLength="15" CssClass="form-control" placeholder="+91-9990331845"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorphoneTextBox" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="phone"
                                    ValidationExpression="^(\+\d{1,3}[- ]?)?\d{10}$" ErrorMessage="Invalid Mobile number !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="phone"
                                    ErrorMessage="Invalid Mobile number !" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Role<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="listRole" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRole" runat="server" ControlToValidate="listRole" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Role !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-6">
                                <label>Date of Joining(MM/DD/YYYY)<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="dojoining" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="dojoining"
                                    ErrorMessage="Date of Joining can't be blank !" />
                            </div>


                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Skill<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="listSkillDD" class="form-control" runat="server" SelectionMode="Multiple"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSkill" runat="server" ControlToValidate="listSkillDD" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Skill !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-6">
                                <label>Address</label>
                                <asp:TextBox ID="addressTxt" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Address"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>PAN</label>
                                <asp:TextBox ID="panNoTxt" runat="server" MaxLength="10" CssClass="form-control" placeholder="PAN"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="panNoTxt"
                                    ValidationExpression="^[A-Za-z][A-Za-z0-9]*$" ErrorMessage="Invalid PAN !" />

                            </div>

                            <div class="col-lg-6">
                                <label>Uppload Photo</label>
                                <asp:FileUpload ID="FileUploadControl" CssClass="form-control" runat="server" text="uploadPhoto" />

                            </div>

                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Passport No.</label>
                                <asp:TextBox ID="passportNum" runat="server" MaxLength="8" CssClass="form-control" placeholder="Passport No"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="passportNum"
                                    ValidationExpression="^[A-Za-z][A-Za-z0-9]*$" ErrorMessage="Invalid Passport No. !" />
                            </div>
                            <div class="col-lg-6">
                                <label>Passport Expiry Date</label>
                                <asp:TextBox ID="passExpDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Visa Expiry Date</label>
                                <asp:TextBox ID="visExpDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <label>Experience<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="expText" runat="server" MaxLength="4" CssClass="form-control" placeholder="Experience in years"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="expText"
                                    ErrorMessage="Experience can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="expText"
                                    ValidationExpression="^(?:50(?:\.0)?|[0-9](?:\.[0-9])?|0?\.[1-9])$" ErrorMessage="Invalid Experience !" />
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-sm-3 pull-right">
                            <div class="col-sm-2s pull-right">
                                <asp:Button ID="UnDoButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" CausesValidation="false" />

                            </div>
                            <div class="col-sm-2s pull-left">
                                <asp:Button ID="AddEmployeeDetail" runat="server" Style="float: right;" CssClass="btn btn-success btn-md" Text="Submit" OnClick="AddEmployee_Click" />
                            </div>
                        </div>

                    </div>
                </div>

            </div>

        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
