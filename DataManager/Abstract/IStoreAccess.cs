using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager.DMModel;

namespace DataManager.Abstract
{
    public interface IStoreAccess
    {
        IEnumerable<Good> Goods();
        Good GetGood(int Id);
        void SaveGood(Good item);
        void DeleteGood(Good item);
    }
}
