using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace SDWxPro.Tool
{
    /// <summary>
    /// 类型转换类
    /// 类型互转
    /// </summary>
    public class Security
    {
        /// <summary>
        /// 输出千分位
        /// </summary>
        /// <param name="jine">金额</param>
        /// <returns>返回处理好的字符串</returns>
        public static string ToQianfenWei(decimal jine)
        {
            try
            {
                string str = Math.Floor(jine).ToString();

                string ret = "";

                while (str.Length > 3)
                {
                    if (ret == "")
                    {
                        ret = str.Substring(str.Length - 3, 3);
                    }
                    else
                    {
                        ret = str.Substring(str.Length - 3, 3) + "," + ret;
                    }
                    str = str.Substring(0, str.Length - 3);
                }
                if (str.Length > 0)
                {
                    if (ret == "")
                    {
                        ret = str;
                    }
                    else
                    {
                        ret = str + "," + ret;
                    }
                }
                return ret;

            }
            catch
            {
                return jine.ToString();
            }
        }


        /// <summary>
        /// 将输入对象转换为长整形
        /// </summary>
        /// <param name="iObject">要转换的值</param>
        /// <returns>32位整形值</returns>
        public static Int32 ToNum(object iObject)
        {
            try
            {
                return Convert.ToInt32(iObject);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 取得字符型数据
        /// </summary>
        /// <param name="sObject">要转换的值</param>
        /// <returns>字符串型</returns>
        public static String ToStr(object sObject)
        {
            try
            {
                //字符串转换之前判断是否被注入，并且清理注入信息
                string s1 = "";
                int i1 = 0;
                string s2 = "";
                int i2 = 0;
                string content = Convert.ToString(sObject).Trim();

                i1 = content.IndexOf("<script");
                i2 = content.LastIndexOf("</script>");
                if (i1 > 1)
                {
                    s1 = content.Substring(i1, i2);

                    s2 = content.Replace(s1, "");
                }
                else
                {
                    s2 = content;
                }
                return s2;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 取双精度型数据
        /// </summary>
        /// <param name="dObject">要转换的值</param>
        /// <returns>双精度浮点型</returns>
        public static Double ToDouble(object dObject)
        {
            try
            {
                return Convert.ToDouble(dObject);
            }
            catch
            {
                return (double)0.0;
            }
        }
        /// <summary>
        /// 取浮点型数据
        /// </summary>
        /// <param name="fObject">要转换的值</param>
        /// <returns>返回浮点类型</returns>
        public static float ToFloat(object fObject)
        {
            try
            {
                return Convert.ToSingle(fObject);
            }
            catch
            {
                return (float)0.0;
            }
        }
        /// <summary>
        /// 取固定长度精度浮点型的数据
        /// </summary>
        /// <param name="iValue">要转换的值</param>
        /// <returns>返回精确值类型</returns>
        public static Decimal ToDecimal(object iValue)
        {
            try
            {
                return  Math.Round(Convert.ToDecimal(iValue), 2);
            }
            catch
            {
                return (decimal)0.0;
            }
        }
        /// <summary>
        /// 取布尔型的数据
        /// </summary>
        /// <param name="iValue">要转换的值</param>
        /// <returns>返回是否</returns>
        public static bool ToBool(object iValue)
        {
            try
            {
                return Convert.ToBoolean(iValue);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 取时间型的数据
        /// </summary>
        /// <param name="sValue">要转换的值</param>
        /// <returns>返回时间类型</returns>
        public static DateTime ToDateTime(object sValue)
        {
            try
            {
                if (sValue == null)
                {
                    return System.DateTime.Now;
                }
                else
                {
                    return Convert.ToDateTime(sValue);
                }
            }
            catch
            {
                return System.DateTime.Now;
            }
        }

        /// <summary>
        /// 返回年月日
        /// </summary>
        /// <param name="sValue">要转换的值</param>
        /// <param name="partition">间隔字符，一般以"-"、"."、" " 隔开</param>
        /// <returns>返回转换后的YMD格式</returns>
        public static string ToYMD(object sValue, string partition)
        {
            try
            {
                DateTime Timess = Convert.ToDateTime(sValue);
                return Timess.Year.ToString() + partition + Timess.Month.ToString().PadLeft(2, '0') + partition + Timess.Day.ToString().PadLeft(2, '0') + "";
            }
            catch
            {
                DateTime Timessz = System.DateTime.Now;
                return Timessz.Year.ToString() + partition + Timessz.Month.ToString().PadLeft(2, '0') + partition + Timessz.Day.ToString().PadLeft(2, '0') + "";
            }
        }

        /// <summary>
        /// 返回yyyy/mm/dd hh:mm
        /// </summary>
        /// <param name="sValue">要转换的值</param>
        /// <returns>返回转换到分钟的格式</returns>
        public static string ToYMDHM(object sValue)
        {
            try
            {
                DateTime Timess = Convert.ToDateTime(sValue);
                return Timess.Year.ToString() + "/" + string.Format("{0:D2}", Timess.Month) + "/" + string.Format("{0:D2}", Timess.Day) + " " + string.Format("{0:D2}", Timess.Hour) + ":" + string.Format("{0:D2}", Timess.Minute);
            }
            catch
            {
                DateTime Timessz = System.DateTime.Now;
                return Timessz.Year.ToString() + "/" + Timessz.Month.ToString() + "/" + Timessz.Day.ToString() + " " + Timessz.Hour.ToString() + ":" + Timessz.Minute.ToString();
            }
        }

        /// <summary>
        /// 返回yyyy/mm/dd hh:mm:ss
        /// </summary>
        /// <param name="sValue">要转换的值</param>
        /// <returns>返回转换到秒的格式</returns>
        public static string Toriqi(object sValue)
        {
            try
            {
                DateTime Timess = Convert.ToDateTime(sValue);
                return Timess.Year.ToString() + "/" + Timess.Month.ToString() + "/" + Timess.Day.ToString() + " " + Timess.Hour.ToString() + ":" + Timess.Minute.ToString() + ":" + Timess.Second.ToString();
            }
            catch
            {
                DateTime Timess = System.DateTime.Now;
                return Timess.Year.ToString() + "/" + Timess.Month.ToString() + "/" + Timess.Day.ToString() + " " + Timess.Hour.ToString() + ":" + Timess.Minute.ToString() + ":" + Timess.Second.ToString();
            }
        }

        /// <summary>
        /// 将对象转换成字节型
        /// </summary>
        /// <param name="iValue">要转换的值</param>
        /// <returns>返回字节型</returns>
        public static byte ToByte(object iValue)
        {
            try
            {
                return Convert.ToByte(iValue);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 将对象转换成长整型
        /// </summary>
        /// <param name="iValue">要转换的值</param>
        /// <returns>返回长整型</returns>
        public static long ToLong(object iValue)
        {
            try
            {
                return Convert.ToInt64(iValue);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 将全角数字转换为数字
        /// </summary>
        /// <param name="SBCCase">要转换的值</param>
        /// <returns>返回转换好的数字</returns>
        public static string SBCCaseToNumberic(string SBCCase)
        {
            char[] c = SBCCase.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            return new string(c);
        }

    }

}
