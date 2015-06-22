<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewBasePage.master" EnableEventValidation="false"
    ValidateRequest="false" AutoEventWireup="true" CodeFile="DefaultNew.aspx.cs"
    Inherits="Administrator_DefaultNew" %>

<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder"
    runat="server">
    Default Page</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="jumbotron">
        <h1>
            Navbar example</h1>
        <p>
            This example is a quick exercise to illustrate how the default, static and fixed
            to top navbar work. It includes the responsive CSS and HTML, so it also adapts to
            your viewport and device.</p>
        <p>
            To see the difference between static and fixed top navbars, just scroll.</p>
        <p>
            <a class="btn btn-lg btn-primary" href="../../components/#navbar" role="button">View
                navbar docs &raquo;</a>
        </p>
    </div>
</asp:Content>
