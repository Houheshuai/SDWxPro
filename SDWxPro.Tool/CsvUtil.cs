using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;

namespace SDWxPro.Tool
{
    public class CsvUtil
    {

        /// <summary>
        /// 读取CSV文件内容
        /// </summary>
        /// <param name="filePath">文件路径，如：F:\\data\\</param>
        /// <param name="fileName">文件名称，如：001.csv</param>
        /// <returns>返回DataTable</returns>
        public static DataTable GetCsvDataTable(string filePath, string fileName)
        {
            string strConn = @"Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=";
            strConn += filePath;//这个地方只需要目录就可以了
            strConn += ";Extensions=asc,csv,tab,txt;";
            OdbcConnection objConn = new OdbcConnection(strConn);
            try
            {
                string strSQL = "select * from " + fileName;//文件名，不要带目录
                OdbcDataAdapter da = new OdbcDataAdapter(strSQL, objConn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
