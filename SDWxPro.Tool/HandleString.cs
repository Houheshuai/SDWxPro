using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SDWxPro.Tool
{
    /// <summary>
    /// 处理字符串操作
    /// 包含截取、过滤、查找危险、替换等操作
    /// </summary>
    public class HandleString
    {
        /// <summary>
        /// 在页面上调试直接输出
        /// </summary>
        /// <param name="str">要输出的内容</param>
        public static void Debug(string str)
        {
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 倒序输出
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>输出的结果</returns>
        public static string DotReverse(string str)
        {
            string str2 = "";
            for (int i = str.Length - 1; i > -1; i--)
            {
                str2 = str2 + str.Substring(i, 1);
            }
            return str2;
        }

        /// <summary>
        /// 获取随机字母字符串
        /// </summary>
        /// <param name="len">长度</param>
        /// <returns>生成好的字符串</returns>
        public static string GenRndString(int len)
        {
            string str = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random r = new Random();
            string result = string.Empty;
            for (int i = 0; i < len; i++)
            {
                int m = r.Next(0, 36);
                string s = str.Substring(m, 1);
                result += s;
            }
            return result;
        }

        /// <summary>
        /// JS过滤
        /// </summary>
        /// <param name="str">要过滤的字符串</param>
        /// <param name="exclueStr">过滤字符</param>
        /// <returns>返回过滤后的字符串</returns>
        public static string JsFilter(string str, string exclueStr)
        {
            if (exclueStr.IndexOf("<script>,") < 0)
            {
                str = str.Replace("<script>", "");
            }
            if (exclueStr.IndexOf("</script>,") < 0)
            {
                str = str.Replace("</script>", "");
            }
            if (exclueStr.IndexOf("javascript,") < 0)
            {
                str = str.Replace("javascript", "");
            }
            if (exclueStr.IndexOf("/,") < 0)
            {
                str = str.Replace("/", "");
            }
            if (exclueStr.IndexOf("',") < 0)
            {
                str = str.Replace("'", "");
            }
            if (exclueStr.IndexOf(";,") < 0)
            {
                str = str.Replace(";", "");
            }
            if (exclueStr.IndexOf("&,") < 0)
            {
                str = str.Replace("&", "");
            }
            if (exclueStr.IndexOf("#,") < 0)
            {
                str = str.Replace("#", "");
            }
            return str;
        }

        /// <summary>
        /// html标签过滤
        /// </summary>
        /// <param name="Htmlstring">html代码</param>
        /// <returns>返回处理过的代码</returns>
        public static string NoHTML(string Htmlstring)
        {
            Htmlstring = Regex.Replace(Htmlstring, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(iexcl|#161);", "\x00a1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(cent|#162);", "\x00a2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(pound|#163);", "\x00a3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(copy|#169);", "\x00a9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }

        /// <summary>
        /// 危险字符过滤
        /// </summary>
        /// <param name="str">要处理的字符串</param>
        /// <param name="exclueStr">过滤字符</param>
        /// <returns>返回过滤后的字符串</returns>
        public static string SafeFilter(string str, string exclueStr)
        {
            str = str.Replace(" ", "");
            if (exclueStr.IndexOf("',") < 0)
            {
                str = str.Replace("'", "");
            }
            if (exclueStr.IndexOf(",,") < 0)
            {
                str = str.Replace(",", "");
            }
            if (exclueStr.IndexOf("-,") < 0)
            {
                str = str.Replace("-", "");
            }
            if (exclueStr.IndexOf("+,") < 0)
            {
                str = str.Replace("+", "");
            }
            if (exclueStr.IndexOf("%,") < 0)
            {
                str = str.Replace("%", "");
            }
            if (exclueStr.IndexOf("&,") < 0)
            {
                str = str.Replace("&", "");
            }
            if (exclueStr.IndexOf("$,") < 0)
            {
                str = str.Replace("$", "");
            }
            if (exclueStr.IndexOf("*,") < 0)
            {
                str = str.Replace("*", "");
            }
            if (exclueStr.IndexOf(".,") < 0)
            {
                str = str.Replace(".", "");
            }
            if (exclueStr.IndexOf("=,") < 0)
            {
                str = str.Replace("=", "");
            }
            if (exclueStr.IndexOf("(,") < 0)
            {
                str = str.Replace("(", "");
            }
            if (exclueStr.IndexOf("),") < 0)
            {
                str = str.Replace(")", "");
            }
            if (exclueStr.IndexOf("!,") < 0)
            {
                str = str.Replace("!", "");
            }
            if (exclueStr.IndexOf("@,") < 0)
            {
                str = str.Replace("@", "");
            }
            if (exclueStr.IndexOf("#,") < 0)
            {
                str = str.Replace("#", "");
            }
            if (exclueStr.IndexOf("^,") < 0)
            {
                str = str.Replace("^", "");
            }
            if (exclueStr.IndexOf("|,") < 0)
            {
                str = str.Replace("|", "");
            }
            if (exclueStr.IndexOf(":,") < 0)
            {
                str = str.Replace(":", "");
            }
            if (exclueStr.IndexOf("xp_cmdshell,") < 0)
            {
                str = str.Replace("xp_cmdshell", "");
            }
            if (exclueStr.IndexOf("/add,") < 0)
            {
                str = str.Replace("/add", "");
            }
            str = str.Replace("exec master.dbo.xp_cmdshell", "");
            str = str.Replace("net localgroup administrators", "");
            str = str.Replace("select", "");
            str = str.Replace("insert", "");
            str = str.Replace("delete from", "");
            str = str.Replace("drop table", "");
            str = str.Replace("update", "");
            str = str.Replace("truncate", "");
            str = str.Replace("from", "");
            return str;
        }

        /// <summary>
        /// 将中间四位变成 *
        /// </summary>
        /// <param name="old">要处理的字符串</param>
        /// <returns>返回处理后的字符串</returns>
        public static string AllString(string old)
        {
            string strs = "";
            if (!string.IsNullOrEmpty(old))
            {
                if (old.Length > 7)
                {
                    strs = old.Substring(0, 3) + "****" + old.Substring(7);
                    //return old.Substring(0, old.Length - 4) + "****";
                }
                else
                {
                    strs = old;
                }
            }
            return strs;
        }

        /// <summary>
        /// 格式化字符串长度，超出部分显示省略号,区分汉字跟字母。汉字2个字节，字母数字一个字节
        /// </summary>
        /// <param name="obj">要处理的字符串</param>
        /// <param name="n">截取长度</param>
        /// <param name="type">1为加...，其它不加</param>
        /// <returns>返回处理好的字符串</returns>
        public static string GetCut(object obj, int n, int type)
        {
            ///
            ///格式化字符串长度，超出部分显示省略号,区分汉字跟字母。汉字2个字节，字母数字一个字节
            ///
            string str = obj.ToString();
            string temp = string.Empty;
            if (System.Text.Encoding.Default.GetByteCount(str) <= n)//如果长度比需要的长度n小,返回原字符串
            {
                return str;
            }
            else
            {
                int t = 0;
                char[] q = str.ToCharArray();
                for (int i = 0; i < q.Length && t < n; i++)
                {
                    if ((int)q[i] >= 0x4E00 && (int)q[i] <= 0x9FA5)//是否汉字
                    {
                        temp += q[i];
                        t += 2;
                    }
                    else
                    {
                        temp += q[i];
                        t++;
                    }
                }
                if (type == 1)
                {
                    return (temp + "...");
                }
                else
                {
                    return (temp);
                }
            }
        }

        /// <summary>
        /// 存入数据库之前过滤
        /// </summary>
        /// <param name="str">要过滤的字符串</param>
        /// <returns>返回过滤后的字符串</returns>
        public static string Replace(string str)
        {
            if (str == null) { str = ""; }
            str = str.Replace("&", "&amp;");
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            return str;
        }

        /// <summary>
        /// 取出数据时反过滤
        /// </summary>
        /// <param name="str">要过滤的字符串</param>
        /// <returns>返回过滤后的字符串</returns>
        public static string Replaces(string str)
        {
            if (str == null) { str = ""; }
            str = str.Replace("&amp;", "&");
            str = str.Replace("&quot;", "\"");
            str = str.Replace("''", "'");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&gt;", ">");
            str = str.Replace("<br>", "\n");
            return str;
        }

        /// <summary>
        /// 手机网站取出数据时反过滤
        /// </summary>
        /// <param name="str">要过滤的字符串</param>
        /// <returns>返回过滤后的字符串</returns>
        public static string Replaces_sj(string str)
        {
            if (str == null) { str = ""; }
            str = str.Replace("&amp;", "&");
            str = str.Replace("&quot;", "\"");
            str = str.Replace("''", "'");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&gt;", ">");
            str = str.Replace("<br>", "\n");

            //str = str.Replace("<tbody>", "");
            //str = str.Replace("</tbody>", "");

            //str = Regex.Replace(str, @"(?i)<table[^>]*>", "<dl class=\"table-dl\">", RegexOptions.IgnoreCase);
            //str = Regex.Replace(str, @"(?i)<tr[^>]*>", "<dt>", RegexOptions.IgnoreCase);
            //str = Regex.Replace(str, @"(?i)<td[^>]*>", "<dd>", RegexOptions.IgnoreCase);

            //str = Regex.Replace(str, @"(?i)</table[^>]*>", "</dl>", RegexOptions.IgnoreCase);
            //str = Regex.Replace(str, @"(?i)</tr[^>]*>", "</dt>", RegexOptions.IgnoreCase);
            //str = Regex.Replace(str, @"(?i)</td[^>]*>", "</dd>", RegexOptions.IgnoreCase);

            str = str.Replace("<table", "<div class=\"mob-table-wrap\"><table");
            str = str.Replace("</table>", "</table></div>");

            str = str.Replace("/job/", "/mjob/");
            str = str.Replace("/news/", "/mnews/");
            str = str.Replace("/pro/", "/mpro/");
            str = str.Replace("/c/", "/mc/");

            return str;
        }

        /// <summary>
        /// 表情工具包
        /// </summary>
        /// <param name="str">表情替换字符</param>
        /// <returns>替换后的表情</returns>
        public static string Face(string str)
        {
            str = str.Replace("[:)]", "<img src=Face/SMILE.gif boder=0>&nbsp;");
            str = str.Replace("[:(]", "<img src=Face/FROWN.gif boder=0>&nbsp;");
            str = str.Replace("[:o]", "<img src=Face/REDFACE.gif boder=0>&nbsp;");
            str = str.Replace("[:D]", "<img src=Face/BIGGRIN.gif boder=0>&nbsp;");
            str = str.Replace("[;)]", "<img src=Face/WINK.gif boder=0>&nbsp;");
            str = str.Replace("[:a]", "<img src=Face/BLUE.gif boder=0>&nbsp;");
            str = str.Replace("[:b]", "<img src=Face/SHY.gif boder=0>&nbsp;");
            str = str.Replace("[:c]", "<img src=Face/SLEEPY.gif boder=0>&nbsp;");
            str = str.Replace("[8)]", "<img src=Face/sunglasses.gif boder=0>&nbsp;");
            str = str.Replace("[:e]", "<img src=Face/supergrin.gif boder=0>&nbsp;");
            str = str.Replace("[:f]", "<img src=Face/EMBARASS.gif boder=0>&nbsp;");
            str = str.Replace("[:g]", "<img src=Face/tongue01.gif boder=0>&nbsp;");
            str = str.Replace("[:()]", "<img src=Face/mad.gif boder=0>&nbsp;");
            str = str.Replace("[:j]", "<img src=Face/eek.gif boder=0>&nbsp;");
            str = str.Replace("[?:(]", "<img src=Face/confused.gif boder=0>&nbsp;");
            str = str.Replace("[:l]", "<img src=Face/rolleyes.gif boder=0>&nbsp;");
            return str;
        }

        #region
        /// <summary>
        /// 返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns>字符长度</returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }
        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                        return i;
                }
                else if (strSearch == stringArray[i])
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>		
        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">字符串数组</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, SplitString(stringarray, ","), false);
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, SplitString(stringarray, strsplit), false);
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
        }
        /// <summary>
        /// 返回一个数组中的第一个元素
        /// </summary>
        /// <param name="strArr">字符串数组</param>
        /// <returns>第一个元素</returns>
        public static string ReturnArrStrFirstString(string[] strArr)
        {
            if (strArr.Length > 0)
            {
                return strArr[0];
            }
            return "";
        }
        #endregion

        #region 字符串截取、替换、分割、连接
        /// <summary>
        /// 删除字符串尾部的回车/换行/空格
        /// </summary>
        /// <param name="str">要处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string RTrim(string str)
        {
            for (int i = str.Length; i >= 0; i--)
            {
                if (str[i].Equals(" ") || str[i].Equals("\r") || str[i].Equals("\n"))
                {
                    str.Remove(i, 1);
                }
            }
            return str;
        }
        /// <summary>
        /// 取指定长度的字符串
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_StartIndex">起始位置</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string myResult = p_SrcString;
            Byte[] bComments = Encoding.UTF8.GetBytes(p_SrcString);
            foreach (char c in Encoding.UTF8.GetChars(bComments))
            {
                //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
                if ((c > '\u0800' && c < '\u4e00') || (c > '\xAC00' && c < '\xD7A3'))
                {
                    if (p_StartIndex >= p_SrcString.Length)
                    {
                        return "";
                    }
                    else
                    {
                        return p_SrcString.Substring(p_StartIndex, ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                    }
                }
            }

            if (p_Length >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString);
                //当字符串长度大于起始位置
                if (bsSrcString.Length > p_StartIndex)
                {
                    int p_EndIndex = bsSrcString.Length;
                    //当要截取的长度在字符串的有效长度范围内
                    if (bsSrcString.Length > (p_StartIndex + p_Length))
                    {
                        p_EndIndex = p_Length + p_StartIndex;
                    }
                    else
                    {
                        //当不在有效范围内时,只取到字符串的结尾
                        p_Length = bsSrcString.Length - p_StartIndex;
                        p_TailString = "";
                    }
                    int nRealLength = p_Length;
                    int[] anResultFlag = new int[p_Length];
                    byte[] bsResult = null;

                    int nFlag = 0;
                    for (int i = p_StartIndex; i < p_EndIndex; i++)
                    {
                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                            {
                                nFlag = 1;
                            }
                        }
                        else
                        {
                            nFlag = 0;
                        }
                        anResultFlag[i] = nFlag;
                    }

                    if ((bsSrcString[p_EndIndex - 1] > 127) && (anResultFlag[p_Length - 1] == 1))
                    {
                        nRealLength = p_Length + 1;
                    }
                    bsResult = new byte[nRealLength];
                    Array.Copy(bsSrcString, p_StartIndex, bsResult, 0, nRealLength);
                    myResult = Encoding.Default.GetString(bsResult);
                    myResult = myResult + p_TailString;
                }
            }
            return myResult;
        }

        /// <summary>
        /// 自定义的替换字符串函数
        /// </summary>
        /// <param name="SourceString">要检查的字符串</param>
        /// <param name="SearchString">要替换的字符串</param>
        /// <param name="ReplaceString">要替换的目标字符串</param>
        /// <param name="IsCaseInsensetive">忽略大小写</param>
        /// <returns>返回处理后的字符串</returns>
        public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInsensetive)
        {
            return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None);
        }

        /// <summary>
        /// 从字符串的指定位置截取指定长度的子字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex = startIndex - length;
                    }
                }

                if (startIndex > str.Length)
                {
                    return "";
                }
            }
            else
            {
                if (length < 0)
                {
                    return "";
                }
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            if (str.Length - startIndex < length)
            {
                length = str.Length - startIndex;
            }

            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// 从字符串的指定位置开始截取到字符串结尾的子符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }

        /// <summary>
        /// 字符串如果操过指定长度则将超出的部分用指定字符串代替
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        /// <summary>
        /// Unicode 转码后截取
        /// </summary>
        /// <param name="str">要操作的字符串</param>
        /// <param name="len">长度</param>
        /// <param name="p_TailString">追加的字符串</param>
        /// <returns>截取后的结果</returns>
        public static string GetUnicodeSubString(string str, int len, string p_TailString)
        {
            string result = string.Empty;// 最终返回的结果
            int byteLen = System.Text.Encoding.Default.GetByteCount(str);// 单字节字符长度
            int charLen = str.Length;// 把字符平等对待时的字符串长度
            int byteCount = 0;// 记录读取进度
            int pos = 0;// 记录截取位置
            if (byteLen > len)
            {
                for (int i = 0; i < charLen; i++)
                {
                    if (Convert.ToInt32(str.ToCharArray()[i]) > 255)// 按中文字符计算加2
                    {
                        byteCount += 2;
                    }
                    else // 按英文字符计算加1
                    {
                        byteCount += 1;
                    }

                    if (byteCount > len)// 超出时只记下上一个有效位置
                    {
                        pos = i;
                        break;
                    }
                    else if (byteCount == len)// 记下当前位置
                    {
                        pos = i + 1;
                        break;
                    }
                }
                if (pos >= 0)
                {
                    result = str.Substring(0, pos) + p_TailString;
                }
            }
            else
            {
                result = str;
            }
            return result;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">字符串内容</param>
        /// <param name="strSplit">分隔符</param>
        /// <returns>返回分割后的数组</returns>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (!String.IsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0)
                {
                    return new string[] { strContent };
                }

                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            else
            {
                return new string[0] { };
            }
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">字符串内容</param>
        /// <param name="strSplit">分隔符</param>
        /// <param name="strSplit">分割多少次</param>
        /// <returns>返回分割后的数组</returns>
        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            string[] result = new string[count];
            string[] splited = SplitString(strContent, strSplit);

            for (int i = 0; i < count; i++)
            {
                if (i < splited.Length)
                {
                    result[i] = splited[i];
                }
                else
                {
                    result[i] = string.Empty;
                }
            }

            return result;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <param name="maxElementLength">单个元素最大长度</param>
        /// <returns>返回分割后的数组</returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);

            return ignoreRepeatItem ? DistinctStringArray(result, maxElementLength) : result;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <param name="minElementLength">单个元素最小长度</param>
        /// <param name="maxElementLength">单个元素最大长度</param>
        /// <returns>返回分割后的数组</returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int minElementLength, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);

            if (ignoreRepeatItem)
            {
                result = DistinctStringArray(result);
            }
            return PadStringArray(result, minElementLength, maxElementLength);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <returns>返回分割后的数组</returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem)
        {
            return SplitString(strContent, strSplit, ignoreRepeatItem, (int)0);
        }

        /// <summary>
        /// 过滤字符串数组中每个元素为合适的大小
        /// 当长度小于minLength时，忽略掉,-1为不限制最小长度
        /// 当长度大于maxLength时，取其前maxLength位
        /// 如果数组中有null元素，会被忽略掉
        /// </summary>
        /// <param name="minLength">单个元素最小长度</param>
        /// <param name="maxLength">单个元素最大长度</param>
        /// <returns>返回过滤后的数组</returns>
        public static string[] PadStringArray(string[] strArray, int minLength, int maxLength)
        {
            if (minLength > maxLength)
            {
                int t = maxLength;
                maxLength = minLength;
                minLength = t;
            }

            int iMiniStringCount = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (minLength > -1 && strArray[i].Length < minLength)
                {
                    strArray[i] = null;
                    continue;
                }
                if (strArray[i].Length > maxLength)
                {
                    strArray[i] = strArray[i].Substring(0, maxLength);
                }
                iMiniStringCount++;
            }

            string[] result = new string[iMiniStringCount];
            for (int i = 0, j = 0; i < strArray.Length && j < result.Length; i++)
            {
                if (strArray[i] != null && strArray[i] != string.Empty)
                {
                    result[j] = strArray[i];
                    j++;
                }
            }
            return result;
        }

        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <param name="maxElementLength">字符串数组中单个元素的最大长度</param>
        /// <returns>返回处理后的数组</returns>
        public static string[] DistinctStringArray(string[] strArray, int maxElementLength)
        {
            Hashtable h = new Hashtable();

            foreach (string s in strArray)
            {
                string k = s;
                if (maxElementLength > 0 && k.Length > maxElementLength)
                {
                    k = k.Substring(0, maxElementLength);
                }
                h[k.Trim()] = s;
            }

            string[] result = new string[h.Count];

            h.Keys.CopyTo(result, 0);

            return result;
        }

        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <returns>返回处理后的数组</returns>
        public static string[] DistinctStringArray(string[] strArray)
        {
            return DistinctStringArray(strArray, 0);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">指定分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">是否忽略重复</param>
        /// <param name="space">是否忽略空白元素</param>
        /// <returns>返回处理后的数组</returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, bool space)
        {
            if (ignoreRepeatItem)
            {
                return space ? DisablSpace(SplitString(strContent, strSplit, ignoreRepeatItem)) : SplitString(strContent, strSplit, ignoreRepeatItem);
            }
            else
            {
                return space ? DisablSpace(SplitString(strContent, strSplit)) : SplitString(strContent, strSplit);
            }
        }

        /// <summary>
        /// 忽略数组中的空白元素
        /// </summary>
        /// <param name="strArr">要处理的数组</param>
        /// <returns>返回处理后的数组</returns>
        public static string[] DisablSpace(string[] strArr)
        {
            Hashtable h = new Hashtable();
            foreach (string str in strArr)
            {
                string temp = str;
                if (str != string.Empty && !Regex.IsMatch(str, @"^\s+$", RegexOptions.IgnoreCase))
                {
                    h[temp] = str;
                }
            }
            string[] result = new string[h.Count];
            h.Keys.CopyTo(result, 0);
            return result;
        }

        /// <summary>
        /// 按长度将每一位分割成一个字符
        /// </summary>
        /// <param name="str">指定字符串</param>
        /// <returns>返回处理后的数组</returns>
        public static string[] SplitLength(string str)
        {
            string[] strArr = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                strArr[i] = str.Substring(i, 1);
            }
            return DisablSpace(strArr);

        }

        /// <summary>
        /// 将多个字符串连接成一个字符串
        /// </summary>
        /// <param name="str">要拼接的数组</param>
        /// <returns>返回拼接好的字符串</returns>
        public static string JoinString(params string[] strArr)
        {
            if (strArr == null)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            foreach (string str in strArr)
            {
                if (!Validator.IsNullOrSpace(str))
                {
                    sb.Append(str);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 删除最后一个字符
        /// </summary>
        /// <param name="str">要处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string ClearLastChar(string str)
        {
            return (str == "") ? "" : str.Substring(0, str.Length - 1);
        }
        /// <summary>
        /// 合并字符
        /// </summary>
        /// <param name="source">要合并的源字符串</param>
        /// <param name="target">要被合并到的目的字符串</param>
        /// <param name="mergechar">合并符</param>
        /// <returns>合并到的目的字符串</returns>
        public static string MergeString(string source, string target)
        {
            return MergeString(source, target, ",");
        }

        /// <summary>
        /// 合并字符
        /// </summary>
        /// <param name="source">要合并的源字符串</param>
        /// <param name="target">要被合并到的目的字符串</param>
        /// <param name="mergechar">合并符</param>
        /// <returns>合并到字符串</returns>
        public static string MergeString(string source, string target, string mergechar)
        {
            if (Validator.IsNullOrSpace(target))
            {
                target = source;
            }
            else
            {
                target += mergechar + source;
            }
            return target;
        }
        /// <summary>
        /// 清除字符串中的子字符串
        /// </summary>
        /// <param name="strContent">指定字符串</param>
        /// <param name="strClear">指定子字符串</param>
        /// <returns>返回处理后的字符串</returns>
        public static string ClearSubstr(string strContent, string strClear)
        {
            if (Validator.IsNullOrSpace(strContent))
            {
                return "";
            }
            else if (Validator.IsNullOrSpace(strClear))
            {
                return strContent;
            }
            else
            {
                int index = strContent.IndexOf(strClear);
                if (index != -1)
                {
                    return strContent.Remove(index, strClear.Length);
                }
                else
                {
                    return strContent;
                }
            }
        }
        ///<summary>
        /// 指定字符串替换
        /// </summary>
        /// <param name="strContent">原字符串</param>
        /// <param name="strDisplace">指定匹配字符串</param>
        /// <param name="strReplace">替换字符串</param>
        /// <returns>返回处理后的字符串</returns>
        public static string DisplaceReplace(string strContent, string strDisplace, string strReplace)
        {
            if (strContent.Contains(strDisplace))
            {
                return strContent.Replace(strDisplace, strReplace);
            }
            return strContent;
        }
        
        /// <summary>
        /// 清理字符串
        /// </summary>
        /// <param name="strIn">要处理的字符串</param>
        /// <returns>返回处理后的字符串</returns>
        public static string CleanInput(string strIn)
        {
            return Regex.Replace(strIn.Trim(), @"[^\w\.@-]", "");
        }

        /// <summary>
        /// 进行指定的替换(脏字过滤)
        /// </summary>
        /// <param name="str">要处理的字符串</param>
        /// <param name="bantext">要过滤的字</param>
        /// <returns>返回处理后的字符串</returns>
        public static string StrFilter(string str, string bantext)
        {
            string text1 = "", text2 = "";
            string[] textArray1 = SplitString(bantext, "\r\n");
            for (int num1 = 0; num1 < textArray1.Length; num1++)
            {
                text1 = textArray1[num1].Substring(0, textArray1[num1].IndexOf("="));
                text2 = textArray1[num1].Substring(textArray1[num1].IndexOf("=") + 1);
                str = str.Replace(text1, text2);
            }
            return str;
        }
        #endregion

        #region html字符过滤、替换
        /// <summary>
        /// 过滤HTML中的不安全标签
        /// </summary>
        /// <param name="content">要处理的字符串</param>
        /// <returns>返回处理后的字符串</returns>
        public static string RemoveUnsafeHtml(string content)
        {
            content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return content;
        }

        /// <summary>
        /// 从HTML中获取文本,保留br,p,img
        /// </summary>
        /// <param name="HTML">要处理的字符串</param>
        /// <returns>返回处理后的字符串</returns>
        public static string GetTextFromHTML(string HTML)
        {
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(@"</?(?!br|/?p|img)[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            return regEx.Replace(HTML, "");
        }

        /// <summary>
        /// 替换html字符
        /// </summary>
        /// <param name="strHtml">要处理后的字符串</param>
        /// <returns>返回处理后的字符串</returns>
        public static string EncodeHtml(string strHtml)
        {
            if (strHtml != "")
            {
                strHtml = strHtml.Replace(",", "&def");
                strHtml = strHtml.Replace("'", "&dot");
                strHtml = strHtml.Replace(";", "&dec");
                return strHtml;
            }
            return "";
        }

        /// <summary>
        /// 生成指定数量的html空格符号
        /// </summary>
        /// <param name="spacesCount">空格数</param>
        /// <returns>返回处理后的字符串</returns>
        public static string GetSpacesString(int spacesCount)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < spacesCount; i++)
            {
                sb.Append(" &nbsp;&nbsp;");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 替换回车换行符为html换行符
        /// </summary>
        /// <param name="str">要处理的字符串</param>
        /// <returns>返回处理后的字符串</returns>
        public static string StrFormat(string str)
        {
            string str2;

            if (str == null)
            {
                str2 = "";
            }
            else
            {
                str = str.Replace("\r\n", "<br />");
                str = str.Replace("\n", "<br />");
                str2 = str;
            }
            return str2;
        }
        #endregion
    }
}
