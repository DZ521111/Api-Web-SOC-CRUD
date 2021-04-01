<%@ Page Title="Add Doctor page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDoctor.aspx.cs" Inherits="WebClientHM.AddDoctor" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
    media="screen" />

    <form id="form1" align ="center">
        <div style="max-width: 600px;">
            <h2 class="form-signin-heading">
                Add Doctor</h2>
            <label for="docname">
                Doctor's Name</label>
            <asp:TextBox ID="docname" runat="server" CssClass="form-control" placeholder="Enter Name"
                required />
            <br />
            <label for="docemail">
                Email-ID</label>
            <asp:TextBox ID="docemail" runat="server" TextMode="Email" CssClass="form-control" placeholder="Enter Email ID"
                required />
            <br />
            <label for="doccontact">
                Contact No</label>
            <asp:TextBox ID="doccontact" runat="server" CssClass="form-control" placeholder="Enter Contact No"
                required />
            <br />
            <label for="docaddress">
                Address</label>
            <asp:TextBox ID="docaddress" runat="server" CssClass="form-control"
                placeholder="Enter Address" required />
            <br />
            <label for="docexperience">
                Experience</label>
            <asp:TextBox ID="docexperience" runat="server" CssClass="form-control"
                placeholder="Enter Experience" required />
            <br />
            <label for="docspeciality">
                Speciality</label>
            <asp:TextBox ID="docspeciality" runat="server" CssClass="form-control"
                placeholder="Enter Experience" required />
            <br />
            <asp:Button ID="btnadd" Text="Add Doctor" runat="server" Class="btn btn-primary" OnClick="btnadd_Click"/>
            &nbsp;  &nbsp;
            <asp:Button ID="btnupdate" Text="Update Doctor" runat="server" Class="btn btn-primary" OnClick="btnupdate_Click"/>
            <br />
            <br />
            <asp:Label ID="errmsg" runat="server" />
            </div>
            <br />
            <p align ="center">
            <li>Delete Doctor <a runat="server" href="~/DeleteDoctor">Click Here!</a></li>
            </p>
        </div>
    </form>

</asp:Content>

