<%@ Page Title="Allocate" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Allocate.aspx.cs" Inherits="CapacityPlanning.Allocate" %>

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
                <div class="content-box-large">
                    <asp:GridView ID="GridView1" Width="100%" runat="server" OnPageIndexChanging="OnPageIndexChanging"
                        CssClass="pager rows header1 mygrdContent" AutoGenerateColumns="False" 
                        
                         BackColor="White" BorderColor="White" EmptyDataText="N/A" Font-Size="Medium" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Font-Names="Calibri" Font-Overline="False" ForeColor="#003300" GridLines="Horizontal" OnRowDataBound="GridView1_RowDataBound">

                        <AlternatingRowStyle BackColor="#F9F9F9" CssClass="table table-striped" />

                        <Columns>
                            
                            <asp:BoundField DataField="RequestID" ReadOnly="true" HeaderText="Request ID" />
                            <asp:BoundField DataField="AccountName" HeaderText="Account Name" />
                            <asp:BoundField DataField="ReportingManagerID" HeaderText="Reporting Manager" />
                            <asp:BoundField DataField="ProcessName" HeaderText="Process Name" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                            <asp:BoundField DataField="SalesStageName" HeaderText="Sales Stage Name" />
                            <asp:BoundField DataField="NoOfResources" HeaderText="No Of Resources" />
                            <asp:BoundField DataField="PriorityName" HeaderText="Priority Name"  Visible = "false" />

                            <asp:TemplateField HeaderText = "Priority Name">
            <ItemTemplate>
                <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("PriorityName") %>' Visible = "false" />
                <asp:DropDownList ID="ddlPriorities" runat="server">
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
                            
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-md" CommandName="Update" HeaderText="Allocate" ShowHeader="True" Text="Allocate"/>
                            
                        </Columns>
                        
                        <FooterStyle BackColor="White" />

                        <HeaderStyle BackColor="White" BorderColor="White" BorderStyle="None" />

                        <PagerSettings Mode="NumericFirstLast" NextPageImageUrl="~/images/126490.png" PageButtonCount="5" />

                        <RowStyle Font-Names="Calibri" />

                        <SelectedRowStyle BorderStyle="Inset" />

                    </asp:GridView>

                </div>
                <br />
                <br />
                <asp:Button ID="btnSave" style="float: left;" class="btn btn-success btn-md" runat="server" Text="Save" OnClick="btnSave_Click" />
                 <br />
                <br />
            </div>
        </div>
    </div>

</asp:Content>
