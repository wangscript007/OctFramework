﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using Oct.Framework.DB.Core;
using Oct.Framework.DB.Interface;

namespace Oct.Framework.DB.Implementation
{
    public class SQLContext : ISQLContext
    {
        public T GetResult<T>(string sql)
        {
            if (SQLWordFilte.CheckSql(sql))
            {
                throw new Exception("您提供的关键字有可能危害数据库，已阻止执行");
            }
            try
            {
                DataSet ds = ExecuteQuery(sql);

                if (ds.Tables.Count == 0)
                    return default(T);

                if (ds.Tables[0].Rows.Count == 0)
                    return default(T);

                object v = ds.Tables[0].Rows[0][0];

                return (T) Convert.ChangeType(v, typeof (T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public T GetResult<T>(string sql, SqlParameter[] para)
        {
            if (SQLWordFilte.CheckSql(sql))
            {
                throw new Exception("您提供的关键字有可能危害数据库，已阻止执行");
            }
            try
            {
                DataSet ds = ExecuteQuery(sql, para);

                if (ds.Tables.Count == 0)
                    return default(T);

                if (ds.Tables[0].Rows.Count == 0)
                    return default(T);

                object v = ds.Tables[0].Rows[0][0];

                return (T) Convert.ChangeType(v, typeof (T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public object GetResult(string sql)
        {
            if (SQLWordFilte.CheckSql(sql))
            {
                throw new Exception("您提供的关键字有可能危害数据库，已阻止执行");
            }
            try
            {
                DataSet ds = ExecuteQuery(sql);

                if (ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                object v = ds.Tables[0].Rows[0][0];

                return v;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object GetResult(string sql, SqlParameter[] paras)
        {
            if (SQLWordFilte.CheckSql(sql))
            {
                throw new Exception("您提供的关键字有可能危害数据库，已阻止执行");
            }
            try
            {
                DataSet ds = ExecuteQuery(sql, paras);

                if (ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                object v = ds.Tables[0].Rows[0][0];

                return v;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<T> GetRowsResults<T>(string sql)
        {
            if (SQLWordFilte.CheckSql(sql))
            {
                throw new Exception("您提供的关键字有可能危害数据库，已阻止执行");
            }
            DataSet ds = ExecuteQuery(sql);

            if (ds.Tables.Count == 0)
                yield return default(T);

            if (ds.Tables[0].Rows.Count == 0)
                yield return default(T);

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                object v = r[0];
                yield return (T) Convert.ChangeType(v, typeof (T));
            }
        }

        public int ExecuteSQL(string sql)
        {
            if (SQLWordFilte.CheckSql(sql))
            {
                throw new Exception("您提供的关键字有可能危害数据库，已阻止执行");
            }
            ISession session = CurrentSessionFactory.GetCurrentSession();
            var cmd = new SqlCommand(sql);
            session.AddCommands(cmd);
            int rows = session.Commit();
            return rows;
        }

        public int ExecuteSQLs(List<string> sqls)
        {
            ISession session = CurrentSessionFactory.GetCurrentSession();
            foreach (string sql in sqls)
            {
                var cmd = new SqlCommand(sql);
                session.AddCommands(cmd);
            }
            int rows = session.Commit();
            return rows;
        }

        public DataSet ExecuteQuery(string sql)
        {
            if (SQLWordFilte.CheckSql(sql))
            {
                throw new Exception("您提供的关键字有可能危害数据库，已阻止执行");
            }
            ISession session = CurrentSessionFactory.GetCurrentSession();
            try
            {
                session.Open();
                var ds = new DataSet();
                var cmd = new SqlCommand(sql);
                cmd.Connection = session.Connection;
                var command = new SqlDataAdapter(cmd);

                command.Fill(ds);
                return ds;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //session.Connection.Close();
            }
        }

        public DataSet ExecuteQuery(string sql, params SqlParameter[] cmdParms)
        {
            if (SQLWordFilte.CheckSql(sql))
            {
                throw new Exception("您提供的关键字有可能危害数据库，已阻止执行");
            }
            ISession session = CurrentSessionFactory.GetCurrentSession();
            try
            {
                session.Open();
                var ds = new DataSet();
                var cmd = new SqlCommand();
                cmd = PrepareCommand(cmd, sql, cmdParms);
                cmd.Connection = session.Connection;
                var command = new SqlDataAdapter(cmd);
                command.Fill(ds);
                return ds;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //session.Connection.Close();
            }
        }


        public IEnumerable<ExpandoObject> ExecuteExpandoObjects(string sql)
        {
            if (SQLWordFilte.CheckSql(sql))
            {
                throw new Exception("您提供的关键字有可能危害数据库，已阻止执行");
            }
            DataSet ds = ExecuteQuery(string.Format(sql));
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                yield break;
            }

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    IDictionary<string, object> expando = new ExpandoObject();
                    foreach (DataColumn column in table.Columns)
                    {
                        expando.Add(column.Caption, row[column]);
                    }

                    yield return (ExpandoObject) expando;
                }
            }
        }

        public ExpandoObject ExecuteExpandoObject(string sql)
        {
            if (SQLWordFilte.CheckSql(sql))
            {
                throw new Exception("您提供的关键字有可能危害数据库，已阻止执行");
            }
            DataSet ds = ExecuteQuery(string.Format(sql));
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    IDictionary<string, object> expando = new ExpandoObject();
                    foreach (DataColumn column in table.Columns)
                    {
                        expando.Add(column.Caption, row[column]);
                    }

                    return (ExpandoObject) expando;
                }
            }
            return null;
        }

        protected SqlCommand PrepareCommand(SqlCommand cmd, string cmdText, SqlParameter[] cmdParms)
        {
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput ||
                         parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }

            return cmd;
        }

        #region 存储过程操作

        /// <summary>
        ///     执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            ISession session = CurrentSessionFactory.GetCurrentSession();
            try
            {
                session.Open();
                SqlDataReader returnReader;
                SqlCommand command = BuildQueryCommand(session.Connection, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return returnReader;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //session.Connection.Close();
            }
        }

        /// <summary>
        ///     执行存储过程
        /// </summary>
        /// <param name="readType">数据读取方式</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            ISession session = CurrentSessionFactory.GetCurrentSession();
            try
            {
                session.Open();
                var dataSet = new DataSet();
                SqlCommand command = BuildQueryCommand(session.Connection, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                var sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = command;
                sqlDA.Fill(dataSet, tableName);
                return dataSet;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //session.Connection.Close();
            }
        }

        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int timeOut)
        {
            ISession session = CurrentSessionFactory.GetCurrentSession();
            try
            {
                session.Open();
                var dataSet = new DataSet();
                SqlCommand command = BuildQueryCommand(session.Connection, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                var sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = command;
                sqlDA.SelectCommand.CommandTimeout = timeOut;
                sqlDA.Fill(dataSet, tableName);
                return dataSet;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //session.Connection.Close();
            }
        }

        /// <summary>
        ///     执行存储过程，返回影响的行数
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            ISession session = CurrentSessionFactory.GetCurrentSession();
            try
            {
                int result;
                session.Open();
                SqlCommand command = BuildIntCommand(session.Connection, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                rowsAffected = command.ExecuteNonQuery();
                result = (int) command.Parameters["ReturnValue"].Value;
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //session.Connection.Close();
            }
        }

        /// <summary>
        ///     构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName,
            IDataParameter[] parameters)
        {
            var command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput ||
                         parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        /// <summary>
        ///     创建 SqlCommand 对象实例(用来返回一个整数值)
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        #endregion
    }
}