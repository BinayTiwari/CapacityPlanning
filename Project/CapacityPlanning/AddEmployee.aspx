<%@ Page Title="Add Employee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="CapacityPlanning.AddEmployee" %>

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
                                    <asp:TextBox ID="fName" runat="server" CssClass="form-control" placeholder="Employee" required></asp:TextBox>
                                </div>

                                <div class="col-lg-6">
                                    <asp:TextBox ID="empIdText" runat="server" CssClass="form-control" placeholder="Employee ID" required></asp:TextBox>

                                </div>

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:TextBox ID="mail" runat="server" TextMode="Email" CssClass="form-control" placeholder="Email" required></asp:TextBox>

                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox TextMode="Password" ID="pass" CssClass="form-control" runat="server" placeholder="Password" required />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:DropDownList ID="RManagerDropDownList" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorRManager" runat="server" ControlToValidate="RManagerDropDownList" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-lg-6">
                                    <asp:TextBox ID="bLocation" runat="server" CssClass="form-control" placeholder="Base Location" required></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:DropDownList ID="listDesignation" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDesignation" runat="server" ControlToValidate="listDesignation" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>


                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="phone" TextMode="Phone" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:DropDownList ID="listRole" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorRole" runat="server" ControlToValidate="listRole" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="dojoining" TextMode="Date" runat="server" CssClass="form-control" placeholder="Date of joining (DD/MM/YYYY)" required></asp:TextBox>

                                </div>


                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:DropDownList ID="listSkillDD" class="form-control" runat="server" AppendDataBoundItems="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSkill" runat="server" ControlToValidate="listSkillDD" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Value Required!" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6">
                                   <asp:TextBox ID="addressTxt" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Address"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:TextBox ID="panNoTxt" runat="server" CssClass="form-control" placeholder="PAN" ></asp:TextBox>

                                </div>

                                <div class="col-lg-6">

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
                                    <asp:TextBox ID="passportNum" runat="server" CssClass="form-control" placeholder="Passport No"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="passExpDate" TextMode="Date" runat="server" CssClass="form-control" placeholder="Passport Expiry Date (DD/MM/YYYY)"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:TextBox ID="visExpDate" TextMode="Date" runat="server" CssClass="form-control" placeholder="Visa Expiry Date (DD/MM/YYYY)"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="expText" runat="server" CssClass="form-control" placeholder="Experience in years"></asp:TextBox>

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
        </div>

    
</asp:Content>
