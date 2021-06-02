using System;

namespace ATS.DAL
{
    public class BaseDAL
    {
        public BaseDAL()
        {

        }
        public Database.Database DbHnd
        {
            get;
            set;
        }
        public String ConnectionString = GetConnectionString();
        
        public String ProviderName = "System.Data.SqlClient";

        public static Func<string> RaiseBuildConnectionString;

        private static string GetConnectionString()
        {
            #if NET472
                return ConexaoBanco.ConnectionString;
            #else
                return RaiseBuildConnectionString();
            #endif
        }
    }

    public class DbConnectionInfo
    {
        public String DataSource { get; set; }
        public String Database { get; set; }
        public String Usuario { get; set; }
        public String DsSenha { get; set; }

    }
}
