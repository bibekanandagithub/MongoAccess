using Bibekanand.MongoAccess.MongoClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MongoAccess
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        MongoAccessDb obj = new MongoAccessDb();
        MongoAccessDbSearch objSearch = new MongoAccessDbSearch();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
             //foreach(string singleitem in objSearch.ViewAllProduct())
             //   {
             //       drp_productType.Items.Add(singleitem);
             //   }
             //   drp_productType.Items.Insert(0, new ListItem("Select Product Type","0"));
            }
        }
    }
}