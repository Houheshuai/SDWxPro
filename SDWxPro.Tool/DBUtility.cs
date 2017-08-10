using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SDWxPro.Tool
{
    /// <summary>
    /// 数据集操作类
    /// </summary>
    public class DBUtility
    {
        
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="dataTable">传入需要排序的表</param>
        /// <param name="columnName">排序的字段</param>
        /// <param name="AscOrDesc">true升序, false降序</param>
        /// <returns>返回排好序的DataTable</returns>
        public static DataTable SortingOrder(DataTable dataTable, string columnName, bool AscOrDesc)
        {
            return SortingOrder(dataTable, HandleString.JoinString(columnName, " ", AscOrDesc ? "asc" : "desc"));
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="dataTable">传入需要排序的表</param>
        /// <param name="strCondition">排序条件</param>
        /// <returns>返回排好序的DataTable</returns>
        public static DataTable SortingOrder(DataTable dataTable, string strCondition)
        {
            DataView dv = dataTable.DefaultView;
            dv.Sort = strCondition;
            return dv.ToTable();
        }

        /// <summary>
        /// 将DataRow装换成DataTable
        /// </summary>
        /// <param name="dataRow">dataRow</param>
        /// <returns>返回DataTable</returns>
        public static DataTable DataRowConvertToDataTable(DataRow[] dataRow)
        {
            if (dataRow.Length > 0)
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                System.Data.DataTable dtClone = dt.Clone();
                foreach (System.Data.DataRow dr in dataRow)
                {
                    dtClone.ImportRow(dr);
                }
                return dtClone;
            }
            return null;
        }

        /// <summary>
        /// 统计dataTable中满足条件的记录的行数
        /// </summary>
        /// <param name="dataTable">要筛选的DataTable</param>
        /// <param name="strCondition">筛选条件</param>
        /// <returns>符合条件的行数</returns>
        public static int CountDataTable(DataTable dataTable, string strCondition)
        {
            return Security.ToNum(dataTable.Compute("count(0)", strCondition));
        }

        /// <summary>
        /// 消除重复
        /// </summary>
        /// <param name="dataTable">要处理的DataTable</param>
        /// <param name="columnNames">列名</param>
        /// <returns>返回DataTable</returns>
        public static DataTable DistictDataTable(DataTable dataTable, params string[] columnNames)
        {
            System.Data.DataView dv = dataTable.DefaultView;
            return dv.ToTable(true, columnNames);
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="colName">列名</param>
        /// <returns>返回string 类型的值</returns>
        public static string GetCellValue(DataRow row, string colName)
        {
            return GetCellValue(row, colName, string.Empty, false);
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="colName">column name</param>
        /// <param name="defaultValue">default value.</param>
        /// <param name="checkCol">Indicator whether need to check the column existed or not.</param>
        /// <returns>cell value in string. If it is null, the default value will be returned.</returns>
        public static string GetCellValue(DataRow row, string colName, string def, bool checkCol)
        {
            if (!checkCol || row.Table.Columns.Contains(colName))
            {
                if (!row.IsNull(colName))
                {
                    return row[colName].ToString();
                }
            }
            return def;
        }

        /// <summary>
        /// 获取单元格的值 
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <returns>返回DateTime类型</returns>
        public static DateTime GetDateTimeValue(DataRow dr, string colName)
        {
            return GetDateTimeValue(dr, colName, new DateTime(1900, 1, 1), false);
        }

        /// <summary>
        /// 获取单元格的值 
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <param name="def">默认值</param>
        /// <param name="checkCol">是否强制转换</param>
        /// <returns>返回DateTime类型</returns>
        public static DateTime GetDateTimeValue(DataRow dr, string colName, DateTime def, bool checkCol)
        {
            if (!checkCol || dr.Table.Columns.Contains(colName))
                if (!dr.IsNull(colName))
                    return Convert.ToDateTime(dr[colName]);
            return def;
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <returns>返回int类型</returns>
        public static int GetIntegerValue(DataRow dr, string colName)
        {
            return GetIntegerValue(dr, colName, 0, false);
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <param name="def">默认值</param>
        /// <param name="checkCol">是否强制转换</param>
        /// <returns>返回int类型</returns>
        public static int GetIntegerValue(DataRow dr, string colName, int def, bool checkCol)
        {
            if (!checkCol || dr.Table.Columns.Contains(colName))
                if (!dr.IsNull(colName))
                    return Convert.ToInt32(dr[colName]);
            return def;
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <returns>返回bool类型</returns>
        public static bool GetBoolValue(DataRow row, string colName)
        {
            return GetBoolValue(row, colName, false, false);
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <param name="def">默认值</param>
        /// <param name="checkCol">是否强制转换</param>
        /// <returns>返回bool类型</returns>
        public static bool GetBoolValue(DataRow row, string colName, bool def, bool checkCol)
        {

            if (!checkCol || row.Table.Columns.Contains(colName))
            {
                if (!row.IsNull(colName))
                {
                    return Security.ToBool(row[colName]);
                }
            }

            return def;
        }
        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <returns>返回double类型</returns>
        public static double GetDoubleValue(DataRow dr, string colName)
        {
            return GetDoubleValue(dr, colName, 0F, false);
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <param name="def">默认值</param>
        /// <param name="checkCol">是否强制转换</param>
        /// <returns>返回double类型</returns>
        public static double GetDoubleValue(DataRow dr, string colName, double def, bool checkCol)
        {
            if (!checkCol || dr.Table.Columns.Contains(colName))
            {
                if (!dr.IsNull(colName))
                {
                    return Convert.ToDouble(dr[colName]);
                }
            }
            return def;
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <returns>返回decimal类型</returns>
        public static decimal GetDecimalValue(DataRow dr, string colName)
        {
            return GetDecimalValue(dr, colName, 0M, false);
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <param name="def">默认值</param>
        /// <param name="checkCol">是否强制转换</param>
        /// <returns>返回decimal类型</returns>
        public static decimal GetDecimalValue(DataRow dr, string colName, decimal def, bool checkCol)
        {
            if (!checkCol || dr.Table.Columns.Contains(colName))
            {
                if (!dr.IsNull(colName))
                {
                    return Convert.ToDecimal(dr[colName]);
                }
            }
            return def;
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <param name="format">格式化</param>
        /// <returns>返回string类型</returns>
        public static string GetDecimalStringValue(DataRow row, string colName, string format)
        {
            return GetDecimalStringValue(row, colName, format, 0M, false);
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="dr">行</param>
        /// <param name="colName">列名</param>
        /// <param name="format">格式化</param>
        /// <param name="def">默认值</param>
        /// <param name="checkCol">强制转换</param>
        /// <returns>返回string类型</returns>
        public static string GetDecimalStringValue(DataRow row, string colName, string format, decimal def, bool checkCol)
        {
            decimal result = GetDecimalValue(row, colName, def, checkCol);
            if (result == 0m)
                return "0";
            else
                return result.ToString(format);
        }

      
    }
}
