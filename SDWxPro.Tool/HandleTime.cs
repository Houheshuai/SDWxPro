using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SDWxPro.Tool
{
    /// <summary>
    /// 处理时间
    /// 格式转换、比较、相差数
    /// </summary>
    public class HandleTime
    {
        /// <summary>
        /// 返回相差的时间
        /// </summary>
        /// <param name="unit">类型：year，month，day，hour，minute，second</param>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>相差数量</returns>
        public static int DateDiff(string unit, DateTime startDate, DateTime endDate)
        {
            int num = 0;
            int num2 = endDate.Year - startDate.Year;
            int num3 = endDate.Month - startDate.Month;
            int num4 = endDate.Day - startDate.Day;
            int num5 = endDate.Hour - startDate.Hour;
            int num6 = endDate.Minute - startDate.Minute;
            int second = endDate.Second;
            int num7 = startDate.Second;

            TimeSpan ts = new TimeSpan();
            ts = endDate - startDate;

            if (unit == "year")
            {
                num = num2;
            }
            if (unit == "month")
            {
                num = (num2 * 12) + num3;
            }
            if (unit == "day")
            {
                num = (int)ts.TotalDays;
            }
            if (unit == "hour")
            {
                num = (int)ts.TotalHours;
            }
            if (unit == "minute")
            {
                num = (int)ts.TotalMinutes;
            }
            if (unit == "second")
            {
                num = (int)ts.TotalSeconds;
            }
            return num;
        }

        /// <summary>
        /// 返回多少分钟后的时间
        /// </summary>
        /// <param name="times">多少钟</param>
        /// <returns>string</returns>
        public static string AdDeTime(int times)
        {
            return (DateTime.Now).AddMinutes(times).ToString();
        }

        /// <summary>
        /// 中文日期转换成英文日期
        /// </summary>
        /// <param name="dtStr">要转换的日期</param>
        /// <returns>转换的结果</returns>
        public static string ConvertTimeToEn(string dtStr)
        {
            string str = Convert.ToDateTime(dtStr).ToString("yyyy年MM月dd日");
            DateTime dt = Convert.ToDateTime(str);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            string res = dt.ToString("D");
            res = res.Replace("January", "Jan").Replace("February", "Feb").Replace("March", "Mar").Replace("April", "Apr").Replace("June", "Jun").Replace("July", "Jul").Replace("August", "Aug").Replace("September", "Sep").Replace("October", "Oct").Replace("November", "Nov").Replace("December", "Dec");
            return res;
        }

        /// <summary>
        /// 根据时间来命名文件
        /// </summary>
        /// <returns>文件名</returns>
        public static string GetDataTimeRandomFileName()
        {
            Random random = new Random(0x3e8);
            return (DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + random.Next().ToString());
        }

        /// <summary>
        /// 根据日期输出星期几
        /// </summary>
        /// <param name="AllTime">要处理的时候</param>
        /// <returns>返回星期几</returns>
        public static string Week(DateTime AllTime)
        {
            string[] weekdays = { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
            string week = weekdays[Convert.ToInt32(AllTime.DayOfWeek)];

            return week;
        }

    }
}
