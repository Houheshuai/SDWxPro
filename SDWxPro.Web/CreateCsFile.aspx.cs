using SDWxPro.Service;
using SDWxPro.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDWxPro.Web
{
    public partial class CreateCsFile : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtFile = OperSystemService.GetAllSystemTable();
                if (dtFile.Rows.Count > 0)
                {
                    RepTable.DataSource = dtFile;
                    RepTable.DataBind();
                }

                string action = Security.ToStr(Request["action"]);
                if (!string.IsNullOrEmpty(action) && action.CompareTo("doCreate") == 0)
                {
                    string tables = Security.ToStr(Request["idstr"]);

                    CreateModelCs(tables, "SDWxPro");
                    CreateDALCs(tables, "SDWxPro");

                    JsUtil.ShowMsg("生成成功！", "CreateCsFile.aspx");
                }
            }
        }

        /// <summary>
        /// 首字母转小写
        /// </summary>
        /// <param name="strs">要处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        public string GetPuscNameToLower(string strs)
        {
            string str1 = HandleString.CutString(strs, 0, 1).ToLower();
            string str2 = HandleString.CutString(strs, 1);
            strs = str1 + str2;
            return strs;
        }

        /// <summary>
        /// 首字母转大写
        /// </summary>
        /// <param name="strs">要处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        public string GetPuscNameToUpper(string strs)
        {
            string str1 = HandleString.CutString(strs, 0, 1).ToUpper();
            string str2 = HandleString.CutString(strs, 1);
            strs = str1 + str2;
            return strs;
        }

        /// <summary>
        /// 创建 Model.cs文件
        /// </summary>
        /// <param name="tables">要创建的表名</param>
        public void CreateModelCs(string tables, string baseName)
        {
            string strColumnType = null;
            string[] arrayTable = tables.Split(',');
            for (int i = 0; i < arrayTable.Length; i++)
            {
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("~/Entities/Model/" + Security.ToStr(arrayTable[i]) + ".cs"), false))
                //false:覆盖已有内容
                {
                    sw.WriteLine("//" + Security.ToStr(arrayTable[i]) + " 表的实体类");
                    sw.WriteLine("");
                    sw.WriteLine("//创建日期: " + DateTime.Now.ToString());
                    sw.WriteLine("");
                    sw.WriteLine("using System;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using System.Text;");
                    sw.WriteLine("");
                    sw.WriteLine("namespace SDWxPro.Model");
                    sw.WriteLine("{");
                    sw.WriteLine("");
                    sw.WriteLine("[Serializable()]");
                    sw.WriteLine("public partial class " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])));
                    sw.WriteLine("{");
                    sw.WriteLine("public " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "() { }");
                    sw.WriteLine("#region Model");

                    DataTable dt1 = OperSystemService.GetTableInfo(baseName, Security.ToStr(arrayTable[i]));
                    if (dt1.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt1.Rows.Count; j++)
                        {
                            switch (Security.ToStr(dt1.Rows[j]["DATA_TYPE"]))
                            {
                                case "varchar":
                                    strColumnType = "string";
                                    break;
                                case "nvarchar":
                                    strColumnType = "string";
                                    break;
                                case "char":
                                    strColumnType = "string";
                                    break;
                                case "nchar":
                                    strColumnType = "string";
                                    break;
                                case "text":
                                    strColumnType = "string";
                                    break;
                                case "ntext":
                                    strColumnType = "string";
                                    break;
                                case "int":
                                    strColumnType = "int";
                                    break;
                                case "smallint":
                                    strColumnType = "Int16";
                                    break;
                                case "bigint":
                                    strColumnType = "Int64";
                                    break;
                                case "decimal":
                                    strColumnType = "decimal";
                                    break;
                                case "money":
                                    strColumnType = "decimal";
                                    break;
                                case "float":
                                    strColumnType = "float";
                                    break;
                                case "datetime":
                                    strColumnType = "DateTime";
                                    break;
                                case "bit":
                                    strColumnType = "bool";
                                    break;
                                default:
                                    strColumnType = "object";
                                    break;
                            }
                            sw.WriteLine("private " + GetWenHao(j, strColumnType) + " " + GetPuscNameToLower(Security.ToStr(dt1.Rows[j]["COLUMN_NAME"])) + ";");
                            sw.WriteLine("public " + GetWenHao(j, strColumnType) + " " + GetPuscNameToUpper(Security.ToStr(dt1.Rows[j]["COLUMN_NAME"])) + " { set { " + GetPuscNameToLower(Security.ToStr(dt1.Rows[j]["COLUMN_NAME"])) + " = value; } get { return " + GetPuscNameToLower(Security.ToStr(dt1.Rows[j]["COLUMN_NAME"])) + "; } }");
                        }
                    }
                    sw.WriteLine("#endregion Model");
                    sw.WriteLine("    } //end of class");
                    sw.WriteLine("} //end of namespace");
                    sw.Flush();

                }
            }
        }

        public string GetWenHao(int index, string type)
        {
            string strs = "";
            if (index > 0)
            {
                switch (type)
                {
                    case "int":
                        strs = type + "?";
                        break;
                    case "Int16":
                        strs = type + "?";
                        break;
                    case "Int64":
                        strs = type + "?";
                        break;
                    case "decimal":
                        strs = type + "?";
                        break;
                    case "float":
                        strs = type + "?";
                        break;
                    case "DateTime":
                        strs = type + "?";
                        break;
                    default:
                        strs = type;
                        break;
                }
            }
            else
            {
                strs = type;
            }
            return strs;
        }

        /// <summary>
        /// 创建 DAL.cs文件
        /// </summary>
        /// <param name="tables">要创建的表名</param>
        public void CreateDALCs(string tables, string baseName)
        {
            string strColumnType = null;
            string[] arrayTable = tables.Split(',');
            for (int i = 0; i < arrayTable.Length; i++)
            {
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("~/Entities/DAL/" + Security.ToStr(arrayTable[i]) + "Service.cs"), false))
                //false:覆盖已有内容
                {
                    sw.WriteLine("//" + Security.ToStr(arrayTable[i]) + " 表" + "的数据访问类");
                    sw.WriteLine("");
                    sw.WriteLine("//创建日期: " + DateTime.Now.ToString());
                    sw.WriteLine("");
                    sw.WriteLine("using System;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using System.Text;");
                    sw.WriteLine("using System.Data;");
                    sw.WriteLine("using System.Data.SqlClient;");
                    sw.WriteLine("using SDWxPro.Model;");
                    sw.WriteLine("");
                    sw.WriteLine("namespace SDWxPro.Service");
                    sw.WriteLine("{");
                    sw.WriteLine("");
                    sw.WriteLine("public static partial class " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "Service");
                    sw.WriteLine("{");
                    sw.WriteLine("#region DAL");

                    string insertSql1 = "";
                    string insertSql2 = "";
                    string parameterSql = "";
                    string updateSql = "";
                    string readSql = "";
                    string rowSql = "";
                    DataTable dt1 = OperSystemService.GetTableInfo(baseName, Security.ToStr(arrayTable[i]));
                    if (dt1.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt1.Rows.Count; j++)
                        {
                            switch (Security.ToStr(dt1.Rows[j]["DATA_TYPE"]))
                            {
                                case "varchar":
                                    strColumnType = "string";
                                    break;
                                case "nvarchar":
                                    strColumnType = "string";
                                    break;
                                case "char":
                                    strColumnType = "string";
                                    break;
                                case "nchar":
                                    strColumnType = "string";
                                    break;
                                case "text":
                                    strColumnType = "string";
                                    break;
                                case "ntext":
                                    strColumnType = "string";
                                    break;
                                case "int":
                                    strColumnType = "int";
                                    break;
                                case "smallint":
                                    strColumnType = "Int16";
                                    break;
                                case "bigint":
                                    strColumnType = "Int64";
                                    break;
                                case "decimal":
                                    strColumnType = "decimal";
                                    break;
                                case "money":
                                    strColumnType = "decimal";
                                    break;
                                case "float":
                                    strColumnType = "float";
                                    break;
                                case "datetime":
                                    strColumnType = "DateTime";
                                    break;
                                case "bit":
                                    strColumnType = "bool";
                                    break;
                                default:
                                    strColumnType = "object";
                                    break;
                            }

                            if (j > 0)
                            {
                                insertSql1 += Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + ",";
                                insertSql2 += "@" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + ",";
                                parameterSql += "new SqlParameter(\"@" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + "\", " + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + "." + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + "),";
                                if (j == 1)
                                {
                                    updateSql += "\"" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + " = @" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + "\" +";
                                }
                                else
                                {
                                    updateSql += "\", " + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + " = @" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + " \" +";
                                }

                                readSql += "if (reader[\"" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + "\"] != null && reader[\"" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + "\"].ToString() != \"\")";
                                readSql += "{";
                                if (strColumnType != "string")
                                {
                                    readSql += "" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + "." + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + " = " + strColumnType + ".Parse(reader[\"" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + "\"].ToString());";
                                }
                                else
                                {
                                    readSql += "" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + "." + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + " = reader[\"" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + "\"].ToString();";
                                }
                                readSql += "}";


                                rowSql += "if (row[\"" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + "\"] != null && row[\"" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + "\"].ToString() != \"\")";
                                rowSql += "{";
                                if (strColumnType != "string")
                                {
                                    rowSql += "" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + "." + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + " = " + strColumnType + ".Parse(row[\"" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + "\"].ToString());";
                                }
                                else
                                {
                                    rowSql += "" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + "." + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + " = row[\"" + Security.ToStr(dt1.Rows[j]["COLUMN_NAME"]) + "\"].ToString();";
                                }
                                rowSql += "}";
                            }
                        }
                    }




                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 添加");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <param name=\"" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + "\">实体对象</param>");
                    sw.WriteLine("/// <returns>返回添加成功后的新对象</returns>");
                    sw.WriteLine("public static " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " Add" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "(" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " " + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + "){");
                    sw.WriteLine("string sql =");
                    sw.WriteLine("\"insert " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " (" + insertSql1.TrimEnd(',') + ") \" +");
                    sw.WriteLine("\"values (" + insertSql2.TrimEnd(',') + ") \";");
                    sw.WriteLine("sql += \" ; select @@identity\";");
                    sw.WriteLine("try");
                    sw.WriteLine("{");
                    sw.WriteLine("SqlParameter[] para = new SqlParameter[]");
                    sw.WriteLine("{");
                    sw.WriteLine(parameterSql.TrimEnd(','));
                    sw.WriteLine("};");
                    sw.WriteLine("int newId = DBHelper.ExecuteScalar(CommandType.Text, sql, para);");
                    sw.WriteLine("return Get" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "ById(newId);");
                    sw.WriteLine("}");
                    sw.WriteLine("catch (Exception e)");
                    sw.WriteLine("{");
                    sw.WriteLine("Console.WriteLine(e.Message);");
                    sw.WriteLine("throw e;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");


                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 删除");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <param name=\"" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + "\">实体对象</param>");
                    sw.WriteLine("public static void Delete" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "(" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " " + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ")");
                    sw.WriteLine("{");
                    sw.WriteLine("Delete" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "ById(" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ".Id);");
                    sw.WriteLine("}");


                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 删除");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <param name=\"id\">按id删除</param>");
                    sw.WriteLine("public static void Delete" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "ById(int id)");
                    sw.WriteLine("{");
                    sw.WriteLine("string sql = \"Delete " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " where Id = @Id\";");
                    sw.WriteLine("try");
                    sw.WriteLine("{");
                    sw.WriteLine("SqlParameter[] para = new SqlParameter[]{ new SqlParameter(\"@Id\", id) };");
                    sw.WriteLine("DBHelper.ExecuteNonQuery(CommandType.Text, sql, para);");
                    sw.WriteLine("}");
                    sw.WriteLine("catch (Exception e)");
                    sw.WriteLine("{");
                    sw.WriteLine("Console.WriteLine(e.Message);");
                    sw.WriteLine("throw e;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");


                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 删除");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <param name=\"strs\">按条件删除</param>");
                    sw.WriteLine("public static void Delete" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "ByStr(string strs)");
                    sw.WriteLine("{");
                    sw.WriteLine("string sql = \"Delete " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " where 1 = 1 \" + strs;");
                    sw.WriteLine("try { DBHelper.ExecuteNonQuery(CommandType.Text, sql, null); }");
                    sw.WriteLine("catch (Exception e)");
                    sw.WriteLine("{");
                    sw.WriteLine("Console.WriteLine(e.Message);");
                    sw.WriteLine("throw e;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");


                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 修改");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <param name=\"" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + "\">实体对象</param>");
                    sw.WriteLine("public static void Modify" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "(" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " " + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ")");
                    sw.WriteLine("{");
                    sw.WriteLine("string sql =");
                    sw.WriteLine("\"UPDATE " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " \" +");
                    sw.WriteLine("\"SET \" +");
                    sw.WriteLine(updateSql.TrimEnd(','));
                    sw.WriteLine("\"WHERE Id = @Id\";");
                    sw.WriteLine("try");
                    sw.WriteLine("{");
                    sw.WriteLine("SqlParameter[] para = new SqlParameter[]{");
                    sw.WriteLine("new SqlParameter(\"@Id\", " + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ".Id),");
                    sw.WriteLine(parameterSql.TrimEnd(','));
                    sw.WriteLine("};");
                    sw.WriteLine("DBHelper.ExecuteNonQuery(CommandType.Text, sql, para);");
                    sw.WriteLine("}");
                    sw.WriteLine("catch (Exception e)");
                    sw.WriteLine("{");
                    sw.WriteLine("Console.WriteLine(e.Message);");
                    sw.WriteLine("throw e;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");


                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 获取IList列表");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <returns>返回IList列表</returns>");
                    sw.WriteLine("public static IList<" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "> GetAll" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "s()");
                    sw.WriteLine("{");
                    sw.WriteLine("string sqlAll = \"SELECT * FROM " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "\";");
                    sw.WriteLine("return Get" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "sBySql(sqlAll);");
                    sw.WriteLine("}");

                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 获取对象");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <param name=\"id\">按id获取</param>");
                    sw.WriteLine("/// <returns>返回获取到的对象</returns>");
                    sw.WriteLine("public static " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " Get" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "ById(int id)");
                    sw.WriteLine("{");
                    sw.WriteLine("string sql = \"select * from " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " where Id = @Id\";");
                    sw.WriteLine("try");
                    sw.WriteLine("{");
                    sw.WriteLine("SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, new SqlParameter(\"@Id\", id));");
                    sw.WriteLine("if (reader.Read()){");
                    sw.WriteLine("" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " " + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + " = new " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "();");
                    sw.WriteLine("if (reader[\"Id\"] != null && reader[\"Id\"].ToString() != \"\")");
                    sw.WriteLine("{");
                    sw.WriteLine("" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ".Id = int.Parse(reader[\"Id\"].ToString());");
                    sw.WriteLine("}");

                    sw.WriteLine(readSql);
                    sw.WriteLine("reader.Close();");
                    sw.WriteLine("return " + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ";");
                    sw.WriteLine("} else {");
                    sw.WriteLine("reader.Close();");
                    sw.WriteLine("return null;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");
                    sw.WriteLine("catch (Exception e)");
                    sw.WriteLine("{");
                    sw.WriteLine("Console.WriteLine(e.Message);");
                    sw.WriteLine("throw e;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");


                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 获取对象");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <param name=\"strs\">查询条件</param>");
                    sw.WriteLine("/// <returns>返回获取到的对象</returns>");
                    sw.WriteLine("public static " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " Get" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "ByStr(string strs)");
                    sw.WriteLine("{");
                    sw.WriteLine("string sql = \"select * from " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " where 1 = 1 \" + strs;");
                    sw.WriteLine("try");
                    sw.WriteLine("{");
                    sw.WriteLine("SqlDataReader reader = DBHelper.ExecuteReader(CommandType.Text, sql, null);");
                    sw.WriteLine("if (reader.Read())");
                    sw.WriteLine("{");
                    sw.WriteLine("" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " " + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + " = new " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "();");
                    sw.WriteLine("if (reader[\"Id\"] != null && reader[\"Id\"].ToString() != \"\")");
                    sw.WriteLine("{");
                    sw.WriteLine("" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ".Id = int.Parse(reader[\"Id\"].ToString());");
                    sw.WriteLine("}");

                    sw.WriteLine(readSql);
                    sw.WriteLine("reader.Close();");
                    sw.WriteLine("return " + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ";");
                    sw.WriteLine("} else {");
                    sw.WriteLine("reader.Close();");
                    sw.WriteLine("return null;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");
                    sw.WriteLine("catch (Exception e)");
                    sw.WriteLine("{");
                    sw.WriteLine("Console.WriteLine(e.Message);");
                    sw.WriteLine("throw e;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");

                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 获取IList列表");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <param name=\"safeSql\">查询条件</param>");
                    sw.WriteLine("/// <returns>返回IList列表</returns>");
                    sw.WriteLine("private static IList<" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "> Get" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "sBySql(string safeSql)");
                    sw.WriteLine("{");
                    sw.WriteLine("List<" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "> list = new List<" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + ">();");
                    sw.WriteLine("try");
                    sw.WriteLine("{");
                    sw.WriteLine("DataTable table = DBHelper.GetDataTable(CommandType.Text, safeSql, null);");
                    sw.WriteLine("foreach (DataRow row in table.Rows)");
                    sw.WriteLine("{");
                    sw.WriteLine("" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " " + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + " = new " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "();");
                    sw.WriteLine("if (row[\"Id\"] != null && row[\"Id\"].ToString() != \"\")");
                    sw.WriteLine("{");
                    sw.WriteLine("" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ".Id = int.Parse(row[\"Id\"].ToString());");
                    sw.WriteLine("}");

                    sw.WriteLine(rowSql);
                    sw.WriteLine("list.Add(" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ");");
                    sw.WriteLine("}");
                    sw.WriteLine("return list;");
                    sw.WriteLine("}");
                    sw.WriteLine("catch (Exception e)");
                    sw.WriteLine("{");
                    sw.WriteLine("Console.WriteLine(e.Message);");
                    sw.WriteLine("throw e;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");

                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 获取IList列表");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <param name=\"sql\">sql语句</param>");
                    sw.WriteLine("/// <param name=\"values\">参数</param>");
                    sw.WriteLine("/// <returns>返回IList列表</returns>");
                    sw.WriteLine("private static IList<" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "> Get" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "sBySql(string sql, params SqlParameter[] values)");
                    sw.WriteLine("{");
                    sw.WriteLine("List<" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "> list = new List<" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + ">();");
                    sw.WriteLine("try");
                    sw.WriteLine("{");
                    sw.WriteLine("DataTable table = DBHelper.GetDataTable(CommandType.Text, sql, values);");
                    sw.WriteLine("foreach (DataRow row in table.Rows)");
                    sw.WriteLine("{");
                    sw.WriteLine("" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " " + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + " = new " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "();");
                    sw.WriteLine("if (row[\"Id\"] != null && row[\"Id\"].ToString() != \"\")");
                    sw.WriteLine("{");
                    sw.WriteLine("" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ".Id = int.Parse(row[\"Id\"].ToString());");
                    sw.WriteLine("}");

                    sw.WriteLine(rowSql);
                    sw.WriteLine("list.Add(" + GetPuscNameToLower(Security.ToStr(arrayTable[i])) + ");");
                    sw.WriteLine("}");
                    sw.WriteLine("return list;");
                    sw.WriteLine("}");
                    sw.WriteLine("catch (Exception e)");
                    sw.WriteLine("{");
                    sw.WriteLine("Console.WriteLine(e.Message);");
                    sw.WriteLine("throw e;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");

                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 获取列表");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <param name=\"strs\">查询条件</param>");
                    sw.WriteLine("/// <returns>返回查询结果</returns>");
                    sw.WriteLine("public static DataTable Get" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "sByStr(string strs)");
                    sw.WriteLine("{");
                    sw.WriteLine("string sql = \"select * from " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " where 1 = 1 \" + strs;");
                    sw.WriteLine("try");
                    sw.WriteLine("{");
                    sw.WriteLine("DataTable dt = DBHelper.GetDataTable(CommandType.Text, sql, null);");
                    sw.WriteLine("return dt;");
                    sw.WriteLine("}");
                    sw.WriteLine("catch (Exception e)");
                    sw.WriteLine("{");
                    sw.WriteLine("Console.WriteLine(e.Message);");
                    sw.WriteLine("throw e;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");


                    sw.WriteLine("/// <summary>");
                    sw.WriteLine("/// 获取列表");
                    sw.WriteLine("/// </summary>");
                    sw.WriteLine("/// <param name=\"top\">前几条</param>");
                    sw.WriteLine("/// <param name=\"strs\">查询条件</param>");
                    sw.WriteLine("/// <returns>返回查询结果</returns>");
                    sw.WriteLine("public static DataTable Get" + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + "sByStr(int top, string strs)");
                    sw.WriteLine("{");
                    sw.WriteLine("string sql = \"select top \" + top + \" * from " + GetPuscNameToUpper(Security.ToStr(arrayTable[i])) + " where 1 = 1 \" + strs;");
                    sw.WriteLine("try");
                    sw.WriteLine("{");
                    sw.WriteLine("DataTable dt = DBHelper.GetDataTable(CommandType.Text, sql, null);");
                    sw.WriteLine("return dt;");
                    sw.WriteLine("}");
                    sw.WriteLine("catch (Exception e)");
                    sw.WriteLine("{");
                    sw.WriteLine("Console.WriteLine(e.Message);");
                    sw.WriteLine("throw e;");
                    sw.WriteLine("}");
                    sw.WriteLine("}");

                    sw.WriteLine("#endregion Model");
                    sw.WriteLine("    } //end of class");
                    sw.WriteLine("} //end of namespace");
                    sw.Flush();

                }
            }
        }
    }
    }
