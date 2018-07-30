<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddExperience.aspx.cs" Inherits="CapacityPlanning.AddExperience" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="ResourceMaster.aspx">Resource Master</a></li>
            <li class="breadcrumb-item active" aria-current="EditEmployee.aspx">Add Experience Details</li>
        </ol>
    </nav>
    <div class="col-md-10 panel-info">
        <div class="row">
            <div class="content-box-header panel-heading" style="color: white; background-color: #07838a">
                <div class="panel-title ">Experience Details</div>


            </div>
            <div class="content-box-large box-with-header">
                <div>

                    <form method="post">
                    <table class="table table-bordered table-hover" id="tab_logic">
                        <thead>
                            <tr>
                                <th class="text-center">#
                                </th>
                                <th class="text-center">Company Name
                                </th>
                                <th class="text-center">Designation
                                </th>
                                <th class="text-center">From
                                </th>
                                <th class="text-center">To
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id='addr0'>
                                <td>1
                                </td>
                                <td>
                                    <input type="text" name='name0' id="companyName0" runat="server" placeholder='Company Name' class="form-control" />
                                </td>
                                <td>
                                    <input type="text" name='mail0' id="designation0" runat="server" placeholder='Designation' class="form-control" />
                                </td>
                                <td>
                                    <input type="date" name='mobile0' id="from0" runat="server" placeholder='From' class="form-control" />
                                </td>
                                <td>
                                    <input type="date" name='mobil0' id="to0" runat="server" placeholder='To' class="form-control" />
                                </td>
                            </tr>
                            <tr id='addr1'>
                                <td>2
                                </td>
                                <td>
                                    <input type="text" name='name1' id="companyName1" runat="server" placeholder='Company Name' class="form-control" />
                                </td>
                                <td>
                                    <input type="text" name='mail1' id="designation1" runat="server" placeholder='Designation' class="form-control" />
                                </td>
                                <td>
                                    <input type="date" name='mobile1' id="from1" runat="server" placeholder='From' class="form-control" />
                                </td>
                                <td>
                                    <input type="date" name='mobil1' id="to1" runat="server" placeholder='To' class="form-control" />
                                </td>
                            </tr>
                            <tr id='addr2'>
                                <td>3
                                </td>
                                <td>
                                    <input type="text" name='name2' id="companyName2" runat="server" placeholder='Company Name' class="form-control" />
                                </td>
                                <td>
                                    <input type="text" name='mail2' id="designation2" runat="server" placeholder='Designation' class="form-control" />
                                </td>
                                <td>
                                    <input type="date" name='mobile2' id="from2" runat="server" placeholder='From' class="form-control" />
                                </td>
                                <td>
                                    <input type="date" name='mobil2' id="to2" runat="server" placeholder='To' class="form-control" />
                                </td>
                            </tr>
                            <tr id='addr3'></tr>
                        </tbody>
                    </table>
                        </form>
                    <div class="row">


                        <div class="col-sm-1.6">
                            <a id="add_row" class="btn btn-primary pull-left">Add Row</a>

                        </div>
                        <div class="col-sm-1.6">
                            <a id='delete_row' class="pull-left btn btn-danger">Delete Row</a>
                        </div>
                        <div class="col-sm-8.8">
                            <a href="ResourceMaster.aspx" id='submit' class="pull-right btn-success  btn btn-default">Submit</a>
                        </div>

                    </div>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
