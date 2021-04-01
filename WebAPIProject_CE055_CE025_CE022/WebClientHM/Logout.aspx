<%@ Page Title="Logout page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="WebClientHM.Logout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p align ="center">
        <h3>
            You Want to Log out!
        </h3>
        <br />
        <asp:Button ID="btnlogout" Text="LogOut" runat="server" Class="btn btn-danger" OnClick="btnlogout_Click"/>
    </p>

</asp:Content>