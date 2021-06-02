using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Data.Common;

namespace ATS.Database
{
    public class Database
    {
        private string _strConnectionString;

        private DbConnection _Connection;

        private DbTransaction _Transaction;

        private bool _InTransaction = false;

        private List<DbParameter> _parametros = new List<DbParameter>();

        private bool _customTimeoutSet;

        private DbCommand _command;

        private DbDataReader _dataReader;

        private string _strCurrentSqlText;

        private DbDataAdapter _dataAdapter;

        private DbProviderFactory _factory;

        private string _ProviderName;

        public string ProviderName
        {
            get
            {
                return _ProviderName;
            }
            set
            {
                _ProviderName = value;
            }
        }

        public List<DbParameter> Parametros
        {
            get
            {
                return _parametros;
            }
            set
            {
                _parametros = value;
            }
        }

        private int _CommandTimeout
        {
            get;
            set;
        }

        public int CommandTimeout
        {
            get
            {
                return _CommandTimeout;
            }
            set
            {
                _CommandTimeout = value;
                _customTimeoutSet = true;
            }
        }

        public bool IsOracle => _strConnectionString.ToUpper().Contains("MSDAORA") || _strConnectionString.ToUpper().Contains("ORACLE") || ProviderName == "System.Data.OracleClient";

        public Database(string strConnString, string strProviderName)
        {
            _ProviderName = strProviderName;
            DbConn_(strConnString);
        }

        protected void DbConn_(string strConnString)
        {
            _strConnectionString = strConnString;
            _factory = DbProviderFactories.GetFactory(ProviderName);
            _command = _factory.CreateCommand();
            _Connection = _factory.CreateConnection();
            _Connection.ConnectionString = _strConnectionString;
            _command.Connection = _Connection;
            _dataAdapter = _factory.CreateDataAdapter();
            _dataAdapter.SelectCommand = _factory.CreateCommand();
            _dataAdapter.SelectCommand.Connection = _Connection;
        }

        public void OpenConnection()
        {
            if (_Connection.State == ConnectionState.Open)
            {
                throw new Exception("A conexão já está aberta");
            }
            _Connection.Open();
            if (ProviderName == "System.Data.OracleClient")
            {
                ExecuteNonQuery("ALTER SESSION SET NLS_COMP=BINARY");
                ExecuteNonQuery("ALTER SESSION SET NLS_SORT=BINARY");
            }
        }

        public void SetCurrentSchema(string pSchemaName)
        {
            if (this.IsOracle)
                ExecuteNonQuery($"ALTER SESSION SET CURRENT_SCHEMA = {pSchemaName}");
        }

        public void CloseConnection()
        {
            _Connection.Close();
        }

