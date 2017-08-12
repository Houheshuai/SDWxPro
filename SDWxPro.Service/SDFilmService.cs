//SDFilm 表的数据访问类

//创建日期: 2017/8/10 星期四 10:04:05

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SDWxPro.Model;

namespace SDWxPro.Service
{

public static partial class SDFilmService
{
#region DAL
/// <summary>
/// 添加
/// </summary>
/// <param name="sDFilm">实体对象</param>
/// <returns>返回添加成功后的新对象</returns>
public static SDFilm AddSDFilm(SDFilm sDFilm){
string sql =
"insert SDFilm (LinkUrl,IsDel,Type,AddTime,Sort,Description,Password,Name) " +
"values (@LinkUrl,@IsDel,@Type,@AddTime,@Sort,@Description,@Password,@Name) ";
sql += " ; select @@identity";
try
{
SqlParameter[] para = new SqlParameter[]
{
new SqlParameter("@LinkUrl", sDFilm.LinkUrl),new SqlParameter("@IsDel", sDFilm.IsDel),new SqlParameter("@Type", sDFilm.Type),new SqlParameter("@AddTime", sDFilm.AddTime),new SqlParameter("@Sort", sDFilm.Sort),new SqlParameter("@Description", sDFilm.Description),new SqlParameter("@Password", sDFilm.Password),new SqlParameter("@Name", sDFilm.Name)
};
int newId = DBHelper.ExecuteScalar(CommandType.Text, sql, para);
return GetSDFilmById(newId);
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
/// <param name="sDFilm">实体对象</param>
public static void DeleteSDFilm(SDFilm sDFilm)
{
DeleteSDFilmById(sDFilm.Id);
}
/// <summary>
/// 删除
/// </summary>
/// <param name="id">按id删除</param>
public static void DeleteSDFilmById(int id)
{
string sql = "Delete SDFilm where Id = @Id";
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
public static void DeleteSDFilmByStr(string strs)
{
string sql = "Delete SDFilm where 1 = 1 " + strs;
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
/// <param name="sDFilm">实体对象</param>
public static void ModifySDFilm(SDFilm sDFilm)
{
string sql =
"UPDATE SDFilm " +
"SET " +
"LinkUrl = @LinkUrl" +", IsDel = @IsDel " +", Type = @Type " +", AddTime = @AddTime " +", Sort = @Sort " +", Description = @Description " +", Password = @Password " +", Name = @Name " +
"WHERE Id = @Id";
try
{
SqlParameter[] para = new SqlParameter[]{
new SqlParameter("@Id", sDFilm.Id),
new SqlParameter("@LinkUrl", sDFilm.LinkUrl),new SqlParameter("@IsDel", sDFilm.IsDel),new SqlParameter("@Type", sDFilm.Type),new SqlParameter("@AddTime", sDFilm.AddTime),new SqlParameter("@Sort", sDFilm.Sort),new SqlParameter("@Description", sDFilm.Description),new SqlParameter("@Password", sDFilm.Password),new SqlParameter("@Name", sDFilm.Name)
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
public static IList<SDFilm> GetAllSDFilms()
{
string sqlAll = "SELECT * FROM SDFilm";
return GetSDFilmsBySql(sqlAll);
}
/// <summary>
/// 获取对象
/// </summary>
/// <param name="id">按id获取</param>
/// <returns>返回获取到的对象</returns>
public static SDFilm GetSDFilmById(int id)
{
string sql = "select * from SDFilm where Id = @Id";
try
{
SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, new SqlParameter("@Id", id));
if (reader.Read()){
SDFilm sDFilm = new SDFilm();
if (reader["Id"] != null && reader["Id"].ToString() != "")
{
sDFilm.Id = int.Parse(reader["Id"].ToString());
}
if (reader["LinkUrl"] != null && reader["LinkUrl"].ToString() != ""){sDFilm.LinkUrl = reader["LinkUrl"].ToString();}if (reader["IsDel"] != null && reader["IsDel"].ToString() != ""){sDFilm.IsDel = int.Parse(reader["IsDel"].ToString());}if (reader["Type"] != null && reader["Type"].ToString() != ""){sDFilm.Type = int.Parse(reader["Type"].ToString());}if (reader["AddTime"] != null && reader["AddTime"].ToString() != ""){sDFilm.AddTime = DateTime.Parse(reader["AddTime"].ToString());}if (reader["Sort"] != null && reader["Sort"].ToString() != ""){sDFilm.Sort = int.Parse(reader["Sort"].ToString());}if (reader["Description"] != null && reader["Description"].ToString() != ""){sDFilm.Description = reader["Description"].ToString();}if (reader["Password"] != null && reader["Password"].ToString() != ""){sDFilm.Password = reader["Password"].ToString();}if (reader["Name"] != null && reader["Name"].ToString() != ""){sDFilm.Name = reader["Name"].ToString();}
reader.Close();
return sDFilm;
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
public static SDFilm GetSDFilmByStr(string strs)
{
string sql = "select * from SDFilm where 1 = 1 " + strs;
try
{
SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, null);
if (reader.Read())
{
SDFilm sDFilm = new SDFilm();
if (reader["Id"] != null && reader["Id"].ToString() != "")
{
sDFilm.Id = int.Parse(reader["Id"].ToString());
}
if (reader["LinkUrl"] != null && reader["LinkUrl"].ToString() != ""){sDFilm.LinkUrl = reader["LinkUrl"].ToString();}if (reader["IsDel"] != null && reader["IsDel"].ToString() != ""){sDFilm.IsDel = int.Parse(reader["IsDel"].ToString());}if (reader["Type"] != null && reader["Type"].ToString() != ""){sDFilm.Type = int.Parse(reader["Type"].ToString());}if (reader["AddTime"] != null && reader["AddTime"].ToString() != ""){sDFilm.AddTime = DateTime.Parse(reader["AddTime"].ToString());}if (reader["Sort"] != null && reader["Sort"].ToString() != ""){sDFilm.Sort = int.Parse(reader["Sort"].ToString());}if (reader["Description"] != null && reader["Description"].ToString() != ""){sDFilm.Description = reader["Description"].ToString();}if (reader["Password"] != null && reader["Password"].ToString() != ""){sDFilm.Password = reader["Password"].ToString();}if (reader["Name"] != null && reader["Name"].ToString() != ""){sDFilm.Name = reader["Name"].ToString();}
reader.Close();
return sDFilm;
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
private static IList<SDFilm> GetSDFilmsBySql(string safeSql)
{
List<SDFilm> list = new List<SDFilm>();
try
{
DataTable table = DBHelper.GetDataTable(CommandType.Text, safeSql, null);
foreach (DataRow row in table.Rows)
{
SDFilm sDFilm = new SDFilm();
if (row["Id"] != null && row["Id"].ToString() != "")
{
sDFilm.Id = int.Parse(row["Id"].ToString());
}
if (row["LinkUrl"] != null && row["LinkUrl"].ToString() != ""){sDFilm.LinkUrl = row["LinkUrl"].ToString();}if (row["IsDel"] != null && row["IsDel"].ToString() != ""){sDFilm.IsDel = int.Parse(row["IsDel"].ToString());}if (row["Type"] != null && row["Type"].ToString() != ""){sDFilm.Type = int.Parse(row["Type"].ToString());}if (row["AddTime"] != null && row["AddTime"].ToString() != ""){sDFilm.AddTime = DateTime.Parse(row["AddTime"].ToString());}if (row["Sort"] != null && row["Sort"].ToString() != ""){sDFilm.Sort = int.Parse(row["Sort"].ToString());}if (row["Description"] != null && row["Description"].ToString() != ""){sDFilm.Description = row["Description"].ToString();}if (row["Password"] != null && row["Password"].ToString() != ""){sDFilm.Password = row["Password"].ToString();}if (row["Name"] != null && row["Name"].ToString() != ""){sDFilm.Name = row["Name"].ToString();}
list.Add(sDFilm);
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
private static IList<SDFilm> GetSDFilmsBySql(string sql, params SqlParameter[] values)
{
List<SDFilm> list = new List<SDFilm>();
try
{
DataTable table = DBHelper.GetDataTable(CommandType.Text, sql, values);
foreach (DataRow row in table.Rows)
{
SDFilm sDFilm = new SDFilm();
if (row["Id"] != null && row["Id"].ToString() != "")
{
sDFilm.Id = int.Parse(row["Id"].ToString());
}
if (row["LinkUrl"] != null && row["LinkUrl"].ToString() != ""){sDFilm.LinkUrl = row["LinkUrl"].ToString();}if (row["IsDel"] != null && row["IsDel"].ToString() != ""){sDFilm.IsDel = int.Parse(row["IsDel"].ToString());}if (row["Type"] != null && row["Type"].ToString() != ""){sDFilm.Type = int.Parse(row["Type"].ToString());}if (row["AddTime"] != null && row["AddTime"].ToString() != ""){sDFilm.AddTime = DateTime.Parse(row["AddTime"].ToString());}if (row["Sort"] != null && row["Sort"].ToString() != ""){sDFilm.Sort = int.Parse(row["Sort"].ToString());}if (row["Description"] != null && row["Description"].ToString() != ""){sDFilm.Description = row["Description"].ToString();}if (row["Password"] != null && row["Password"].ToString() != ""){sDFilm.Password = row["Password"].ToString();}if (row["Name"] != null && row["Name"].ToString() != ""){sDFilm.Name = row["Name"].ToString();}
list.Add(sDFilm);
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
public static DataTable GetSDFilmsByStr(string strs)
{
string sql = "select * from SDFilm where 1 = 1 " + strs;
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
public static DataTable GetSDFilmsByStr(int top, string strs)
{
string sql = "select top " + top + " * from SDFilm where 1 = 1 " + strs;
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
