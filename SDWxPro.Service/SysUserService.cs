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
    public static partial class SysUserService
    {
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sysUser">实体对象</param>
        /// <returns>返回添加成功后的新对象</returns>
        public static SysUser AddSysUser(SysUser sysUser)
        {
            string sql =
            "insert SysUser (UserName,PassWord,LevelId,IsHidden,MenuStr,LoginIp,LoginTime) " +
            "values (@UserName,@PassWord,@LevelId,@IsHidden,@MenuStr,@LoginIp,@LoginTime) ";
            sql += " ; select @@identity";
            try
            {
                SqlParameter[] para = new SqlParameter[]
{
new SqlParameter("@UserName", sysUser.UserName),new SqlParameter("@PassWord", sysUser.PassWord),new SqlParameter("@LevelId", sysUser.LevelId),new SqlParameter("@IsHidden", sysUser.IsHidden),new SqlParameter("@MenuStr", sysUser.MenuStr),new SqlParameter("@LoginIp", sysUser.LoginIp),new SqlParameter("@LoginTime", sysUser.LoginTime)
};
                int newId = DBHelper.ExecuteScalar(CommandType.Text, sql, para);
                return GetSysUserById(newId);
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
        /// <param name="sysUser">实体对象</param>
        public static void DeleteSysUser(SysUser sysUser)
        {
            DeleteSysUserById(sysUser.Id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">按id删除</param>
        public static void DeleteSysUserById(int id)
        {
            string sql = "Delete SysUser where Id = @Id";
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
        public static void DeleteSysUserByStr(string strs)
        {
            string sql = "Delete SysUser where 1 = 1 " + strs;
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
        /// <param name="sysUser">实体对象</param>
        public static void ModifySysUser(SysUser sysUser)
        {
            string sql =
            "UPDATE SysUser " +
            "SET " +
            "UserName = @UserName" + ", PassWord = @PassWord " + ", LevelId = @LevelId " + ", IsHidden = @IsHidden " + ", MenuStr = @MenuStr " + ", LoginIp = @LoginIp " + ", LoginTime = @LoginTime " +
            "WHERE Id = @Id";
            try
            {
                SqlParameter[] para = new SqlParameter[]{
new SqlParameter("@Id", sysUser.Id),
new SqlParameter("@UserName", sysUser.UserName),new SqlParameter("@PassWord", sysUser.PassWord),new SqlParameter("@LevelId", sysUser.LevelId),new SqlParameter("@IsHidden", sysUser.IsHidden),new SqlParameter("@MenuStr", sysUser.MenuStr),new SqlParameter("@LoginIp", sysUser.LoginIp),new SqlParameter("@LoginTime", sysUser.LoginTime)
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
        public static IList<SysUser> GetAllSysUsers()
        {
            string sqlAll = "SELECT * FROM SysUser";
            return GetSysUsersBySql(sqlAll);
        }
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="id">按id获取</param>
        /// <returns>返回获取到的对象</returns>
        public static SysUser GetSysUserById(int id)
        {
            string sql = "select * from SysUser where Id = @Id";
            try
            {
                SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, new SqlParameter("@Id", id));
                if (reader.Read())
                {
                    SysUser sysUser = new SysUser();
                    if (reader["Id"] != null && reader["Id"].ToString() != "")
                    {
                        sysUser.Id = int.Parse(reader["Id"].ToString());
                    }
                    if (reader["UserName"] != null && reader["UserName"].ToString() != "") { sysUser.UserName = reader["UserName"].ToString(); } if (reader["PassWord"] != null && reader["PassWord"].ToString() != "") { sysUser.PassWord = reader["PassWord"].ToString(); } if (reader["LevelId"] != null && reader["LevelId"].ToString() != "") { sysUser.LevelId = int.Parse(reader["LevelId"].ToString()); } if (reader["IsHidden"] != null && reader["IsHidden"].ToString() != "") { sysUser.IsHidden = int.Parse(reader["IsHidden"].ToString()); } if (reader["MenuStr"] != null && reader["MenuStr"].ToString() != "") { sysUser.MenuStr = reader["MenuStr"].ToString(); } if (reader["LoginIp"] != null && reader["LoginIp"].ToString() != "") { sysUser.LoginIp = reader["LoginIp"].ToString(); } if (reader["LoginTime"] != null && reader["LoginTime"].ToString() != "") { sysUser.LoginTime = DateTime.Parse(reader["LoginTime"].ToString()); }
                    reader.Close();
                    return sysUser;
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
        public static SysUser GetSysUserByStr(string strs)
        {
            string sql = "select * from SysUser where 1 = 1 " + strs;
            try
            {
                SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, null);
                if (reader.Read())
                {
                    SysUser sysUser = new SysUser();
                    if (reader["Id"] != null && reader["Id"].ToString() != "")
                    {
                        sysUser.Id = int.Parse(reader["Id"].ToString());
                    }
                    if (reader["UserName"] != null && reader["UserName"].ToString() != "") { sysUser.UserName = reader["UserName"].ToString(); } if (reader["PassWord"] != null && reader["PassWord"].ToString() != "") { sysUser.PassWord = reader["PassWord"].ToString(); } if (reader["LevelId"] != null && reader["LevelId"].ToString() != "") { sysUser.LevelId = int.Parse(reader["LevelId"].ToString()); } if (reader["IsHidden"] != null && reader["IsHidden"].ToString() != "") { sysUser.IsHidden = int.Parse(reader["IsHidden"].ToString()); } if (reader["MenuStr"] != null && reader["MenuStr"].ToString() != "") { sysUser.MenuStr = reader["MenuStr"].ToString(); } if (reader["LoginIp"] != null && reader["LoginIp"].ToString() != "") { sysUser.LoginIp = reader["LoginIp"].ToString(); } if (reader["LoginTime"] != null && reader["LoginTime"].ToString() != "") { sysUser.LoginTime = DateTime.Parse(reader["LoginTime"].ToString()); }
                    reader.Close();
                    return sysUser;
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
        private static IList<SysUser> GetSysUsersBySql(string safeSql)
        {
            List<SysUser> list = new List<SysUser>();
            try
            {
                DataTable table = DBHelper.GetDataTable(CommandType.Text, safeSql, null);
                foreach (DataRow row in table.Rows)
                {
                    SysUser sysUser = new SysUser();
                    if (row["Id"] != null && row["Id"].ToString() != "")
                    {
                        sysUser.Id = int.Parse(row["Id"].ToString());
                    }
                    if (row["UserName"] != null && row["UserName"].ToString() != "") { sysUser.UserName = row["UserName"].ToString(); } if (row["PassWord"] != null && row["PassWord"].ToString() != "") { sysUser.PassWord = row["PassWord"].ToString(); } if (row["LevelId"] != null && row["LevelId"].ToString() != "") { sysUser.LevelId = int.Parse(row["LevelId"].ToString()); } if (row["IsHidden"] != null && row["IsHidden"].ToString() != "") { sysUser.IsHidden = int.Parse(row["IsHidden"].ToString()); } if (row["MenuStr"] != null && row["MenuStr"].ToString() != "") { sysUser.MenuStr = row["MenuStr"].ToString(); } if (row["LoginIp"] != null && row["LoginIp"].ToString() != "") { sysUser.LoginIp = row["LoginIp"].ToString(); } if (row["LoginTime"] != null && row["LoginTime"].ToString() != "") { sysUser.LoginTime = DateTime.Parse(row["LoginTime"].ToString()); }
                    list.Add(sysUser);
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
        private static IList<SysUser> GetSysUsersBySql(string sql, params SqlParameter[] values)
        {
            List<SysUser> list = new List<SysUser>();
            try
            {
                DataTable table = DBHelper.GetDataTable(CommandType.Text, sql, values);
                foreach (DataRow row in table.Rows)
                {
                    SysUser sysUser = new SysUser();
                    if (row["Id"] != null && row["Id"].ToString() != "")
                    {
                        sysUser.Id = int.Parse(row["Id"].ToString());
                    }
                    if (row["UserName"] != null && row["UserName"].ToString() != "") { sysUser.UserName = row["UserName"].ToString(); } if (row["PassWord"] != null && row["PassWord"].ToString() != "") { sysUser.PassWord = row["PassWord"].ToString(); } if (row["LevelId"] != null && row["LevelId"].ToString() != "") { sysUser.LevelId = int.Parse(row["LevelId"].ToString()); } if (row["IsHidden"] != null && row["IsHidden"].ToString() != "") { sysUser.IsHidden = int.Parse(row["IsHidden"].ToString()); } if (row["MenuStr"] != null && row["MenuStr"].ToString() != "") { sysUser.MenuStr = row["MenuStr"].ToString(); } if (row["LoginIp"] != null && row["LoginIp"].ToString() != "") { sysUser.LoginIp = row["LoginIp"].ToString(); } if (row["LoginTime"] != null && row["LoginTime"].ToString() != "") { sysUser.LoginTime = DateTime.Parse(row["LoginTime"].ToString()); }
                    list.Add(sysUser);
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
        public static DataTable GetSysUsersByStr(string strs)
        {
            string sql = "select * from SysUser where 1 = 1 " + strs;
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
        public static DataTable GetSysUsersByStr(int top, string strs)
        {
            string sql = "select top " + top + " * from SysUser where 1 = 1 " + strs;
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
        /// 用户登录
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns></returns>
        public static bool CheckSysUser(SysUser sysUser)
        {
            string SqlString = "Select count(*) from [SysUser] where UserName=@UserName and PassWord=@PassWord";
            SqlCommand cmd = new SqlCommand();
            //参数化查询
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@UserName",DbType.String),
                new SqlParameter("@PassWord",DbType.String)
            };
            param[0].Value = sysUser.UserName;
            param[1].Value = sysUser.PassWord;
            int intAffectedCount = DBHelper.ExecuteScalar(CommandType.Text, SqlString, param);
            if (intAffectedCount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
