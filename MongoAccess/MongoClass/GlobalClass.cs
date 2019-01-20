using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibekanand.GlobalClasses
{
    public class GlobalClass
    {
        public const string DatabaseName = "Automation";
        public const string EmailTable = "Email";
        public const string ProductTable = "Product";
        public const string configTable = "ConfigFiles";
        public const string ClassConfigTable = "ClassFiles";
        public const string ConnectionString = "mongodb://localhost:27017";
    }

    public class Products
    {
        public string productType { set; get; }
        public string testsettings { set; get; }
        public string classSettings { set; get; }
        public string subject { set; get; }
        public string dll { set; get; }
        public string testID { set; get; }
        public string testName { set; get; }

    }
    public class Emails
    {
        public string ProductType { set; get; }
        public string Email { set; get; }
    }
}