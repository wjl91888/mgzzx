using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace RICH.Common.DB
{
    public class DbHelper
    {
        private string ConnectionString { get; set; }

        public DbHelper(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Execute a scalar stored procedure using existing connection string
        /// </summary>
        /// <param name="sprocName">stored procedure name to be executed</param>
        /// <param name="timeout">The time out value</param>
        /// <param name="connection">The connection command execute on</param>
        /// <param name="transaction">The transaction command will be included</param>
        /// <param name="commandParams">sql parameters to pass into the stored procedure</param>
        /// <returns>
        ///     Thr first column of the first row int he result set, or a null reference if the result set is empty.
        /// </returns>
        public object ExecuteScalarHelper(string sprocName, int timeout = 0, DbConnection connection = null, DbTransaction transaction = null, params SqlParameter[] commandParams)
        {
            if (String.IsNullOrEmpty(sprocName))
            {
                throw new ArgumentNullException("sprocName");
            }
            DbCommand cmd = new SqlCommand(sprocName);
            cmd.CommandType = CommandType.StoredProcedure;
            if (timeout > 0)
            {
                cmd.CommandTimeout = timeout;
            }
            cmd.Parameters.AddRange(commandParams);
            return this.ExecuteScalarHelper(command: cmd, connection: connection, transaction: transaction);
        }

        /// <summary>
        /// Execute a scalar stored procedure using existing connection string
        /// </summary>
        /// <param name="command">The command to be executed on the connection</param>
        /// <param name="transaction">The transaction command will be included</param>
        /// <param name="commandParams">sql parameters to pass into the stored procedure</param>
        /// <returns>
        ///     Thr first column of the first row int he result set, or a null reference if the result set is empty.
        /// </returns>
        public object ExecuteScalarHelper(DbCommand command, DbConnection connection = null, DbTransaction transaction = null)
        {
            return ExecuteSprocHelper(cmd: command, isScalar: true, connection: connection, dbTran: transaction);
        }

        /// <summary>
        /// Execute a scalar stored procedure using existing connection string
        /// </summary>
        /// <param name="sprocName">stored procedure name to be executed</param>
        /// <param name="timeout">The time out value</param>
        /// <param name="connection">The connection command execute on</param>
        /// <param name="dbTran">The transaction command will be included</param>
        /// <param name="commandParams">sql parameters to pass into the stored procedure</param>
        /// <returns>
        ///     The return result
        /// </returns>
        public int ExecuteNonQueryHelper(string sprocName, int timeout = 0, DbConnection connection = null, DbTransaction dbTran = null, params SqlParameter[] commandParams)
        {
            return (int)ExecuteSprocHelper(sprocName: sprocName, isScalar: false, timeout: timeout, connection: connection, dbTran: dbTran, commandParams: commandParams);
        }

        /// <summary>
        /// The method to prcess a data reader from ExecuteReaderHelper to return caller expected value
        /// </summary>
        /// <typeparam name="T">the expected return type</typeparam>
        /// <param name="reader">the data reader made by the command</param>
        /// <returns>
        ///     A instance of expected return type.
        /// </returns>
        public delegate T ProcessingDelegate<T>(IDataReader reader);

        /// <summary>
        /// Execute a reader stored procedure using existing connection string
        /// </summary>
        /// <typeparam name="T">the return type which need to be got from the data reader</typeparam>
        /// <param name="sprocName">stored procedure name to be executed</param>
        /// <param name="processMethod">method to process data reader and make return value</param>
        /// <param name="connection">The connection the command will execute on</param>
        /// <param name="dbTran">The transaction the command will execute on</param>
        /// <param name="commandParams">sql parameters to pass into the stored procedure</param>
        /// <returns>
        ///     The process result as specific return type
        /// </returns>
        public T ExecuteReaderHelper<T>(string sprocName,
                                                              ProcessingDelegate<T> processMethod,
                                                              DbConnection connection = null,
                                                              DbTransaction dbTran = null,
                                                              params SqlParameter[] commandParams) where T : class
        {
            DbConnection dbConnection = null;
            try
            {
                T sqlRet = default(T);
                dbConnection = connection ?? new SqlConnection(this.ConnectionString);
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }
                using (var cmd = dbConnection.CreateCommand())
                {
                    cmd.Transaction = dbTran;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sprocName;
                    cmd.Parameters.AddRange(commandParams);
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sqlRet = processMethod(reader);
                        }
                    }
                }
                return sqlRet;
            }
            catch (Exception)
            {
                if (null != dbTran)
                {
                    dbTran.Rollback();
                }
                throw;
            }
            finally
            {
                if (null == connection && null != dbConnection)
                {
                    dbConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// Execute a reader stored procedure using existing connection string
        /// </summary>
        /// <typeparam name="T">the return type which need to be got from the data reader</typeparam>
        /// <param name="sprocName">stored procedure name to be executed</param>
        /// <param name="processMethod">method to process data reader and make return value</param>
        /// <param name="connection">The connection the command will execute on</param>
        /// <param name="dbTran">The transaction the command will execute on</param>
        /// <param name="commandParams">sql parameters to pass into the stored procedure</param>
        /// <returns>
        ///     The process result as specific return type
        /// </returns>
        public IList<T> ExecuteReaderToListHelper<T>(string sprocName,
                                                              ProcessingDelegate<T> processMethod,
                                                              DbConnection connection = null,
                                                              DbTransaction dbTran = null,
                                                              params SqlParameter[] commandParams) where T : class
        {
            DbConnection dbConnection = null;
            try
            {
                IList<T> collection = new List<T>();
                dbConnection = connection ?? new SqlConnection(this.ConnectionString);
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }
                using (var cmd = dbConnection.CreateCommand())
                {
                    cmd.Transaction = dbTran;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sprocName;
                    cmd.Parameters.AddRange(commandParams);
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            collection.Add(processMethod(reader));
                        }
                    }
                }
                return collection;
            }
            catch (Exception)
            {
                if (null != dbTran)
                {
                    dbTran.Rollback();
                }
                throw;
            }
            finally
            {
                if (null == connection && null != dbConnection)
                {
                    dbConnection.Dispose();
                }
            }
        }

        private object ExecuteSprocHelper(string sprocName, bool isScalar, int timeout = 0, DbConnection connection = null, DbTransaction dbTran = null, params SqlParameter[] commandParams)
        {
            if (String.IsNullOrEmpty(sprocName))
            {
                throw new ArgumentNullException("sprocName");
            }
            DbCommand cmd = new SqlCommand(sprocName);
            cmd.CommandType = CommandType.StoredProcedure;
            if (timeout > 0)
            {
                cmd.CommandTimeout = timeout;
            }
            cmd.Parameters.AddRange(commandParams);
            return this.ExecuteSprocHelper(cmd, isScalar, connection, dbTran);
        }

        private object ExecuteSprocHelper(DbCommand cmd, bool isScalar, DbConnection connection = null, DbTransaction dbTran = null)
        {
            DbConnection dbConnection = null;
            try
            {
                dbConnection = connection ?? new SqlConnection(this.ConnectionString);
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }
                object ret = null;
                using (cmd)
                {
                    cmd.Connection = dbConnection;
                    if (dbTran != null)
                    {
                        cmd.Transaction = dbTran;
                    }
                    ret = isScalar ? cmd.ExecuteScalar() : cmd.ExecuteNonQuery();
                }
                return ret;
            }
            catch (Exception)
            {
                if (null != dbTran)
                {
                    dbTran.Rollback();
                }
                throw;
            }
            finally
            {
                if (null == connection && null != dbConnection)
                {
                    dbConnection.Dispose();
                }
            }
        }
    }
}
