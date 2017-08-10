using System;
using System.Text;
using System.Web;
using System.Configuration;

namespace SDWxPro.Tool
{
    public class ConfigHelper
    {
        public static string GetConfigPathName(Enums.ConfigList list)
        {
            string relativePath = ConfigurationSettings.AppSettings[list.ToString()];
            return string.IsNullOrEmpty(relativePath)
                       ? string.Empty
                       : HttpRuntime.AppDomainAppPath + @"\" + relativePath;

        }

        public static string GetConfigPathName(Enums.ConfigFile config)
        {
            string relativePath = ConfigurationSettings.AppSettings[config.ToString()];
            return string.IsNullOrEmpty(relativePath)
                       ? string.Empty
                       : HttpRuntime.AppDomainAppPath + @"\" + relativePath;

        }

        public static string GetConfigKeyValue(Enums.ConfigList config, string key)
        {
            string path = GetConfigPathName(config);
            return XmlHelper.GetXMLDocValue(path, key);
        }


        #region 获取配置文件的AppSetting+string GetConfigAppSetting(string key)

        /// <summary>
        /// 获取配置文件的AppSetting
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigAppSetting(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return value.ToString();
            }
        } 
        #endregion
    }
}
