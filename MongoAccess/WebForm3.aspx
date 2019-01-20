<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="MongoAccess.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script lang="ja">

function ConfirmDeletion()

{

 return (confirm("Are you sure you want to delete the record?"));

}

</script>
      <div class="jumbotron">
        
        <p class="lead">Product Settings.</p>
        <p><a href="EmailSettings.aspx" class="btn btn-primary btn-lg">Back &raquo;</a></p>


         <div class="form-group">
              <asp:Label ID="lbl_errorMessage" runat="server"  CssClass="label label-danger"></asp:Label>
             <br />


    <asp:Label ID="lbl_email" runat="server" Text="Email" >Enter Product</asp:Label>
    <asp:TextBox ID="txt_product" placeholder="Enter Product Type" autocomplete="off" runat="server" class="form-control"></asp:TextBox>
       </div>
  
  
          <asp:Button ID="btn_update" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_update_Click" />
          <br />      <hr />

               </div>

          <asp:GridView ID="grd_allProduct" runat="server" AllowPaging="true" PageSize="20" AutoGenerateColumns="false"  CssClass="table table-bordered table-responsive"  OnRowCommand="grd_allProduct_RowCommand" OnPageIndexChanging="grd_allProduct_PageIndexChanging">
              <Columns>               

                  <asp:TemplateField HeaderText="Product">
                      <ItemTemplate>
                          <%#Eval("value") %>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Action">
                      <ItemTemplate>
                        <asp:LinkButton ID="lnk_delete" runat="server" CommandArgument='<%#Eval("value") %>'  CommandName="deleteRecords" onclientclick="return ConfirmDeletion();"  CssClass="alert-link">Delete</asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>

          </asp:GridView>


</asp:Content>
