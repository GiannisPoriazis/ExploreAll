<%@ Page Title="" Language="C#" MasterPageFile="~/system/template/base.Master" AutoEventWireup="true" CodeBehind="UserAccounts.aspx.cs" Inherits="ExploreAll_Admin.UserAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <exploreall:Grid runat="server" DataSource="UserTable" ID="UsersGrid" Editable="true" GridStyle="alpine" WrapperCssClass="FullWidth Controls" Permission="ManageAccounts"></exploreall:Grid>
    <script>
        pageTitle = "User Accounts";
        pagePath = "Account Management";
    </script>
</asp:Content>
