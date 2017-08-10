using SDWxPro.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDWxPro.Service
{
    public static partial class SysSettingService
    {
        #region DAL
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sysSetting">实体对象</param>
        /// <returns>返回添加成功后的新对象</returns>
        public static SysSetting AddSysSetting(SysSetting sysSetting)
        {
            string sql =
            "insert SysSetting (WebName,WebSite,WxSite,WapSite,MailName,MailPass,MailSmtp,IntegralConvert,JsCode,WxTokenKey,WxTokenTimeOut,CustomerCount) " +
            "values (@WebName,@WebSite,@WxSite,@WapSite,@MailName,@MailPass,@MailSmtp,@IntegralConvert,@JsCode,@WxTokenKey,@WxTokenTimeOut,@CustomerCount) ";
            sql += " ; select @@identity";
            try
            {
                SqlParameter[] para = new SqlParameter[]
{
new SqlParameter("@WebName", sysSetting.WebName),new SqlParameter("@WebSite", sysSetting.WebSite),new SqlParameter("@WxSite", sysSetting.WxSite),new SqlParameter("@WapSite", sysSetting.WapSite),new SqlParameter("@MailName", sysSetting.MailName),new SqlParameter("@MailPass", sysSetting.MailPass),new SqlParameter("@MailSmtp", sysSetting.MailSmtp),new SqlParameter("@IntegralConvert", sysSetting.IntegralConvert),new SqlParameter("@JsCode", sysSetting.JsCode),new SqlParameter("@WxTokenKey", sysSetting.WxTokenKey),new SqlParameter("@WxTokenTimeOut", sysSetting.WxTokenTimeOut),new SqlParameter("@CustomerCount",sysSetting.CustomerCount)
};
                int newId = DBHelper.ExecuteScalar(CommandType.Text, sql, para);
                return GetSysSettingById(newId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sysSetting">实体对象</param>
        public static void DeleteSysSetting(SysSetting sysSetting)
        {
            DeleteSysSettingById(sysSetting.Id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">按id删除</param>
        public static void DeleteSysSettingById(int id)
        {
            string sql = "Delete SysSetting where Id = @Id";
            try
            {
                SqlParameter[] para = new SqlParameter[] { new SqlParameter("@Id", id) };
                DBHelper.ExecuteNonQuery(CommandType.Text, sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strs">按条件删除</param>
        public static void DeleteSysSettingByStr(string strs)
        {
            string sql = "Delete SysSetting where 1 = 1 " + strs;
            try { DBHelper.ExecuteNonQuery(CommandType.Text, sql, null); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sysSetting">实体对象</param>
        public static void ModifySysSetting(SysSetting sysSetting)
        {
            string sql =
            "UPDATE SysSetting " +
            "SET " +
            "WebName = @WebName" + ", WebSite = @WebSite " + ", WxSite = @WxSite " + ", WapSite = @WapSite " + ", MailName = @MailName " + ", MailPass = @MailPass " + ", MailSmtp = @MailSmtp " + ", IntegralConvert = @IntegralConvert " + ", JsCode = @JsCode " + ", WxTokenKey = @WxTokenKey " + ", WxTokenTimeOut = @WxTokenTimeOut " + ",CustomerCount=@CustomerCount" +
            " WHERE Id = @Id";
            try
            {
                SqlParameter[] para = new SqlParameter[]{
new SqlParameter("@Id", sysSetting.Id),
new SqlParameter("@WebName", sysSetting.WebName),new SqlParameter("@WebSite", sysSetting.WebSite),new SqlParameter("@WxSite", sysSetting.WxSite),new SqlParameter("@WapSite", sysSetting.WapSite),new SqlParameter("@MailName", sysSetting.MailName),new SqlParameter("@MailPass", sysSetting.MailPass),new SqlParameter("@MailSmtp", sysSetting.MailSmtp),new SqlParameter("@IntegralConvert", sysSetting.IntegralConvert),new SqlParameter("@JsCode", sysSetting.JsCode),new SqlParameter("@WxTokenKey", sysSetting.WxTokenKey),new SqlParameter("@WxTokenTimeOut", sysSetting.WxTokenTimeOut),new SqlParameter("@CustomerCount",sysSetting.CustomerCount)
};
                DBHelper.ExecuteNonQuery(CommandType.Text, sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 获取IList列表
        /// </summary>
        /// <returns>返回IList列表</returns>
        public static IList<SysSetting> GetAllSysSettings()
        {
            string sqlAll = "SELECT * FROM SysSetting";
            return GetSysSettingsBySql(sqlAll);
        }
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="id">按id获取</param>
        /// <returns>返回获取到的对象</returns>
        public static SysSetting GetSysSettingById(int id)
        {
            string sql = "select * from SysSetting where Id = @Id";
            try
            {
                SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    SysSetting sysSetting = new SysSetting();
                    if (reader["Id"] != null && reader["Id"].ToString() != "")
                    {
                        sysSetting.Id = int.Parse(reader["Id"].ToString());
                    }
                    if (reader["WebName"] != null && reader["WebName"].ToString() != "") { sysSetting.WebName = reader["WebName"].ToString(); } if (reader["WebSite"] != null && reader["WebSite"].ToString() != "") { sysSetting.WebSite = reader["WebSite"].ToString(); } if (reader["WxSite"] != null && reader["WxSite"].ToString() != "") { sysSetting.WxSite = reader["WxSite"].ToString(); } if (reader["WapSite"] != null && reader["WapSite"].ToString() != "") { sysSetting.WapSite = reader["WapSite"].ToString(); } if (reader["MailName"] != null && reader["MailName"].ToString() != "") { sysSetting.MailName = reader["MailName"].ToString(); } if (reader["MailPass"] != null && reader["MailPass"].ToString() != "") { sysSetting.MailPass = reader["MailPass"].ToString(); } if (reader["MailSmtp"] != null && reader["MailSmtp"].ToString() != "") { sysSetting.MailSmtp = reader["MailSmtp"].ToString(); } if (reader["IntegralConvert"] != null && reader["IntegralConvert"].ToString() != "") { sysSetting.IntegralConvert = int.Parse(reader["IntegralConvert"].ToString()); } if (reader["JsCode"] != null && reader["JsCode"].ToString() != "") { sysSetting.JsCode = reader["JsCode"].ToString(); } if (reader["WxTokenKey"] != null && reader["WxTokenKey"].ToString() != "") { sysSetting.WxTokenKey = reader["WxTokenKey"].ToString(); } if (reader["WxTokenTimeOut"] != null && reader["WxTokenTimeOut"].ToString() != "") { sysSetting.WxTokenTimeOut = DateTime.Parse(reader["WxTokenTimeOut"].ToString()); }
                    if (reader["CustomerCount"] != null && reader["CustomerCount"].ToString() != "") { sysSetting.CustomerCount = int.Parse(reader["CustomerCount"].ToString()); }
                    reader.Close();
                    return sysSetting;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="strs">查询条件</param>
        /// <returns>返回获取到的对象</returns>
        public static SysSetting GetSysSettingByStr(string strs)
        {
            string sql = "select * from SysSetting where 1 = 1 " + strs;
            try
            {
                SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, null);
                if (reader.Read())
                {
                    SysSetting sysSetting = new SysSetting();
                    if (reader["Id"] != null && reader["Id"].ToString() != "")
                    {
                        sysSetting.Id = int.Parse(reader["Id"].ToString());
                    }
                    if (reader["WebName"] != null && reader["WebName"].ToString() != "") { sysSetting.WebName = reader["WebName"].ToString(); } if (reader["WebSite"] != null && reader["WebSite"].ToString() != "") { sysSetting.WebSite = reader["WebSite"].ToString(); } if (reader["WxSite"] != null && reader["WxSite"].ToString() != "") { sysSetting.WxSite = reader["WxSite"].ToString(); } if (reader["WapSite"] != null && reader["WapSite"].ToString() != "") { sysSetting.WapSite = reader["WapSite"].ToString(); } if (reader["MailName"] != null && reader["MailName"].ToString() != "") { sysSetting.MailName = reader["MailName"].ToString(); } if (reader["MailPass"] != null && reader["MailPass"].ToString() != "") { sysSetting.MailPass = reader["MailPass"].ToString(); } if (reader["MailSmtp"] != null && reader["MailSmtp"].ToString() != "") { sysSetting.MailSmtp = reader["MailSmtp"].ToString(); } if (reader["IntegralConvert"] != null && reader["IntegralConvert"].ToString() != "") { sysSetting.IntegralConvert = int.Parse(reader["IntegralConvert"].ToString()); } if (reader["JsCode"] != null && reader["JsCode"].ToString() != "") { sysSetting.JsCode = reader["JsCode"].ToString(); } if (reader["WxTokenKey"] != null && reader["WxTokenKey"].ToString() != "") { sysSetting.WxTokenKey = reader["WxTokenKey"].ToString(); } if (reader["WxTokenTimeOut"] != null && reader["WxTokenTimeOut"].ToString() != "") { sysSetting.WxTokenTimeOut = DateTime.Parse(reader["WxTokenTimeOut"].ToString()); }
                    if (reader["CustomerCount"] != null && reader["CustomerCount"].ToString() != "") { sysSetting.CustomerCount = int.Parse(reader["CustomerCount"].ToString()); }
                    reader.Close();
                    return sysSetting;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 获取IList列表
        /// </summary>
        /// <param name="safeSql">查询条件</param>
        /// <returns>返回IList列表</returns>
        private static IList<SysSetting> GetSysSettingsBySql(string safeSql)
        {
            List<SysSetting> list = new List<SysSetting>();
            try
            {
                DataTable table = DBHelper.GetDataTable(CommandType.Text, safeSql, null);
                foreach (DataRow row in table.Rows)
                {
                    SysSetting sysSetting = new SysSetting();
                    if (row["Id"] != null && row["Id"].ToString() != "")
                    {
                        sysSetting.Id = int.Parse(row["Id"].ToString());
                    }
                    if (row["WebName"] != null && row["WebName"].ToString() != "") { sysSetting.WebName = row["WebName"].ToString(); } if (row["WebSite"] != null && row["WebSite"].ToString() != "") { sysSetting.WebSite = row["WebSite"].ToString(); } if (row["WxSite"] != null && row["WxSite"].ToString() != "") { sysSetting.WxSite = row["WxSite"].ToString(); } if (row["WapSite"] != null && row["WapSite"].ToString() != "") { sysSetting.WapSite = row["WapSite"].ToString(); } if (row["MailName"] != null && row["MailName"].ToString() != "") { sysSetting.MailName = row["MailName"].ToString(); } if (row["MailPass"] != null && row["MailPass"].ToString() != "") { sysSetting.MailPass = row["MailPass"].ToString(); } if (row["MailSmtp"] != null && row["MailSmtp"].ToString() != "") { sysSetting.MailSmtp = row["MailSmtp"].ToString(); } if (row["IntegralConvert"] != null && row["IntegralConvert"].ToString() != "") { sysSetting.IntegralConvert = int.Parse(row["IntegralConvert"].ToString()); } if (row["JsCode"] != null && row["JsCode"].ToString() != "") { sysSetting.JsCode = row["JsCode"].ToString(); } if (row["WxTokenKey"] != null && row["WxTokenKey"].ToString() != "") { sysSetting.WxTokenKey = row["WxTokenKey"].ToString(); } if (row["WxTokenTimeOut"] != null && row["WxTokenTimeOut"].ToString() != "") { sysSetting.WxTokenTimeOut = DateTime.Parse(row["WxTokenTimeOut"].ToString()); }
                    if (row["CustomerCount"] != null && row["CustomerCount"].ToString() != "") { sysSetting.CustomerCount = int.Parse(row["CustomerCount"].ToString()); }
                    list.Add(sysSetting);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 获取IList列表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数</param>
        /// <returns>返回IList列表</returns>
        private static IList<SysSetting> GetSysSettingsBySql(string sql, params SqlParameter[] values)
        {
            List<SysSetting> list = new List<SysSetting>();
            try
            {
                DataTable table = DBHelper.GetDataTable(CommandType.Text, sql, values);
                foreach (DataRow row in table.Rows)
                {
                    SysSetting sysSetting = new SysSetting();
                    if (row["Id"] != null && row["Id"].ToString() != "")
                    {
                        sysSetting.Id = int.Parse(row["Id"].ToString());
                    }
                    if (row["WebName"] != null && row["WebName"].ToString() != "") { sysSetting.WebName = row["WebName"].ToString(); } if (row["WebSite"] != null && row["WebSite"].ToString() != "") { sysSetting.WebSite = row["WebSite"].ToString(); } if (row["WxSite"] != null && row["WxSite"].ToString() != "") { sysSetting.WxSite = row["WxSite"].ToString(); } if (row["WapSite"] != null && row["WapSite"].ToString() != "") { sysSetting.WapSite = row["WapSite"].ToString(); } if (row["MailName"] != null && row["MailName"].ToString() != "") { sysSetting.MailName = row["MailName"].ToString(); } if (row["MailPass"] != null && row["MailPass"].ToString() != "") { sysSetting.MailPass = row["MailPass"].ToString(); } if (row["MailSmtp"] != null && row["MailSmtp"].ToString() != "") { sysSetting.MailSmtp = row["MailSmtp"].ToString(); } if (row["IntegralConvert"] != null && row["IntegralConvert"].ToString() != "") { sysSetting.IntegralConvert = int.Parse(row["IntegralConvert"].ToString()); } if (row["JsCode"] != null && row["JsCode"].ToString() != "") { sysSetting.JsCode = row["JsCode"].ToString(); } if (row["WxTokenKey"] != null && row["WxTokenKey"].ToString() != "") { sysSetting.WxTokenKey = row["WxTokenKey"].ToString(); } if (row["WxTokenTimeOut"] != null && row["WxTokenTimeOut"].ToString() != "") { sysSetting.WxTokenTimeOut = DateTime.Parse(row["WxTokenTimeOut"].ToString()); }
                    if (row["CustomerCount"] != null && row["CustomerCount"].ToString() != "") { sysSetting.CustomerCount = int.Parse(row["CustomerCount"].ToString()); }
                    list.Add(sysSetting);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="strs">查询条件</param>
        /// <returns>返回查询结果</returns>
        public static DataTable GetSysSettingsByStr(string strs)
        {
            string sql = "select * from SysSetting where 1 = 1 " + strs;
            try
            {
                DataTable dt = DBHelper.GetDataTable(CommandType.Text, sql, null);
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="top">前几条</param>
        /// <param name="strs">查询条件</param>
        /// <returns>返回查询结果</returns>
        public static DataTable GetSysSettingsByStr(int top, string strs)
        {
            string sql = "select top " + top + " * from SysSetting where 1 = 1 " + strs;
            try
            {
                DataTable dt = DBHelper.GetDataTable(CommandType.Text, sql, null);
                return dt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        #endregion Model
    } //end of class
}
