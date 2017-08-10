using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDWxPro.Tool
{
    /// <summary>
    /// 微信API
    /// </summary>
    public class WxApi
    {
        #region 验证Token是否过期
        /// <summary>
        /// 验证Token是否过期
        /// </summary>
        public static bool TokenExpired(string access_token)
        {
            string jsonStr = HttpRequestUtil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", access_token));
            //if (WxTools.GetJsonValue(jsonStr, "errcode") == "42001")
            //{
            //    return true;
            //}
            if (jsonStr.Contains("errcode"))
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }
        #endregion


        #region 获取Token
        /// <summary>
        /// 获取Token
        /// </summary>
        public static string GetToken(string appid, string secret)
        {
            string strJson = HttpRequestUtil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appid, secret));
            return WxTools.GetJsonValue(strJson, "access_token");
        }
        #endregion

        #region 获取用户详细信息+string GetUserDicMsg(string access_token, string openId)
        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public static string GetUserDicMsg(string access_token, string openId)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN",access_token
                , openId);
            return HttpRequestUtil.RequestUrl(url, "Get");
        } 
        #endregion


        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string UploadContent(string access_token, string msg,string openid)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", access_token);
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"touser\":\"");
            sb.Append(openid);
            sb.Append("\", \"msgtype\":\"text\", \"text\":{ \"content\":\"");
            sb.Append(msg);
            sb.Append("\"}}");

            return HttpRequestUtil.PostUrl(url,sb.ToString());

        
        }

        /// <summary>
        /// 上传媒体返回媒体ID
        /// </summary>
        public static string UploadMedia(string access_token, string type, string path)
        {
            // 设置参数
            string url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}", access_token, type);
            return HttpRequestUtil.HttpUploadFile(url, path);
        }

        /// <summary>
        /// 上传图文消息素材返回media_id
        /// </summary>
        public static string UploadNews(string access_token, string postData)
        {
            // 设置参数
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}", access_token);
            return HttpRequestUtil.PostUrl(url, postData);
        }

        /// <summary>
        /// 上传视频返回media_id
        /// </summary>
        public static string uploadvideo(string access_token,string path, string title,string description)
        {
            string media_id = UploadMedia(access_token, "video", path);//通过基础上传媒体接口得到mediaid path是视频的路径
            //拼接视频json
            string PostData=GetVideoJson(media_id,title,description);
            string url = string.Format("https://file.api.weixin.qq.com/cgi-bin/media/uploadvideo?access_token={0}", access_token);
            return HttpRequestUtil.PostUrl(url, PostData);

        }
        public static string GetVideoJson(string mediaid, string title, string description)
        {

            //string str = "{\"articles\":[{\"title\":";
            //str += "\"" + title + "\"";
            //str += ",";
            //str += "\"thumb_media_id\":\"" + mediaid + "\"";
            //str += ",";
            //str += "\"author\":\"" + author + "\"";
            //str += ",";
            //str += "\"digest\":\"" + disgest + "\"";
            //str += ",";
            //str += "\"show_cover_pic\":" + show_cover_pic + "";
            //str += ",";
            //str += "\"content\":\"" + content + "\"";
            //str += ",";
            //str += "\"content_source_url\":\"" + url + "\"";
            //str += "}]}";

            string str = "{\"media_id\":";
            str += "\"";
            str += mediaid;
            str += "\"";
            str += ",";
            str += "\"";
            str += "title";
            str += "\"";
            str += ":";
            str += "\"";
            str += title;
            str += "\"";
            str += ",";
            str += "\"";
            str += "description";
            str += "\"";
            str += ":";
            str += "\"";
            str += description;
            str += "\"}";
            return str;
        }
        /// <summary>
        /// 获取关注者OpenID集合
        /// </summary>
        public static List<string> GetOpenIDs(string access_token)
        {
            List<string> result = new List<string>();

            List<string> openidList = GetOpenIDs(access_token, null);
            result.AddRange(openidList);

            while (openidList.Count > 0)
            {
                openidList = GetOpenIDs(access_token, openidList[openidList.Count - 1]);
                result.AddRange(openidList);
            }

            return result;
        }

        /// <summary>
        /// 获取关注者OpenID集合
        /// </summary>
        public static List<string> GetOpenIDs(string access_token, string next_openid)
        {
            // 设置参数
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}", access_token, string.IsNullOrEmpty(next_openid) ? "" : next_openid);
            string returnStr = HttpRequestUtil.RequestUrl(url);
            int count = int.Parse(WxTools.GetJsonValue(returnStr, "count"));
            if (count > 0)
            {
                string startFlg = "\"openid\":[";
                int start = returnStr.IndexOf(startFlg) + startFlg.Length;
                int end = returnStr.IndexOf("]", start);
                string openids = returnStr.Substring(start, end - start).Replace("\"", "");
                return openids.Split(',').ToList<string>();
            }
            else
            {
                return new List<string>();
            }
        }


        /// <summary>
        /// 根据OpenID列表群发
        /// </summary>
        public static string Send(string access_token, string postData)
        {
            return HttpRequestUtil.PostUrl(string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}", access_token), postData);
        }


        /// <summary>
        /// 根据分组列表群发
        /// </summary>
        public static string SendGroup(string access_token, string postData)
        {
            //
            return HttpRequestUtil.PostUrl(string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}", access_token), postData);
        }

        /// <summary>
        /// 获取用户所有的分组
        /// </summary>
        /// <param name="acccess_token"></param>
        /// <returns></returns>
        public static string GetAllGroups(string acccess_token)
        {
            return HttpRequestUtil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}", acccess_token), "Get");
        }

        /// <summary>
        /// 根据分组发消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string SenMsgAccordingGroupId(string access_token, string msg)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", access_token);
            return HttpRequestUtil.PostUrl(url, msg);
        }
    }
}
