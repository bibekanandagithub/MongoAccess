<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnlineSyncSettings.aspx.cs" Inherits="MongoAccess.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
     <div class="jumbotron">        
        <p class="lead">Sync all testcases from remote server...</p>
        <asp:Label ID="lbl_erromessage" runat="server" CssClass="label-info"></asp:Label>
        <asp:TextBox ID="txt_path" runat="server"   CssClass="form-control text-center" /> 
        <asp:Button ID="btn_upload" runat="server" Text="Sync" CssClass=" btn btn-primary" OnClick="btn_upload_Click"  />
        
       </div>


</asp:Content>
