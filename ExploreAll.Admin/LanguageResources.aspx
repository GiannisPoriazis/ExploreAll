<%@ Page Title="" Language="C#" MasterPageFile="~/system/template/base.Master" AutoEventWireup="true" CodeBehind="LanguageResources.aspx.cs" Inherits="ExploreAll.Admin.LanguageResources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
         <exploreall:Grid runat="server" DataSource="Resources" ID="ResourcesGrid" Editable="true" Permission="4" GridStyle="alpine" WrapperCssClass="FullWidth Controls"></exploreall:Grid>
     <input id="FileUploader" type="file" hidden/>
    <script>
        pageTitle = "Translation Management";
        pagePath = "Setup";
    </script>
</asp:Content>
