using Bibekanand.MongoAccess.MongoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bibekanand.GlobalClasses;

namespace MongoAccess
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        MongoAccessDb obj = new MongoAccessDb();
        MongoAccessDbSearch objSearch = new MongoAccessDbSearch();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowRecords();
            }
        }
        private void ShowRecords()
        {
            
                grd_allProduct.DataSource = objSearch.ViewAllProduct();
                grd_allProduct.DataBind();
            
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            using (obj)
            {
                var doc = new MongoDB.Bson.BsonDocument
            {
                {"productType" , !string.IsNullOrEmpty(txt_product.Text)?txt_product.Text.Trim():string.Empty },

            };
                lbl_errorMessage.Text= obj.InsertSingleClass(doc, GlobalClass.ProductTable,true,doc);
                txt_product.Text = string.Empty;
            }
        }

        protected void grd_allProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName!=null && e.CommandName.Equals("deleteRecords"))
            {
                string arg = Convert.ToString(e.CommandArgument);
                var doc = new MongoDB.Bson.BsonDocument
            {
               {"productType" , arg }

            };
                obj.singleRecordRemove(doc, GlobalClass.ProductTable);
                ShowRecords();
            }
        }

        protected void grd_allProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_allProduct.PageIndex = e.NewPageIndex;
            ShowRecords();
        }
    }
}