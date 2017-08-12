//SDFileImage 表的数据访问类

//创建日期: 2017/8/10 星期四 10:04:05

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SDWxPro.Model;

namespace SDWxPro.Service
{

public static partial class SDFileImageService
{
#region DAL
/// <summary>
/// 添加
/// </summary>
/// <param name="sDFileImage">实体对象</param>
/// <returns>返回添加成功后的新对象</returns>
public static SDFileImage AddSDFileImage(SDFileImage sDFileImage){
string sql =
"insert SDFileImage (ImageUrl,IsDel,Sort,IsMain,SDFileId,AddTime) " +
"values (@ImageUrl,@IsDel,@Sort,@IsMain,@SDFileId,@AddTime) ";
sql += " ; select @@identity";
try
{
SqlParameter[] para = new SqlParameter[]
{
new SqlParameter("@ImageUrl", sDFileImage.ImageUrl),new SqlParameter("@IsDel", sDFileImage.IsDel),new SqlParameter("@Sort", sDFileImage.Sort),new SqlParameter("@IsMain", sDFileImage.IsMain),new SqlParameter("@SDFileId", sDFileImage.SDFileId),new SqlParameter("@AddTime", sDFileImage.AddTime)
};
int newId = DBHelper.ExecuteScalar(CommandType.Text, sql, para);
return GetSDFileImageById(newId);
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
/// <param name="sDFileImage">实体对象</param>
public static void DeleteSDFileImage(SDFileImage sDFileImage)
{
DeleteSDFileImageById(sDFileImage.Id);
}
/// <summary>
/// 删除
/// </summary>
/// <param name="id">按id删除</param>
public static void DeleteSDFileImageById(int id)
{
string sql = "Delete SDFileImage where Id = @Id";
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
public static void DeleteSDFileImageByStr(string strs)
{
string sql = "Delete SDFileImage where 1 = 1 " + strs;
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
/// <param name="sDFileImage">实体对象</param>
public static void ModifySDFileImage(SDFileImage sDFileImage)
{
string sql =
"UPDATE SDFileImage " +
"SET " +
"ImageUrl = @ImageUrl" +", IsDel = @IsDel " +", Sort = @Sort " +", IsMain = @IsMain " +", SDFileId = @SDFileId " +", AddTime = @AddTime " +
"WHERE Id = @Id";
try
{
SqlParameter[] para = new SqlParameter[]{
new SqlParameter("@Id", sDFileImage.Id),
new SqlParameter("@ImageUrl", sDFileImage.ImageUrl),new SqlParameter("@IsDel", sDFileImage.IsDel),new SqlParameter("@Sort", sDFileImage.Sort),new SqlParameter("@IsMain", sDFileImage.IsMain),new SqlParameter("@SDFileId", sDFileImage.SDFileId),new SqlParameter("@AddTime", sDFileImage.AddTime)
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
public static IList<SDFileImage> GetAllSDFileImages()
{
string sqlAll = "SELECT * FROM SDFileImage";
return GetSDFileImagesBySql(sqlAll);
}
/// <summary>
/// 获取对象
/// </summary>
/// <param name="id">按id获取</param>
/// <returns>返回获取到的对象</returns>
public static SDFileImage GetSDFileImageById(int id)
{
string sql = "select * from SDFileImage where Id = @Id";
try
{
SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, new SqlParameter("@Id", id));
if (reader.Read()){
SDFileImage sDFileImage = new SDFileImage();
if (reader["Id"] != null && reader["Id"].ToString() != "")
{
sDFileImage.Id = int.Parse(reader["Id"].ToString());
}
if (reader["ImageUrl"] != null && reader["ImageUrl"].ToString() != ""){sDFileImage.ImageUrl = reader["ImageUrl"].ToString();}if (reader["IsDel"] != null && reader["IsDel"].ToString() != ""){sDFileImage.IsDel = int.Parse(reader["IsDel"].ToString());}if (reader["Sort"] != null && reader["Sort"].ToString() != ""){sDFileImage.Sort = int.Parse(reader["Sort"].ToString());}if (reader["IsMain"] != null && reader["IsMain"].ToString() != ""){sDFileImage.IsMain = int.Parse(reader["IsMain"].ToString());}if (reader["SDFileId"] != null && reader["SDFileId"].ToString() != ""){sDFileImage.SDFileId = int.Parse(reader["SDFileId"].ToString());}if (reader["AddTime"] != null && reader["AddTime"].ToString() != ""){sDFileImage.AddTime = DateTime.Parse(reader["AddTime"].ToString());}
reader.Close();
return sDFileImage;
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
public static SDFileImage GetSDFileImageByStr(string strs)
{
string sql = "select * from SDFileImage where 1 = 1 " + strs;
try
{
SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, null);
if (reader.Read())
{
SDFileImage sDFileImage = new SDFileImage();
if (reader["Id"] != null && reader["Id"].ToString() != "")
{
sDFileImage.Id = int.Parse(reader["Id"].ToString());
}
if (reader["ImageUrl"] != null && reader["ImageUrl"].ToString() != ""){sDFileImage.ImageUrl = reader["ImageUrl"].ToString();}if (reader["IsDel"] != null && reader["IsDel"].ToString() != ""){sDFileImage.IsDel = int.Parse(reader["IsDel"].ToString());}if (reader["Sort"] != null && reader["Sort"].ToString() != ""){sDFileImage.Sort = int.Parse(reader["Sort"].ToString());}if (reader["IsMain"] != null && reader["IsMain"].ToString() != ""){sDFileImage.IsMain = int.Parse(reader["IsMain"].ToString());}if (reader["SDFileId"] != null && reader["SDFileId"].ToString() != ""){sDFileImage.SDFileId = int.Parse(reader["SDFileId"].ToString());}if (reader["AddTime"] != null && reader["AddTime"].ToString() != ""){sDFileImage.AddTime = DateTime.Parse(reader["AddTime"].ToString());}
reader.Close();
return sDFileImage;
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
private static IList<SDFileImage> GetSDFileImagesBySql(string safeSql)
{
List<SDFileImage> list = new List<SDFileImage>();
try
{
DataTable table = DBHelper.GetDataTable(CommandType.Text, safeSql, null);
foreach (DataRow row in table.Rows)
{
SDFileImage sDFileImage = new SDFileImage();
if (row["Id"] != null && row["Id"].ToString() != "")
{
sDFileImage.Id = int.Parse(row["Id"].ToString());
}
if (row["ImageUrl"] != null && row["ImageUrl"].ToString() != ""){sDFileImage.ImageUrl = row["ImageUrl"].ToString();}if (row["IsDel"] != null && row["IsDel"].ToString() != ""){sDFileImage.IsDel = int.Parse(row["IsDel"].ToString());}if (row["Sort"] != null && row["Sort"].ToString() != ""){sDFileImage.Sort = int.Parse(row["Sort"].ToString());}if (row["IsMain"] != null && row["IsMain"].ToString() != ""){sDFileImage.IsMain = int.Parse(row["IsMain"].ToString());}if (row["SDFileId"] != null && row["SDFileId"].ToString() != ""){sDFileImage.SDFileId = int.Parse(row["SDFileId"].ToString());}if (row["AddTime"] != null && row["AddTime"].ToString() != ""){sDFileImage.AddTime = DateTime.Parse(row["AddTime"].ToString());}
list.Add(sDFileImage);
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
private static IList<SDFileImage> GetSDFileImagesBySql(string sql, params SqlParameter[] values)
{
List<SDFileImage> list = new List<SDFileImage>();
try
{
DataTable table = DBHelper.GetDataTable(CommandType.Text, sql, values);
foreach (DataRow row in table.Rows)
{
SDFileImage sDFileImage = new SDFileImage();
if (row["Id"] != null && row["Id"].ToString() != "")
{
sDFileImage.Id = int.Parse(row["Id"].ToString());
}
if (row["ImageUrl"] != null && row["ImageUrl"].ToString() != ""){sDFileImage.ImageUrl = row["ImageUrl"].ToString();}if (row["IsDel"] != null && row["IsDel"].ToString() != ""){sDFileImage.IsDel = int.Parse(row["IsDel"].ToString());}if (row["Sort"] != null && row["Sort"].ToString() != ""){sDFileImage.Sort = int.Parse(row["Sort"].ToString());}if (row["IsMain"] != null && row["IsMain"].ToString() != ""){sDFileImage.IsMain = int.Parse(row["IsMain"].ToString());}if (row["SDFileId"] != null && row["SDFileId"].ToString() != ""){sDFileImage.SDFileId = int.Parse(row["SDFileId"].ToString());}if (row["AddTime"] != null && row["AddTime"].ToString() != ""){sDFileImage.AddTime = DateTime.Parse(row["AddTime"].ToString());}
list.Add(sDFileImage);
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
public static DataTable GetSDFileImagesByStr(string strs)
{
string sql = "select * from SDFileImage where 1 = 1 " + strs;
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
public static DataTable GetSDFileImagesByStr(int top, string strs)
{
string sql = "select top " + top + " * from SDFileImage where 1 = 1 " + strs;
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
