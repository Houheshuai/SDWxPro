//SDFilmCategory 表的数据访问类

//创建日期: 2017/8/10 星期四 10:04:05

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SDWxPro.Model;

namespace SDWxPro.Service
{

public static partial class SDFilmCategoryService
{
#region DAL
/// <summary>
/// 添加
/// </summary>
/// <param name="sDFilmCategory">实体对象</param>
/// <returns>返回添加成功后的新对象</returns>
public static SDFilmCategory AddSDFilmCategory(SDFilmCategory sDFilmCategory){
string sql =
"insert SDFilmCategory (Name,IsDel,Sort,AddTime) " +
"values (@Name,@IsDel,@Sort,@AddTime) ";
sql += " ; select @@identity";
try
{
SqlParameter[] para = new SqlParameter[]
{
new SqlParameter("@Name", sDFilmCategory.Name),new SqlParameter("@IsDel", sDFilmCategory.IsDel),new SqlParameter("@Sort", sDFilmCategory.Sort),new SqlParameter("@AddTime", sDFilmCategory.AddTime)
};
int newId = DBHelper.ExecuteScalar(CommandType.Text, sql, para);
return GetSDFilmCategoryById(newId);
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
/// <param name="sDFilmCategory">实体对象</param>
public static void DeleteSDFilmCategory(SDFilmCategory sDFilmCategory)
{
DeleteSDFilmCategoryById(sDFilmCategory.Id);
}
/// <summary>
/// 删除
/// </summary>
/// <param name="id">按id删除</param>
public static void DeleteSDFilmCategoryById(int id)
{
string sql = "Delete SDFilmCategory where Id = @Id";
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
public static void DeleteSDFilmCategoryByStr(string strs)
{
string sql = "Delete SDFilmCategory where 1 = 1 " + strs;
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
/// <param name="sDFilmCategory">实体对象</param>
public static void ModifySDFilmCategory(SDFilmCategory sDFilmCategory)
{
string sql =
"UPDATE SDFilmCategory " +
"SET " +
"Name = @Name" +", IsDel = @IsDel " +", Sort = @Sort " +", AddTime = @AddTime " +
"WHERE Id = @Id";
try
{
SqlParameter[] para = new SqlParameter[]{
new SqlParameter("@Id", sDFilmCategory.Id),
new SqlParameter("@Name", sDFilmCategory.Name),new SqlParameter("@IsDel", sDFilmCategory.IsDel),new SqlParameter("@Sort", sDFilmCategory.Sort),new SqlParameter("@AddTime", sDFilmCategory.AddTime)
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
public static IList<SDFilmCategory> GetAllSDFilmCategorys()
{
string sqlAll = "SELECT * FROM SDFilmCategory";
return GetSDFilmCategorysBySql(sqlAll);
}
/// <summary>
/// 获取对象
/// </summary>
/// <param name="id">按id获取</param>
/// <returns>返回获取到的对象</returns>
public static SDFilmCategory GetSDFilmCategoryById(int id)
{
string sql = "select * from SDFilmCategory where Id = @Id";
try
{
SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, new SqlParameter("@Id", id));
if (reader.Read()){
SDFilmCategory sDFilmCategory = new SDFilmCategory();
if (reader["Id"] != null && reader["Id"].ToString() != "")
{
sDFilmCategory.Id = int.Parse(reader["Id"].ToString());
}
if (reader["Name"] != null && reader["Name"].ToString() != ""){sDFilmCategory.Name = reader["Name"].ToString();}if (reader["IsDel"] != null && reader["IsDel"].ToString() != ""){sDFilmCategory.IsDel = int.Parse(reader["IsDel"].ToString());}if (reader["Sort"] != null && reader["Sort"].ToString() != ""){sDFilmCategory.Sort = int.Parse(reader["Sort"].ToString());}if (reader["AddTime"] != null && reader["AddTime"].ToString() != ""){sDFilmCategory.AddTime = DateTime.Parse(reader["AddTime"].ToString());}
reader.Close();
return sDFilmCategory;
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
public static SDFilmCategory GetSDFilmCategoryByStr(string strs)
{
string sql = "select * from SDFilmCategory where 1 = 1 " + strs;
try
{
SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, null);
if (reader.Read())
{
SDFilmCategory sDFilmCategory = new SDFilmCategory();
if (reader["Id"] != null && reader["Id"].ToString() != "")
{
sDFilmCategory.Id = int.Parse(reader["Id"].ToString());
}
if (reader["Name"] != null && reader["Name"].ToString() != ""){sDFilmCategory.Name = reader["Name"].ToString();}if (reader["IsDel"] != null && reader["IsDel"].ToString() != ""){sDFilmCategory.IsDel = int.Parse(reader["IsDel"].ToString());}if (reader["Sort"] != null && reader["Sort"].ToString() != ""){sDFilmCategory.Sort = int.Parse(reader["Sort"].ToString());}if (reader["AddTime"] != null && reader["AddTime"].ToString() != ""){sDFilmCategory.AddTime = DateTime.Parse(reader["AddTime"].ToString());}
reader.Close();
return sDFilmCategory;
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
private static IList<SDFilmCategory> GetSDFilmCategorysBySql(string safeSql)
{
List<SDFilmCategory> list = new List<SDFilmCategory>();
try
{
DataTable table = DBHelper.GetDataTable(CommandType.Text, safeSql, null);
foreach (DataRow row in table.Rows)
{
SDFilmCategory sDFilmCategory = new SDFilmCategory();
if (row["Id"] != null && row["Id"].ToString() != "")
{
sDFilmCategory.Id = int.Parse(row["Id"].ToString());
}
if (row["Name"] != null && row["Name"].ToString() != ""){sDFilmCategory.Name = row["Name"].ToString();}if (row["IsDel"] != null && row["IsDel"].ToString() != ""){sDFilmCategory.IsDel = int.Parse(row["IsDel"].ToString());}if (row["Sort"] != null && row["Sort"].ToString() != ""){sDFilmCategory.Sort = int.Parse(row["Sort"].ToString());}if (row["AddTime"] != null && row["AddTime"].ToString() != ""){sDFilmCategory.AddTime = DateTime.Parse(row["AddTime"].ToString());}
list.Add(sDFilmCategory);
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
private static IList<SDFilmCategory> GetSDFilmCategorysBySql(string sql, params SqlParameter[] values)
{
List<SDFilmCategory> list = new List<SDFilmCategory>();
try
{
DataTable table = DBHelper.GetDataTable(CommandType.Text, sql, values);
foreach (DataRow row in table.Rows)
{
SDFilmCategory sDFilmCategory = new SDFilmCategory();
if (row["Id"] != null && row["Id"].ToString() != "")
{
sDFilmCategory.Id = int.Parse(row["Id"].ToString());
}
if (row["Name"] != null && row["Name"].ToString() != ""){sDFilmCategory.Name = row["Name"].ToString();}if (row["IsDel"] != null && row["IsDel"].ToString() != ""){sDFilmCategory.IsDel = int.Parse(row["IsDel"].ToString());}if (row["Sort"] != null && row["Sort"].ToString() != ""){sDFilmCategory.Sort = int.Parse(row["Sort"].ToString());}if (row["AddTime"] != null && row["AddTime"].ToString() != ""){sDFilmCategory.AddTime = DateTime.Parse(row["AddTime"].ToString());}
list.Add(sDFilmCategory);
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
public static DataTable GetSDFilmCategorysByStr(string strs)
{
string sql = "select * from SDFilmCategory where 1 = 1 " + strs;
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
public static DataTable GetSDFilmCategorysByStr(int top, string strs)
{
string sql = "select top " + top + " * from SDFilmCategory where 1 = 1 " + strs;
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
