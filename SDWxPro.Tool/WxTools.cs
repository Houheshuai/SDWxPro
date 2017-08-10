using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SDWxPro.Tool
{
    /// <summary>
    /// 微信工具类
    /// </summary>
    public class WxTools
    {
        #region 获取Json字符串某节点的值
        /// <summary>
        /// 获取Json字符串某节点的值
        /// </summary>
        public static string GetJsonValue(string jsonStr, string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(jsonStr))
            {
                key = "\"" + key.Trim('"') + "\"";
                int index = jsonStr.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值
                    int end = jsonStr.IndexOf(',', index);
                    if (end == -1)
                    {
                        end = jsonStr.IndexOf('}', index);
                    }

                    result = jsonStr.Substring(index, end - index);
                    result = result.Trim(new char[] { '"', ' ', '\'' }); //过滤引号或空格
                }
            }
            return result;
        }
        #endregion

        #region
        /// <summary>
        /// 判断是否是在微信浏览器
        /// </summary>
        /// <returns>确认返回true</returns>
        public static bool OnlyWeiXinLook()
        {
            bool res = true;
            String userAgent = HttpContext.Current.Request.UserAgent;
            if (userAgent.IndexOf("MicroMessenger") <= -1)
            {
                res = false;
            }
            return res;
        }
        #endregion
    }
}
