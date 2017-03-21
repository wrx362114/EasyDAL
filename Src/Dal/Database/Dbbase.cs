using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Base;

namespace Dal.Database
{
    /// <summary>
    /// 数据库基类
    /// 包含多表查询方法
    /// </summary>
    public abstract class DbBase
    {
        protected abstract string DbName { get; }
        /// <summary>
        /// 开始一个新的数据库事务.同一个连接只能开启一层事务.重复调用会引发异常
        /// </summary>
        /// <returns></returns>
        public DbSession BeginTransaction()
        {
            return DbSession.Begin(DbName);
        }
        /// <summary>
        /// 自定义数据库查询.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(Action<SqlExp<T>> expression)
        {
            using (var conn = DbConnFactory.Open(DbName))
            {
                var exp = SqlExp<T>.GetSqlExp(conn);
                expression(exp);
                return conn.Select(exp.GetExp());
            }
        }
        /// <summary>
        /// 自定义数据库查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql)
        {
            using (var conn = DbConnFactory.Open(DbName))
            {
                return conn.Select<T>(sql);
            }
        }
        /// <summary>
        /// 自定义数据库查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object param)
        {
            using (var conn = DbConnFactory.Open(DbName))
            { 
                return conn.Select<T>(sql, param);
            }
        }
        /// <summary>
        /// 自定义数据库查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(  string sql, Dictionary<string, object> dict)
        {
            using (var conn = DbConnFactory.Open(DbName))
            { 
                return conn.Select<T>(sql, dict);
            }
        }
    }
}
