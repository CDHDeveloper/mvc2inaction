﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountProfile.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Log On</h2>
    <p>
        Please enter your username and password. <%= Html.ActionLink("Register", "Register") %> if you don't have an account.
    </p>
    <%= Html.ValidationSummary("Login was unsuccessful. Please correct the errors and try again.") %>

<% using (Html.BeginForm()) { %>
    <div>
        <fieldset>
            <legend>Account Information</legend>
            <%= Html.EditorForModel() %>
            <p>
                <input type="submit" value="Log On" />
            </p>
        </fieldset>
    </div>
<% } %>
</asp:Content>
