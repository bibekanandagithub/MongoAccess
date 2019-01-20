using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Bibekanand.GlobalClasses;
using System.Data;

namespace Bibekanand.MongoAccess.MongoClass
{
    public class MongoAccessDbSearch
    {
        Dictionary<string, string> Ptypelst = new Dictionary<string, string>();

        public Dictionary<string,string> ViewAllProduct()
        {
            var ConnectionString = GlobalClass.ConnectionString;
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(GlobalClass.DatabaseName);
            var col = db.GetCollection<BsonDocument>(GlobalClass.ProductTable);

            var list = col.Find(new BsonDocument()).ToList();

            foreach (var doc in list)
            {
                Ptypelst.Add(Convert.ToString(doc[0]), Convert.ToString(doc[1]));

            }
            return Ptypelst == null ? null : Ptypelst;
        }
    }


    public class MongoAccessDb:IDisposable
    {
        public string singleRecordRemove(BsonDocument search,string tableName)
        {
            try
            {
                var ConnectionString = GlobalClass.ConnectionString;
                var client = new MongoClient(ConnectionString);
                var db = client.GetDatabase(GlobalClass.DatabaseName);
                var col = db.GetCollection<BsonDocument>(tableName);
                DeleteResult dl = col.DeleteOne(new BsonDocument(search));
               if(dl.DeletedCount>0)
                {
                    return "Record Deleted Sucessfully..";
                }
            }
            catch (Exception ex) { throw ex; }
            return string.Empty;
        }
        public string MultipleRecordRemove(BsonDocument search, string tableName)
        {
            try
            {
                var ConnectionString = GlobalClass.ConnectionString;
                var client = new MongoClient(ConnectionString);
                var db = client.GetDatabase(GlobalClass.DatabaseName);
                var col = db.GetCollection<BsonDocument>(tableName);
                DeleteResult dl = col.DeleteMany(new BsonDocument(search));
                if (dl.DeletedCount > 0)
                {
                    return "Records Deleted Sucessfully..";
                }
            }
            catch (Exception ex) { throw ex; }
            return string.Empty;
        }

        public bool RecordExist(BsonDocument Search,string TableName)
        {
            try
            {
                var ConnectionString = GlobalClass.ConnectionString;
                var client = new MongoClient(ConnectionString);
                var db = client.GetDatabase(GlobalClass.DatabaseName);
                var col = db.GetCollection<BsonDocument>(TableName);
                var list = col.Find(new BsonDocument(Search)).ToList();
                if (list != null && list.Count > 0) { return true; }
            }catch(Exception ex) { throw ex; }
            return false;
        }

        public string InsertSingleClass(BsonDocument bsonDocument,string TableName)
        {
            try
            {
                var ConnectionString = GlobalClass.ConnectionString;
                var client = new MongoClient(ConnectionString);
                var db = client.GetDatabase(GlobalClass.DatabaseName);
                var col = db.GetCollection<BsonDocument>(TableName);
                MongoDB.Bson.BsonDocument document
              = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(bsonDocument);
                col.InsertOne(document);
                return "Uploaded Sucessfully....";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string InsertSingleClass(BsonDocument bsonDocument, string TableName,bool ActiveSearchCriteria=false, BsonDocument SearchCriteria=null)
        {
            try
            {
                if (ActiveSearchCriteria == false && SearchCriteria==null)
                {
                    var ConnectionString = GlobalClass.ConnectionString;
                    var client = new MongoClient(ConnectionString);
                    var db = client.GetDatabase(GlobalClass.DatabaseName);
                    var col = db.GetCollection<BsonDocument>(TableName);
                    MongoDB.Bson.BsonDocument document
                  = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(bsonDocument);
                    col.InsertOne(document);
                    return "Uploaded Sucessfully....";
                }
                else
                {
                    bool isrecordExist = RecordExist(SearchCriteria, TableName);
                    if (isrecordExist == false)
                    {
                        var ConnectionString = GlobalClass.ConnectionString;
                        var client = new MongoClient(ConnectionString);
                        var db = client.GetDatabase(GlobalClass.DatabaseName);
                        var col = db.GetCollection<BsonDocument>(TableName);
                        MongoDB.Bson.BsonDocument document
                      = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(bsonDocument);
                        col.InsertOne(document);
                        return "Uploaded Sucessfully....";
                    }
                    else
                    {
                        return "Record Exist";
                    }
                   
                    
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            

        }


        public void Dispose()
        {
            GC.Collect();
        }
    }
}