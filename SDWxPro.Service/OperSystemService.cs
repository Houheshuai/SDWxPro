using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDWxPro.Service
{
    public class OperSystemService
    {

        public static DataTable GetAllSystemTable()
        {
            string sql = " select name from sys.tables order by name asc ";
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

        public static DataTable GetTableInfo(string dbname, string table)
        {
            string sql = "SELECT TABLE_CATALOG, TABLE_NAME, COLUMN_NAME, ORDINAL_POSITION, COLUMN_DEFAULT, IS_NULLABLE, DATA_TYPE,  CHARACTER_MAXIMUM_LENGTH, CHARACTER_OCTET_LENGTH, COLLATION_NAME FROM " + dbname + ".INFORMATION_SCHEMA.COLUMNS AS COLUMNS_1 WHERE TABLE_NAME IN ('" + table + "')";
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
    }
}
