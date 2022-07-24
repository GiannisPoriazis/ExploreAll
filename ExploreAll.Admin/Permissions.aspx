<%@ Page Title="" Language="C#" MasterPageFile="~/system/template/base.Master" AutoEventWireup="true" CodeBehind="Permissions.aspx.cs" Inherits="ExploreAll.Admin.Permissions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <exploreall:Grid runat="server" DataSource="UserPermissions" ID="PermissionsGrid" Editable="true" GridStyle="alpine" WrapperCssClass="FullWidth Controls"></exploreall:Grid>
    <script>
        pageTitle = "Permissions";
        pagePath = "Account Management";
    </script>
</asp:Content>