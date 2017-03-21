using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Base
{
    public class SqlExp<T>
    {
        private SqlExpression<T> Exp;
        public SqlExp(SqlExpression<T> exp)
        {
            Exp = exp;
        }
        internal SqlExpression<T> GetExp()
        {
            return Exp;
        }
        internal static SqlExp<T> GetSqlExp(IDbConnection conn)
        {
            return new SqlExp<T>(conn.GetDialectProvider().SqlExpression<T>());
        }


        public SqlExp<T> From<T1>()
        {
            Exp.FromExpression = Exp.DialectProvider.SqlExpression<T1>().FromExpression;
            return this;
        }

        public SqlExp<T> Where(Expression<Func<T, bool>> predicate)
        {
            Exp.Where(predicate);
            return this;
        }
        public SqlExp<T> And(string sqlFilter, params object[] filterParams)
        {
            Exp.And(sqlFilter, filterParams);
            return this;
        }
        public SqlExp<T> And(Expression<Func<T, bool>> predicate)
        {
            Exp.And(predicate);
            return this;
        }
        public SqlExp<T> And<Target>(Expression<Func<Target, bool>> predicate)
        {
            Exp.And(predicate);
            return this;
        }
        public SqlExp<T> And<Source, Target>(Expression<Func<Source, Target, bool>> predicate)
        {
            Exp.And(predicate);
            return this;
        }
        public SqlExp<T> Limit(int skip, int rows)
        {
            Exp.Limit(skip, rows);
            return this;
        }
        public SqlExp<T> Or(Expression<Func<T, bool>> predicate)
        {
            Exp.Or(predicate);
            return this;
        }
        public SqlExp<T> OrderBy<T1>(Expression<Func<T1, object>> keySelector)
        {
            Exp.OrderBy(keySelector);
            return this;
        }

        public SqlExp<T> OrderByDescending<T1>(Expression<Func<T1, object>> keySelector)
        {
            Exp.OrderByDescending(keySelector);
            return this;
        }
        public SqlExp<T> OrderBy(Expression<Func<T, object>> keySelector)
        {
            Exp.OrderBy(keySelector);
            return this;
        }

        public SqlExp<T> OrderByDescending(Expression<Func<T, object>> keySelector)
        {
            Exp.OrderByDescending(keySelector);
            return this;
        }
        public SqlExp<T> OrderByRandom()
        {
            Exp.OrderByRandom();
            return this;
        }
        public SqlExp<T> ThenBy(Expression<Func<T, object>> keySelector)
        {
            Exp.ThenBy(keySelector);
            return this;
        }
        public SqlExp<T> ThenByDescending(Expression<Func<T, object>> keySelector)
        {
            Exp.ThenByDescending(keySelector);

            return this;
        }

        public SqlExp<T> ThenBy<T1>(Expression<Func<T1, object>> keySelector)
        {
            Exp.ThenBy(keySelector);
            return this;
        }
        public SqlExp<T> ThenByDescending<T1>(Expression<Func<T1, object>> keySelector)
        {
            Exp.ThenByDescending(keySelector);

            return this;
        }



        public SqlExp<T> CrossJoin<Target>(Expression<Func<T, Target, bool>> joinExpr = null)
        {
            Exp.CrossJoin<Target>(joinExpr);
            return this;
        }
        public SqlExp<T> CrossJoin<Source, Target>(Expression<Func<Source, Target, bool>> joinExpr = null)
        {
            Exp.CrossJoin(joinExpr);
            return this;
        }
        public SqlExp<T> FullJoin<Target>(Expression<Func<T, Target, bool>> joinExpr = null)
        {
            Exp.FullJoin<Target>(joinExpr);
            return this;
        }
        public SqlExp<T> FullJoin<Source, Target>(Expression<Func<Source, Target, bool>> joinExpr = null)
        {
            Exp.FullJoin(joinExpr);
            return this;
        }
        public SqlExp<T> Join<Target>(Expression<Func<T, Target, bool>> joinExpr = null)
        {
            Exp.Join<Target>(joinExpr);
            return this;
        }
        public SqlExp<T> Join<Source, Target>(Expression<Func<Source, Target, bool>> joinExpr = null)
        {
            Exp.Join(joinExpr);
            return this;
        }
        public SqlExp<T> LeftJoin<Target>(Expression<Func<T, Target, bool>> joinExpr = null)
        {
            Exp.LeftJoin<Target>(joinExpr);
            return this;
        }
        public SqlExp<T> LeftJoin<Source, Target>(Expression<Func<Source, Target, bool>> joinExpr = null)
        {
            Exp.Join(joinExpr);
            return this;
        }
        public SqlExp<T> RightJoin<Target>(Expression<Func<T, Target, bool>> joinExpr = null)
        {
            Exp.RightJoin<Target>(joinExpr);
            return this;
        }
        public SqlExp<T> RightJoin<Source, Target>(Expression<Func<Source, Target, bool>> joinExpr = null)
        {
            Exp.RightJoin(joinExpr);
            return this;
        }
        public SqlExp<T> Select()
        {
            Exp.Select();
            return this;
        }
        public SqlExp<T> Select(Expression<Func<T, object>> fields)
        {
            Exp.Select(fields);
            return this;
        }
        public SqlExp<T> Select<Table1>(Expression<Func<Table1, object>> fields)
        {
            Exp.Select(fields);
            return this;
        }
        public SqlExp<T> Select<Table1, Table2>(Expression<Func<Table1, Table2, object>> fields)
        {
            Exp.Select(fields);
            return this;
        }
        public SqlExp<T> Select<Table1, Table2, Table3>(Expression<Func<Table1, Table2, Table3, object>> fields)
        {
            Exp.Select(fields);
            return this;
        }
        public SqlExp<T> Select<Table1, Table2, Table3, Table4>(Expression<Func<Table1, Table2, Table3, Table4, object>> fields)
        {
            Exp.Select(fields);
            return this;
        }
        public SqlExp<T> Select<Table1, Table2, Table3, Table4, Table5>(Expression<Func<Table1, Table2, Table3, Table4, Table5, object>> fields)
        {
            Exp.Select(fields);
            return this;
        }
        public SqlExp<T> Select<Table1, Table2, Table3, Table4, Table5, Table6>(Expression<Func<Table1, Table2, Table3, Table4, Table5, Table6, object>> fields)
        {
            Exp.Select(fields);
            return this;
        }
        public SqlExp<T> Select<Table1, Table2, Table3, Table4, Table5, Table6, Table7>(Expression<Func<Table1, Table2, Table3, Table4, Table5, Table6, Table7, object>> fields)
        {
            Exp.Select(fields);
            return this;
        }
        public SqlExp<T> SelectDistinct()
        {
            Exp.SelectDistinct();
            return this;
        }
        public SqlExp<T> SelectDistinct(Expression<Func<T, object>> fields)
        {
            Exp.SelectDistinct(fields);
            return this;
        }
        public SqlExp<T> SelectDistinct<Table1, Table2>(Expression<Func<Table1, Table2, object>> fields)
        {
            Exp.SelectDistinct(fields);
            return this;
        }
        public SqlExp<T> SelectDistinct<Table1, Table2, Table3>(Expression<Func<Table1, Table2, Table3, object>> fields)
        {
            Exp.SelectDistinct(fields);
            return this;
        }
        public SqlExp<T> SelectDistinct<Table1, Table2, Table3, Table4>(Expression<Func<Table1, Table2, Table3, Table4, object>> fields)
        {
            Exp.SelectDistinct(fields);
            return this;
        }
        public SqlExp<T> SelectDistinct<Table1, Table2, Table3, Table4, Table5>(Expression<Func<Table1, Table2, Table3, Table4, Table5, object>> fields)
        {
            Exp.SelectDistinct(fields);
            return this;
        }
        public SqlExp<T> SelectDistinct<Table1, Table2, Table3, Table4, Table5, Table6>(Expression<Func<Table1, Table2, Table3, Table4, Table5, Table6, object>> fields)
        {
            Exp.SelectDistinct(fields);
            return this;
        }
        public SqlExp<T> SelectDistinct<Table1, Table2, Table3, Table4, Table5, Table6, Table7>(Expression<Func<Table1, Table2, Table3, Table4, Table5, Table6, Table7, object>> fields)
        {
            Exp.SelectDistinct(fields);
            return this;
        } 
    }
}
