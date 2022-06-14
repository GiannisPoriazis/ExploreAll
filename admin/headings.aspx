<%@ Page Title="" Language="C#" MasterPageFile="~/admin/system/template/base.Master" AutoEventWireup="true" CodeBehind="headings.aspx.cs" Inherits="ExploreAll.admin.pages.headings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <exploreall:Grid runat="server" DataSource="headingsTable" ID="headingsGrid" Editable="true" GridStyle="alpine" WrapperCssClass="FullWidth Controls"></exploreall:Grid>
    <script>
        pageTitle = "Headings";
        pagePath = "General";
    </script>
</asp:Content>
