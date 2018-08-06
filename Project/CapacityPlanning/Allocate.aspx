﻿<%@ Page Title="Allocate" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Allocate.aspx.cs" Inherits="CapacityPlanning.Allocate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
 
                    <div class="col-lg-12">
                        <h1 class="page-header"> Project Prioritization</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                     
                </div>
         <div class="row">
                
                       
                    <div class="col-lg-12">
                      
                        <div class="panel panel-default">
                                        
                            <div class="panel-heading">
                               Project Prioritization
                            </div>
                            <!-- /.panel-heading -->
                            <div class="panel-body">
                     
                                <div class="dataTable_wrapper">
                                       
          
                                    <table class="table table-striped table-bordered table-hover" id="dataTables">
                                        <thead>
                                            <tr>
                                                <th>Request Id</th>
                                                 <th>Request Date </th>
                                                <th>Account Name</th>
                                              
                                                <th>Opportunity Type</th>
                                                <th>Sales Stage </th>
                                               
                                                <th>Priority </th>
                                                <th></th>
                                                
                                              
                                            </tr>
                                        </thead>
                                        <tbody>
                                             <asp:Repeater ID="rptResourceAllocation" runat="server" OnItemDataBound="rptResourceAllocation_ItemDataBound">
                                <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td><asp:Label id ="Request" Text='<%#Eval("RequestId")%>' runat="server"/></td>
                                                <td><%#Eval("DateOfCreation", "{0:d}")%> </td>
                                                <td><%#string.Concat(Eval("AccountName"),"-", Eval("CityName"))%></td>
                                                <td ><%#Eval("OpportunityType")%></td>
                                                <td ><%#Eval("SalesStageName")%></td>
                                                <td  ><asp:DropDownList ID="ddlPriorities" runat="server">
                                    </asp:DropDownList></td>
                                                <td class="center" ><ul><i class="fa fa-fw" aria-hidden="true" title="View"></i></ul></td>
                                                
                                            </tr>
                                             </ItemTemplate>

                            </asp:Repeater>
                                 
                                        </tbody>
                                    </table>
                                </div>
                                <!-- /.table-responsive -->
                                
                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
 
                <asp:Button ID="btnSave" Style="float: right;" class="btn btn-success btn-md" runat="server" Text="Save" OnClick="btnSave_Click" />
       

</asp:Content>
