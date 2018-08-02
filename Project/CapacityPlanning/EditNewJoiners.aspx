<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditNewJoiners.aspx.cs" Inherits="CapacityPlanning.EditNewJoiners" %>

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
            <li class="breadcrumb-item"><a href="NewJoiners.aspx">New Joiners</a></li>


            <li class="breadcrumb-item active" aria-current="page">Add New Joiner</li>
        </ol>
    </nav>
    <div class="col-md-10 panel-info">
        <div class="row">
            <div class="content-box-header panel-heading" style="color: white; background-color: #07838a">

                <div class="panel-title ">Add New Joiner</div>


            </div>
            <div class="content-box-large box-with-header">
                <div>



                    <div class="row">
                        <div class="col-sm-8">
                            <label>Name</label>
                            <asp:TextBox ID="firstNameTextBox" CssClass="form-control" placeholder="Name" runat="server" required></asp:TextBox>
                        </div>

                    </div>
                    <br>
                    <div class="row">

                        <div class="col-sm-4">
                            <label>Desgnation</label>
                            <asp:DropDownList ID="listDesignation" AppendDataBoundItems="true" CssClass="form-control" runat="server" required>
                                <asp:ListItem>--Select Designation--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <label>Date of Joining</label>
                            <asp:TextBox ID="dojTextBox" CssClass="form-control" Placehplder="Date of Joining (DD/MM/YYYY)" runat="server" required></asp:TextBox>

                        </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-sm-4">
                            <label>Base Locaton</label>
                            <asp:TextBox ID="baseLocationTextBox" Placeholder="Base Location" CssClass="form-control" runat="server" required></asp:TextBox>

                        </div>
                        <div class="col-sm-4">
                            <label>Experience</label>

                            <asp:TextBox ID="expTextBox" Placeholder="Experience" CssClass="form-control" runat="server" required></asp:TextBox>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col-sm-4">
                            <label>Account</label>
                            <asp:DropDownList ID="accountDropDownList" AppendDataBoundItems="true" CssClass="form-control" runat="server" required>
                                <asp:ListItem>--Select Account--</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-sm-4">
                            <label>Interviewed By</label>
                            <asp:TextBox ID="interviewedTextBox" Placeholder="Interviewed By" CssClass="form-control" runat="server" required></asp:TextBox>
                        </div>

                    </div>
                    <br>
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:Label ID="Label1" class="form-control" runat="server" Text="Select Skills: "></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:ListBox ID="skillList" class="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">

                        <div class="col-sm-8">
                            <div class="col-md-2 pull-right" >
                            <asp:Button ID="UnDoButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click"/>
                                </div>
                            <div>
                            <asp:Button ID="NewJoinerButton" Style="float: right;" CssClass="btn btn-success btn-md" OnClick="NewJoinerButton_Click" runat="server" Text="Save" />
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('[id*=skillList]').multiselect({
                includeSelectAllOption: true
            });
            $("#NewJoinerButton").click(function () {
                alert($(".multiselect-selected-text").html());
            });
        });
    </script>
</asp:Content>
