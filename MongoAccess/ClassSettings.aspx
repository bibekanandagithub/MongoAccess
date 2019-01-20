<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClassSettings.aspx.cs" Inherits="MongoAccess.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
     <div class="jumbotron">
        
        <p class="lead">Class Settings.</p>
         <asp:Label ID="lbl_errorMessage" runat="server" CssClass="label label-danger"></asp:Label>
                <div class="form-group">
    <asp:Label ID="lbl_productType" runat="server" Text=" Product" ></asp:Label><br />
    <asp:DropDownList ID="drp_productType" runat="server">

    </asp:DropDownList>
       </div>
         <div class="form-group">
    <asp:Label ID="lbl_class" runat="server" Text="Email" >Class</asp:Label>
    <asp:TextBox ID="txt_class" runat="server" class="form-control"></asp:TextBox>
       </div>
       <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_Submit_Click" />
         <asp:Button ID="tbn_view" runat="server" Text="View Records" CssClass="btn btn-success"  />


     </div>


</asp:Content>
