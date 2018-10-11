<%@ Page Title="SkillsSet" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetSkills.aspx.cs" Inherits="CapacityPlanning.SetSkills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Skill Set</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>

    <div class="row">

        <asp:Button ID="backButton" runat="server" CssClass="btn btn-primary pull-right" Text="&#8617; Back" PostBackUrl="#"></asp:Button>


        <div class="col-lg-12">
            <div class="panel panel-default">

                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-4">
                            <label>Please enter your Employee ID<span style="color: red;"> *</span></label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="EmpID" runat="server" MaxLength="6" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorfirstNameTextBox" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="EmpID"
                            ValidationExpression="^[0-9]{5,6}$" ErrorMessage="Invalid Employee ID !" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="EmpID"
                            ErrorMessage="Employee ID Required !" />
                        <asp:Label ID="lblEmpID" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1">
                            <label>Skills:<span style="color: red;"> *</span></label>
                        </div>
                        <div class="col-md-11">
                            <br />
                            <div class="row">
                                <asp:DataList ID="dtlSkills" runat="server" RepeatColumns="3" RepeatDirection="horizontal">
                                    <ItemTemplate>
                                        <div class="col-lg-4">
                                            <asp:CheckBox ID="chkSkill" SkillID='<%#Eval("SkillsMasterID") %>'
                                                OnCheckedChanged="chkSkill_CheckedChanged" runat="server" />

                                            <%#DataBinder.Eval(Container,"DataItem.SkillsName")%>
                                        </div>
                                    </ItemTemplate>

                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <!-- /.table-responsive -->
                    <div class="row ">
                        <div class="col-md-2 pull-right">
                            <asp:Button ID="Submit" runat="server" CssClass="btn btn-success" Text="Submit"
                                OnClick="UpdateEmpSkills"></asp:Button>
                        </div>
                        <div class="col-md-2 pull-right">
                            <asp:Button ID="Cancel" runat="server" CssClass="btn btn-danger" Text="Cancel"
                                CausesValidation="false"></asp:Button>
                        </div>
                    </div>
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>

