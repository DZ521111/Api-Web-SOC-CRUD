<%@ Page Title="All Doctors page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllDoctors.aspx.cs" Inherits="WebClientHM.AllDoctors" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
    media="screen" />
    <p>
        <h3 align ="center"><b>All Doctors List</b></h3>
    </p>
    <p align ="center">
        <asp:Button ID="btnview" Text="All Doctors" runat="server" Class="btn btn-primary" OnClick="btnview_Click"/>
        <br />
    </p>
    <p align ="center">
        <asp:GridView ID="gridview" runat="server" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="224px" Width="695px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />   
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </p>

</asp:Content>