<%@ Page Title="Resource Master" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Allocate.aspx.cs" Inherits="CapacityPlanning.Allocate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-10">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>

                <li class="breadcrumb-item active" aria-current="page">Allocation</li>
            </ol>
        </nav>

        <div class="row">
            <div class="col-md-12">
                <div class="panel-heading">
                    <div class="panel-title">Allocation </div>

                   


                </div>
                <br />
                <br />
                <div class="content-box-large">
                    <asp:GridView ID="GridView1" Width="100%" runat="server" DataKeyNames="RequestID,AccountMasterID,EmployeeMasterID,SalesStageMasterID,PriorityID" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                        CssClass="pager rows header1 mygrdContent" ShowFooter="false" AutoGenerateColumns="False" 
                        
                        
                         BackColor="White" BorderColor="White" EmptyDataText="N/A" Font-Size="Medium" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Names="Calibri" Font-Overline="False" ForeColor="#003300" GridLines="Horizontal">


                        <AlternatingRowStyle BackColor="#F9F9F9" CssClass="table table-striped" />


                        <Columns>
                            
                            <asp:BoundField DataField="RequestID" HeaderText="Request ID" />
                            <asp:BoundField DataField="AccountName" HeaderText="Account Name" />
                            <asp:BoundField DataField="ReportingManager" HeaderText="Reporting Manager" />
                            <asp:BoundField DataField="ProcessName" HeaderText="Process Name" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                            <asp:BoundField DataField="SalesStageName" HeaderText="Sales Stage Name" />
                            <asp:BoundField DataField="NoOfResources" HeaderText="No Of Resources" />
                            <asp:BoundField DataField="PriorityName" HeaderText="Priority Name" />
                            

                        </Columns>
                        
                        <FooterStyle BackColor="White" />


                        <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />


                        <PagerSettings Mode="NumericFirstLast" NextPageImageUrl="~/images/126490.png" PageButtonCount="5" />


                        <RowStyle Font-Names="Calibri" />


                        <SelectedRowStyle BorderStyle="Inset" />


                    </asp:GridView>


                </div>
            </div>
        </div>
    </div>


</asp:Content>
