using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;


namespace DataManager.Abstract
{
    public interface IDBAccessLayer
    {
        DataTable sQuery(string QueryString);
        void duiQuery(string QueryString);
        DataTable sQuery(DbCommand QueryCommand);
        void duiQuery(DbCommand QueryCommand);

        int esQuery(DbCommand QueryCommand);
    }
}
