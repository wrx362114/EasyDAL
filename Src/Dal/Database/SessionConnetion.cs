using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Database
{
    /// <summary>
    /// 回话连接封装类,
    /// 用以管理连接
    /// </summary>
    public class SessionConnetion : IDisposable, IDbConnection
    {
        /// <summary>
        /// 构造一个会话连接
        /// </summary>
        /// <param name="conn"></param>
        public SessionConnetion(IDbConnection conn)
        {
            Conn = conn;
        }
        /// <summary>
        /// 所封装的连接
        /// 几乎没有用
        /// </summary>
        public IDbConnection Conn { get; private set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get { return Conn.ConnectionString; } set { Conn.ConnectionString = value; } }
        /// <summary>
        /// 连接超时时间
        /// </summary>
        public int ConnectionTimeout { get { return Conn.ConnectionTimeout; } }
        /// <summary>
        /// 连接的数据库
        /// </summary>
        public string Database { get { return Conn.Database; } }
        /// <summary>
        /// 连接状态
        /// </summary>
        public ConnectionState State { get { return Conn.State; } }
        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        public IDbTransaction BeginTransaction()
        {
            return Conn.BeginTransaction();
        }
        /// <summary>
        /// 开启事务
        /// </summary>
        /// <param name="il">指定事务级别</param>
        /// <returns></returns>
        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return Conn.BeginTransaction(il);
        }
        /// <summary>
        /// 修改当前连接的数据库
        /// 不要用.会出问题.
        /// </summary>
        /// <param name="databaseName"></param>
        public void ChangeDatabase(string databaseName)
        {
            Conn.ChangeDatabase(databaseName);
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            Conn.Close();
        }

        /// <summary>
        /// 创建数据库命令对象
        /// </summary>
        /// <returns></returns>
        public IDbCommand CreateCommand()
        {
            return Conn.CreateCommand();
        }
        /// <summary>
        /// 释放连接
        /// </summary>
        public void Dispose()
        {
            if (Conn != null && !DbSession.InDbTrasaction)
            {
                Conn.Dispose();
            }
        }
        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open()
        {
            Conn.Open();
        }
    }
}
