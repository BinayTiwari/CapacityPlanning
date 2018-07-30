<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddExperience.aspx.cs" Inherits="CapacityPlanning.AddExperience" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="Gridview1" runat="server" ShowFooter="true"
        AutoGenerateColumns="false"
        OnRowCreated="Gridview1_RowCreated">
        <Columns>
            <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
            <asp:TemplateField HeaderText="Header 1">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Header 2">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Header 3">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">Select</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Header 4">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server"
                        AppendDataBoundItems="true">
                        <asp:ListItem Value="-1">Select</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                    <asp:Button ID="ButtonAdd" runat="server"
                        Text="Add New Row"
                        OnClick="ButtonAdd_Click" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server"
                        OnClick="LinkButton1_Click">Remove</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
