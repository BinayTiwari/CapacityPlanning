<%@ Page Title="Add Resource Demand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddResourceDemand.aspx.cs" Inherits="CapacityPlanning.AddResourceDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
            <li class="breadcrumb-item "><a href="ResourceDemand.aspx">Resource Demand</a></li>
            <li class="breadcrumb-item active">Add Resource Demand</li>
        </ol>
    </nav>
    <div class="col-md-10 panel-info">
        <div class="row">
            <div class="content-box-header panel-heading" style="color: white; background-color: #07838a">
                <div class="panel-title">Add Resource Demand</div>
            </div>

            <div class="content-box-large box-with-header">
                <div>
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:DropDownList ID="RegionMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="RegionMasterID_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="AccountMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>                        
                    </div>
                    <br />
                    
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:DropDownList ID="OpportunityID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="SalesStageMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-sm-4">
                            <asp:TextBox ID="processName" runat="server" CssClass="form-control" placeholder="Process Name"></asp:TextBox>
                        </div>                        
                    </div>                   
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:GridView ID="GridviewResourceDetail" runat="server" ShowFooter="true" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnRowCreated="GridviewResourceDetail_RowCreated">
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="#" />
                            <asp:TemplateField HeaderText="Resource Type" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ResourceTypeID" runat="server" CssClass="form-control" AppendDataBoundItems="true"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No of resources" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:TextBox ID="NoOfResources" TextMode="Number" placeholder='No of Resources' CssClass="form-control" runat="server" required></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Skills" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:ListBox ID="SkillID" CssClass="form-control" AppendDataBoundItems="true" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:TextBox ID="StartDate" TextMode="Date" runat="server" CssClass="form-control" required></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Date" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:TextBox ID="EndDate" TextMode="Date" runat="server" CssClass="form-control" required></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />
                                <FooterTemplate>
                                    <asp:Button ID="ButtonAdd" runat="server" CssClass="btn btn-primary" Text="Add New Row" OnClick="ButtonAdd_Click" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger" OnClick="LinkButton1_Click">Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-1.5 pull-right">
                                <asp:Button ID="cancel" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" OnClick="UnDoButton_Click" formnovalidate />

                            </div>
                            <div>
                                <asp:Button ID="save" runat="server" CssClass="pull-right btn-success btn btn-default" Text="Save" OnClick="Add_Resource_Demand" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://code.jquery.com/jquery.js"></script>
    <!-- jQuery UI -->
    <script src="https://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="vendors/form-helpers/js/bootstrap-formhelpers.min.js"></script>
    <script src="vendors/select/bootstrap-select.min.js"></script>
    <script src="vendors/tags/js/bootstrap-tags.min.js"></script>
    <script src="vendors/mask/jquery.maskedinput.min.js"></script>
    <script src="vendors/moment/moment.min.js"></script>
    <script src="vendors/wizard/jquery.bootstrap.wizard.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>
    

    <script type="text/javascript">  
        $(function () {
            $('[id*=SkillID]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>
</asp:Content>

