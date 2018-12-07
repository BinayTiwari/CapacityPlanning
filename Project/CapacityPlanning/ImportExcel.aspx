<%@ Page Title="Import Data" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportExcel.aspx.cs" Inherits="CapacityPlanning.ImportExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Import Excel</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>
    <div class="row">
        <div id ="Ui" runat="server">
            <div class="center-block">
                <div class="col-md-3">
                    <asp:FileUpload ID="FileUpload1" CssClass="" runat="server" />
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnUpload" CssClass="btn btn-success" runat="server" Text="Upload Excel"
                        OnClick="btnUpload_Click" />
                </div>
                <br />
            </div>
        </div>
        <div id="gridView" style="display: none;" runat="server">
            <asp:GridView ID="GridView1" runat="server"
                OnPageIndexChanging="PageIndexChanging" AllowPaging="true">
            </asp:GridView>
        </div>
        <%--<asp:GridView ID="GridView2" runat="server"
                OnPageIndexChanging="PageIndexChanging2" AllowPaging="true">
            </asp:GridView>
            <asp:GridView ID="GridView3" runat="server"
                OnPageIndexChanging="PageIndexChanging3" AllowPaging="true">
            </asp:GridView>
            <asp:GridView ID="GridView4" runat="server"
                OnPageIndexChanging="PageIndexChanging4" AllowPaging="true">
            </asp:GridView>--%>
    </div>
</asp:Content>

