using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SDWxPro.Tool
{
    public class ImgItemDal
    {
        /// <summary>
        /// 拼接图文消息素材Json字符串
        /// </summary>
        public static string GetArticlesJsonStr(string access_token, DataTable dt)
        {
            StringBuilder sbArticlesJson = new StringBuilder();

            sbArticlesJson.Append("{\"articles\":[");
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("/" + dr["Pic"].ToString());
                if (!File.Exists(path))
                {
                    return "{\"code\":0,\"msg\":\"要发送的图片不存在\"}";
                }
                string msg = WxApi.UploadMedia(access_token, "image", path); // 上图片返回媒体ID
                string media_id = WxTools.GetJsonValue(msg, "media_id");
                sbArticlesJson.Append("{");
                sbArticlesJson.Append("\"thumb_media_id\":\"" + media_id + "\",");
                sbArticlesJson.Append("\"author\":\"" + dr["Author"].ToString() + "\",");
                sbArticlesJson.Append("\"title\":\"" + dr["Name"].ToString() + "\",");
                sbArticlesJson.Append("\"content_source_url\":\"" + dr["Url"].ToString() + "\",");
                sbArticlesJson.Append("\"content\":\"" + HandleString.Replaces(dr["Contents"].ToString()) + "\",");
                sbArticlesJson.Append("\"digest\":\"" + HandleString.Replaces(dr["Description"].ToString()) + "\",");
                if (i == dt.Rows.Count - 1)
                {
                    sbArticlesJson.Append("\"show_cover_pic\":\"" + Security.ToNum(dr["ShowCoverPic"].ToString()) + "\"}");
                }
                else
                {
                    sbArticlesJson.Append("\"show_cover_pic\":\"" + Security.ToNum(dr["ShowCoverPic"].ToString()) + "\"},");
                }
                i++;
            }
            sbArticlesJson.Append("]}");

            return sbArticlesJson.ToString();
        }

        /// <summary>
        /// 上传图文消息素材返回media_id
        /// </summary>
        public static string UploadNews(string access_token, string postData)
        {
            return HttpRequestUtil.PostUrl(string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}", access_token), postData);
        }
    }
}
