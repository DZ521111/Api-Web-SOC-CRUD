<%@ Page Title="PLogin page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PLogin.aspx.cs" Inherits="WebClientHM.PLogin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
    media="screen" />

    <form id="form1" align ="center">
        <div style="max-width: 400px;">
            <h2 class="form-signin-heading">
                Patient Login</h2>
            <label for="plemail">
                Username</label>
            <asp:TextBox ID="plemail" runat="server" CssClass="form-control" placeholder="Enter Username"
                required />
            <br />
            <label for="plpasswd">
                Password</label>
            <asp:TextBox ID="plpasswd" runat="server" TextMode="Password" CssClass="form-control"
                placeholder="Enter Password" required />
            <br />
            <asp:Button ID="btnplogin" Text="Sign In" runat="server" Class="btn btn-primary" OnClick="btnplogin_Click"/>
            <br />
            <br />
            <asp:Label ID="errplogin" runat="server" />
            </div>
        </div>
    </form>

</asp:Content>

