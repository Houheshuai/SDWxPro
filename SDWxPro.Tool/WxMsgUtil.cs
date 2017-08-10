using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDWxPro.Tool
{
    /// <summary>
    /// Json消息拼接类
    /// </summary>
    public class WxMsgUtil
    {
        /// <summary>
        /// 按用户推送文本消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="openidList"></param>
        /// <returns></returns>
        public static string CreateTextJson(string data, List<string> openidList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"touser\":[");
            sb.Append(string.Join(",", openidList.ConvertAll<string>(a => "\"" + a + "\"").ToArray()));
            sb.Append("],");
            sb.Append("\"msgtype\":\"text\",");
            sb.Append("\"text\":{\"content\":\"" + data + "\"}");
            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 按用户推送图文消息
        /// </summary>
        public static string CreateNewsJson(string media_id, List<string> openidList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"touser\":[");
            sb.Append(string.Join(",", openidList.ConvertAll<string>(a => "\"" + a + "\"").ToArray()));
            sb.Append("],");
            sb.Append("\"msgtype\":\"mpnews\",");
            sb.Append("\"mpnews\":{\"media_id\":\"" + media_id + "\"}");
            sb.Append("}");
            return sb.ToString();
        }

        

        /// <summary>
        /// 按用户推送图片消息
        /// </summary>
        /// <param name="media_id"></param>
        /// <param name="openidList"></param>
        /// <returns></returns>
        public static string CreateImageJson(string media_id, List<string> openidList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"touser\":[");
            sb.Append(string.Join(",", openidList.ConvertAll<string>(a => "\"" + a + "\"").ToArray()));
            sb.Append("],");
            sb.Append("\"image\":{");
            sb.Append("\"media_id\":\"" + media_id + "\"");
            sb.Append("},");
            sb.Append("\"msgtype\":\"image\"");
            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 按用户推送语音消息
        /// </summary>
        /// <param name="media_id"></param>
        /// <param name="openidList"></param>
        /// <returns></returns>
        public static string CreateVoiceJson(string media_id, List<string> openidList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"touser\":[");
            sb.Append(string.Join(",", openidList.ConvertAll<string>(a => "\"" + a + "\"").ToArray()));
            sb.Append("],");
            sb.Append("\"voice\":{");
            sb.Append("\"media_id\":\"" + media_id + "\"");
            sb.Append("},");
            sb.Append("\"msgtype\":\"voice\"");
            sb.Append("}");
            return sb.ToString();
        }


        /// <summary>
        /// 按分组推送文本消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="openidList"></param>
        /// <returns></returns>
        public static string CreateTextJson_Group(string data, string groupstr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"filter\":{");
            sb.Append("\"is_to_all\":false, ");
            sb.Append("\"group_id\":\"" + groupstr + "\"");
            sb.Append("},");
            sb.Append("\"text\":{");
            sb.Append("\"content\":\"" + data + "\"");
            sb.Append("},");
            sb.Append("\"msgtype\":\"text\"");
            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 按分组推送图文消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="openidList"></param>
        /// <returns></returns>
        public static string CreateNewsJson_Group(string media_id, string groupstr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"filter\":{");
            sb.Append("\"is_to_all\":true, ");
            sb.Append("\"group_id\":\"" + groupstr + "\"");
            sb.Append("},");
            sb.Append("\"mpnews\":{");
            sb.Append("\"media_id\":\"" + media_id + "\"");
            sb.Append("},");
            sb.Append("\"msgtype\":\"mpnews\"");
            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 按分组推送语音消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="openidList"></param>
        /// <returns></returns>
        public static string CreateVoiceJson_Group(string media_id, string groupstr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"filter\":{");
            sb.Append("\"is_to_all\":true, ");
            sb.Append("\"group_id\":\"" + groupstr + "\"");
            sb.Append("},");
            sb.Append("\"voice\":{");
            sb.Append("\"media_id\":\"" + media_id + "\"");
            sb.Append("},");
            sb.Append("\"msgtype\":\"voice\"");
            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 按分组推送图片消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="openidList"></param>
        /// <returns></returns>
        public static string CreateImageJson_Group(string media_id, string groupstr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"filter\":{");
            sb.Append("\"is_to_all\":true, ");
            sb.Append("\"group_id\":\"" + groupstr + "\"");
            sb.Append("},");
            sb.Append("\"image\":{");
            sb.Append("\"media_id\":\"" + media_id + "\"");
            sb.Append("},");
            sb.Append("\"msgtype\":\"image\"");
            sb.Append("}");
            return sb.ToString();
        }
        /// <summary>
        /// 按分组推送视频消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="openidList"></param>
        /// <returns></returns>
        public static string CreateVideoJson_Group(string media_id, string groupstr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"filter\":{");
            sb.Append("\"is_to_all\":true, ");
            sb.Append("\"group_id\":\"" + groupstr + "\"");
            sb.Append("},");
            sb.Append("\"mpvideo\":{");
            sb.Append("\"media_id\":\"" + media_id + "\"");
            sb.Append("},");
            sb.Append("\"msgtype\":\"mpvideo\"");
            sb.Append("}");
            return sb.ToString();
        }
    }
}
