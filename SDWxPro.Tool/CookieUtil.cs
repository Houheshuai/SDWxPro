using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SDWxPro.Tool
{
    /// <summary>
    /// Cookie操作类
    /// </summary>
    public class CookieUtil
    {
        /// <summary>
        /// Cookie添加
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strMinute">存放时间</param>
        public static void Add(string strName, string strValue, int strMinute)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(DESCrypt.Crypt(strName));
                cookie.Expires = DateTime.Now.AddMinutes((double)strMinute);
                cookie.Value = DESCrypt.Crypt(strValue);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Cookie删除
        /// </summary>
        /// <param name="strName">名称</param>
        public static void Delete(string strName)
        {
            try
            {
                HttpCookie cookie = new HttpCookie(DESCrypt.Crypt(strName));
                cookie.Expires = DateTime.Now.AddDays(-1.0);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// 判断Cookie是否存在
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>是否存在</returns>
        public static bool Exists(string strName)
        {
            bool flag = false;
            if ((Read(strName) != null) && (Read(strName) != ""))
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 读取Cookie
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>值</returns>
        public static string Read(string strName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[DESCrypt.Crypt(strName)];
            if (cookie != null)
            {
                return DESCrypt.DeCrypt(cookie.Value);
            }
            return "";
        }

    }
}
