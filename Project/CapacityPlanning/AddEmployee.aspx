<%@ Page Title="Add Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="CapacityPlanning.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
   
    <div class="col-lg-12">
        <h1 class="page-header">Manage Resources</h1>
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
                                <label>Employee Name<span style="color:red;"> *</span></label>
                                <asp:TextBox ID="fName" runat="server" CssClass="form-control" placeholder="Employee" required></asp:TextBox>
                            </div>
                            <label>Employee ID<span style="color:red;"> *</span></label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="empIdText" runat="server" CssClass="form-control" placeholder="Employee ID" required></asp:TextBox>

                            </div>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Email<span style="color:red;"> *</span></label>
                                <asp:TextBox ID="mail" runat="server" TextMode="Email" CssClass="form-control" placeholder="Email" required></asp:TextBox>

                            </div>

                            <div class="col-lg-6">
                                <label>Password<span style="color:red;"> *</span></label>
                                <asp:TextBox TextMode="Password" ID="pass" CssClass="form-control" runat="server" placeholder="Password" required />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Reporting Manager<span style="color:red;"> *</span></label>
                                <asp:DropDownList ID="RManagerDropDownList" AppendDataBoundItems="true" CssClass="form-control" runat="server" required>
                                    <asp:ListItem Value="">--Select Reporting Manager--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRManager" runat="server" ControlToValidate="RManagerDropDownList" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Reporting Manager !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-lg-6">
                                <label>Base Location<span style="color:red;"> *</span></label>
                                <asp:TextBox ID="bLocation" runat="server" CssClass="form-control" placeholder="Base Location" required></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Designation<span style="color:red;"> *</span></label>
                                <asp:DropDownList ID="listDesignation" AppendDataBoundItems="true" CssClass="form-control" runat="server" required>
                                    <asp:ListItem Value="">--Select Designation--</asp:ListItem>
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDesignation" runat="server" ControlToValidate="listDesignation" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Designation !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-lg-6">
                                <label>Mobile No.<span style="color:red;"> *</span></label>
                                <asp:TextBox ID="phone" TextMode="Phone" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Role<span style="color:red;"> *</span></label>
                                <asp:DropDownList ID="listRole" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">--Select Role--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRole" runat="server" ControlToValidate="listRole" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Role !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-6">
                                <label>Date of Joining<span style="color:red;"> *</span></label>
                                <asp:TextBox ID="dojoining" runat="server" CssClass="form-control" TextMode="Date" required></asp:TextBox>

                            </div>


                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Skill<span style="color:red;"> *</span></label>
                                <asp:DropDownList ID="listSkillDD" class="form-control" runat="server" SelectionMode="Multiple"></asp:DropDownList>

                                <%--<asp:ListBox ID="listSkill" runat="server" CssClass="from-control" AppendDataBoundItems="true" SelectionMode="Multiple"></asp:ListBox>--%>
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
                                <asp:TextBox ID="panNoTxt" runat="server" CssClass="form-control" placeholder="PAN"></asp:TextBox>

                            </div>

                            <div class="col-lg-6">
                                <label>Photo</label>
                                <asp:FileUpload ID="FileUploadControl" CssClass="form-control" runat="server" text="uploadPhoto" />

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$"
                                    ControlToValidate="FileUploadControl" runat="server" ForeColor="Red" ErrorMessage="Please select a Image"
                                    Display="Dynamic" />
                            </div>

                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Passport No.</label>
                                <asp:TextBox ID="passportNum" runat="server" CssClass="form-control" placeholder="Passport No"></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <label>Passport Expiry Date</label>
                                <asp:TextBox ID="passExpDate" runat="server" CssClass="form-control"  TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Visa Expiry Date</label>
                                <asp:TextBox ID="visExpDate" runat="server" CssClass="form-control" TextMode="Date" ></asp:TextBox>
                            </div>
                            <div class="col-lg-6">
                                <label>Previous Experience</label>
                                <asp:TextBox ID="expText" runat="server" CssClass="form-control" placeholder="Experience in years"></asp:TextBox>

                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-sm-3 pull-right">
                            <div class="col-sm-2s pull-right">
<%--                                <asp:Button ID="UnDoButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" formnovalidate />--%>
                                <asp:Button ID="backButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel"
            OnClientClick="JavaScript:window.history.back(1);return false;"></asp:Button>
                            </div>
                            <div class="col-sm-2s pull-left">
                                <asp:Button ID="AddEmployeeDetail" runat="server" Style="float: right;" CssClass="btn btn-success btn-md" Text="Submit" OnClick="AddEmployee_Click" />
                            </div>
                        </div>

                    </div>
                </div>



            </div>
            <!-- /.col-lg-12 -->
        </div>
    </div>


    <link href="http://cdn.rawqit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawqit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('[id*=listSkill]').multiselect({
                includeSelectAllOption: true
            });
            
        });
    </script>
</asp:Content>
