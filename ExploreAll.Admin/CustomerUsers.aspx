<%@ Page Title="" Language="C#" MasterPageFile="~/system/template/base.Master" AutoEventWireup="true" CodeBehind="CustomerUsers.aspx.cs" Inherits="ExploreAll.Admin.CustomerUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <exploreall:Grid runat="server" DataSource="CustomerUsers" ID="CustomerUsersGrid" Editable="true" Permission="0" GridStyle="alpine" WrapperCssClass="FullWidth Controls"></exploreall:Grid>
    <script>
        pageTitle = "Customer Users";
        pagePath = "Account Management";
    </script>
</asp:Content>
