<%@ Page Title="View Employeee" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewEmployee.aspx.cs" Inherits="CapacityPlanning.viewEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
    
    </style>

    <div class="col-lg-12">
        <h1 class="page-header">Manage Employee</h1>
    </div>
    <!-- /.col-lg-12 -->

    <div class="row">

        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                   <asp:Label ID="nameLBL" Text="" runat="server"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="row">
								<div class="col-md-3">
									<img src="images/user.png" class="rounded-circle" width="100px" height="100px">
								</div>
								<div class="col-md-9">
									<h4> <asp:Label ID="Name" runat="server" Text=""></asp:Label> </h4>
									<h4> <asp:Label ID="mailID" runat="server" Text=""></asp:Label> </h4>
									<h4>RPA </h4>
									<p><span class="fa fa-star checked"></span>
									<span class="fa fa-star checked"></span>
									<span class="fa fa-star checked"></span>
									<span class="fa fa-star checked"></span>
									<span class="fa fa-star"></span></p>
								</div>
							</div>
                </div>

                <div class="panel-body">

                      
                    
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-5">
                                <label>Employee ID</label>
                                <asp:TextBox ID="empIdText" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>

                           

                        </div>
                    </div>


                   

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-5">
                                <label>Reporting Manager</label>
                                <asp:DropDownList ID="RManagerDropDownList" AppendDataBoundItems="true" CssClass="form-control" runat="server" Enabled="false">
                                    <asp:ListItem Value="">--Select Reporting Manager--</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-lg-5">
                                <label>Base Location</label>
                                <asp:TextBox ID="bLocation" runat="server" CssClass="form-control" readonly></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-5">
                                <label>Designation</label>
                                <asp:DropDownList ID="listDesignation" AppendDataBoundItems="true" CssClass="form-control" runat="server" Enabled="false" >
                                    <asp:ListItem Value="">--Select Designation--</asp:ListItem>
                                </asp:DropDownList>

                            </div>

                            <div class="col-lg-5">
                                <label>Mobile No.</label>
                                <asp:TextBox ID="phone" TextMode="Phone" runat="server" CssClass="form-control" readonly></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-5">
                                <label>Role</label>
                                <asp:DropDownList ID="listRole" AppendDataBoundItems="true" CssClass="form-control" runat="server" Enabled="false" >
                                    <asp:ListItem Value="">--Select Role--</asp:ListItem>
                                </asp:DropDownList>

                            </div>

                            <div class="col-lg-5">
                                <label>Date of Joining</label>
                                <asp:TextBox ID="dojoining" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>

                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-5">
                                <label>Skill</label>
                                <asp:DropDownList ID="listSkillDD" CssClass="form-control" runat="server" Enabled="false" ></asp:DropDownList>
                            </div>

                            <div class="col-lg-5">
                                <label>PAN</label>
                                <asp:TextBox ID="panNoTxt" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-5">
                                <label>Address</label>
                                <asp:TextBox ID="addressTxt" TextMode="MultiLine" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
                            </div>


                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-5">
                            <h5>Passport and visa details:</h5>

                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-5">
                                <label>Passport No.</label>
                                <asp:TextBox ID="passportNum" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>


                            </div>

                            <div class="col-lg-5">
                                <label>Passport Expiry Date</label>
                                <asp:TextBox ID="passExpDate" runat="server" CssClass="form-control"  Enabled="false" ></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-5">
                                <label>Visa Expiry Date</label>
                                <asp:TextBox ID="visExpDate" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>


                            </div>


                        </div>
                    </div>
                       <div class="row">
                        <div class="col-sm-5">
                            <h5>Experience details:</h5>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-5">
                                <label>Prior Experience</label>
                                <asp:TextBox ID="expText" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>


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
            $("#Button1").click(function () {
                alert($(".multiselect-selected-text").html());
            });
        });
    </script>
</asp:Content>