        public virtual DataSet FillDataSet(string strSql)
        {
            _dataAdapter.SelectCommand = preencheCommand(_dataAdapter.SelectCommand, strSql);
            DataSet dataSet = new DataSet();
            try
            {
                _dataAdapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataSet;
        }

        public virtual DataSet FillDataSet(string strSql, int intRegistroInicial, int intNrDeRegistros)
        {
            _strCurrentSqlText = strSql;
            _dataAdapter.SelectCommand.CommandText = _strCurrentSqlText;
            foreach (DbParameter parametro in _parametros)
            {
                _dataAdapter.SelectCommand.Parameters.Add(parametro);
            }
            _parametros.Clear();
            if (_InTransaction)
            {
                _dataAdapter.SelectCommand.Transaction = _Transaction;
            }
            DataSet dataSet = new DataSet();
            try
            {
                _dataAdapter.Fill(dataSet, intRegistroInicial, intNrDeRegistros, "table1");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataSet;
        }

        public DataRow FillDataRow(string strSql)
        {
            DbDataReader reader = ExecuteReader(strSql);
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            if (dataTable.Rows.Count <= 0)
            {
                return null;
            }
            return dataTable.Rows[0];
        }

        public DbDataReader ExecuteReader(string strSql)
        {
            _command = preencheCommand(_command, strSql);
            if (_dataReader != null)
            {
                _dataReader.Dispose();
                _dataReader = null;
            }
            try
            {
                _dataReader = _command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dataReader;
        }

        public virtual void ExecuteNonQuery(string strSql)
        {
            DbCommand dbCommand = _factory.CreateCommand();
            dbCommand = preencheCommand(dbCommand, strSql);
            try
            {
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand.Dispose();
            }
        }

        public virtual int ExecuteQuery(string strSql)
        {
            DbCommand dbCommand = _factory.CreateCommand();
            dbCommand = preencheCommand(dbCommand, strSql);
            int result = 0;
            try
            {
                result = dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand.Dispose();
            }
            return result;
        }

        public virtual object ExecuteScalar(string strSql)
        {
            DbCommand dbCommand = _factory.CreateCommand();
            dbCommand = preencheCommand(dbCommand, strSql);
            try
            {
                return dbCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand.Dispose();
            }
        }

        public virtual long InsertGetKey(string strSql, string strNmColuna)
        {
            string text = "INSERT INTO ";
            int num = strSql.IndexOf(text);
            int num2 = strSql.IndexOf(" (");
            string str = strSql.Substring(num + text.Length, num2 - text.Length);
            bool flag = false;
            if (!_InTransaction)
            {
                BeginTransaction();
                flag = true;
            }
            long result;
            try
            {
                ExecuteNonQuery(strSql);
                object obj = ExecuteScalar("SELECT MAX(" + strNmColuna + ") AS newId FROM " + str);
                result = long.Parse(obj.ToString());
                if (flag)
                {
                    Commit();
                }
            }
            catch (Exception ex)
            {
                if (flag)
                {
                    Rollback();
                }
                throw ex;
            }
            return result;
        }

        public virtual long InsertGetKey(string strSql, string strNmColuna, bool useSelectIdentity)
        {
            string text = "INSERT INTO ";
            int num = strSql.IndexOf(text);
            int num2 = strSql.IndexOf(" (");
            string text2 = strSql.Substring(num + text.Length, num2 - text.Length);
            bool flag = false;
            if (!_InTransaction)
            {
                BeginTransaction();
                flag = true;
            }
            long result;
            try
            {
                ExecuteNonQuery(strSql);
                if (ProviderName == "System.Data.SqlClient" && useSelectIdentity)
                {
                    object obj = ExecuteScalar("SELECT @@IDENTITY");
                    result = long.Parse(obj.ToString());
                    if (flag)
                    {
                        Commit();
                    }
                }
                else if (ProviderName == "System.Data.OracleClient" && text2.ToUpper() == "DOCUMENTO")
                {
                    object obj = ExecuteScalar("SELECT SEQ_DOCUMENTO.currval FROM DUAL");
                    result = long.Parse(obj.ToString());
                    if (flag)
                    {
                        Commit();
                    }
                }
                else
                {
                    object obj = ExecuteScalar("SELECT MAX(" + strNmColuna + ") AS newId FROM " + text2);
                    result = long.Parse(obj.ToString());
                    if (flag)
                    {
                        Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                if (flag)
                {
                    Rollback();
                }
                throw ex;
            }
            return result;
        }

        public void BeginTransaction(IsolationLevel isoLvl)
        {
            try
            {
                _Transaction = _Connection.BeginTransaction(isoLvl);
                _InTransaction = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BeginTransaction()
        {
            try
            {
                _Transaction = _Connection.BeginTransaction();
                _InTransaction = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Commit()
        {
            if (_Transaction != null)
            {
                _Transaction.Commit();
                _InTransaction = false;
                _Transaction.Dispose();
                _Transaction = null;
                return;
            }
            throw new Exception("Não há uma transação aberta");
        }

        public void Rollback()
        {
            if (_Transaction != null)
            {
                _Transaction.Rollback();
                _InTransaction = false;
                _Transaction.Dispose();
                _Transaction = null;
                return;
            }
            throw new Exception("Não há uma transação aberta");
        }

        //public int? GrantLock(string resource, string lockMode, string lockOwner, string lockTimeout = null)
        //{
        //    int? result = null;
        //    if (ProviderName == "System.Data.SqlClient")
        //    {
        //        string text = string.Empty;
        //        if (lockTimeout != null)
        //        {
        //            text = @",  @LockTimeout = {lockTimeout}";
        //        }
        //        string strSql = @"DECLARE @RC INT;\r\n                                                   EXEC @RC = sp_getapplock @Resource='{resource}', @LockMode='{lockMode}', @LockOwner='{lockOwner}' {text};\r\n                                                   SELECT @RC;";
        //        object value = ExecuteScalar(strSql);
        //        result = Convert.ToInt16(value);
        //    }
        //    return result;
        //}

        public void Dispose()
        {
            if (_dataReader != null)
            {
                _dataReader.Dispose();
            }
            if (_dataAdapter != null)
            {
                _dataAdapter.Dispose();
            }
            if (_command != null)
            {
                _command.Dispose();
            }
            if (_Transaction != null)
            {
                _Transaction.Dispose();
            }
            if (_Connection.State == ConnectionState.Open)
            {
                _Connection.Close();
            }
            _Connection.Dispose();
            _InTransaction = false;
        }

        private DbCommand preencheCommand(DbCommand dbCommand, string strSql)
        {
            _strCurrentSqlText = strSql;
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = strSql;
            dbCommand.Connection = _Connection;
            if (_customTimeoutSet)
            {
                dbCommand.CommandTimeout = CommandTimeout;
            }
            foreach (DbParameter parametro in _parametros)
            {
                dbCommand.Parameters.Add(parametro);
            }
            _parametros.Clear();
            if (_InTransaction)
            {
                dbCommand.Transaction = _Transaction;
            }
            return dbCommand;
        }
    }
}
