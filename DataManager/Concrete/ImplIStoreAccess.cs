using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager.Abstract;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

using DataManager.DMModel;


namespace DataManager.Concrete
{
    public class ImplIStoreAccess : IStoreAccess
    {
        private IDBAccessLayer AL;
        public ImplIStoreAccess(IDBAccessLayer _AL){
            AL = _AL;
        }

        public IEnumerable<Good> Goods() {

            List<Good> Goods = new List<Good>();

            string selectQuery = "SELECT [Id],[Title],[RegistrationDate],[Amount] FROM [Store].[dbo].[Goods] ";

            using (SqlCommand _dbCommand = new SqlCommand())
            {
                _dbCommand.CommandText = selectQuery;

                DataTable _dataTable = AL.sQuery(_dbCommand);
                foreach (DataRow textrow in _dataTable.Rows)
                {
                    Goods.Add(new Good( Convert.ToInt32(textrow["Id"].ToString()),
                                        textrow["Title"].ToString(),
                                        Convert.ToDateTime(textrow["RegistrationDate"].ToString()),
                                        Convert.ToInt32(textrow["Amount"].ToString())));

                }
            }
            return Goods;
        }
        public Good GetGood(int Id) {
            string selectQuery = "SELECT top 1 [Id],[Title],[RegistrationDate],[Amount] FROM [Store].[dbo].[Goods] where [Id] = " + Id.ToString() ;

            using (SqlCommand _dbCommand = new SqlCommand())
            {
                _dbCommand.CommandText = selectQuery;

                DataTable _dataTable = AL.sQuery(_dbCommand);
                if (_dataTable.Rows.Count != 0) { 
                return new Good(Convert.ToInt32(_dataTable.Rows[0]["Id"].ToString()),
                                _dataTable.Rows[0]["Title"].ToString(),
                                Convert.ToDateTime(_dataTable.Rows[0]["RegistrationDate"].ToString()),
                                Convert.ToInt32(_dataTable.Rows[0]["Amount"].ToString()));
                }
            }
            return null;
        }
        public void SaveGood(Good item)
        {
            string query ;
            if (item.Id != 0)
            {
                query = "update [Store].[dbo].[Goods] set title='" + item.Title + "', Amount = " + item.Amount.ToString() + " where Id = " + item.Id.ToString();
            }
            else {
                query = "insert into [Store].[dbo].[Goods] ([Title], [Amount]) values ('" + item.Title + "'," + item.Amount.ToString() + ")";
            }

            using (SqlCommand _dbCommand = new SqlCommand())
            {
                _dbCommand.CommandText = query;
                AL.duiQuery(query);
            }
        }
        public void DeleteGood(Good item)
        {
            string query = "delete from [Store].[dbo].[Goods] where Id = " + item.Id.ToString();

            using (SqlCommand _dbCommand = new SqlCommand())
            {
                _dbCommand.CommandText = query;
                AL.duiQuery(query);
            }
        }
    }
}
