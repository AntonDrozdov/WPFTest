using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;

using DataManager.Abstract;

namespace DataManager.Concrete
{
    public class ImplDbAccessLayer : IDBAccessLayer
    {
        private string _connectionString;
        public string _dataProvider;

        private DbConnection _curConnection = null;

        public DbProviderFactory _curDataObjFactory = null;
 
        //конструктор
        public ImplDbAccessLayer(string connectionString, string dataProvider)
        {
            _connectionString = connectionString;
            _dataProvider = dataProvider;

               _curDataObjFactory = DbProviderFactories.GetFactory(dataProvider);
        }

        //методы открытия соединения - видимо нахер не нужны. подключени создаются внутри нижеследующих методов
        public void OpenConnection()
        {
            using (_curConnection = _curDataObjFactory.CreateConnection())
            {
                _curConnection.ConnectionString = _connectionString;
                _curConnection.Open();
            }

        }
        public void CloseConnection()
        {
            _curConnection.Close();
        }
        
        //методы отправки запросов
        public DataTable sQuery(string QueryString)
        {
            DataTable _curDataTable = new DataTable();
            using (_curConnection = _curDataObjFactory.CreateConnection())
            {
                _curConnection.ConnectionString = _connectionString;
                _curConnection.Open();
                using (DbCommand curCommand = _curDataObjFactory.CreateCommand())
                {
                    curCommand.Connection = _curConnection;
                    curCommand.CommandText = QueryString;
                    //исполенение запроса
                    using (DbDataReader curDataReader = curCommand.ExecuteReader())
                    {
                        _curDataTable.Load(curDataReader);
                        curDataReader.Close();
                    }
                }
                _curConnection.Close();
            }
            return _curDataTable;
        }
        public void duiQuery(string QueryString)
        {
            using (_curConnection = _curDataObjFactory.CreateConnection())
            {
                try
                {
                    _curConnection.ConnectionString = _connectionString;
                    _curConnection.Open();

                    using (DbCommand curCommand = _curDataObjFactory.CreateCommand())
                    {
                        curCommand.Connection = _curConnection;
                        curCommand.CommandText = QueryString;

                        curCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _curConnection.Close();
                }
            }
        }
    
        public DataTable sQuery(DbCommand QueryCommand)
        {
            DataTable _curDataTable = new DataTable();
            
            using (_curConnection = _curDataObjFactory.CreateConnection())
            {
                try
                {
                    _curConnection.ConnectionString = _connectionString;
                    _curConnection.Open();

                    QueryCommand.Connection = _curConnection;

                    using (DbDataReader curDataReader = QueryCommand.ExecuteReader())
                    {
                        _curDataTable.Load(curDataReader);
                        curDataReader.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _curConnection.Close();
                }

            }

            return _curDataTable   ;
        }
        public void duiQuery(DbCommand QueryCommand)
        {
            using (_curConnection = _curDataObjFactory.CreateConnection())
            {
                try
                {
                    _curConnection.ConnectionString = _connectionString;
                    _curConnection.Open();

                    QueryCommand.Connection = _curConnection;

                    QueryCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                        throw;
                }
                finally
                {
                    _curConnection.Close();
                }
            }
        }

        public int esQuery(DbCommand QueryCommand)
        {
            using (_curConnection = _curDataObjFactory.CreateConnection())
            {
                int id=0;
                try
                {
                    _curConnection.ConnectionString = _connectionString;
                    _curConnection.Open();

                    QueryCommand.Connection = _curConnection;
                    object i = QueryCommand.ExecuteScalar();
                    if(i!=null)
                    {
                        id = Int32.Parse(i.ToString());
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _curConnection.Close();
                }

                return id;
            }
        }
    }
}
