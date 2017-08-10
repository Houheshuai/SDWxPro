//SDUser 表的数据访问类

//创建日期: 2017/8/8 19:26:15

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SDWxPro.Model;

namespace SDWxPro.Service
{

public static partial class SDUserService
{
#region DAL
/// <summary>
/// 添加
/// </summary>
/// <param name="sDUser">实体对象</param>
/// <returns>返回添加成功后的新对象</returns>
public static SDUser AddSDUser(SDUser sDUser){
string sql =
"insert SDUser (NickName,Photo,WxTokenId,Gender,IsDel,LastLoginIp,AddTime,RealName,Phone,UserName,Password,Email) " +
"values (@NickName,@Photo,@WxTokenId,@Gender,@IsDel,@LastLoginIp,@AddTime,@RealName,@Phone,@UserName,@Password,@Email) ";
sql += " ; select @@identity";
try
{
SqlParameter[] para = new SqlParameter[]
{
new SqlParameter("@NickName", sDUser.NickName),new SqlParameter("@Photo", sDUser.Photo),new SqlParameter("@WxTokenId", sDUser.WxTokenId),new SqlParameter("@Gender", sDUser.Gender),new SqlParameter("@IsDel", sDUser.IsDel),new SqlParameter("@LastLoginIp", sDUser.LastLoginIp),new SqlParameter("@AddTime", sDUser.AddTime),new SqlParameter("@RealName", sDUser.RealName),new SqlParameter("@Phone", sDUser.Phone),new SqlParameter("@UserName", sDUser.UserName),new SqlParameter("@Password", sDUser.Password),new SqlParameter("@Email", sDUser.Email)
};
int newId = DBHelper.ExecuteScalar(CommandType.Text, sql, para);
return GetSDUserById(newId);
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
/// <param name="sDUser">实体对象</param>
public static void DeleteSDUser(SDUser sDUser)
{
DeleteSDUserById(sDUser.Id);
}
/// <summary>
/// 删除
/// </summary>
/// <param name="id">按id删除</param>
public static void DeleteSDUserById(int id)
{
string sql = "Delete SDUser where Id = @Id";
try
{
SqlParameter[] para = new SqlParameter[]{ new SqlParameter("@Id", id) };
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
public static void DeleteSDUserByStr(string strs)
{
string sql = "Delete SDUser where 1 = 1 " + strs;
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
/// <param name="sDUser">实体对象</param>
public static void ModifySDUser(SDUser sDUser)
{
string sql =
"UPDATE SDUser " +
"SET " +
"NickName = @NickName" +", Photo = @Photo " +", WxTokenId = @WxTokenId " +", Gender = @Gender " +", IsDel = @IsDel " +", LastLoginIp = @LastLoginIp " +", AddTime = @AddTime " +", RealName = @RealName " +", Phone = @Phone " +", UserName = @UserName " +", Password = @Password " +", Email = @Email " +
"WHERE Id = @Id";
try
{
SqlParameter[] para = new SqlParameter[]{
new SqlParameter("@Id", sDUser.Id),
new SqlParameter("@NickName", sDUser.NickName),new SqlParameter("@Photo", sDUser.Photo),new SqlParameter("@WxTokenId", sDUser.WxTokenId),new SqlParameter("@Gender", sDUser.Gender),new SqlParameter("@IsDel", sDUser.IsDel),new SqlParameter("@LastLoginIp", sDUser.LastLoginIp),new SqlParameter("@AddTime", sDUser.AddTime),new SqlParameter("@RealName", sDUser.RealName),new SqlParameter("@Phone", sDUser.Phone),new SqlParameter("@UserName", sDUser.UserName),new SqlParameter("@Password", sDUser.Password),new SqlParameter("@Email", sDUser.Email)
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
public static IList<SDUser> GetAllSDUsers()
{
string sqlAll = "SELECT * FROM SDUser";
return GetSDUsersBySql(sqlAll);
}
/// <summary>
/// 获取对象
/// </summary>
/// <param name="id">按id获取</param>
/// <returns>返回获取到的对象</returns>
public static SDUser GetSDUserById(int id)
{
string sql = "select * from SDUser where Id = @Id";
try
{
SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, new SqlParameter("@Id", id));
if (reader.Read()){
SDUser sDUser = new SDUser();
if (reader["Id"] != null && reader["Id"].ToString() != "")
{
sDUser.Id = int.Parse(reader["Id"].ToString());
}
if (reader["NickName"] != null && reader["NickName"].ToString() != ""){sDUser.NickName = reader["NickName"].ToString();}if (reader["Photo"] != null && reader["Photo"].ToString() != ""){sDUser.Photo = reader["Photo"].ToString();}if (reader["WxTokenId"] != null && reader["WxTokenId"].ToString() != ""){sDUser.WxTokenId = reader["WxTokenId"].ToString();}if (reader["Gender"] != null && reader["Gender"].ToString() != ""){sDUser.Gender = int.Parse(reader["Gender"].ToString());}if (reader["IsDel"] != null && reader["IsDel"].ToString() != ""){sDUser.IsDel = int.Parse(reader["IsDel"].ToString());}if (reader["LastLoginIp"] != null && reader["LastLoginIp"].ToString() != ""){sDUser.LastLoginIp = reader["LastLoginIp"].ToString();}if (reader["AddTime"] != null && reader["AddTime"].ToString() != ""){sDUser.AddTime = DateTime.Parse(reader["AddTime"].ToString());}if (reader["RealName"] != null && reader["RealName"].ToString() != ""){sDUser.RealName = reader["RealName"].ToString();}if (reader["Phone"] != null && reader["Phone"].ToString() != ""){sDUser.Phone = reader["Phone"].ToString();}if (reader["UserName"] != null && reader["UserName"].ToString() != ""){sDUser.UserName = reader["UserName"].ToString();}if (reader["Password"] != null && reader["Password"].ToString() != ""){sDUser.Password = reader["Password"].ToString();}if (reader["Email"] != null && reader["Email"].ToString() != ""){sDUser.Email = reader["Email"].ToString();}
reader.Close();
return sDUser;
} else {
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
public static SDUser GetSDUserByStr(string strs)
{
string sql = "select * from SDUser where 1 = 1 " + strs;
try
{
SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, null);
if (reader.Read())
{
SDUser sDUser = new SDUser();
if (reader["Id"] != null && reader["Id"].ToString() != "")
{
sDUser.Id = int.Parse(reader["Id"].ToString());
}
if (reader["NickName"] != null && reader["NickName"].ToString() != ""){sDUser.NickName = reader["NickName"].ToString();}if (reader["Photo"] != null && reader["Photo"].ToString() != ""){sDUser.Photo = reader["Photo"].ToString();}if (reader["WxTokenId"] != null && reader["WxTokenId"].ToString() != ""){sDUser.WxTokenId = reader["WxTokenId"].ToString();}if (reader["Gender"] != null && reader["Gender"].ToString() != ""){sDUser.Gender = int.Parse(reader["Gender"].ToString());}if (reader["IsDel"] != null && reader["IsDel"].ToString() != ""){sDUser.IsDel = int.Parse(reader["IsDel"].ToString());}if (reader["LastLoginIp"] != null && reader["LastLoginIp"].ToString() != ""){sDUser.LastLoginIp = reader["LastLoginIp"].ToString();}if (reader["AddTime"] != null && reader["AddTime"].ToString() != ""){sDUser.AddTime = DateTime.Parse(reader["AddTime"].ToString());}if (reader["RealName"] != null && reader["RealName"].ToString() != ""){sDUser.RealName = reader["RealName"].ToString();}if (reader["Phone"] != null && reader["Phone"].ToString() != ""){sDUser.Phone = reader["Phone"].ToString();}if (reader["UserName"] != null && reader["UserName"].ToString() != ""){sDUser.UserName = reader["UserName"].ToString();}if (reader["Password"] != null && reader["Password"].ToString() != ""){sDUser.Password = reader["Password"].ToString();}if (reader["Email"] != null && reader["Email"].ToString() != ""){sDUser.Email = reader["Email"].ToString();}
reader.Close();
return sDUser;
} else {
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
private static IList<SDUser> GetSDUsersBySql(string safeSql)
{
List<SDUser> list = new List<SDUser>();
try
{
DataTable table = DBHelper.GetDataTable(CommandType.Text, safeSql, null);
foreach (DataRow row in table.Rows)
{
SDUser sDUser = new SDUser();
if (row["Id"] != null && row["Id"].ToString() != "")
{
sDUser.Id = int.Parse(row["Id"].ToString());
}
if (row["NickName"] != null && row["NickName"].ToString() != ""){sDUser.NickName = row["NickName"].ToString();}if (row["Photo"] != null && row["Photo"].ToString() != ""){sDUser.Photo = row["Photo"].ToString();}if (row["WxTokenId"] != null && row["WxTokenId"].ToString() != ""){sDUser.WxTokenId = row["WxTokenId"].ToString();}if (row["Gender"] != null && row["Gender"].ToString() != ""){sDUser.Gender = int.Parse(row["Gender"].ToString());}if (row["IsDel"] != null && row["IsDel"].ToString() != ""){sDUser.IsDel = int.Parse(row["IsDel"].ToString());}if (row["LastLoginIp"] != null && row["LastLoginIp"].ToString() != ""){sDUser.LastLoginIp = row["LastLoginIp"].ToString();}if (row["AddTime"] != null && row["AddTime"].ToString() != ""){sDUser.AddTime = DateTime.Parse(row["AddTime"].ToString());}if (row["RealName"] != null && row["RealName"].ToString() != ""){sDUser.RealName = row["RealName"].ToString();}if (row["Phone"] != null && row["Phone"].ToString() != ""){sDUser.Phone = row["Phone"].ToString();}if (row["UserName"] != null && row["UserName"].ToString() != ""){sDUser.UserName = row["UserName"].ToString();}if (row["Password"] != null && row["Password"].ToString() != ""){sDUser.Password = row["Password"].ToString();}if (row["Email"] != null && row["Email"].ToString() != ""){sDUser.Email = row["Email"].ToString();}
list.Add(sDUser);
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
private static IList<SDUser> GetSDUsersBySql(string sql, params SqlParameter[] values)
{
List<SDUser> list = new List<SDUser>();
try
{
DataTable table = DBHelper.GetDataTable(CommandType.Text, sql, values);
foreach (DataRow row in table.Rows)
{
SDUser sDUser = new SDUser();
if (row["Id"] != null && row["Id"].ToString() != "")
{
sDUser.Id = int.Parse(row["Id"].ToString());
}
if (row["NickName"] != null && row["NickName"].ToString() != ""){sDUser.NickName = row["NickName"].ToString();}if (row["Photo"] != null && row["Photo"].ToString() != ""){sDUser.Photo = row["Photo"].ToString();}if (row["WxTokenId"] != null && row["WxTokenId"].ToString() != ""){sDUser.WxTokenId = row["WxTokenId"].ToString();}if (row["Gender"] != null && row["Gender"].ToString() != ""){sDUser.Gender = int.Parse(row["Gender"].ToString());}if (row["IsDel"] != null && row["IsDel"].ToString() != ""){sDUser.IsDel = int.Parse(row["IsDel"].ToString());}if (row["LastLoginIp"] != null && row["LastLoginIp"].ToString() != ""){sDUser.LastLoginIp = row["LastLoginIp"].ToString();}if (row["AddTime"] != null && row["AddTime"].ToString() != ""){sDUser.AddTime = DateTime.Parse(row["AddTime"].ToString());}if (row["RealName"] != null && row["RealName"].ToString() != ""){sDUser.RealName = row["RealName"].ToString();}if (row["Phone"] != null && row["Phone"].ToString() != ""){sDUser.Phone = row["Phone"].ToString();}if (row["UserName"] != null && row["UserName"].ToString() != ""){sDUser.UserName = row["UserName"].ToString();}if (row["Password"] != null && row["Password"].ToString() != ""){sDUser.Password = row["Password"].ToString();}if (row["Email"] != null && row["Email"].ToString() != ""){sDUser.Email = row["Email"].ToString();}
list.Add(sDUser);
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
public static DataTable GetSDUsersByStr(string strs)
{
string sql = "select * from SDUser where 1 = 1 " + strs;
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
public static DataTable GetSDUsersByStr(int top, string strs)
{
string sql = "select top " + top + " * from SDUser where 1 = 1 " + strs;
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
} //end of namespace
