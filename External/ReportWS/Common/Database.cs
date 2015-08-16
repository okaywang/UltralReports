using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using MvcMiniProfiler;
using MvcMiniProfiler.Data;
using System.Data.SqlClient;

namespace Rinch.Common
{
    public class Database {
        private readonly string _ConnectionString;
        private readonly DbProviderFactory _ProviderFactory;

        public string ConnectionString { get { return _ConnectionString; } } 

        public Database(string connectionStringName) {
            // TODO: 此处是否应该采用多例模式，缓存 providerFactory ？
            // 经测试，5秒内可创建20万个Database对象，不必进行缓存
            var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
            _ConnectionString = connectionStringSettings.ConnectionString;
            _ProviderFactory = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
        }

        private DbConnection CreateConnection() {
            var connection = _ProviderFactory.CreateConnection();
            connection.ConnectionString = _ConnectionString;
            connection.Open();
#if (DEBUG)
            return ProfiledDbConnection.Get(connection, MiniProfiler.Current);
#else
                return connection;
#endif
        }

        private T Execute<T>(string sql, object parameters, Func<DbCommand, T> action) {
            using (var connection = CreateConnection()) {
                using (var cmd = connection.CreateCommand()) {
                    cmd.CommandTimeout = 60 * 60 * 2; 
                    cmd.CommandText = sql;
                    cmd.SetParameters(parameters);

                    return action.Invoke(cmd);
                }
            }
        }

        public int ExecuteNonQuery(string sql, object parameters = null) {
            return Execute(sql, parameters, cmd => cmd.ExecuteNonQuery());
        }

        public int ExecuteNonQuery(string sql, object parameters, Action<DbParameterCollection> outAction)
        {
            int rowCount = 0;
            DbParameterCollection pars = null;

            rowCount = Execute(sql, parameters, cmd =>
            {

               rowCount =  cmd.ExecuteNonQuery();
                pars=cmd.Parameters;
                return rowCount;
            });
            if (outAction != null)
                outAction.Invoke(pars);

            return rowCount;
        }


        //public void ExecuteNoQuery(string sql, object parameter = null) {
        //    using (var Connection = CreateConnection()) {
        //        using (var cmd = Connection.CreateCommand()) {
        //            if (parameter != null) {
        //                cmd.CommandText = sql;
        //                cmd.Parameters.Add(parameter);
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //}


        //public void BulkToDataBase(DataTable dtable, string tableName) {
        //    using (var connection = CreateConnection()) {
        //        using (var transaction = connection.BeginTransaction()) {
        //            try {
        //                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(_ConnectionString)) {
        //                    if (dtable != null && dtable.Rows.Count > 0) {
        //                        bulkcopy.DestinationTableName = tableName;
        //                        bulkcopy.BatchSize = dtable.Rows.Count;
        //                        bulkcopy.WriteToServer(dtable);
        //                    }
        //                }
        //                transaction.Commit();
        //            }
        //            catch {
        //                transaction.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}

        public IEnumerable<T> ExecuteDataReader<T>(string sql, object parameters, Func<DbDataReader, T> action) {
            //return Execute(sql, parameters, cmd => ExecuteReader(cmd, action));
            using (var connection = CreateConnection()) {
                using (var cmd = connection.CreateCommand()) {
                    cmd.CommandText = sql;
                    cmd.SetParameters(parameters);

                    using (var dr = cmd.ExecuteReader()) {
                        while (dr.Read())
                            yield return action.Invoke(dr);
                    }
                }
            }
        }

        public void ExecuteDataReader(string sql, object parameters, Action<DbDataReader> action,Action<DbParameterCollection> outAction)
        {
            //return Execute(sql, parameters, cmd => ExecuteReader(cmd, action));
            using (var connection = CreateConnection())
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.SetParameters(parameters);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            action.Invoke(dr);
                    }

                    outAction.Invoke(cmd.Parameters);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeOut">超时值(单位：秒)</param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="action"></param>
        /// <param name="outAction"></param>
        public void ExecuteDataReaderForTimeOut(int timeOut,string sql, object parameters, Action<DbDataReader> action, Action<DbParameterCollection> outAction)
        {
            //return Execute(sql, parameters, cmd => ExecuteReader(cmd, action));
            using (var connection = CreateConnection())
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.SetParameters(parameters);
                    cmd.CommandTimeout = timeOut;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            action.Invoke(dr);
                    }

                    outAction.Invoke(cmd.Parameters);
                }
            }
        }
        //private IEnumerable<T> ExecuteReader<T>(DbCommand cmd, Func<DbDataReader, T> action) {
        //    using (var dr = cmd.ExecuteReader()) {
        //        while (dr.Read())
        //            yield return action.Invoke(dr);
        //    }
        //}

        public object ExecuteScalar(string sql, object parameters = null)
        {
            return Execute(sql, parameters, cmd => cmd.ExecuteScalar());
        }

        public void ExecuteDataReader(string sql, object parameters, Action<DbDataReader> action) {
            Execute(sql, parameters, cmd => {
                using (var dr = cmd.ExecuteReader()) {
                    while (dr.Read())
                        action.Invoke(dr);
                }
                return new object();
            });
        }

        public DataTable ExecuteDataTable(string sql, object parameters) 
        {
            DataTable dt = new DataTable();
            DbDataAdapter adapter = null;
             DbConnection connection = null;
            try
            {
                adapter = _ProviderFactory.CreateDataAdapter();
                connection = _ProviderFactory.CreateConnection();// CreateConnection();   
                connection.ConnectionString = ConnectionString;
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                adapter.SelectCommand =  connection.CreateCommand();
                adapter.SelectCommand.CommandText = sql;
                adapter.SelectCommand.CommandTimeout = 60 * 60 * 2;
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.SetParameters(parameters);
                adapter.Fill(dt);
              
            }           
            finally
            {
                if (adapter != null)
                    adapter.Dispose();
                if (connection != null && connection.State != ConnectionState.Closed)
                    connection.Close();
            }
          
            return dt;
        }

        public void ExecuteTransaction(Action<DbCommand> action) {
            using (var connection = CreateConnection()) {
                using (var transaction = connection.BeginTransaction()) {
                    try {
                        using (var cmd = connection.CreateCommand()) {
                            cmd.Transaction = transaction;
                            cmd.Connection = connection;

                            if (action != null)
                                action.Invoke(cmd);
                            //foreach (var action in actions)
                            //{
                            //    cmd.CommandText = action.Item1;
                            //    if (action.Item2 != null)
                            //        SetParameters(cmd, action.Item2);
                            //    cmd.ExecuteNonQuery();

                            //}
                        }

                        transaction.Commit();
                    }
                    catch {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
