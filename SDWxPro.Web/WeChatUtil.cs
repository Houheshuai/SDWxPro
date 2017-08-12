using SDWxPro.Model;
using SDWxPro.Service;
using SDWxPro.Tool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SDWxPro.Web
{
    public class WeChatUtil
    {
        public static string PostWebRequest(string postUrl, string menuInfo)
        {
            string returnValue = string.Empty;
            try
            {
                byte[] byteData = Encoding.UTF8.GetBytes(menuInfo);
                Uri uri = new Uri(postUrl);
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(uri);
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = byteData.Length;
                //定义Stream信息
                Stream stream = webReq.GetRequestStream();
                stream.Write(byteData, 0, byteData.Length);
                stream.Close();
                //获取返回信息
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                returnValue = streamReader.ReadToEnd();
                //关闭信息
                streamReader.Close();
                response.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                //lblResult.Text = ex.ToString();
            }
            return returnValue;
        }

        #region 获取access_token
        /// <summary>
        /// 获取access_token
        /// </summary>
        public static string GetAccessToken(int ssid, string WxAppId, string WxAppSecret)
        {
            string access_token = string.Empty;
            SysSetting ss = SysSettingService.GetSysSettingById(ssid);
            if (ss != null)
            {
                WriteLog("oooo");
                if (string.IsNullOrEmpty(ss.WxTokenKey)) //尚未保存过access_token
                {
                    WriteLog(WxAppId);
                    WriteLog(WxAppSecret);
                    access_token = WxApi.GetToken(WxAppId, WxAppSecret);
                    WriteLog(access_token);
                }
                else
                {
                    if (WxApi.TokenExpired(ss.WxTokenKey)) //access_token过期
                    {
                        access_token = WxApi.GetToken(WxAppId, WxAppSecret);
                    }
                    else
                    {
                        access_token = ss.WxTokenKey;
                    }
                    //WriteLog("pppp");
                    //access_token = WxApi.GetToken(WxAppId, WxAppSecret);

                    
                }
                ss.WxTokenKey = access_token;
                SysSettingService.ModifySysSetting(ss);
            }
            return access_token;
        }
        #endregion



        public static void WriteLog(string tes)
        {
            using (FileStream fs = new FileStream(HttpContext.Current.Request.MapPath("~") + "log.txt", FileMode.Append, FileAccess.Write))
            {
                var byteStr = System.Text.Encoding.UTF8.GetBytes(tes + "\r\n");
                fs.Write(byteStr, 0, byteStr.Length);
            }
        }

    }
}