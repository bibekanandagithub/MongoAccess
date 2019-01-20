<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmailSettings.aspx.cs" Inherits="MongoAccess.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <div class="jumbotron">
        
        <p class="lead">Email Settings.</p>
        <p><a href="WebForm3.aspx" class="btn btn-primary btn-lg"> Add New Product &raquo;</a></p>

        <div class="form-group">
    <asp:Label ID="lbl_productType" runat="server" Text=" Product" ></asp:Label><br />
    <asp:DropDownList ID="drp_productType" runat="server">

    </asp:DropDownList>
       </div>
         <div class="form-group">
    <asp:Label ID="lbl_email" runat="server" Text="Email" >Email</asp:Label>
    <asp:TextBox ID="txt_email" runat="server" class="form-control"></asp:TextBox>
       </div>
    
  
  <button type="submit" class="btn btn-success">Submit</button>


     </div>

   

</asp:Content>
