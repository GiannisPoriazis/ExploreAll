<%@ Page Title="" Language="C#" MasterPageFile="~/system/template/base.Master" AutoEventWireup="true" CodeBehind="Subscriptions.aspx.cs" Inherits="ExploreAll.Admin.Subscriptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <exploreall:Grid runat="server" DataSource="Subscriptions" ID="SubscriptionsGrid" Editable="true" Permission="8" GridStyle="alpine" WrapperCssClass="FullWidth Controls"></exploreall:Grid>
    <script>
        pageTitle = "Subscriptions";
        pagePath = "Finances";
    </script>
</asp:Content>
