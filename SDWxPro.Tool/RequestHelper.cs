using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;

namespace SDWxPro.Tool
{
    /// <summary>
    /// Request 工具获取类
    /// </summary>
    public class RequestHelper
    {
        #region Properties

        /// <summary>
        /// 指定参数名 POST
        /// </summary>
        public static readonly string POST = "POST";
        /// <summary>
        /// 指定参数名 POST
        /// </summary>
        public static readonly string GET = "GET";

        #endregion

        #region Methods
        /// <summary>
        /// 获取域名
        /// </summary>
        /// <returns>域名</returns>
        public static string GetDomainName()
        {
            string host = HttpContext.Current.Request.Url.Host;
            if (Regex.IsMatch(host, @"\w+\.\w+\.\w+"))
            {
                int idx = host.IndexOf(".");
                return host.Substring(idx);
            }
            return string.Empty;
        }

        /// <usmmary>
        /// 获取客户端Mac地址
        /// </usmmary>
        /// <param name="clientip">客户端IP</param>
        public static string GetMac(string clientip)
        {
            string mac = "";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            //线程类，可以启动关闭一些线程
            process.StartInfo.FileName = "netstat";
            //传递给启动线程名，命令为nbtstat
            //此命令为cmd命令，可以根据其进一步获取mac等地址
            process.StartInfo.Arguments = "-a " + clientip;
            //设置nbtstat的命令参数
            process.StartInfo.UseShellExecute = false;
            //不启动外壳启动线程
            process.StartInfo.CreateNoWindow = true;
            //在新窗口中启动
            process.StartInfo.RedirectStandardOutput = true;
            //将程序输入写入输出流
            process.Start();
            //启动
            string output = process.StandardOutput.ReadToEnd();
            //获取流并以从头读到尾的形式赋值与变量
            int length = output.IndexOf("MAC Address =");
            //获取字符串以MAC Address=为索引的项
            if (length > 0)
            {
                mac = output.Substring(length + 14, 17);
            }
            return mac;
        }

