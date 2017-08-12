using SDWxPro.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDWxPro.Service
{
    public static partial class ProcedureService
    {
        public static DataTable GetDataTableProce(string TableName, string ReFieldsStr, string OrderString, string WhereString, Int32 PageSize, Int32 PageIndex, out Int32 TotalRecord)
        {
            StringBuilder strSqlString = new StringBuilder("Proce_Page");
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@TableName",DbType.String),
                new SqlParameter("@ReFieldsStr",DbType.String),                
                new SqlParameter("@OrderString",DbType.String),
                new SqlParameter("@WhereString",DbType.String),
                new SqlParameter("@PageSize",DbType.Int32),
                new SqlParameter("@PageIndex",DbType.Int32),
                new SqlParameter("@TotalRecord",DbType.Int32)
            };
            param[0].Value = TableName;
            param[1].Value = ReFieldsStr;
            param[2].Value = OrderString;
            param[3].Value = WhereString;
            param[4].Value = PageSize;
            param[5].Value = PageIndex;
            param[6].Direction = ParameterDirection.Output;
            DataTable dt = DBHelper.GetDataTable(CommandType.StoredProcedure, strSqlString.ToString(), param);
            TotalRecord = SDWxPro.Tool.Security.ToNum(param[6].Value);
            return dt;
        }

        public static DataTable GetSearchProce(string WhereString, Int32 PageSize, Int32 PageIndex, out Int32 TotalRecord)
        {
            StringBuilder strSqlString = new StringBuilder("Proce_Search");
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@WhereStr",DbType.String),
                new SqlParameter("@PageSize",DbType.Int32),
                new SqlParameter("@PageIndex",DbType.Int32),
                new SqlParameter("@TotalRecord",DbType.Int32)
            };
            param[0].Value = WhereString;
            param[1].Value = PageSize;
            param[2].Value = PageIndex;
            param[3].Direction = ParameterDirection.Output;
            DataTable dt = DBHelper.GetDataTable(CommandType.StoredProcedure, strSqlString.ToString(), param);
            TotalRecord = Security.ToNum(param[3].Value);
            return dt;
        }

        public static DataTable GetSysInfoProce(out Int32 TodayNum, out Int32 WeekNum, out Int32 MonthNum, out Int32 SumNum, out Int32 PadNum, out Int32 PcNum, out Int32 FromNum1, out Int32 FromNum2, out Int32 FromNum3, out Int32 ProSumClick, out Int32 NewsSumClick)
        {
            StringBuilder strSqlString = new StringBuilder("GetVisitLog");
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@TodayNum",DbType.Int32),
                new SqlParameter("@WeekNum",DbType.Int32),                
                new SqlParameter("@MonthNum",DbType.Int32),
                new SqlParameter("@SumNum",DbType.Int32),
                new SqlParameter("@PadNum",DbType.Int32),
                new SqlParameter("@PcNum",DbType.Int32),
                new SqlParameter("@FromNum1",DbType.Int32),
                new SqlParameter("@FromNum2",DbType.Int32),
                new SqlParameter("@FromNum3",DbType.Int32),
                new SqlParameter("@ProSumClick",DbType.Int32),
                new SqlParameter("@NewsSumClick",DbType.Int32)
            };
            param[0].Direction = ParameterDirection.Output;
            param[1].Direction = ParameterDirection.Output;
            param[2].Direction = ParameterDirection.Output;
            param[3].Direction = ParameterDirection.Output;
            param[4].Direction = ParameterDirection.Output;
            param[5].Direction = ParameterDirection.Output;
            param[6].Direction = ParameterDirection.Output;
            param[7].Direction = ParameterDirection.Output;
            param[8].Direction = ParameterDirection.Output;
            param[9].Direction = ParameterDirection.Output;
            param[10].Direction = ParameterDirection.Output;
            DataTable dt = DBHelper.GetDataTable(CommandType.StoredProcedure, strSqlString.ToString(), param);
            TodayNum = Security.ToNum(param[0].Value);
            WeekNum = Security.ToNum(param[1].Value);
            MonthNum = Security.ToNum(param[2].Value);
            SumNum = Security.ToNum(param[3].Value);
            PadNum = Security.ToNum(param[4].Value);
            PcNum = Security.ToNum(param[5].Value);
            FromNum1 = Security.ToNum(param[6].Value);
            FromNum2 = Security.ToNum(param[7].Value);
            FromNum3 = Security.ToNum(param[8].Value);
            ProSumClick = Security.ToNum(param[9].Value);
            NewsSumClick = Security.ToNum(param[10].Value);
            return dt;
        }

        public static DataTable GetSysInfoProceZst(out Int32 PvNum1, out Int32 PvNum2, out Int32 PvNum3, out Int32 PvNum4, out Int32 PvNum5, out Int32 PvNum6, out Int32 PvNum7, out Int32 PvNum8, out Int32 PvNum9, out Int32 PvNum10, out Int32 OnlineNum1, out Int32 OnlineNum2, out Int32 OnlineNum3, out Int32 OnlineNum4, out Int32 OnlineNum5, out Int32 OnlineNum6, out Int32 OnlineNum7, out Int32 OnlineNum8, out Int32 OnlineNum9, out Int32 OnlineNum10)
        {
            StringBuilder strSqlString = new StringBuilder("GetVisitLogZst");
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@PvNum1",DbType.Int32),
                new SqlParameter("@PvNum2",DbType.Int32),
                new SqlParameter("@PvNum3",DbType.Int32),
                new SqlParameter("@PvNum4",DbType.Int32),
                new SqlParameter("@PvNum5",DbType.Int32),
                new SqlParameter("@PvNum6",DbType.Int32),
                new SqlParameter("@PvNum7",DbType.Int32),
                new SqlParameter("@PvNum8",DbType.Int32),
                new SqlParameter("@PvNum9",DbType.Int32),
                new SqlParameter("@PvNum10",DbType.Int32),
                new SqlParameter("@OnlineNum1",DbType.Int32),
                new SqlParameter("@OnlineNum2",DbType.Int32),
                new SqlParameter("@OnlineNum3",DbType.Int32),
                new SqlParameter("@OnlineNum4",DbType.Int32),
                new SqlParameter("@OnlineNum5",DbType.Int32),
                new SqlParameter("@OnlineNum6",DbType.Int32),
                new SqlParameter("@OnlineNum7",DbType.Int32),
                new SqlParameter("@OnlineNum8",DbType.Int32),
                new SqlParameter("@OnlineNum9",DbType.Int32),
                new SqlParameter("@OnlineNum10",DbType.Int32)
            };
            param[0].Direction = ParameterDirection.Output;
            param[1].Direction = ParameterDirection.Output;
            param[2].Direction = ParameterDirection.Output;
            param[3].Direction = ParameterDirection.Output;
            param[4].Direction = ParameterDirection.Output;
            param[5].Direction = ParameterDirection.Output;
            param[6].Direction = ParameterDirection.Output;
            param[7].Direction = ParameterDirection.Output;
            param[8].Direction = ParameterDirection.Output;
            param[9].Direction = ParameterDirection.Output;
            param[10].Direction = ParameterDirection.Output;
            param[11].Direction = ParameterDirection.Output;
            param[12].Direction = ParameterDirection.Output;
            param[13].Direction = ParameterDirection.Output;
            param[14].Direction = ParameterDirection.Output;
            param[15].Direction = ParameterDirection.Output;
            param[16].Direction = ParameterDirection.Output;
            param[17].Direction = ParameterDirection.Output;
            param[18].Direction = ParameterDirection.Output;
            param[19].Direction = ParameterDirection.Output;
            DataTable dt = DBHelper.GetDataTable(CommandType.StoredProcedure, strSqlString.ToString(), param);

            PvNum1 = Security.ToNum(param[0].Value);
            PvNum2 = Security.ToNum(param[1].Value);
            PvNum3 = Security.ToNum(param[2].Value);
            PvNum4 = Security.ToNum(param[3].Value);
            PvNum5 = Security.ToNum(param[4].Value);
            PvNum6 = Security.ToNum(param[5].Value);
            PvNum7 = Security.ToNum(param[6].Value);
            PvNum8 = Security.ToNum(param[7].Value);
            PvNum9 = Security.ToNum(param[8].Value);
            PvNum10 = Security.ToNum(param[9].Value);
            OnlineNum1 = Security.ToNum(param[10].Value);
            OnlineNum2 = Security.ToNum(param[11].Value);
            OnlineNum3 = Security.ToNum(param[12].Value);
            OnlineNum4 = Security.ToNum(param[13].Value);
            OnlineNum5 = Security.ToNum(param[14].Value);
            OnlineNum6 = Security.ToNum(param[15].Value);
            OnlineNum7 = Security.ToNum(param[16].Value);
            OnlineNum8 = Security.ToNum(param[17].Value);
            OnlineNum9 = Security.ToNum(param[18].Value);
            OnlineNum10 = Security.ToNum(param[19].Value);
            return dt;
        }



    }
}
