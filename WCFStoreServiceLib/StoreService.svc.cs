using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Configuration; 

using DataManager.Abstract;
using DataManager.Concrete;
using DataManager.DMModel;

namespace WCFStoreSErviceLib
{

    public class StoreService : IStoreService
    {
        public  IDBAccessLayer AL;
        public IStoreAccess SA;

        public StoreService()
        {
            string Provider = "System.Data.SqlClient";
            string ConnectionString = ConfigurationManager.ConnectionStrings["active"].ConnectionString;

            AL = new ImplDbAccessLayer(ConnectionString, Provider);
            SA = new ImplIStoreAccess(AL);
        }
   
        public IEnumerable<Good> Goods(){
            return  SA.Goods().ToList<Good>();
        }
        public Good GetGood(int Id) {
            return SA.GetGood(Id);
        }
        public void SaveGood(Good item) {
            SA.SaveGood(item);
        }
        public void DeleteGood(Good item)
        {
            SA.DeleteGood(item);
        }
    }
}
