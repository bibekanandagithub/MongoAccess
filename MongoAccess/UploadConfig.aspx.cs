using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bibekanand.MongoAccess.MongoClass;
using Bibekanand.GlobalClasses;

namespace MongoAccess
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        MongoAccessDb obj = new MongoAccessDb();
        MongoAccessDbSearch objSearch = new MongoAccessDbSearch();

        protected void Page_Load(object sender, EventArgs e)
        {
           
           
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            if(fld_upload.HasFile)
            {
                
                var doc = new MongoDB.Bson.BsonDocument
            {
                {"_id" ,"test" },
                { "testsettings" ,  33 },
                 { "class" ,  33 },
                  { "dll" ,  33 },
                   { "email" ,  33 },
                    { "testID" ,  33 },
                     { "testName" ,  33 },
                      { "SourceType" ,  33 },
                      { "SourceSubType" ,  33 },
                      { "Created By" ,  33 },
            };
            lbl_erromessage.Text= obj.InsertSingleClass(doc,GlobalClass.configTable);
            }
            else
            {
                lbl_erromessage.Text = "Sorry no files to upload...";
            }
        }
    }
}