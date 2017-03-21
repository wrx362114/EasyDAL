using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Base;

namespace Dal.Database
{
    /// <summary>
    /// 数据库会话,用于管理数据库事务
    /// </summary>
    public class DbSession : IDisposable
    {
        [ThreadStatic]
        static DbSession _CurrentSession;

        /// <summary>
        /// 当前会话
        /// </summary>
        public static DbSession Current { get { return _CurrentSession; } }
        /// <summary>
        /// 是否在一个事务中
        /// </summary>
        public static bool InDbTrasaction { get { return _CurrentSession != null; } }
        /// <summary>
        /// 默认构造函数为私有.不能被外部实例化
        /// </summary>
        private DbSession() { }
        /// <summary>
        /// 开启一次数据库回话
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DbSession Begin(string db)
        {
            if (_CurrentSession != null)
            {
                throw new NotSupportedException("当前已有打开的数据库事务");
            }
            var session = new DbSession();
            session._Conn = DbConnFactory.Open(db);
            session.DT = session._Conn.BeginTransaction();
            _CurrentSession = session;

            return _CurrentSession;
        }
        /// <summary>
        /// 本次回话的数据库连接
        /// </summary>
        public IDbConnection Conn { get { return _Conn; } }

        private IDbConnection _Conn;

        private IDbTransaction DT;
        private bool Commited = false;
        /// <summary>
        /// 提交事务
        /// 事务只能提交一次
        /// </summary>
        public void Commit()
        {
            if (Commited || DT == null || _Conn == null || _Conn.State != ConnectionState.Open)
            {
                throw new Exception("事务状态错误,无法提交");
            }
            DT.Commit();
            Commited = true;
        }
        /// <summary>
        /// 释放回话与连接,未提交时自动回滚
        /// </summary>
        public void Dispose()
        {
            if (DT != null)
            {
                if (!Commited)
                {
                    DT.Rollback();
                }
                DT.Dispose();
            }
            if (_Conn != null && _Conn.State != ConnectionState.Closed)
            {
                _Conn.Close();
                _Conn.Dispose();
            }
            if (_CurrentSession != null)
            {
                _CurrentSession = null;
            }
        }
    }
}
