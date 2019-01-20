<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadConfig.aspx.cs" Inherits="MongoAccess.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <div class="jumbotron">        
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <asp:Label ID="lbl_erromessage" runat="server" CssClass="label-info"></asp:Label>
        <asp:FileUpload ID="fld_upload" runat="server"  CssClass="form-control" /> 
        <asp:Button ID="btn_upload" runat="server" Text="Upload" CssClass=" btn btn-primary" OnClick="btn_upload_Click" />
        <br />
        <asp:GridView ID="grid_uploadDetails" runat="server" CssClass="table table-bordered table-responsive">

        </asp:GridView>
       </div>
</asp:Content>
