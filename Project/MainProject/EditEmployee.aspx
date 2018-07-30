<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="CapacityPlanning.EditEmployee" %>
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
                            <label >First Name</label>
                            <asp:TextBox ID="fName" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="fName" runat="server" Display="Dynamic" ForeColor="Red" />


                        </div>
                        <div class="col-sm-4">
                            <label >Last Name</label>
                            <asp:TextBox ID="lName" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="lName" runat="server" Display="Dynamic" ForeColor="Red" />

                        </div>

                    </div>
                    


                    <div class="row">

                        
                        

                    </div>
                    <br>


                    <div class="row">
                        <div class="col-sm-4">
                            <label >Reporting Manager</label>
                            <asp:TextBox ID="rManager" runat="server" CssClass="form-control" placeholder="Reporting Manager"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="rManager" runat="server" Display="Dynamic" ForeColor="Red" />

                        </div>
                        <div class="col-sm-4">
                            <label >Email</label>
                            <asp:TextBox ID="mail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="mail" runat="server" Display="Dynamic" ForeColor="Red" />

                        </div>
                    </div>
                    <br>

                    <div class="row">
                        <div class="col-sm-4">
                            <label >Base Location</label>
                            <asp:TextBox ID="bLocation" runat="server" CssClass="form-control" placeholder="Base Location"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="bLocation" runat="server" Display="Dynamic" ForeColor="Red" />

                        </div>
                        <div class="col-sm-4">
                            <label >Mobile</label>
                            <asp:TextBox ID="phone" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="phone" runat="server" Display="Dynamic" ForeColor="Red" />

                        </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-sm-4">
                            <label >Designation</label>
                            <asp:DropDownList ID="listDesignation" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                <asp:ListItem Value="0">--Select Designation--</asp:ListItem>
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="listDesignation" runat="server" Display="Dynamic" ForeColor="Red" />


                        </div>

                        <div class="col-sm-4">
                            <label >Grade</label>
                            <asp:DropDownList ID="listGrade" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                <asp:ListItem Value="0">--Select Grade--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="listGrade" runat="server" Display="Dynamic" ForeColor="Red" />

                        </div>

                    </div>
                    <br>
                    <div class="row">
                        <div class="col-sm-4">
                            <label >Role</label>
                            <asp:DropDownList ID="listRole" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                <asp:ListItem Value="0">--Select Role--</asp:ListItem>
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="listRole" runat="server" Display="Dynamic" ForeColor="Red" />


                        </div>
                   
                    <div class="col-sm-4">
                        <label >Date of Birth</label>
                        <asp:TextBox ID="dobirth" runat="server" CssClass="form-control" placeholder="Date of Birth"></asp:TextBox>

                        </div>
                    </div>
                    <br>
                    <div class="row">

                        <div class="col-sm-4">
                            <label >Date of Joining</label>
                            <asp:TextBox ID="dojoining"  runat="server" CssClass="form-control" placeholder="Date of joining"></asp:TextBox>

                        </div>
                        <div class="col-sm-4">
                            <label >PAN</label>
                            <asp:TextBox ID="panno" runat="server" CssClass="form-control" placeholder="PAN"></asp:TextBox>


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
                    <div class="col-sm-4">
                        <h4>Present Address:</h4>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label >House No</label>
                        <asp:TextBox ID="prsnthno" runat="server" CssClass="form-control" placeholder="House No"></asp:TextBox>

                    </div>
                    <div class="col-sm-4">
                        <label >Area</label>
                        <asp:TextBox ID="prsntareastreet" runat="server" CssClass="form-control" placeholder="Area and Street"></asp:TextBox>

                    </div>
                </div>
                <br>
                <div class="row">
                    <div class="col-sm-4">
                        <label >City</label>
                        <asp:DropDownList ID="listCity" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">--Select City--</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <div class="col-sm-4">
                        <label >State</label>
                        <asp:TextBox ID="State" runat="server" CssClass="form-control" placeholder="State"></asp:TextBox>
                    </div>
                </div>
                <br>

                <div class="row">
                    <div class="col-sm-3">
                        <label >PIN</label>
                        <asp:TextBox ID="pin" runat="server" CssClass="form-control" placeholder="PIN"></asp:TextBox>
                    </div>

                </div>
                <br>
                <div class="row">
                    <div class="col-sm-4">
                        <h4>Permanent Address:</h4>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label >House No.</label>
                        <asp:TextBox ID="pmnthno" runat="server" CssClass="form-control" placeholder="House No"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <label >Area</label>
                        <asp:TextBox ID="pmntAreaStreet" runat="server" CssClass="form-control" placeholder="Area and Street"></asp:TextBox>
                    </div>
                </div>
                <br>
                <div class="row">
                    <div class="col-sm-4">
                        <label >City</label>
                        <asp:DropDownList ID="listCitypmnt" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">--Select City--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    
                    <div class="col-sm-4">
                        <label >State</label>
                        
                        <asp:TextBox ID="StatePmnt" runat="server" CssClass="form-control" placeholder="State"></asp:TextBox>
                    
                    </div>
                    </div>

                    <br>
  
                    <div class="row">
                        <div class="col-sm-3">
                            <label >PIN</label>
                            <asp:TextBox ID="pmntPIN" runat="server" CssClass="form-control" placeholder="PIN"></asp:TextBox>
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
                            <label >Passport No</label>
                            <asp:TextBox ID="passportNum" runat="server" CssClass="form-control" placeholder="Passport No"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            <label >Passport Expiry Date</label>
                            <asp:TextBox ID="passExpDate" runat="server" CssClass="form-control" placeholder="Passport Expiry Date(dd/mm/yyyy)"></asp:TextBox>
                        </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-sm-4">
                            <label >Visa Expiry Date</label>
                            <asp:TextBox ID="visExpDate" runat="server" CssClass="form-control" placeholder="Visa Expiry Date(dd/mm/yyyy)"></asp:TextBox>
                       
                            </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-8">
                            <asp:Button ID="AddEmployeeDetail" runat="server" Style="float: right;" CssClass="btn btn-success btn-md" Text="Update" OnClick="AddEmployeeDetail_Click"/>
                            
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
