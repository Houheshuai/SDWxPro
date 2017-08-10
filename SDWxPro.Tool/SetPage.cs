using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;

namespace SDWxPro.Tool
{
    /// <summary>
    /// 页面匹配关键字
    /// </summary>
    public class SetPage
    {
        /// <summary>
        /// 返回页面信息
        /// </summary>
        /// <param name="filePath">存储页面信息的文件路径</param>
        /// <param name="webPageType">页面类型</param>
        /// <param name="pageInfoType">页面信息类型</param>
        /// <param name="defValue">默认值</param>
        /// <returns></returns>
        public static string ReturnPageInfo(string filename, Enums.PageInfo nodename, string defValue, string title, string cname, string search)
        {
            string rtv = defValue;
            try
            {
                string filePath = ConfigHelper.GetConfigPathName(Enums.ConfigFile.PageInfo);

                XmlDocument xmldoc = XmlHelper.GetXMLDocument(filePath);
                XmlNodeList nodeList = xmldoc.LastChild.ChildNodes;

                foreach (XmlNode node in nodeList)
                {
                    if (string.IsNullOrEmpty(filename))
                    {
                        filename = GetFilename(HttpContext.Current.Request.FilePath);
                    }
                    XmlNode pattrenNode = node.SelectSingleNode("filename");        //根据文件名匹配
                    if (!filename.ToLower().Contains(".aspx"))
                    {
                        filename += ".aspx";
                    }
                    if (pattrenNode.InnerText.ToLower() == filename.ToLower())
                    {
                        XmlNode subNode = node.SelectSingleNode(nodename.ToString().ToLower());  //获取页面信息
                        if (node.SelectSingleNode("available").InnerText.ToLower() == "true")
                        {
                            string[] tagArray = { "{title}", "{cname}", "{search}" };
                            string[] valueArray = { title, cname, search };
                            string defvalue = node.SelectSingleNode("defaultvalue").InnerText;
                            rtv = string.IsNullOrEmpty(subNode.InnerText) ? defValue : ReplaceTag(subNode.InnerText, tagArray, valueArray, defvalue);  //页面信息为空,则返回默认信息
                        }
                        break;
                    }
                }
            }
            catch
            {
                ;
            }
            return rtv;
        }

        public static string ReturnPageInfo(Enums.PageInfo nodename, string defValue, string title, string cname, string search)
        {
            return ReturnPageInfo("", nodename, defValue, title, cname, search);
        }

        public static string ReturnPageInfo(string filename, Enums.PageInfo nodename, string defValue)
        {
            return ReturnPageInfo(filename, nodename, defValue, "", "", "");
        }

        public static string ReturnPageInfo(Enums.PageInfo nodename, string defValue)
        {
            return ReturnPageInfo("", nodename, defValue);
        }

        /// <summary>
        /// 返回URL中结尾的文件名
        /// </summary>		
        public static string GetFilename(string url)
        {
            if (url == null)
            {
                return "";
            }
            string[] strs1 = url.Split(new char[] { '\\', '/' });
            return strs1[strs1.Length - 1].Split(new char[] { '?' })[0];
        }

        public static string GetFilename(string url, bool withParam)
        {
            if (withParam)
            {
                return System.IO.Path.GetFileName(url);
            }
            else
            {
                return GetFilename(url);
            }
        }

        public static string ReplaceTag(string strContent, string[] tagArray, string[] valueArray, string defValue)
        {
            if (tagArray != null)
            {
                int len = ReturnSmallInt(tagArray.Length, valueArray.Length);
                for (int i = 0; i < len; i++)
                {
                    strContent = strContent.Replace(tagArray[i], string.IsNullOrEmpty(valueArray[i]) ? defValue : valueArray[i]);
                }
            }
            return strContent;
        }

        public static int ReturnSmallInt(params int[] number)
        {
            if (number.Length > 1)
            {
                List<int> list = new List<int>();
                list.AddRange(number);
                list.Sort();
                return list[0];
            }
            return number[0];
        }
    }
}
