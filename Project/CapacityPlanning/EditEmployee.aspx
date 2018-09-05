<%@ Page Title="Edit Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="CapacityPlanning.EditEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />

    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <div class="col-lg-12">
        <h1 class="page-header">Manage Resources</h1>
    </div>
    <!-- /.col-lg-12 -->

    <div class="row">

        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Edit Employee Details
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Employee Name<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="fName" runat="server" CssClass="form-control" placeholder="Employee Name"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorfirstNameTextBox" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="fName"
                                    ValidationExpression="^[A-Za-z][A-Za-z. ]*$" ErrorMessage="Invalid Employee Name !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="fName"
                                    ErrorMessage="Invalid Employee Name !" />
                            </div>

                            <div class="col-lg-6">
                                <label>Employee ID<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="empIdText" runat="server" TextMode="Number" step="1" min="10000" max="100000" CssClass="form-control" placeholder="Employee ID" Enabled="false"></asp:TextBox>

                            </div>

                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Email<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="mail" runat="server" MaxLength="50" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="mail"
                                    ErrorMessage="Email can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="mail"
                                    ValidationExpression="^\w.+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" ErrorMessage="Invalid Email !" />
                            </div>

                            <div class="col-lg-6">
                                <label>Skill<span style="color: red;"> *</span></label>
                                <%--                                <asp:DropDownList ID="listSkillDD" class="form-control" runat="server" SelectionMode="Multiple"></asp:DropDownList>--%>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorSkill" runat="server" ControlToValidate="listSkillDD" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Skill !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                <asp:ListBox ID="listSkill" class="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSkill" runat="server" ControlToValidate="listSkill" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Skill !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>

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
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="bLocation"
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
                                <asp:TextBox ID="phone" runat="server" MaxLength="15" placeholder="+91-9990331845" CssClass="form-control"></asp:TextBox>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="listRole" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Role !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                                <label>Address</label>
                                <asp:TextBox ID="addressTxt" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Address"></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <label>PAN</label>
                                <asp:TextBox ID="panNoTxt" runat="server" MaxLength="8" CssClass="form-control" placeholder="PAN"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="panNoTxt"
                                    ValidationExpression="^[A-Za-z][A-Za-z0-9]*$" ErrorMessage="Invalid PAN !" />
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-sm-4">
                            <h4>Passport and visa details:</h4>

                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Passport No.</label>
                                <asp:TextBox ID="passportNum" runat="server" MaxLength="8" CssClass="form-control" placeholder="Passport No"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="passportNum"
                                    ValidationExpression="^[A-Za-z][A-Za-z0-9]*$" ErrorMessage="Invalid Passport No. !" />
                            </div>

                            <div class="col-lg-6">
                                <label>Passport Expiry Date(MM/DD/YYYY)</label>
                                <asp:TextBox ID="passExpDate" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Visa Expiry Date(MM/DD/YYYY)</label>
                                <asp:TextBox ID="visExpDate" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>


                            </div>


                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <h4>Experience details:</h4>

                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Prior Experience<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="expText" runat="server" value="0" MaxLength="4" CssClass="form-control" placeholder="Experience in years"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="expText"
                                    ErrorMessage="Experience can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="expText"
                                    ValidationExpression="[0-9.]*$" ErrorMessage="Invalid Experience !" />
                            </div>

                        </div>


                    </div>
                    <div class="row">
                        <div class="col-sm-3 pull-right">
                            <div class="col-sm-2s pull-right">
                                <asp:Button ID="UnDoButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" CausesValidation="false" formnovalidate />

                            </div>
                            <div class="col-sm-2s pull-left">
                                <asp:Button ID="AddEmployeeDetail" runat="server" Style="float: right;" CssClass="btn btn-success btn-md" Text="Update" OnClick="AddEmployeeDetail_Click" />
                            </div>
                        </div>

                    </div>
                </div>


            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            $('[id*=listSkill]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>

</asp:Content>
