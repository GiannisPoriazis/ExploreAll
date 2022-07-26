<%@ Page Title="" Language="C#" MasterPageFile="~/system/template/base.Master" AutoEventWireup="true" CodeBehind="StoreManagement.aspx.cs" Inherits="ExploreAll.Admin.StoreManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <exploreall:Grid runat="server" DataSource="UserTable" Editable="true" Permission="2" GridStyle="alpine" ID="UserGrid" WrapperCssClass="FullWidth Controls"></exploreall:Grid>
    <script>
        pageTitle = "Store Management";
        pagePath = "Content";
    </script>
</asp:Content>
