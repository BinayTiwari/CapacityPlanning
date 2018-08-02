﻿<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="CapacityPlanning.EditEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>

    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="ResourceMaster.aspx">Resource Master</a></li>
            <li class="breadcrumb-item active" aria-current="page">Add Employee</li>
        </ol>
    </nav>
    <div class="col-md-10 panel-info">
        <div class="row">
            <div class="content-box-header panel-heading" style="color: white; background-color: #07838a">
                <div class="panel-title ">Edit Employee</div>
            </div>

            <div class="content-box-large box-with-header">
                <div>
                    <div class="row">
                        <div class="col-sm-4">
                            <label>Name</label>
                            <asp:TextBox ID="fName" runat="server" CssClass="form-control" placeholder="Employee Name" required></asp:TextBox>
                            


                        </div>
                        <div class="col-sm-4">

                            
                                <label>Employee ID</label>
                            <asp:TextBox ID="empIdText" runat="server" CssClass="form-control" placeholder="Employee ID" required></asp:TextBox>
                            


                        
                        </div>

                    </div>
                    <br>
                    <div class="row">
                        <div class="col-sm-4">
                            <label>Email</label>
                            <asp:TextBox ID="mail" runat="server" TextMode="Email" CssClass="form-control" placeholder="Email" required></asp:TextBox>
                            
                        </div>
                        <div class="col-sm-4">
                            <label>Password</label>
                            <asp:TextBox TextMode="Password" ID="pass" CssClass="form-control" runat="server" placeholder="Password" required/>
                            
                        </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-sm-4">
                            <label>Reporting Manager</label>
                            <asp:DropDownList ID="RManagerDropDownList" AppendDataBoundItems="true" CssClass="form-control" runat="server" equired>
                                <asp:ListItem Value="">--Select Reporting Manager--</asp:ListItem>
                            </asp:DropDownList>
                            


                        </div>
                        <div class="col-sm-4">
                            <label>Base Location</label>
                            <asp:TextBox ID="bLocation" runat="server" CssClass="form-control" placeholder="Base Location" required ></asp:TextBox>
                           
                        </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-sm-4">
                            <label>Designation</label>
                            <asp:DropDownList ID="listDesignation" AppendDataBoundItems="true" CssClass="form-control" runat="server" required>
                                <asp:ListItem Value="">--Select Designation--</asp:ListItem>
                            </asp:DropDownList>
                            


                        </div>
                        <div class="col-sm-4">
                            <label>Mobile No.</label>
                            <asp:TextBox ID="phone" TextMode="Phone" runat="server" CssClass="form-control" placeholder="Mobile Number" required></asp:TextBox>
                            
                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>Role</label>
                            <asp:DropDownList ID="listRole" AppendDataBoundItems="true" CssClass="form-control" runat="server" required>
                                <asp:ListItem Value="">--Select Role--</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-sm-4">
                            <label>Date of Joining</label>
                            <asp:TextBox ID="dojoining" runat="server" CssClass="form-control" placeholder="Date of joining (DD/MM/YYYY)" required ></asp:TextBox>

                        </div>


                    </div>
                    <br>

                    <div class="row">
                        <div class="col-sm-4">
                            <asp:Label ID="Label1" class="form-control" runat="server" Text="Select Skills: "></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:ListBox ID="listSkill" class="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox>
                        </div>
                    </div>
                </div>
                <br>

                <div class="row">
                    <div class="col-sm-8">
                        <label>Address</label>
                        <asp:TextBox ID="addressTxt" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Address"></asp:TextBox>

                    </div>
                    
                </div>
                <br />
                 <div class="row">
                    <div class="col-sm-8">
                        <label>PAN</label>
                        <asp:TextBox ID="panNoTxt" runat="server" CssClass="form-control" placeholder="PAN"></asp:TextBox>

                    </div>

                </div>
                <br>

                <div class="row">
                    <div class="col-sm-4">
                        <h4>Passport & Visa Details:</h4>

                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <asp:TextBox ID="passportNum" runat="server" CssClass="form-control" placeholder="Passport No"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="passExpDate" runat="server" CssClass="form-control" placeholder="Passport Expiry Date (DD/MM/YYYY)"></asp:TextBox>
                    </div>
                </div>
                <br>
                <div class="row">
                    <div class="col-sm-4">
                        <asp:TextBox ID="visExpDate" runat="server" CssClass="form-control" placeholder="Visa Expiry Date (DD/MM/YYYY)"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-4">
                        <h4>Previous Experience:</h4>

                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-4">
                        <asp:TextBox ID="expText" runat="server" CssClass="form-control" placeholder="Experience in years"></asp:TextBox>
                    </div>

                </div>
                    <div class="row">
                        <div class="col-sm-8">
                            <div class="col-md-2 pull-right" >
                            <asp:Button ID="UnDoButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" formnovalidate/>
                                </div>
                            <div  >
                            <asp:Button ID="AddEmployeeDetail" runat="server" Style="float: right;" CssClass="btn btn-success btn-md" Text="Update" OnClick="AddEmployeeDetail_Click"/>
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
            $("#Button1").click(function () {
                alert($(".multiselect-selected-text").html());
            });
        });
    </script>
</asp:Content>
