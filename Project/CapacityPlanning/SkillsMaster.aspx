<%@ Page Title="Skills Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SkillsMaster.aspx.cs" Inherits="CapacityPlanning.SkillsMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Manage Skills</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>

    <div class="row">
        <div class="form-group form-inline col-lg-12">
            <asp:TextBox ID="SkillsNameTextBox" placeholder="Skills Name" CssClass="form-control" runat="server" required></asp:TextBox>

            <asp:Button ID="SkillsAddButton" runat="server" Text="Add Skills" CssClass="btn btn-md btn-success" OnClick="SkillsAddButton_Click" />
        </div>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorSkills" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="SkillsNameTextBox"
            ValidationExpression="^[A-Za-z][A-Za-z ]+$" ErrorMessage="*Only Alphabets are allowed." />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSkills" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="SkillsNameTextBox" 
    ErrorMessage="*Only Alphabets are allowed." />

        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Skills Details
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper">
                        <asp:GridView ID="gvSkills" runat="server" DataKeyNames="SkillsMasterID" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                            CssClass="table table-striped table-bordered table-hover" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                            OnRowDeleting="delete"
                            OnRowCancelingEdit="canceledit"
                            OnRowUpdating="update" EmptyDataText="No records to show" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField ReadOnly="True" DataField="SkillsMasterID" HeaderText="Skills ID" />
                                <asp:BoundField DataField="SkillsName" HeaderText="Skills" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ButtonEdit" runat="server" CssClass="center-block" ImageUrl="~/images/22.png" CommandName="Edit" CausesValidation="false"  formnovalidate />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/images/yes.png" Width="25px" Height="25px" ID="ButtonUpdate" runat="server" CommandName="Update" CausesValidation="false" formnovalidate />
                                        <asp:ImageButton ImageUrl="~/images/cross-red.png" Width="25px" Height="25px" ID="ButtonCancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" formnovalidate />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/trash.png" HeaderText="" />--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="DeleteButton" runat="server" CssClass="center-block" ImageUrl="~/images/11.png"
                                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this Account?');"
                                            AlternateText="Delete" CausesValidation="false" formnovalidate />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>


                    </div>
                    <!-- /.table-responsive -->

                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
