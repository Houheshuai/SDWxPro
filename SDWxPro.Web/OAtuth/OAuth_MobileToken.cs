using SDWxPro.Tool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SDWxPro.Web.OAtuth
{
    public class OAuth_MobileToken
    {
        public static OAuthonUserMobile GetUser(string token, string openid)
        {
            //获取微信回传的openid、access token
            string Str = GetJson("https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + token + "&openid=" + openid + "&lang=zh_CN");

            OAuthonUserMobile OAuthUser_Model = new OAuthonUserMobile();
            //微信回传的数据为Json格式，将Json格式转化成对象
            OAuthUser_Model = JsonHelper.ParseFromJson<OAuthonUserMobile>(Str);
            string subid = Str.Substring(13, 1);
            OAuthUser_Model.Subscribe = Security.ToNum(subid);
            return OAuthUser_Model;
        }

        /// <summary>
        /// 记录bug，以便调试
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool WriteTxt(string str)
        {
            try
            {
                FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("/bugLog.txt"), FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.WriteLine(str);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //访问微信url并返回微信信息
        public static string GetJson(string url)
        {
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            string returnText = wc.DownloadString(url);

            if (returnText.Contains("errcode"))
            {
                //可能发生错误
            }
            return returnText;
        }

    }
}