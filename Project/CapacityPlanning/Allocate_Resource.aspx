<%@ Page Title="Allocate Resource" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Allocate_Resource.aspx.cs" Inherits="CapacityPlanning.Allocate_Resource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-10">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>

                <li class="breadcrumb-item active" aria-current="page">Allocate Resources</li>
            </ol>
        </nav>

        <div class="row">
            <div class="col-md-12">
                <div class="panel-heading">
                    <div class="panel-title">Allocate Resources</div>

                </div>
                <br />
                <div class="content-box-large">
                    <asp:GridView ID="gdvAllocateResources" Width="100%" runat="server" OnPageIndexChanging="OnPageIndexChanging"
                        CssClass="pager rows header1 mygrdContent" AutoGenerateColumns="False" 
                        
                         BackColor="White" BorderColor="White" EmptyDataText="N/A" Font-Size="Medium" OnSelectedIndexChanged="gdvAllocateResources_SelectedIndexChanged" Font-Names="Calibri" Font-Overline="False" ForeColor="#003300" GridLines="Horizontal" OnRowDataBound="gdvAllocateResources_RowDataBound">

                        <AlternatingRowStyle BackColor="#F9F9F9" CssClass="table table-striped" />

                        <Columns>
                            
                            <asp:BoundField DataField="DesignationName" ReadOnly="true" HeaderText="Resource Type" />
                            <asp:BoundField DataField="NoOfResources" HeaderText="Resources" />
                            <asp:BoundField DataField="SkillsName" HeaderText="Tool/Domain Knowledge" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="EndDate" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="StatusName" HeaderText="Status" />
                            <asp:BoundField DataField="PriorityName" HeaderText="Priority" />
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-md" CommandName="Update" HeaderText="Align to Project" ShowHeader="False" Text="Align"/>
                            
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
                <%--<asp:Button ID="btnSave" style="float: left;" class="btn btn-success btn-md" runat="server" Text="Save" OnClick="btnSave_Click" />--%>
                 <br />
                <br />
            </div>
        </div>
    </div>

</asp:Content>
