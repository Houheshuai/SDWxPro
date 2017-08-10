using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace SDWxPro.Tool
{
    /// <summary>
    /// XML操作
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// 将object序列化成Xml
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="obj">类型</param>
        public static void XmlSeria(string filePath, object obj)
        {
            IOHelper.FileExists(filePath, true);
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                System.Xml.Serialization.XmlSerializer xmlser = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                xmlser.Serialize(sw, obj);
                sw.Close();
            }
        }
        /// <summary>
        /// 将xml反序列化
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回反序列化后的对象</returns>
        public static object XmlDeSeria(string filePath, System.Type type)
        {
            if (IOHelper.FileExists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlser = new System.Xml.Serialization.XmlSerializer(type);
                    object obj = xmlser.Deserialize(sr);
                    sr.Close();
                    return obj;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取xml文档
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回XML结构</returns>
        public static XmlDocument GetXMLDocument(string path)
        {
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(path))
            {
                //throw new Exception("文件不存在");
                return null;
            }

            try
            {
                doc.Load(path);
            }
            catch
            {
                //throw new Exception(e.ToString());
                return null;
            }
            return doc;
        }
        /// <summary>
        /// 获取xml文档下name节点的值 只支持<key = "" value ="" >格式
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="name">节点Key</param>
        /// <returns>返回key对应值</returns>
        public static string GetXMLDocValue(string path, string name)
        {
            XmlDocument doc = GetXMLDocument(path);
            if (doc == null)
            {
                return string.Empty;
            }

            if (doc.HasChildNodes)
            {
                XmlNodeList root = doc.ChildNodes;

                if (root.Count > 1)
                {
                    throw new Exception("根目录下只容许有一个子节点！");
                }

                XmlNodeList children = root[0].ChildNodes;
                if (children.Count == 0)
                {
                    return string.Empty;
                }
                try
                {
                    foreach (XmlNode node in children)
                    {
                        if (node.Attributes["key"] != null && node.Attributes["key"].Value == name)
                        {
                            return node.Attributes["value"].Value;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("xml文档格式不正确，必须存在key和value!", e);
                }
                return string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 初始化XML文档
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="rootNodeName">节点名</param>
        /// <returns>返回初始化后的XML文档</returns>
        public static XmlDocument InitXmlDocument(string filepath, string rootNodeName)
        {
            XmlDocument doc = new XmlDocument();
            bool flag = IOHelper.FileExists(filepath, true);
            if (!flag)
            {
                try
                {
                    doc.AppendChild(doc.CreateNode(XmlNodeType.XmlDeclaration, "", ""));
                    doc.AppendChild(doc.CreateNode(XmlNodeType.Element, rootNodeName, ""));
                    doc.Save(filepath);
                }
                catch
                {
                    return null;
                }
            }
            return GetXMLDocument(filepath);
        }
    }
}
