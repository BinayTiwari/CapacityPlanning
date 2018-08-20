<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnboardNewJoiners.aspx.cs" Inherits="CapacityPlanning.OnboardNewJoiners" %>
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
                                    <label>Name</label>
                                    <asp:TextBox ID="fName" runat="server" CssClass="form-control" placeholder="Employee" required></asp:TextBox>
                                </div>

                                <div class="col-lg-6">
                                    <label>Employee ID</label>
                                    <asp:TextBox ID="empIdText" runat="server" CssClass="form-control" placeholder="Employee ID" required></asp:TextBox>

                                </div>

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <label>Email</label>
                                    <asp:TextBox ID="mail" runat="server" TextMode="Email" CssClass="form-control" placeholder="Email" required></asp:TextBox>

                                </div>
                                <div class="col-lg-6">
                                    <label>Password</label>
                                    <asp:TextBox TextMode="Password" ID="pass" CssClass="form-control" runat="server" placeholder="Password" required />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <label>Reporting Manager</label>
                                    <asp:DropDownList ID="RManagerDropDownList" AppendDataBoundItems="true" CssClass="form-control" runat="server" required>
                                        <asp:ListItem Value="">--Select Reporting Manager--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="col-lg-6">
                                    <label>Base Location</label>
                                    <asp:TextBox ID="bLocation" runat="server" CssClass="form-control" placeholder="Base Location" required></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <label>Designation</label>
                                    <asp:DropDownList ID="listDesignation" AppendDataBoundItems="true" CssClass="form-control" runat="server" required>
                                        <asp:ListItem Value="">--Select Designation--</asp:ListItem>
                                    </asp:DropDownList>



                                </div>
                                <div class="col-lg-6">
                                    <label>Mobile No.</label>
                                    <asp:TextBox ID="phone" TextMode="Phone" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <label>Role</label>
                                    <asp:DropDownList ID="listRole" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">--Select Role--</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="col-lg-6">
                                    <label>Date of Joining</label>
                                    <asp:TextBox ID="dojoining" runat="server" CssClass="form-control" placeholder="Date of joining (DD/MM/YYYY)" required></asp:TextBox>

                                </div>


                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <label>Skill</label>
                                    <asp:DropDownList ID="listSkillDD" class="form-control" runat="server" SelectionMode="Multiple"></asp:DropDownList>
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
                                    <asp:TextBox ID="panNoTxt" runat="server" CssClass="form-control" placeholder="PAN" required></asp:TextBox>

                                </div>

                                <div class="col-lg-6">
                                    <label>Uppload Photo</label>
                                    <asp:FileUpload ID="FileUploadControl" CssClass="form-control" runat="server" text="uploadPhoto" />
                                    <asp:RequiredFieldValidator ErrorMessage="File format is not supported" ControlToValidate="FileUploadControl" runat="server" Display="Dynamic" ForeColor="Red" />
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
