using Bibekanand.MongoAccess.MongoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MongoAccess
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        MongoAccessDb obj = new MongoAccessDb();
        MongoAccessDbSearch objSearch = new MongoAccessDbSearch();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                foreach (KeyValuePair<string,string> singleitem in objSearch.ViewAllProduct())
                {
                    drp_productType.Items.Add(new ListItem(singleitem.Value, singleitem.Key));
                }
                drp_productType.Items.Insert(0, new ListItem("Select Product Type", "0"));
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            var doc = new MongoDB.Bson.BsonDocument
            {
                {"productType" , drp_productType.SelectedIndex>0?drp_productType.SelectedItem.Text:string.Empty },
                {"ClassSetting" , !string.IsNullOrEmpty(txt_class.Text)?txt_class.Text.Trim():string.Empty }

            };

            var docCondition = new MongoDB.Bson.BsonDocument
            {
               
                {"ClassSetting" , !string.IsNullOrEmpty(txt_class.Text)?txt_class.Text.Trim():string.Empty }

            };
            lbl_errorMessage.Text= obj.InsertSingleClass(doc, Bibekanand.GlobalClasses.GlobalClass.ClassConfigTable,true, docCondition);
            txt_class.Text = string.Empty;
            drp_productType.SelectedIndex = -1;
        }
    }
}