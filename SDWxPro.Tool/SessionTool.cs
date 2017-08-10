using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SDWxPro.Tool
{
    /// <summary>
    /// Session 工具类
    /// </summary>
    public class SessionTool
    {
        /// <summary>
        /// 存值，键值对形式存取
        /// </summary>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public static void Add(string Key, string Value)
        {
            HttpContext.Current.Session[Key] = Value;
        }

        /// <summary>
        /// 删除，根据键来删除
        /// </summary>
        /// <param name="Key">键</param>
        public static void Delete(string Key)
        {
            HttpContext.Current.Session[Key] = "";
        }

        /// <summary>
        /// 判断是否有Session
        /// </summary>
        /// <param name="Key">键</param>
        /// <returns>返回是或否</returns>
        public static bool Exists(string Key)
        {
            bool flag2;
            try
            {
                bool flag = true;
                if ((HttpContext.Current.Session[Key] == null) || (HttpContext.Current.Session[Key].ToString() == ""))
                {
                    flag = false;
                }
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw new Exception(Key + " " + exception.Message);
            }
            return flag2;
        }

        /// <summary>
        /// 根据键取值
        /// </summary>
        /// <param name="Key">键</param>
        /// <returns>返回读取到的值</returns>
        public static string Read(string Key)
        {
            if (Exists(Key))
            {
                return HttpContext.Current.Session[Key].ToString();
            }
            return "";
        }

        /// <summary>
        /// 取出所有 Session
        /// </summary>
        /// <returns>返回读取到的所有Session</returns>
        public static string ReadAll()
        {
            string str = "";
            for (int i = 0; i < HttpContext.Current.Session.Keys.Count; i++)
            {
                str = str + "Key:" + HttpContext.Current.Session.Keys[i] + "|";
            }
            return str;
        }


    }
}
