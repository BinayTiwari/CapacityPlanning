<%@ Page Title="Onboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnboardNewJoiners.aspx.cs" Inherits="CapacityPlanning.OnboardNewJoiners" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h1 class="page-header">Manage Employee</h1>
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

                                <div class="col-lg-6">
                                    <label>Employee ID<span style="color:red;"> *</span></label>
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
                                        
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorRManager" runat="server" ControlToValidate="RManagerDropDownList" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Reporting Manager!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                                       
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorRole" runat="server" ControlToValidate="listRole" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Role !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6">
                                    <label>Date of Joining<span style="color:red;"> *</span></label>
                                    <asp:TextBox ID="dojoining" runat="server" CssClass="form-control" placeholder="Date of joining (DD/MM/YYYY)" required></asp:TextBox>

                                </div>


                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <label>Skill<span style="color:red;"> *</span></label>
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
                                    <asp:TextBox ID="panNoTxt" runat="server" CssClass="form-control" placeholder="PAN"></asp:TextBox>

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
                                    <asp:TextBox ID="passportNum" runat="server" CssClass="form-control" placeholder="Passport No"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <label>Passport Expiry Date</label>
                                    <asp:TextBox ID="passExpDate" runat="server" CssClass="form-control" placeholder="Passport Expiry Date (DD/MM/YYYY)"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <label>Visa Expiry Date</label>
                                    <asp:TextBox ID="visExpDate" runat="server" CssClass="form-control" placeholder="Visa Expiry Date (DD/MM/YYYY)"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <label>Experience</label>
                                    <asp:TextBox ID="expText" runat="server" CssClass="form-control" placeholder="Experience in years" required></asp:TextBox>

                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-sm-3 pull-right">
                                <div class="col-sm-2s pull-right">
                                    <asp:Button ID="UnDoButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" formnovalidate />
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
</asp:Content>
