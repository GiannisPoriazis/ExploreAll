<%@ Page Title="" Language="C#" MasterPageFile="~/system/template/base.Master" AutoEventWireup="true" CodeBehind="Hosts.aspx.cs" Inherits="ExploreAll.Admin.Hosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <exploreall:Grid runat="server" DataSource="HostTable" ID="HostGrid" Editable="true" Permission="6" GridStyle="alpine" WrapperCssClass="FullWidth Controls"></exploreall:Grid>
    <script>
        pageTitle = "Website Hosts";
        pagePath = "Setup";
    </script>
</asp:Content>
