<%@ Page Title="Edit Resource Demand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditResourceDemand.aspx.cs" Inherits="CapacityPlanning.EditResourceDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Resource Demand</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>

    <div class="row">


        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Edit Resource Demand Status
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">


                                <label>Opportunity Type</label>
                                <asp:DropDownList ID="OpportunityID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>

                            </div>

                            <div class="col-lg-6">
                                <label>Region</label>
                                <asp:DropDownList ID="RegionMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">



                                <label>Account</label>
                                <asp:DropDownList ID="AccountMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-6">
                                <label>Sales Stage</label>
                                <asp:DropDownList ID="SalesStageMasterID" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>



                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">

                                <label>Process Name</label>

                                <asp:TextBox ID="processName" runat="server" CssClass="form-control" placeholder="Process Name"></asp:TextBox>


                            </div>
                            <div class="col-lg-6">
                            </div>
                        </div>
                    </div>


                </div>
            </div>
            <div class="dataTable_wrapper">

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
            </div>
            </div>

        <div class="panel-body">
        <div class="col-md-10 panel-info">
            <div class="row">
                <div class="content-box-large box-with-header">
                    <br />
               <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-2 pull-right">
                                <asp:Button ID="cancel" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel"  formnovalidate />

                            </div>
                            <div >
                    <asp:Button ID="save" runat="server" CssClass="pull-right btn-success btn btn-default" Text="Save" OnClick="Update_Resource_Demand" />
                </div>
</div>
                   </div>
                    </div>
            </div>

        </div>

    </div>
        </div>
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
