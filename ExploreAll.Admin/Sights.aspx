<%@ Page Title="" Language="C#" MasterPageFile="~/system/template/base.Master" AutoEventWireup="true" CodeBehind="Sights.aspx.cs" Inherits="ExploreAll.Admin.Sights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <exploreall:Grid runat="server" DataSource="SightsTable" ID="SightsGrid" Editable="true" GridStyle="alpine" WrapperCssClass="FullWidth Controls"></exploreall:Grid>
    <input id="FileUploader" type="file" hidden/>
    <script>
        pageTitle = "Sights";
        pagePath = "Content";
    </script>
</asp:Content>
