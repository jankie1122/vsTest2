/*----------------------------------------------------------------
// Copyright (C) 2017 天美联盟企业管理咨询有限公司
// 版权所有。
//
// 文件名：ConnectionBase
// 文件功能描述：结合dapper的数据库链接工厂总线，简化事务写法。
// 请求
// 创建者：陈璧
// 创建时间：2017-09-25 10:26:09
//  
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using System.Data.Common;
using TM.SOA.Interface;
using TM.SOA.Utility.Configs;
using System.ComponentModel;
using TM.SOA.Utility.Log;

namespace TM.SOA.Core.Data
{
    /// <summary>
    /// 数据库链接总线
    /// </summary>
    public class ConnectionBase : IConnectionBase
    {
        #region Member Fields
        private string _connectionString;
        private IDbProvider _provider;
        private IDbConnection _sharedConnection;
        private int _sharedConnectionDepth;
        private DbProviderFactory _factory;

        private IDbTransaction _transaction;
        private int _transactionDepth;
        private bool _transactionCancelled;
        private IsolationLevel? _isolationLevel;
        private string _paramPrefix;

        #endregion

        #region IDisposable

        /// <summary>
        ///     Automatically close one open shared connection
        /// </summary>
        public void Dispose()
        {
            // Automatically close one open connection reference
            //  (Works with KeepConnectionAlive and manually opening a shared connection)
            CloseSharedConnection();
        }

        #endregion

        #region Constructors
        public ConnectionBase()
        {
            _connectionString = TMConfig.SqlConn;
            Initialise(DatabaseProvider.Resolve("SqlServer", true, _connectionString));
        }
        public ConnectionBase(string connectionString, string providerName = null)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("Connection string cannot be null or empty", "connectionString");

            _connectionString = connectionString;
            Initialise(DatabaseProvider.Resolve((providerName ?? "SqlServer"), true, _connectionString));
            //_connectionString = connectionString;
        }
        
        /// <summary>
        ///     Provides common initialization for the various constructors.
        /// </summary>
        private void Initialise(IDbProvider provider)
        {
            // Reset
            // What character is used for delimiting parameters in SQL
            _provider = provider;
            _paramPrefix = _provider.GetParameterPrefix(_connectionString);
            _factory = _provider.GetFactory();
            //_defaultMapper = mapper ?? new ConventionMapper();
        }

        #endregion

        #region Public Properties
        /// <summary>
        ///     When set to true, PetaPoco will automatically create the "SELECT columns" part of any query that looks like it
        ///     needs it
        /// </summary>
        public bool EnableAutoSelect { get; set; }

        /// <summary>
        ///     When set to true, parameters can be named ?myparam and populated from properties of the passed in argument values.
        /// </summary>
        public bool EnableNamedParams { get; set; }

        /// <summary>
        ///     Sets the timeout value for all SQL statements.
        /// </summary>
        public int CommandTimeout { get; set; }

        /// <summary>
        ///     Sets the timeout value for the next (and only next) SQL statement
        /// </summary>
        public int OneTimeCommandTimeout { get; set; }

        /// <summary>
        ///     Gets the loaded database provider. <seealso cref="Provider" />.
        /// </summary>
        /// <returns>
        ///     The loaded database type.
        /// </returns>
        public IDbProvider Provider
        {
            get { return _provider; }
        }

        /// <summary>
        ///     Gets the connection string.
        /// </summary>
        /// <returns>
        ///     The connection string.
        /// </returns>
        public string ConnectionString
        {
            get { return _connectionString; }
        }

        /// <summary>
        ///     Gets or sets the transaction isolation level.
        /// </summary>
        /// <remarks>
        ///     When value is null, the underlying providers default isolation level is used.
        /// </remarks>
        public IsolationLevel? IsolationLevel
        {
            get { return _isolationLevel; }
            set
            {
                if (_transaction != null)
                    throw new InvalidOperationException("Isolation level can't be changed during a transaction.");

                _isolationLevel = value;
            }
        }

        #endregion

        #region Transaction Management

        /// <summary>
        ///     Gets the current transaction instance.
        /// </summary>
        /// <returns>
        ///     The current transaction instance; else, <c>null</c> if not transaction is in progress.
        /// </returns>
        IDbTransaction ITransactionAccessor.Transaction
        {
            get { return _transaction; }
        }

        // Helper to create a transaction scope

        /// <summary>
        ///     Starts or continues a transaction.
        /// </summary>
        /// <returns>An ITransaction reference that must be Completed or disposed</returns>
        /// <remarks>
        ///     This method makes management of calls to Begin/End/CompleteTransaction easier.
        ///     The usage pattern for this should be:
        ///     using (var tx = db.GetTransaction())
        ///     {
        ///     // Do stuff
        ///     db.Update(...);
        ///     // Mark the transaction as complete
        ///     tx.Complete();
        ///     }
        ///     Transactions can be nested but they must all be completed otherwise the entire
        ///     transaction is aborted.
        /// </remarks>
        public ITransaction GetTransaction()
        {
            return new Transaction(this);
        }

        /// <summary>
        ///     Called when a transaction starts.  Overridden by the T4 template generated database
        ///     classes to ensure the same DB instance is used throughout the transaction.
        /// </summary>
        public virtual void OnBeginTransaction()
        {
        }

        /// <summary>
        ///     Called when a transaction ends.
        /// </summary>
        public virtual void OnEndTransaction()
        {
        }

        /// <summary>
        ///     Starts a transaction scope, see GetTransaction() for recommended usage
        /// </summary>
        public void BeginTransaction()
        {
            _transactionDepth++;

            if (_transactionDepth == 1)
            {
                OpenSharedConnection();
                _transaction = !_isolationLevel.HasValue ? _sharedConnection.BeginTransaction() : _sharedConnection.BeginTransaction(_isolationLevel.Value);
                _transactionCancelled = false;
                OnBeginTransaction();
            }
        }

        /// <summary>
        ///     Internal helper to cleanup transaction
        /// </summary>
        private void CleanupTransaction()
        {
            OnEndTransaction();

            if (_transactionCancelled)
                _transaction.Rollback();
            else
                _transaction.Commit();

            _transaction.Dispose();
            _transaction = null;

            CloseSharedConnection();
        }

        /// <summary>
        ///     Aborts the entire outer most transaction scope
        /// </summary>
        /// <remarks>
        ///     Called automatically by Transaction.Dispose()
        ///     if the transaction wasn't completed.
        /// </remarks>
        public void AbortTransaction()
        {
            _transactionCancelled = true;
            if ((--_transactionDepth) == 0)
                CleanupTransaction();
        }

        /// <summary>
        ///     Marks the current transaction scope as complete.
        /// </summary>
        public void CompleteTransaction()
        {
            if ((--_transactionDepth) == 0)
                CleanupTransaction();
        }

        /// <summary>
        ///     Transaction object helps maintain transaction depth counts
        /// </summary>
        public class Transaction : ITransaction
        {
            private ConnectionBase _db;

            public Transaction(ConnectionBase db)
            {
                _db = db;
                _db.BeginTransaction();
            }

            public void Complete()
            {
                _db.CompleteTransaction();
                _db = null;
            }

            public void Dispose()
            {
                if (_db != null)
                    _db.AbortTransaction();
            }
        }

        #endregion

        #region Connection Management
        /// <summary>
        ///     When set to true the first opened connection is kept alive until this object is disposed
        /// </summary>
        public bool KeepConnectionAlive { get; set; }

        /// <summary>
        ///     Open a connection that will be used for all subsequent queries.
        /// </summary>
        /// <remarks>
        ///     Calls to Open/CloseSharedConnection are reference counted and should be balanced
        /// </remarks>
        public void OpenSharedConnection()
        {
            if (_sharedConnectionDepth == 0)
            {
                _sharedConnection = _factory.CreateConnection();
                _sharedConnection.ConnectionString = _connectionString;

                if (_sharedConnection.State == ConnectionState.Broken)
                    _sharedConnection.Close();

                if (_sharedConnection.State == ConnectionState.Closed)
                    _sharedConnection.Open();

                _sharedConnection = OnConnectionOpened(_sharedConnection);

                if (KeepConnectionAlive)
                    _sharedConnectionDepth++; // Make sure you call Dispose
            }
            _sharedConnectionDepth++;
        }

        /// <summary>
        ///     Releases the shared connection
        /// </summary>
        public void CloseSharedConnection()
        {
            if (_sharedConnectionDepth > 0)
            {
                _sharedConnectionDepth--;
                if (_sharedConnectionDepth == 0)
                {
                    OnConnectionClosing(_sharedConnection);
                    _sharedConnection.Dispose();
                    _sharedConnection = null;
                }
            }
        }

        /// <summary>
        ///     Provides access to the currently open shared connection (or null if none)
        /// </summary>
        public IDbConnection Connection
        {
            get { return _sharedConnection; }
        }


        #endregion

        #region Exception Reporting and Logging

        /// <summary>
        ///     Called if an exception occurs during processing of a DB operation.  Override to provide custom logging/handling.
        /// </summary>
        /// <param name="x">The exception instance</param>
        /// <returns>True to re-throw the exception, false to suppress it</returns>
        public virtual bool OnException(string operation, Exception ex)
        {
            Log4NetHelper.Log(Utility.Enums.LogTypeEnum.SysLog, Utility.Enums.LogLevelEnum.Error, "ConnectionBase执行db["+ operation + "]异常", ex);
            //System.Diagnostics.Debug.WriteLine(ex.ToString());
            //System.Diagnostics.Debug.WriteLine(LastCommand);
            return true;
        }

        /// <summary>
        ///     Called when DB connection opened
        /// </summary>
        /// <param name="conn">The newly opened IDbConnection</param>
        /// <returns>The same or a replacement IDbConnection</returns>
        /// <remarks>
        ///     Override this method to provide custom logging of opening connection, or
        ///     to provide a proxy IDbConnection.
        /// </remarks>
        public virtual IDbConnection OnConnectionOpened(IDbConnection conn)
        {
            return conn;
        }

        /// <summary>
        ///     Called when DB connection closed
        /// </summary>
        /// <param name="conn">The soon to be closed IDBConnection</param>
        public virtual void OnConnectionClosing(IDbConnection conn)
        {
        }

        /// <summary>
        ///     Called just before an DB command is executed
        /// </summary>
        /// <param name="cmd">The command to be executed</param>
        /// <remarks>
        ///     Override this method to provide custom logging of commands and/or
        ///     modification of the IDbCommand before it's executed
        /// </remarks>
        public virtual void OnExecutingCommand(IDbCommand cmd)
        {
        }

        /// <summary>
        ///     Called on completion of command execution
        /// </summary>
        /// <param name="cmd">The IDbCommand that finished executing</param>
        public virtual void OnExecutedCommand(IDbCommand cmd)
        {
        }
        #endregion

        #region IProvider
        /// <summary>
        ///     Look at the type and provider name being used and instantiate a suitable DatabaseType instance.
        /// </summary>
        /// <param name="providerName">The provider name.</param>
        /// <param name="allowDefault">A flag that when set allows the default <see cref="SqlServerDatabaseProvider"/> to be returned if not match is found.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The database type.</returns>
        internal static IDbProvider Resolve(string providerName, bool allowDefault, string connectionString)
        {
            // Try again with provider name
            if (providerName.IndexOf("SqlServer", StringComparison.InvariantCultureIgnoreCase) >= 0 ||
               providerName.IndexOf("System.Data.SqlClient", StringComparison.InvariantCultureIgnoreCase) >= 0)
                return Singleton<SqlServerDatabaseProvider>.Instance;

            //if (providerName.IndexOf("MySql", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<MySqlDatabaseProvider>.Instance;
            //if (providerName.IndexOf("MariaDb", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<MariaDbDatabaseProvider>.Instance;
            //if (providerName.IndexOf("SqlServerCe", StringComparison.InvariantCultureIgnoreCase) >= 0 ||
            //    providerName.IndexOf("SqlCeConnection", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<SqlServerCEDatabaseProviders>.Instance;
            //if (providerName.IndexOf("Npgsql", StringComparison.InvariantCultureIgnoreCase) >= 0
            //    || providerName.IndexOf("pgsql", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<PostgreSQLDatabaseProvider>.Instance;
            //if (providerName.IndexOf("Oracle", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<OracleDatabaseProvider>.Instance;
            //if (providerName.IndexOf("SQLite", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<SQLiteDatabaseProvider>.Instance;
            //if (providerName.IndexOf("Firebird", StringComparison.InvariantCultureIgnoreCase) >= 0 ||
            //    providerName.IndexOf("FbConnection", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<FirebirdDbDatabaseProvider>.Instance;
            //if (providerName.IndexOf("OleDb", StringComparison.InvariantCultureIgnoreCase) >= 0
            //    && (connectionString.IndexOf("Jet.OLEDB", StringComparison.InvariantCultureIgnoreCase) > 0 || connectionString.IndexOf("ACE.OLEDB", StringComparison.InvariantCultureIgnoreCase) > 0))
            //{
            //    return Singleton<MsAccessDbDatabaseProvider>.Instance;
            //}

            if (!allowDefault)
                throw new ArgumentException("Could not match `" + providerName + "` to a provider.", "providerName");

            // Assume SQL Server
            return Singleton<SqlServerDatabaseProvider>.Instance;
        }

        #endregion

        #region Operation
        public dynamic Insert<T>(T ob) where T : class
        {
            OpenSharedConnection();
            try
            {
                return _sharedConnection.Insert<T>(ob, _transaction);
            }
            catch (Exception ex)
            {
                if (OnException("Insert", ex))
                    return null;
                return null;
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public async Task<dynamic> InsertAsync<T>(T ob) where T : class
        {
            OpenSharedConnection();
            try
            {
                return await _sharedConnection.InsertAsync<T>(ob, _transaction);
            }
            catch (Exception ex)
            {
                if (OnException("InsertAsync", ex))
                    return null;
                return null;
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public bool Update<T>(T ob) where T : class
        {
            OpenSharedConnection();
            try
            {
                return _sharedConnection.Update<T>(ob,_transaction);
            }
            catch (Exception ex)
            {
                if (OnException("Update", ex))
                    return false;
                return false;
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public async Task<bool> UpdateAsync<T>(T ob) where T : class
        {
            OpenSharedConnection();
            try
            {
                return await _sharedConnection.UpdateAsync<T>(ob, _transaction);
            }
            catch (Exception ex)
            {
                if (OnException("UpdateAsync", ex))
                    return false;
                return false;
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public int Execute(string sql, object param = null, int? commandTimeout = null, CommandType ? commandType = null)
        {
            OpenSharedConnection();
            try
            {
                return _sharedConnection.Execute(sql, param, _transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                if (OnException("Execute", ex))
                    throw ex;
                return 0;
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public async Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            OpenSharedConnection();
            try
            {
                return await _sharedConnection.ExecuteAsync(sql, param, _transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                if (OnException("ExecuteAsync", ex))
                    throw ex;
                return 0;
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public bool Delete<T>(T ob) where T : class
        {
            OpenSharedConnection();
            try
            {
                return _sharedConnection.Delete(ob, _transaction);
            }
            catch (Exception ex)
            {
                if (OnException("Delete", ex))
                    throw ex;
                return false;
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public async Task<bool> DeleteAsync<T>(T ob) where T : class
        {
            OpenSharedConnection();
            try
            {
                return await _sharedConnection.DeleteAsync(ob, _transaction);
            }
            catch (Exception ex)
            {
                if (OnException("DeleteAsync", ex))
                    throw ex;
                return false;
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public object ExecuteScalar(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            OpenSharedConnection();
            try
            {
                return _sharedConnection.ExecuteScalar(sql, param, _transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                if (OnException("ExecuteScalar", ex))
                    throw ex;
                return 0;
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public async Task<object> ExecuteScalarAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            OpenSharedConnection();
            try
            {
                return await _sharedConnection.ExecuteScalarAsync(sql, param, _transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                if (OnException("ExecuteScalarAsync", ex))
                    throw ex;
                return 0;
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public T ExecuteScalar<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            OpenSharedConnection();
            try
            {
                return _sharedConnection.ExecuteScalar<T>(sql, param, _transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                if (OnException("ExecuteScalar", ex))
                    throw ex;
                return default(T);
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null) 
        {
            OpenSharedConnection();
            try
            {
                return await _sharedConnection.ExecuteScalarAsync<T>(sql, param, _transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                if (OnException("ExecuteScalarAsync", ex))
                    throw ex;
                return default(T);
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public T QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            OpenSharedConnection();
            try
            {
                return _sharedConnection.QueryFirstOrDefault<T>(sql, param, _transaction, commandTimeout,commandType);
            }
            catch (Exception ex)
            {
                if (OnException("QueryFirstOrDefault", ex))
                    throw ex;
                return default(T);
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null)
        {
            OpenSharedConnection();
            try
            {
                return await _sharedConnection.QueryFirstOrDefaultAsync<T>(sql, param, _transaction);
            }
            catch (Exception ex)
            {
                if (OnException("QueryFirstOrDefaultAsync", ex))
                    throw ex;
                return default(T);
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            OpenSharedConnection();
            try
            {
                return _sharedConnection.Query<T>(sql, param, _transaction);
            }
            catch (Exception ex)
            {
                if (OnException("Query", ex))
                    throw ex;
                return null;
            }
            finally
            {
                CloseSharedConnection();
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            OpenSharedConnection();
            try
            {
                return await _sharedConnection.QueryAsync<T>(sql, param, _transaction);
            }
            catch (Exception ex)
            {
                if (OnException("QueryAsync", ex))
                    throw ex;
                return null;
            }
            finally
            {
                CloseSharedConnection();
            }
        }

        #endregion
    }

    #region DatabaseProvider
    internal static class Singleton<T> where T : new()
    {
        public static T Instance = new T();
    }
    /// <summary>
    ///     Base class for DatabaseType handlers - provides default/common handling for different database engines
    /// </summary>
    public abstract class DatabaseProvider : IDbProvider
    {
        /// <summary>
        ///     Gets the DbProviderFactory for this database provider.
        /// </summary>
        /// <returns>The provider factory.</returns>
        public abstract DbProviderFactory GetFactory();

        /// <summary>
        ///     Returns the .net standard conforming DbProviderFactory.
        /// </summary>
        /// <param name="assemblyQualifiedNames">The assembly qualified name of the provider factory.</param>
        /// <returns>The db provider factory.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="assemblyQualifiedNames" /> does not match a type.</exception>
        protected DbProviderFactory GetFactory(params string[] assemblyQualifiedNames)
        {
            Type ft = null;
            foreach (var assemblyName in assemblyQualifiedNames)
            {
                ft = Type.GetType(assemblyName);

                if (ft != null)
                {
                    break;
                }
            }

            if (ft == null)
                throw new ArgumentException("Could not load the " + GetType().Name + " DbProviderFactory.");

            return (DbProviderFactory)ft.GetField("Instance").GetValue(null);
        }

        /// <summary>
        ///     Look at the type and provider name being used and instantiate a suitable DatabaseType instance.
        /// </summary>
        /// <param name="type">The type name.</param>
        /// <param name="allowDefault">A flag that when set allows the default <see cref="SqlServerDatabaseProvider"/> to be returned if not match is found.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The database provider.</returns>
        internal static IDbProvider Resolve(Type type, bool allowDefault, string connectionString)
        {
            var typeName = type.Name;
            if (typeName.Equals("SqlConnection") || typeName.Equals("SqlClientFactory"))
                return Singleton<SqlServerDatabaseProvider>.Instance;
            // Try using type name first (more reliable)
            if (typeName.StartsWith("MySql"))
                 return Singleton<MySqlDatabaseProvider>.Instance;
            //if (typeName.StartsWith("MariaDb"))
            //    return Singleton<MariaDbDatabaseProvider>.Instance;
            //if (typeName.StartsWith("SqlCe"))
            //    return Singleton<SqlServerCEDatabaseProviders>.Instance;
            //if (typeName.StartsWith("Npgsql") || typeName.StartsWith("PgSql"))
            //    return Singleton<PostgreSQLDatabaseProvider>.Instance;
            if (typeName.StartsWith("Oracle"))
                 return Singleton<OracleDatabaseProvider>.Instance;
            //if (typeName.StartsWith("SQLite"))
            //    return Singleton<SQLiteDatabaseProvider>.Instance;
            //if (typeName.StartsWith("FbConnection") || typeName.EndsWith("FirebirdClientFactory"))
            //    return Singleton<FirebirdDbDatabaseProvider>.Instance;
            //if (typeName.IndexOf("OleDb", StringComparison.InvariantCultureIgnoreCase) >= 0
            //    && (connectionString.IndexOf("Jet.OLEDB", StringComparison.InvariantCultureIgnoreCase) > 0 || connectionString.IndexOf("ACE.OLEDB", StringComparison.InvariantCultureIgnoreCase) > 0))
            //{
            //    return Singleton<MsAccessDbDatabaseProvider>.Instance;
            //}
            if (!allowDefault)
                throw new ArgumentException("Could not match `" + type.FullName + "` to a provider.", "type");

            // Assume SQL Server
            return Singleton<SqlServerDatabaseProvider>.Instance;
        }

        /// <summary>
        ///     Look at the type and provider name being used and instantiate a suitable DatabaseType instance.
        /// </summary>
        /// <param name="providerName">The provider name.</param>
        /// <param name="allowDefault">A flag that when set allows the default <see cref="SqlServerDatabaseProvider"/> to be returned if not match is found.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The database type.</returns>
        internal static IDbProvider Resolve(string providerName, bool allowDefault, string connectionString)
        {
            //// Try again with provider name
             if (providerName.IndexOf("MySql", StringComparison.InvariantCultureIgnoreCase) >= 0)
                 return Singleton<MySqlDatabaseProvider>.Instance;
            //if (providerName.IndexOf("MariaDb", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<MariaDbDatabaseProvider>.Instance;
            //if (providerName.IndexOf("SqlServerCe", StringComparison.InvariantCultureIgnoreCase) >= 0 ||
            //    providerName.IndexOf("SqlCeConnection", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<SqlServerCEDatabaseProviders>.Instance;
            //if (providerName.IndexOf("Npgsql", StringComparison.InvariantCultureIgnoreCase) >= 0
            //    || providerName.IndexOf("pgsql", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<PostgreSQLDatabaseProvider>.Instance;
            if (providerName.IndexOf("Oracle", StringComparison.InvariantCultureIgnoreCase) >= 0)
                 return Singleton<OracleDatabaseProvider>.Instance;
            //if (providerName.IndexOf("SQLite", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<SQLiteDatabaseProvider>.Instance;
            //if (providerName.IndexOf("Firebird", StringComparison.InvariantCultureIgnoreCase) >= 0 ||
            //    providerName.IndexOf("FbConnection", StringComparison.InvariantCultureIgnoreCase) >= 0)
            //    return Singleton<FirebirdDbDatabaseProvider>.Instance;
            //if (providerName.IndexOf("OleDb", StringComparison.InvariantCultureIgnoreCase) >= 0
            //    && (connectionString.IndexOf("Jet.OLEDB", StringComparison.InvariantCultureIgnoreCase) > 0 || connectionString.IndexOf("ACE.OLEDB", StringComparison.InvariantCultureIgnoreCase) > 0))
            //{
            //    return Singleton<MsAccessDbDatabaseProvider>.Instance;
            //}
            if (providerName.IndexOf("SqlServer", StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                providerName.IndexOf("System.Data.SqlClient", StringComparison.InvariantCultureIgnoreCase) >= 0)
                return Singleton<SqlServerDatabaseProvider>.Instance;

            if (!allowDefault)
                throw new ArgumentException("Could not match `" + providerName + "` to a provider.", "providerName");

            // Assume SQL Server
            return Singleton<SqlServerDatabaseProvider>.Instance;
        }

        /// <summary>
        ///     Unwraps a wrapped <see cref="DbProviderFactory"/>.
        /// </summary>
        /// <param name="factory">The factory to unwrap.</param>
        /// <returns>The unwrapped factory or the original factory if no wrapping occurred.</returns>
        internal static DbProviderFactory Unwrap(DbProviderFactory factory)
        {
            var sp = factory as IServiceProvider;

            if (sp == null)
                return factory;

            var unwrapped = sp.GetService(factory.GetType()) as DbProviderFactory;
            return unwrapped == null ? factory : Unwrap(unwrapped);
        }

        /// <summary>
        ///     Escape and arbitary SQL identifier into a format suitable for the associated database provider
        /// </summary>
        /// <param name="sqlIdentifier">The SQL identifier to be escaped</param>
        /// <returns>The escaped identifier</returns>
        public virtual string EscapeSqlIdentifier(string sqlIdentifier)
        {
            return string.Format("[{0}]", sqlIdentifier);
        }

        /// <summary>
        ///     Returns the prefix used to delimit parameters in SQL query strings.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The providers character for prefixing a query parameter.</returns>
        public virtual string GetParameterPrefix(string connectionString)
        {
            return "@";
        }
    }
    public class SqlServerDatabaseProvider : DatabaseProvider
    {
        public override DbProviderFactory GetFactory()
        {
            return GetFactory("System.Data.SqlClient.SqlClientFactory, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
        }
    }
    public class MySqlDatabaseProvider : DatabaseProvider
    {
        public override DbProviderFactory GetFactory()
        {
            return GetFactory("MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Culture=neutral, PublicKeyToken=c5687fc88969c44d");
        }

        public override string GetParameterPrefix(string connectionString)
        {
            if (connectionString != null && connectionString.IndexOf("Allow User Variables=true") >= 0)
                return "?";
            else
                return "@";
        }

        public override string EscapeSqlIdentifier(string sqlIdentifier)
        {
            return string.Format("`{0}`", sqlIdentifier);
        }

       
    }


    public class OracleDatabaseProvider : DatabaseProvider
    {
        public override string GetParameterPrefix(string connectionString)
        {
            return ":";
        }

        public override DbProviderFactory GetFactory()
        {
            // "Oracle.ManagedDataAccess.Client.OracleClientFactory, Oracle.ManagedDataAccess" is for Oracle.ManagedDataAccess.dll
            // "Oracle.DataAccess.Client.OracleClientFactory, Oracle.DataAccess" is for Oracle.DataAccess.dll
            return GetFactory("Oracle.ManagedDataAccess.Client.OracleClientFactory, Oracle.ManagedDataAccess, Culture=neutral, PublicKeyToken=89b483f429c47342",
                              "Oracle.DataAccess.Client.OracleClientFactory, Oracle.DataAccess");
        }

        public override string EscapeSqlIdentifier(string sqlIdentifier)
        {
            return string.Format("\"{0}\"", sqlIdentifier.ToUpperInvariant());
        }
        
    }

    #endregion

    #region Base Interface

    public interface IConnectionBase : IDependency, IDisposable, ITransactionAccessor
    {
        /// <summary>
        ///     Gets the current <seealso cref="Provider" />.
        /// </summary>
        /// <returns>
        ///     The current database provider.
        /// </returns>
        IDbProvider Provider { get; }

        /// <summary>
        ///     Gets the connection string.
        /// </summary>
        /// <returns>
        ///     The connection string.
        /// </returns>
        string ConnectionString { get; }

        /// <summary>
        ///     Gets or sets the transaction isolation level.
        /// </summary>
        /// <remarks>
        ///     When value is null, the underlying providers default isolation level is used.
        /// </remarks>
        IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        ///     Starts or continues a transaction.
        /// </summary>
        /// <returns>An ITransaction reference that must be Completed or disposed</returns>
        /// <remarks>
        ///     This method makes management of calls to Begin/End/CompleteTransaction easier.
        ///     The usage pattern for this should be:
        ///     using (var tx = db.GetTransaction())
        ///     {
        ///     // Do stuff
        ///     db.Update(...);
        ///     // Mark the transaction as complete
        ///     tx.Complete();
        ///     }
        ///     Transactions can be nested but they must all be completed otherwise the entire
        ///     transaction is aborted.
        /// </remarks>
        ITransaction GetTransaction();

        /// <summary>
        ///     Starts a transaction scope, see GetTransaction() for recommended usage
        /// </summary>
        void BeginTransaction();

        /// <summary>
        ///     Aborts the entire outer most transaction scope
        /// </summary>
        /// <remarks>
        ///     Called automatically by Transaction.Dispose()
        ///     if the transaction wasn't completed.
        /// </remarks>
        void AbortTransaction();

        /// <summary>
        ///     Marks the current transaction scope as complete.
        /// </summary>
        void CompleteTransaction();
    }
    /// <summary>
    ///     Represents a contract for a database type provider.
    /// </summary>
    public interface IDbProvider
    {
        DbProviderFactory GetFactory();
        /// <summary>
        ///     Returns the prefix used to delimit parameters in SQL query strings.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The providers character for prefixing a query parameter.</returns>
        string GetParameterPrefix(string connectionString);
    }
    /// <summary>
    ///     Represents a contract which exposes the current <see cref="IDbTransaction" /> instance.
    /// </summary>
    public interface ITransactionAccessor
    {
        /// <summary>
        ///     Gets the current transaction instance.
        /// </summary>
        /// <returns>
        ///     The current transaction instance; else, <c>null</c> if not transaction is in progress.
        /// </returns>
        IDbTransaction Transaction { get; }
    }
    /// <summary>
    ///     Represents the contract for the transaction.
    /// </summary>
    /// <remarks>
    ///     A PetaPoco helper to support transactions using the using syntax.
    /// </remarks>
    public interface ITransaction : IDisposable, IHideObjectMethods
    {
        /// <summary>
        ///     Completes the transaction. Not calling complete will cause the transaction to rollback on dispose.
        /// </summary>
        void Complete();
    }

    /// <summary>
    ///     An interface used to hide the 4 System.Object instance methods from the API in Visual Studio intellisense.
    /// </summary>
    /// <remarks>
    ///     Reference Project: MircoLite ORM (https://github.com/TrevorPilley/MicroLite)
    ///     Author: Trevor Pilley
    ///     Source: https://github.com/TrevorPilley/MicroLite/blob/develop/MicroLite/IHideObjectMethods.cs
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHideObjectMethods
    {
        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object other);

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <returns>The type of the object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification = "The method is defined on System.Object, this interface is just to hide it from intelisense in Visual Studio")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "GetType",
            Justification = "The method is defined on System.Object, this interface is just to hide it from intelisense in Visual Studio")]
        Type GetType();

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();
    }
    


    #endregion
}
