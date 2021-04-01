<%@ Page Title="BookAppointment page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookAppointment.aspx.cs" Inherits="WebClientHM.BookAppointment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
    media="screen" />

    <form id="form1" align ="center">
        <div style="max-width: 400px;">
            <h2 class="form-signin-heading">
                Book Appointment</h2>
            <br />
            <label for="doctoremail">
                Doctor Email</label>
            <asp:TextBox ID="doctoremail" runat="server" TextMode="Email" CssClass="form-control" placeholder="Enter Doctor's Email"
                required />
            <br />
            <label for="patientemail">
                Patient Email</label>
            <asp:TextBox ID="patientemail" runat="server" TextMode="Email" CssClass="form-control" placeholder="Enter Patient's Email"
                required />
            <br />
            <label for="description">
                Current Health</label>
            <asp:TextBox ID="description" runat="server" CssClass="form-control" placeholder="Enter current health of yours!"
                required />
            <br />
            <label for="description">
                Date</label>
            <asp:TextBox ID="date" runat="server" Textmode="Date" CssClass="form-control" placeholder="Enter current health of yours!"
                required />
            <br />
            <asp:Button ID="book" Text="Book" runat="server" Class="btn btn-primary" OnClick="book_Click"/>
            <br />
            <br />
            <asp:Label ID="errbook" runat="server" />
            </div>
        </div>
    </form>

</asp:Content>

