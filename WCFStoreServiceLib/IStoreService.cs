using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using DataManager.DMModel;

namespace WCFStoreSErviceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoreService" in both code and config file together.
    [ServiceContract]
    public interface IStoreService
    {
        [OperationContract]
        IEnumerable<Good> Goods();
        [OperationContract]
        Good GetGood(int Id);
        [OperationContract]
        void SaveGood(Good item);
        [OperationContract]
        void DeleteGood(Good item);
    }
}
