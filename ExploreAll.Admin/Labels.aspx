<%@ Page Title="" Language="C#" MasterPageFile="~/system/template/base.Master" AutoEventWireup="true" CodeBehind="Labels.aspx.cs" Inherits="ExploreAll_Admin.Labels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <exploreall:Grid runat="server" DataSource="LabelsTable" ID="LabelsGrid" Editable="true" GridStyle="alpine" WrapperCssClass="FullWidth Controls"></exploreall:Grid>
    <script>
        pageTitle = "Labels";
        pagePath = "Content";
    </script>
</asp:Content>