        /// <summary>
        /// 获取网站目录路径 
        /// </summary>
        /// <param name="type">1</param>
        /// <returns>路径地址</returns>
        public static string GetAppPath(int type)
        {
            if (type == 1)
            {
                return HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
            }
            string str2 = HttpContext.Current.Request.ServerVariables["path_translated"];
            return str2.Substring(0, str2.LastIndexOf(@"\") + 1);
        }

        /// <summary>
        /// 获取客户端Ip地址
        /// </summary>
        /// <returns>客户端Ip地址</returns>
        public static string GetClientIP()
        {
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
        }

        #region get parameter values from request.

        /// <summary>
        /// 在给定参数名称的请求中获取参数值
        /// </summary>
        /// <param name="param">参数名</param>
        /// <returns>返回参数值</returns>
        public static string GetParamValue(string param)
        {
            HttpRequest r = HttpContext.Current.Request;
            return GetParamValue(param, r.RequestType);
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="param">参数名称</param>
        /// <param name="requestType">类型 POST 或 GET</param>
        /// <returns>取值</returns>
        public static string GetParamValue(string param, string requestType)
        {
            HttpRequest r = HttpContext.Current.Request;
            switch (requestType.ToUpper())
            {
                case "POST":
                    return r.Form[param];
                case "GET":
                default:
                    return r.QueryString[param];
            }
        }

        /// <summary>
        /// 从参数值列表获取值
        /// </summary>
        /// <param name="param">参数名</param>
        /// <returns>返回获取到的列表</returns>
        public static string[] GetParamValues(string param)
        {
            HttpRequest r = HttpContext.Current.Request;
            return GetParamValues(param, r.RequestType);
        }

        /// <summary>
        /// 获取参数名称和请求类型的参数值列表。
        /// </summary>
        /// <param name="param">参数名称</param>
        /// <param name="requestType">类型 POST 或 GET</param>
        /// <returns>返回参数值数组</returns>
        public static string[] GetParamValues(string param, string requestType)
        {
            HttpRequest r = HttpContext.Current.Request;
            switch (requestType.ToUpper())
            {
                case "POST":
                    return r.Form.GetValues(param);
                case "GET":
                default:
                    return r.QueryString.GetValues(param);
            }
        }

        /// <summary>
        /// 在整数类型中获取参数值。如果该值不能被解析为整数，将返回0。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <returns>返回参数值</returns>
        public static int GetParamIntValue(string param)
        {
            HttpRequest r = HttpContext.Current.Request;
            return GetParamIntValue(param, r.RequestType);
        }

        /// <summary>
        /// 在整数类型中获取参数值。如果该值不能被解析为整数，将返回0。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <param name="requestType">类型 POST 或 GET</param>
        /// <returns>返回参数值</returns>
        public static int GetParamIntValue(string param, string requestType)
        {
            return GetParamIntValue(param, requestType, 0);
        }

        /// <summary>
        /// 在整数类型中获取参数值。如果该值不能被解析为整数，则将返回默认值。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <param name="requestType">类型 POST 或 GET</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>返回参数值</returns>
        public static int GetParamIntValue(string param, string requestType, int defaultValue)
        {
            int returnValue = 0;
            if (int.TryParse(GetParamValue(param, requestType), out returnValue))
            {
                return returnValue;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 在double类型中获取参数值。如果该值不能被解析为整数，将返回0。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <returns>返回参数值</returns>
        public static double GetParamDoubleValue(string param)
        {
            HttpRequest r = HttpContext.Current.Request;
            return GetParamDoubleValue(param, r.RequestType);
        }

        /// <summary>
        /// 在double类型中获取参数值。如果该值不能被解析为整数，将返回0。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <param name="requestType">类型 POST 或 GET</param>
        /// <returns>返回参数值</returns>
        public static double GetParamDoubleValue(string param, string requestType)
        {
            return GetParamDoubleValue(param, requestType, 0d);
        }

        /// <summary>
        /// 在double类型中获取参数值。如果该值不能被解析为整数，将返回0。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <param name="requestType">类型 POST 或 GET</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>返回参数值</returns>
        public static double GetParamDoubleValue(string param, string requestType, double defaultValue)
        {
            double returnValue = 0d;
            if (double.TryParse(GetParamValue(param, requestType), out returnValue))
            {
                return returnValue;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 在decimal类型中获取参数值。如果该值不能被解析为整数，将返回0。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <returns>返回参数值</returns>
        public static decimal GetParamDecimalValue(string param)
        {
            HttpRequest r = HttpContext.Current.Request;
            return GetParamDecimalValue(param, r.RequestType);
        }

        /// <summary>
        /// 在decimal类型中获取参数值。如果该值不能被解析为整数，将返回0。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <param name="requestType">类型 POST 或 GET</param>
        /// <returns>返回参数值</returns>
        public static decimal GetParamDecimalValue(string param, string requestType)
        {
            return GetParamDecimalValue(param, requestType, 0);
        }
        /// <summary>
        /// 在decimal类型中获取参数值。如果该值不能被解析为整数，将返回0。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <param name="requestType">类型 POST 或 GET</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>返回参数值</returns>
        public static decimal GetParamDecimalValue(string param, string requestType, decimal defaultValue)
        {
            decimal returnValue = 0;
            if (decimal.TryParse(GetParamValue(param, requestType), out returnValue))
            {
                return returnValue;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 在DateTime类型中获取参数值。如果这个值不能被解析为整数，就将返回当前时间。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <returns>返回参数值</returns>
        public static DateTime GetParamDateValue(string param)
        {
            HttpRequest r = HttpContext.Current.Request;
            return GetParamDateValue(param, r.RequestType);
        }
        /// <summary>
        /// 在DateTime类型中获取参数值。如果这个值不能被解析为整数，就将返回当前时间。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <param name="requestType">类型 POST 或 GET</param>
        /// <returns>返回参数值</returns>
        public static DateTime GetParamDateValue(string param, string requestType)
        {
            return GetParamDateValue(param, requestType, DateTime.Now);
        }
        /// <summary>
        /// 在DateTime类型中获取参数值。如果这个值不能被解析为整数，就将返回当前时间。
        /// </summary>
        /// <param name="param">参数名</param>
        /// <param name="requestType">类型 POST 或 GET</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>返回参数值</returns>
        public static DateTime GetParamDateValue(string param, string requestType, DateTime defaultValue)
        {
            DateTime returnValue = DateTime.MinValue;
            if (DateTime.TryParse(GetParamValue(param, requestType), out returnValue))
            {
                return returnValue;
            }
            else
            {
                return defaultValue;
            }
        }
        #endregion
        #endregion
    }
}
