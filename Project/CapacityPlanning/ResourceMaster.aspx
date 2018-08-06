<%@ Page Title="Resource Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResourceMaster.aspx.cs" Inherits="CapacityPlanning.ResourceMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
 
                    <div class="col-lg-12">
                        <h1 class="page-header">Manage Employees</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                     
                </div>
        
               <div class="row">
                   <div style="float: right;">        <asp:Button ID="AddEmployee" runat="server" Text="Add Employee" class="btn btn-primary"
                        PostBackUrl="AddEmployee.aspx" /></div>
             
                       
                    <div class="col-lg-12">
                      
                        <div class="panel panel-default">
                                        
                            <div class="panel-heading">
                                Employee List
                            </div>
                            <!-- /.panel-heading -->
                            <div class="panel-body">
                     
                                <div class="dataTable_wrapper">
                                           
          
                                    <table class="table table-striped table-bordered table-hover" id="dataTables">
                                        <thead>
                                            <tr>
                                                <th></th>
                                                 <th>Employee ID </th>
                                                <th>Name</th>
                                              
                                                <th>Reporting Manager</th>
                                                <th>Location</th>
                                               
                                                <th>Role </th>
                                                <th></th>
                                                <th></th>
                                              
                                            </tr>
                                        </thead>
                                        <tbody>
                                             <asp:Repeater ID="rptResourceMaster" runat="server">
                                <ItemTemplate>
                                            <tr class="odd gradeX">
                                                <td>  <asp:Image ID="Image1" Height="40" Width="40" runat="server"   ImageUrl="~/images/user.png" /></td>
                                                <td><%#Eval("EmployeeMasterID")%> </td>
                                                <td><%#Eval("EmployeetName")%> </td>
                                                <td><%#Eval("mgrName")%></td>
                                                <td ><%#Eval("BaseLocation")%></td>
                                                <td ><%#Eval("RoleName")%></td>
                                                 <td class="center" ><ul><i class="fa fa-fw" aria-hidden="true" title="View"></i></ul></td>
                                                <td class="center" ><ul><i class="fa fa-fw" aria-hidden="true" title="Edit"></i></ul></td>
                                                
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
   
    
    
  

</asp:Content>
