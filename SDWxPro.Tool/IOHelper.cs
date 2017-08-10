using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;

namespace SDWxPro.Tool
{
    /// <summary>
    /// IO操作
    /// </summary>
    public class IOHelper
    {
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="strArr">指定文件名</param>
        public static void DeleteFile(params string[] strArr)
        {
            foreach (string str in strArr)
            {
                if (File.Exists(str))
                {
                    System.IO.File.Delete(str);
                }
            }
        }

        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <param name="overwrite">当目标文件存在时是否覆盖</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
        {
            if (!System.IO.File.Exists(sourceFileName))
                throw new FileNotFoundException(sourceFileName + "文件不存在！");

            if (!overwrite && System.IO.File.Exists(destFileName))
                return false;

            try
            {
                System.IO.File.Copy(sourceFileName, destFileName, true);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName)
        {
            return BackupFile(sourceFileName, destFileName, true);
        }
        /// <summary>
        /// 恢复文件
        /// </summary>
        /// <param name="backupFileName">备份文件名</param>
        /// <param name="targetFileName">要恢复的文件名</param>
        /// <param name="backupTargetFileName">要恢复文件再次备份的名称,如果为null,则不再备份恢复文件</param>
        /// <returns>操作是否成功</returns>
        public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
        {
            try
            {
                if (!System.IO.File.Exists(backupFileName))
                    throw new FileNotFoundException(backupFileName + "文件不存在！");

                if (backupTargetFileName != null)
                {
                    if (!System.IO.File.Exists(targetFileName))
                        throw new FileNotFoundException(targetFileName + "文件不存在！无法备份此文件！");
                    else
                        System.IO.File.Copy(targetFileName, backupTargetFileName, true);
                }
                System.IO.File.Delete(targetFileName);
                System.IO.File.Copy(backupFileName, targetFileName);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
        /// <summary>
        /// 恢复文件
        /// </summary>
        /// <param name="backupFileName">备份文件名</param>
        /// <param name="targetFileName">恢复后的文件名</param>
        /// <returns>操作是否成功</returns>
        public static bool RestoreFile(string backupFileName, string targetFileName)
        {
            return RestoreFile(backupFileName, targetFileName, null);
        }
        /// <summary>
        /// 返回文件是否存在
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否存在</returns>
        public static bool FileExists(string filePath)
        {
            return System.IO.File.Exists(filePath);
        }
        /// <summary>
        /// 判断文件是否存在，不存在时，是否创建该文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="flag">缺省为false（不创建）</param>
        /// <returns>操作是否成功</returns>
        public static bool FileExists(string filePath, bool flag)
        {

            if (!System.IO.File.Exists(filePath))
            {
                if (flag)
                {
                    try
                    {
                        FileInfo f = new FileInfo(filePath);
                        if (!Directory.Exists(f.DirectoryName)) Directory.CreateDirectory(f.DirectoryName);

                        File.Create(filePath).Close();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.ToString());
                    }
                }
                return false;
            }
            return true;
        }
        /// <summary>
        /// 覆盖将内容写入文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="strContent">写入内容</param>
        public static void WriteText(string filePath, string strContent)
        {
            if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(strContent))
            {
                FileExists(filePath, true);

                FileStream fs = File.Open(filePath, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                try
                {
                    sw.Write(strContent);
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="encode">缺省为utf-8</param>
        /// <returns>读取到的内容</returns>
        public static string ReadText(string filePath, string encode)
        {
            string strContent = string.Empty;
            if (!string.IsNullOrEmpty(filePath))
            {
                StreamReader sr = new StreamReader(filePath, System.Text.Encoding.GetEncoding(encode));
                try
                {
                    strContent = sr.ReadToEnd();
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                }
                finally
                {
                    sr.Close();
                }

            }
            return strContent;
        }
        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>读取到的内容</returns>
        public static string ReadText(string filePath)
        {
            return ReadText(filePath, "UTF-8");
        }
        /// <summary>
        /// 文件移动
        /// </summary>
        /// <param name="sourceFileName">要移动的文件</param>
        /// <param name="destFileName">移动目标文件夹</param>
        public static void Move(string sourceFileName, string destFileName)
        {
            if (File.Exists(sourceFileName))
            {
                FileInfo f = new FileInfo(destFileName);
                // 如果文件所在的文件夹不存在则创建文件夹
                if (!Directory.Exists(f.DirectoryName)) Directory.CreateDirectory(f.DirectoryName);
                if (File.Exists(destFileName)) File.Delete(destFileName);
                File.Move(sourceFileName, destFileName);
            }
        }
        /// <summary>
        /// 写入日志文件，文件目录按yyyyMM/dd组成
        /// </summary>
        /// <param name="filePath">文件的最顶目录</param>
        /// <param name="fileType">文件类型</param>
        /// <param name="content">文件内容</param>
        public static void WriteLogFile(string filePath, string fileType, string content)
        {
            try
            {
                string fileFullPath = string.Format("{0}\\{1:yyyyMM}\\{2:dd}\\{3}_{4:yyyyMMdd}.log", filePath, DateTime.Now, DateTime.Now, fileType, DateTime.Now);
                FileInfo file = new FileInfo(fileFullPath);
                if (!Directory.Exists(file.DirectoryName))
                {
                    Directory.CreateDirectory(file.DirectoryName);
                }
                StreamWriter sw = new StreamWriter(fileFullPath, true, System.Text.Encoding.GetEncoding("GB2312"));
                sw.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]		" + content);
                sw.Close();
            }
            catch { }
        }
        /// <summary>
        /// 写入日志文件，文件目录按yyyyMM/dd组成，默认从配置文件的logfile读取
        /// </summary>
        /// <param name="fileType">文件类型</param>
        /// <param name="content">文件内容</param>
        public static void WriteLogFile(string fileType, string content)
        {
            try
            {
                string filePath = ConfigurationSettings.AppSettings["logfile"];
                string fileFullPath = string.Format("{0}\\{1:yyyyMM}\\{2:dd}\\{3}_{4:yyyyMMdd}.log", filePath, DateTime.Now, DateTime.Now, fileType, DateTime.Now);
                FileInfo file = new FileInfo(fileFullPath);
                if (!Directory.Exists(file.DirectoryName))
                {
                    Directory.CreateDirectory(file.DirectoryName);
                }
                StreamWriter sw = new StreamWriter(fileFullPath, true, System.Text.Encoding.GetEncoding("GB2312"));
                sw.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]		" + content);
                sw.Close();
            }
            catch { }
        }
    }
}
