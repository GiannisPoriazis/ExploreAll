<%@ Page Title="" Language="C#" MasterPageFile="~/system/template/base.Master" AutoEventWireup="true" CodeBehind="NotificationsManager.aspx.cs" Inherits="ExploreAll.Admin.NotificationsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="col-4">
        <div class="form-group">
            <label for="notifTitle">Notification Title</label>
            <input id="notifTitle" name="notifTitle" class="form-control" placeholder="My title">
        </div>
        <div class="form-group">
            <label for="notifMessage">Message</label>
            <textarea id="notifMessage" name="notifMessage" class="form-control" placeholder="My message"></textarea>
        </div>
        <button id="submitNotif" type="button" class="btn btn-primary">Send</button>
    </div>
    <script>
        $(document).ready(() => {
            pagePath = "Account Management";
            pageTitle = "Notifications Manager";
            $(".pageheader-title").text(pageTitle);
            $(".breadcrumb-link").text(pagePath);
            $(".breadcrumb-item.active").text(pageTitle);

            $("#submitNotif").click(() => {
                let notifTitle = $("#notifTitle");
                let notifMessage = $("#notifMessage");

                if (!$(notifTitle).val() || !$(notifMessage).val()) {
                    alert("Please fill out required fields.");
                    return;
                }

                let notif = {
                    Sender: user,
                    Title: $(notifTitle).val(),
                    Message: $(notifMessage).val()
                }

                hub.server.broadcastMessage(notif);

                $(notifTitle).val("");
                $(notifMessage).val("");
            });
        });
    </script>
</asp:Content>
