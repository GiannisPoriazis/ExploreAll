<%@ Page Title="" Language="C#" MasterPageFile="~/system/template/base.Master" AutoEventWireup="true" CodeBehind="CustomerAccounts.aspx.cs" Inherits="ExploreAll.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
     <exploreall:Grid runat="server" DataSource="CustomersTable" ID="CustomersGrid" Editable="true" Permission="0" GridStyle="alpine" WrapperCssClass="FullWidth Controls"></exploreall:Grid>
    <input id="FileUploader" type="file" hidden/>
    <script>
        pageTitle = "Customer Accounts";
        pagePath = "Account Management";
    </script>

</asp:Content>
