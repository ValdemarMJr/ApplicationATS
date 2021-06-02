using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Database.Utils
{
    public class ConnectionUtils
    {
        public static string GetProviderName(DbProviderEnum pDbProvider)
        {
            switch (pDbProvider)
            {
                case DbProviderEnum.Oracle:
                    return "System.Data.OracleClient";
                default:
                    return "System.Data.SqlClient";
            }
        }

        public static string BuildConnectionString(string pInstancia, string pUsuario, string pSenha, string pBanco, bool isOracle)
        {
            string connectionString = "Data Source=" + pInstancia + ";";
            if (!isOracle)
                connectionString += "database=" + pBanco + ";";
            connectionString += "user id=" + pUsuario + ";password=" + pSenha;
            return connectionString;
        }
    }
}
