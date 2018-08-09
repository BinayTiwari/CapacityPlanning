<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditNewJoiners.aspx.cs" Inherits="CapacityPlanning.EditNewJoiners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <div class="col-lg-12">
        <h1 class="page-header">Manage New Joiner</h1>
    </div>
    <!-- /.col-lg-12 -->

    <div class="row">

        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Add New Joiner
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Name</label>
                                <asp:TextBox ID="firstNameTextBox" CssClass="form-control" placeholder="Name" runat="server" required></asp:TextBox>
                            </div>

                            <div class="col-lg-6">
                                <label>Skill</label>
                                <asp:DropDownList ID="skillListDD" class="form-control" runat="server" SelectionMode="Multiple"></asp:DropDownList>

                            </div>

                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Designation</label>
                                <asp:DropDownList ID="listDesignation" AppendDataBoundItems="true" CssClass="form-control" runat="server" required>
                                    <asp:ListItem>--Select Designation--</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-6">
                                <label>Date of Joining</label>
                                <asp:TextBox ID="dojTextBox" ToolTip="Date of joining" Placeholder="Date of Joining" CssClass="form-control" runat="server" required></asp:TextBox>

                            </div>

                        </div>

                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Base Location</label>
                                <asp:TextBox ID="baseLocationTextBox" Placeholder="Base Location" CssClass="form-control" runat="server" required></asp:TextBox>

                            </div>
                            <div class="col-lg-6">
                                <label>Experience</label>
                                <asp:TextBox ID="expTextBox" Placeholder="Experience" CssClass="form-control" runat="server" required></asp:TextBox>

                            </div>


                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Account</label>
                                <asp:DropDownList ID="accountDropDownList" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="">--Select Account--</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-6">
                                <label>Interviewed By</label>
                                <asp:TextBox ID="interviewedTextBox" Placeholder="Interviewed By" CssClass="form-control" runat="server" required></asp:TextBox>
                            </div>


                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-3 pull-right">
                            <div class="col-sm-2s pull-right">
                                <asp:Button ID="UnDoButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" />
                            </div>
                        </div>
                        <div class="col-sm-2s pull-right">
                            <asp:Button ID="NewJoinerButton" Style="float: right;" CssClass="btn btn-success btn-md" OnClick="NewJoinerButton_Click" runat="server" Text="Save" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
