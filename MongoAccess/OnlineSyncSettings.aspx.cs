using Bibekanand.GlobalClasses;
using Bibekanand.MongoAccess.MongoClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace MongoAccess
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        MongoAccessDb obj = new MongoAccessDb();
        string productType_Value = string.Empty;
        string TestSetting_value = string.Empty;
        string Class_Value = string.Empty;
        string Dll_value = string.Empty;
        string Email_value = string.Empty;
        string Subject_value = string.Empty;
        string tcid_value = string.Empty;
        string tcname_value = string.Empty;
        string SourceType = string.Empty;
        string SourceSubType = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            PopupMessage("hi");
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            SyncTc(@"C:\builds");
        }

        public static string GetTagValue(string tagname, string xmlfilepath)
        {
            try
            {
                XmlDocument pathretrivedoc = new XmlDocument();
                pathretrivedoc.Load(xmlfilepath);
                XmlNodeList elemList = pathretrivedoc.GetElementsByTagName(tagname);
                return elemList[0].InnerText;
            }
            catch (Exception ex)
            {
               
            }
            return null;
        }

        private void SyncTc(string remotePathAddress)
        {
            var stopWatch = Stopwatch.StartNew();
            #region ReadFileFormLocalDirectory
            List<ConfigFileList> listvalues = new List<ConfigFileList>();
            Dictionary<string, string> collectiondictionary = new Dictionary<string, string>();
            XmlDocument pathretrivedoc = new XmlDocument();
            pathretrivedoc.Load(Server.MapPath("Pathlist.xml"));
            XmlNodeList elemList = pathretrivedoc.GetElementsByTagName("remotePath");
            XmlNodeList configNodename = pathretrivedoc.GetElementsByTagName("NameofConfigFile");
            foreach (XmlNode xcollectnode in elemList)
            {
                #endregion
                string storepath = null;
                storepath = xcollectnode.InnerText.ToString();
                if (Directory.Exists(storepath))
                {
                    foreach (string conlist in Directory.GetDirectories(storepath))
                    {
                        string includeconfig = conlist + "\\" + configNodename[0].InnerText;
                        if (Directory.Exists(includeconfig))
                        {
                            foreach (string one in Directory.EnumerateFiles(includeconfig, "*.xml"))
                            {
                                XmlDocument xdoc = new XmlDocument();
                                xdoc.Load(one);
                                productType_Value = GetTagValue("productType", one);
                                TestSetting_value = GetTagValue("testsettings", one);
                                Class_Value = GetTagValue("class", one);
                                Subject_value = GetTagValue("subject", one);
                                Dll_value = GetTagValue("dll", one);
                                Email_value = GetTagValue("email", one);
                                XmlNodeList columnnode = xdoc.DocumentElement.SelectNodes("tests/test");
                                //  / Configuration / exportParameters / Parameter
                                XmlNodeList parameters = xdoc.DocumentElement.SelectNodes("/Configuration/exportParameters/Parameter");
                                if (parameters != null && parameters.Count > 0)
                                {
                                    foreach (XmlNode xnode in parameters)
                                    {                                       
                                        if(xnode.Attributes[0].Value== "SourceType")
                                        {
                                            SourceType = xnode.InnerText;                                           
                                        }
                                        if (xnode.Attributes[0].Value == "SourceSubType")
                                        {
                                            SourceSubType = xnode.InnerText;
                                        }

                                    }
                                }
                                
                                foreach (XmlNode xnode in columnnode)
                                {
                                    if (xnode.Attributes != null && xnode.Attributes.Count > 0)
                                    {
                                      //  SourceType = !string.IsNullOrEmpty(xnode.Attributes[0].Value) ? Convert.ToString(xnode.Attributes[0].Value) : string.Empty;

                                        tcid_value = !string.IsNullOrEmpty(xnode.Attributes[0].Value) ? Convert.ToString(xnode.Attributes[0].Value) : string.Empty; 

                                        tcname_value = !string.IsNullOrEmpty(xnode.InnerXml) ? Convert.ToString(xnode.InnerXml) : string.Empty;

                                        ConfigFileList obj = new ConfigFileList
                                        {
                                            Class = Class_Value,
                                            ProductType = productType_Value,
                                            TestSettings = TestSetting_value,
                                            Subject = Subject_value,
                                            Dll = Dll_value,
                                            Email = Email_value,
                                            TestcaseID = tcid_value,
                                            TestcaseName = tcname_value
                                        };
                                        listvalues.Add(obj);

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    PopupMessage("Remote Directory does not exists !!!");
                }
            }

            var UniqIDs = (from urecords in listvalues
                           select new
                           {
                               ProductType = urecords.ProductType,
                               TestSetting = urecords.TestSettings,
                               dll = urecords.Dll,
                               Email = Email_value
                           }).ToList().GroupBy(x => x.ProductType).Select(x => x.FirstOrDefault());

            foreach (var clist in UniqIDs)
            {
               
            }



            var allIDs = (from urecords in listvalues
                          select urecords
                           ).ToList().GroupBy(x => x.TestcaseID).Select(x => x.FirstOrDefault());

            foreach (var clist in allIDs)
            {

                var doc = new MongoDB.Bson.BsonDocument
                {

                {"ProductType" ,clist.ProductType },
                { "TestSetting" ,  clist.TestSettings },
                 { "ClassSetting" ,  clist.Class },
                  { "dll" ,  clist.Dll },
                   { "email" ,  clist.Email },
                    { "testID" ,  clist.TestcaseID },
                     { "testCaseName" ,  clist.TestcaseName },
                      { "SourceType" ,  SourceType },
                      { "SourceSubType" , SourceSubType },
                      { "subject" ,  clist.Subject },
                      { "CreatedBy" , "Bibekananda Panigrahi Time 20012019" },
            };
                var condition = new MongoDB.Bson.BsonDocument
            {
                {"testID" ,  clist.TestcaseID },

            };

                lbl_erromessage.Text = obj.InsertSingleClass(doc, GlobalClass.configTable,true, condition);
            }

            stopWatch.Stop();
            lbl_erromessage.Text = string.Format("Sync execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);
        }
        public static void PopupMessage(string message)
        {
            string cleanMessage = message.Replace("'", "\'");
            Page page = HttpContext.Current.CurrentHandler as Page;
            string script = string.Format("alert('{0}');", cleanMessage);
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
            }
        }
    }

    [Serializable()]
    public class ConfigFileList
    {
        public string ProductType { set; get; } = "";
        public string TestSettings { set; get; } = "";
        public string Class { set; get; } = "";
        public string Subject { set; get; } = "";
        public string Dll { set; get; } = "";
        public string Email { set; get; } = "";
        public string TestcaseID { set; get; } = "";
        public string TestcaseName { set; get; } = "";


    }

    [Serializable()]
    public class ConfigFileListForFileName
    {

        public string ConfigFileName { set; get; } = "";
        public string TestcaseID { set; get; } = "";
        public string TestcaseName { set; get; } = "";


    }
}