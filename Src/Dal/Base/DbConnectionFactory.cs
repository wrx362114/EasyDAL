using ServiceStack.OrmLite;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Database;

namespace Dal.Base
{
    public static class DbConnFactory
    {
        static ConcurrentDictionary<string, OrmLiteConnectionFactory> factorys = new ConcurrentDictionary<string, OrmLiteConnectionFactory>();

        public static SessionConnetion Open(string db)
        {
            if (DbSession.InDbTrasaction)
            {
                return new SessionConnetion(DbSession.Current.Conn);
            }
            return new SessionConnetion(GetFactory(db).Open());
        }
        private static OrmLiteConnectionFactory GetFactory(string db)
        {
            OrmLiteConnectionFactory temp;
            if (factorys.TryGetValue(db, out temp))
            {
                return temp;
            }
            var conn = ConfigurationManager.ConnectionStrings[db];
            switch (conn.ProviderName)
            {
                //case "System.Data.SqlClient":
                //    temp = new OrmLiteConnectionFactory(conn.ConnectionString, SqlServerDialect.Provider);
                //    break;
                //case "MySql.Data.MySqlClient":
                //    temp = new OrmLiteConnectionFactory(conn.ConnectionString, MySqlDialect.Provider);
                //    break;
                default:
                    throw new Exception("不支持数据库:" + db);
            }
            factorys.TryAdd(db, temp);
            return temp;
        }
    }
}
