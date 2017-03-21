using ServiceStack.Model;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dal.Database;

namespace Dal.Base
{
    /// <summary>
    /// 命令基类.实现数据库操作
    /// </summary>
    /// <typeparam name="T">要操作的表实体</typeparam> 
    public class CommandBase<T> : QueryBase<T> where T : Model.HasId
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public CommandBase(string db) : base(db) { }

        /// <summary> 插入一个实体
        /// </summary>
        /// <param name="entity">要插入的实体</param>
        /// <returns>受影响的行数</returns>
        public long Insert(T entity)
        {
            using (var conn = DbConnFactory.Open(DbName))
            {
                entity.Id = conn.Insert(entity, true);
                return entity.Id;
            }
        }

        /// <summary> 插入一个实体数组
        /// </summary>
        /// <param name="entitys">要插入的实体数组</param>
        /// <returns>受影响的行数</returns>
        public int Insert(IEnumerable<T> entitys)
        {
            using (var conn = DbConnFactory.Open(DbName))
            {
                if (DbSession.InDbTrasaction)
                {
                    foreach (var entity in entitys)
                    {
                        entity.Id = conn.Insert(entity, true);
                    }
                }
                else
                {
                    using (var dt = conn.BeginTransaction())
                    {
                        foreach (var entity in entitys)
                        {
                            entity.Id = conn.Insert(entity, true);
                        }
                        dt.Commit();
                    }
                }
            }
            return entitys.Count();
        }

        /// <summary> 删除一个实体
        /// </summary>
        /// <param name="id">要删除的实体id</param>
        /// <returns>受影响的行数</returns>
        public int Delete(long id)
        {
            using (var conn = DbConnFactory.Open(DbName))
            {
                return conn.DeleteById<T>(id);
            }
        }

        /// <summary> 删除一个实体数组
        /// </summary>
        /// <param name="ids">要删除的实体id数组</param>
        /// <returns>受影响的行数</returns>
        public int Delete(IEnumerable<long> ids)
        {
            using (var conn = DbConnFactory.Open(DbName))
            {
                return conn.DeleteByIds<T>(ids);
            }
        }

        /// <summary> 根据条件删除
        /// </summary>
        /// <param name="predicate">删除的条件表达式</param>
        /// <returns>受影响的行数</returns>
        public int Delete(Expression<Func<T, bool>> predicate)
        {
            using (var conn = DbConnFactory.Open(DbName))
            {
                return conn.Delete(predicate);
            }
        }

        /// <summary>
        /// 根据id更新一个实体
        /// </summary>
        /// <param name="entity">要更新的实体.</param>
        /// <returns>受影响的行数</returns>
        public int Update(T entity)
        {
            using (var conn = DbConnFactory.Open(DbName))
            {
                return conn.Update(entity);
            }
        }


        /// <summary>
        /// 根据id更新一个实体数组
        /// </summary>
        /// <param name="entitys">要更新的实体数组.</param>
        /// <returns>受影响的行数</returns>
        public int Update(IEnumerable<T> entitys)
        {
            using (var conn = DbConnFactory.Open(DbName))
            {
                if (DbSession.InDbTrasaction)
                {
                    foreach (var item in entitys)
                    {
                        conn.Update(item);
                    }
                }
                else
                {
                    using (var dt = conn.BeginTransaction())
                    {
                        foreach (var item in entitys)
                        {
                            conn.Update(item);
                        }
                        dt.Commit();
                    }
                }
            }
            return entitys.Count();
        }


        /// <summary>
        /// 根据条件更新部分字段
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Update(object fields, Expression<Func<T, bool>> predicate)
        {
            using (var conn = DbConnFactory.Open(DbName))
            {
                return conn.Update(fields, predicate);
            }
        }
        /// <summary>
        /// 增量更新方法
        /// 例子:UpdateAdd(()=>new T{Field=1(或者-1)},m=>条件表示)
        /// </summary>
        /// <param name="updateFields">要修改的字段和增量值,不修改的字段不赋值</param>
        /// <param name="where">条件表达式</param>
        /// <returns></returns>
        public int UpdateAdd(Expression<Func<T>> updateFields, Expression<Func<T, bool>> where = null)
        {
            using (var conn = DbConnFactory.Open(DbName))
            {
                return conn.UpdateAdd(updateFields, where);
            }
        }

    }
}