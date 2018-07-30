<%@ Page Title="Edit Resource Demand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditResourceDemand.aspx.cs" Inherits="CapacityPlanning.EditResourceDemand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
            <li class="breadcrumb-item "><a href="ResourceDemand.aspx">Resource Demand</a></li>
            <li class="breadcrumb-item active">Edit Resource Demand</li>
        </ol>
    </nav>
    <div class="col-md-10 panel-info">
        <div class="row">
            <div class="content-box-header panel-heading" style="color: white; background-color: #07838a">
                <div class="panel-title ">Edit Resource Demand</div>
            </div>

            <div class="content-box-large box-with-header">
                <div>
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:DropDownList ID="AccountMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="RegionMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:DropDownList ID="CountryMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="CityID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br>

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
                    <br>
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:TextBox ID="processName" runat="server" CssClass="form-control" placeholder="Process Name"></asp:TextBox>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="PriorityID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />

                    <table class="table table-bordered table-hover" id="tab_logic">
                        <thead>
                            <tr>
                                <th class="text-center">#
                                </th>
                                <th class="text-center">Resource Type
                                </th>
                                <th class="text-center">No of Resources
                                </th>
                                <th class="text-center">Tool/Domain Knowledge
                                </th>
                                <th class="text-center">Start Date
                                </th>
                                <th class="text-center">End Date
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id='addr0'>
                                <td>1
                                </td>
                                <td>
                                    <asp:DropDownList ID="ResourceType" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">Select ResourceType</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="NoOfResources0" runat="server" TextMode="Number" CssClass="form-control" placeholder='No of Resources'>
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:ListBox ID="SkillList0" CssClass="form-control" AppendDataBoundItems="true" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="From0" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="To0" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id='addr1'>
                                <td>2
                                </td>
                                <td>
                                    <asp:DropDownList ID="ResourceType1" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">Select ResourceType</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="NoOfResources1" runat="server" TextMode="Number" CssClass="form-control" placeholder='No of Resources'>
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:ListBox ID="SkillList1" CssClass="form-control" AppendDataBoundItems="true" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="From1" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="To1" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id='addr2'>
                                <td>3
                                </td>
                                <td>
                                    <asp:DropDownList ID="ResourceType2" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">Select ResourceType</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="NoOfResources2" runat="server" TextMode="Number" CssClass="form-control" placeholder='No of Resources'>
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:ListBox ID="SkillList2" CssClass="form-control" AppendDataBoundItems="true" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="From2" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="To2" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    
                    <div class="row">
                        <div class="col-md-1">
                            <asp:Button ID="add_row" runat="server" CssClass="btn btn-primary pull-left" Text="Add Row" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="delete_row" runat="server" CssClass="btn btn-danger pull-left" Text="Delete Row" />
                        </div>
                        <div class="col-md-9">
                            <asp:Button ID="save" runat="server" CssClass="pull-right btn-success btn btn-default" Text="Save" OnClick="Update_Resource_Demand" />
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
    <!-- bootstrap-datetimepicker -->
    <link href="vendors/bootstrap-datetimepicker/datetimepicker.css" rel="stylesheet">
    <script src="vendors/bootstrap-datetimepicker/bootstrap-datetimepicker.js"></script>
    <link href="//cdnjs.cloudflare.com/ajax/libs/x-editable/1.5.0/bootstrap3-editable/css/bootstrap-editable.css" rel="stylesheet" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/x-editable/1.5.0/bootstrap3-editable/js/bootstrap-editable.min.js"></script>

    <script>
        $(".dropdown dt a").on('click', function () {
            $(".dropdown dd ul").slideToggle('fast');
        });
        $(".dropdown dd ul li a").on('click', function () {
            $(".dropdown dd ul").hide();
        });
        function getSelectedValue(id) {
            return $("#" + id).find("dt a span.value").html();
        }
        $(document).bind('click', function (e) {
            var $clicked = $(e.target);
            if (!$clicked.parents().hasClass("dropdown")) $(".dropdown dd ul").hide();
        });
        $('.mutliSelect input[type="checkbox"]').on('click', function () {
            var title = $(this).closest('.mutliSelect').find('input[type="checkbox"]').val(),
                title = $(this).val() + ",";
            if ($(this).is(':checked')) {
                var html = '<span title="' + title + '">' + title + '</span>';
                $('.multiSel').append(html);
                $(".hida").hide();
            } else {
                $('span[title="' + title + '"]').remove();
                var ret = $(".hida");
                $('.dropdown dt a').append(ret);
            }
        });
    </script>
    <script type="text/javascript">  
        $(function () {
            $('[id*=SkillList0]').multiselect({
                includeSelectAllOption: true
            });
            $('[id*=SkillList1]').multiselect({
                includeSelectAllOption: true
            });
            $('[id*=SkillList2]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>
    <script src="~/Scripts/dynamic_demand.js"></script>
</asp:Content>
