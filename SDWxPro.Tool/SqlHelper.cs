using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SDWxPro.Tool
{
    public class SqlHelper
    {

        private static readonly string connStr = ConfigurationManager.ConnectionStrings[""].ConnectionString;
        /// <summary>
        /// 将一个DataReader对象转换为一个List<T>类型+IEnumerable<T> MapEntity<T>(SqlDataReader reader) where T : class,new()
        /// </summary>
        /// <typeparam name="T">一个实体对象</typeparam>
        /// <param name="reader">一个SqlDataReader对象</param>
        /// <returns>返回一个实体List集合</returns>
        public static IEnumerable<T> MapEntity<T>(SqlDataReader reader) where T : class,new()
        {
            try
            {
                var props = typeof(T).GetProperties();
                List<T> list = new List<T>();
                T entity = null;
                while (reader.Read())
                {
                    entity = new T();
                    foreach (var pro in props)
                    {
                        if (pro.CanWrite)
                        {
                            try
                            {
                                var index = reader.GetOrdinal(pro.Name);
                                var data = reader.GetValue(index);
                                pro.SetValue(entity, Convert.ChangeType(data, pro.PropertyType), null);
                            }
                            catch (IndexOutOfRangeException)
                            {

                                continue;
                            }
                           
                        }
                    }
                    list.Add(entity);
                }
                return list;
            }
            catch
            {

                return null;
            }
        }

        /// <summary>
        /// 执行一个sql语句或者存储过程返回一个实体list集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="text">执行的sql语句或者存储过程名字</param>
        /// <param name="type">执行命令类型</param>
        /// <param name="action">委托类型</param>
        /// <param name="parms">执行参数</param>
        /// <returns>返回的实体集合</returns>
        public static IEnumerable<T> ExecuteReader<T>(string text,CommandType type, Func<SqlDataReader, List<T>> action, params SqlParameter[] parms)
        {
            using (SqlConnection con=new SqlConnection(connStr))
            {
                using (SqlCommand cmd=new SqlCommand(connStr,con))
                {
                    if (parms!=null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddRange(parms);
                    }
                    cmd.CommandType = type;
                    cmd.CommandText = text;
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader=cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            List<T> list = action(reader);
                            return list;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        
                        throw e;
                    }
                }
            }
        }


    }
}
