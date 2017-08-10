using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SDWxPro.Tool
{
    public class FileOper
    {
        private string errMessage; //保存的错误信息

        public string ErrMessage
        {
            set
            {
                this.errMessage = value;
            }
            get
            {
                return this.errMessage;
            }
        }
        public FileOper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        /// <summary>
        /// 写文件操作,返回bool形数据
        /// </summary>
        /// <param name="fileDir">相对于根目录的文件路径，如update\</param>
        /// <param name="fileName">文件名，如temp.doc</param>
        /// <param name="txtStream">文本流，要输入的文本流信息</param>
        public bool writeOneFile(string fileDir, string fileName, string txtStream)
        {
            bool returnValue = true;
            string serverBasePath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];//服务器根目录
            string strDirPath = serverBasePath + fileDir;//文件夹路径
            //如果文件夹不存在,则创建一个
            if (!Directory.Exists(strDirPath))
            {
                Directory.CreateDirectory(strDirPath);
            }
            StreamWriter sw = null;
            string fullPath = strDirPath + fileName;//完整目录
            Encoding encod = Encoding.GetEncoding("gb2312");//设置编码
            try  //开始写文件
            {
                sw = new StreamWriter(fullPath, false, encod);
                sw.Write(txtStream);
                sw.Flush();
            }
            catch (Exception exp)
            {
                this.errMessage = exp.ToString();
                returnValue = false;
            }
            finally
            {
                sw.Close();
            }
            return returnValue;
        }
        /// <summary>
        /// 读文件操作,返回string数据
        /// </summary>
        /// <param name="fileDir">根目录下的文件路径，如update\</param>
        /// <param name="fileName">文件名，如temp.doc</param>
        public string readOneFile(string fileDir, string fileName)
        {
            string returnValue = "没有读取到数据";
            string serverBasePath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];//服务器根目录
            string fullPath = serverBasePath + fileDir + fileName;//完整目录
            Encoding encod = Encoding.GetEncoding("utf-8");//设置编码
            StreamReader sr = null;
            try  //读文件
            {
                if (ifHaveThisFile(fileDir + fileName))
                {
                    sr = new StreamReader(fullPath, encod);
                    returnValue = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception exp)
            {
                this.errMessage = exp.ToString();
                returnValue = returnValue + exp.ToString();
            }
            return returnValue;
        }
        /// <summary>
        /// 复制文件操作,返回bool形数据
        /// </summary>
        /// <param name="sourceFileFullPath">源文件完整路径</param>
        /// <param name="newFileFullPath">目的文件完整路径</param>
        public bool copyOneFile(string sourceFileFullPath, string newFileFullPath)
        {
            bool returnValue = false;
            string serverBasePath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];//服务器根目录
            try
            {
                if (ifHaveThisFile(sourceFileFullPath))
                {
                    File.Copy(serverBasePath + sourceFileFullPath, serverBasePath + newFileFullPath, true);
                    returnValue = true;
                }
            }
            catch (Exception exp)
            {
                this.errMessage = exp.ToString();
            }
            return returnValue;
        }
        /// <summary>
        /// 删除文件操作,返回bool形数据
        /// </summary>
        /// <param name="fileFullPath">所要删除的文件的相对路径（相对根目录）</param>
        public bool deleteOneFile(string filePath)
        {
            bool returnValue = true;
            try
            {
                string fullPath = HttpContext.Current.Server.MapPath(filePath);
                File.Delete(fullPath);
            }
            catch (Exception exp)
            {
                this.errMessage = exp.ToString();
                returnValue = false;
            }
            return returnValue;
        }
        /// <summary>
        /// 判断文件是否存在,返回bool形数据
        /// </summary>
        /// <param name="fileFullPath">文件完整路径</param>
        public bool ifHaveThisFile(string fileFullPath)
        {
            bool returnValue = false;
            string serverBasePath = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];//服务器根目录
            try
            {
                if (File.Exists(serverBasePath + fileFullPath))
                    returnValue = true;
            }
            catch (Exception exp)
            {
                this.errMessage = exp.ToString();
            }
            return returnValue;
        }

        ///   <summary>   
        ///   打开指定的文件   
        ///   </summary>   
        ///   <param   name="PathName">路径（相对路径）</param>   
        ///   <param   name="FileName">文件名（带扩展名）</param>   
        public void OpenFile(string PathName, string FileName)
        {
            try
            {
                string name = PathName + FileName;
                FileInfo aFile = new FileInfo(HttpContext.Current.Server.MapPath(name));
                string na = Path.GetFileName(name);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.BufferOutput = false;
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8));
                HttpContext.Current.Response.AddHeader("Content-Length", aFile.Length.ToString());
                HttpContext.Current.Response.WriteFile(name);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            catch (Exception exp)
            {
                this.errMessage = exp.ToString();
            }
        }
    }
}
