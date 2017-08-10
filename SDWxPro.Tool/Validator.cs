using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SDWxPro.Tool
{
    /// <summary>
    /// 正则验证类
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// 判断给定的字符串数组(strNumber)中的数据是不是都为数值型
        /// </summary>
        /// <param name="strNumber">要确认的字符串数组</param>
        /// <returns>是则返加true 不是则返回 false</returns>
        public static bool IsIntArray(string[] strNumber)
        {
            if (strNumber == null)
                return false;

            if (strNumber.Length < 1)
                return false;

            foreach (string id in strNumber)
            {
                if (!IsInt(id))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 是否为数值串列表，各数值间用","间隔
        /// </summary>
        /// <param name="numList">数字串</param>
        /// <returns>返回是否全为Int类型</returns>
        public static bool IsNumericList(string numList)
        {
            if (Validator.IsNullOrSpace(numList))
            {
                return false;
            }
            return Validator.IsIntArray(numList.Split(','));
        }
        /// <summary>
        /// 是否为移动电话(手机)
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否为手机</returns>
        public static bool IsMobile(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return Regex.IsMatch(input, @"^1[3-8]\d{9}$");
            }
            return false;
        }
        /// <summary>
        /// 是否为固定电话(座机)
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsFixed(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return Regex.IsMatch(input, @"^\d{3}-\d{8}$|^\d{4}-\d{7}$");
            }
            return false;
        }
        /// <summary>
        /// 是否为QQ
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsQQ(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return Regex.IsMatch(input, @"^[1-9]\d{4,}$");
            }
            return false;
        }
        /// <summary>
        /// 是否全是汉字
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsFontChinaese(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return Regex.IsMatch(input, @"^[\u4e00-\u9fa5]+$");
            }
            return false;
        }
        /// <summary>
        /// 是否为int类型正整数
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsPInt(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string pattern = @"^[1-9][0-9]*$|^0$";
                Regex rege = new Regex(pattern);
                if (rege.IsMatch(input) && input.Length <= 10)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 是否为int类型负整数
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsNInt(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string pattern = @"^\-?[1-9]\d*$|^0$";
                Regex rege = new Regex(pattern);
                if (rege.IsMatch(input) && input.Length <= 11)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 是否为int类型整数
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsInt(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string pattern = @"^\-?[1-9][0-9]*$|^0$";
                Regex rege = new Regex(pattern);
                if (rege.IsMatch(input) && input.Length <= 10 || (input.Length == 11 && input.Substring(0, 1) == "-"))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 是否为数字
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsNumber(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return Regex.IsMatch(input, @"^\d+$");
            }
            return false;
        }
        /// <summary>
        /// 是否为空或者空格
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsNullOrSpace(string input)
        {
            return (input == null) || (Regex.IsMatch(input, @"^\s+$"));
        }
        /// <summary>
        /// 是否为双精度小数
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsDouble(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return Regex.IsMatch(input, @"^-?\d\d*(\.\w*)?$");
            }
            return false;
        }
        /// <summary>
        /// 是否为E-Mail格式
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsMail(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return Regex.IsMatch(input, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            }
            return false;
        }
        /// <summary>
        /// 是否为时间格式 时间 yyyy-MM-dd or yyyy.MM.dd or yyyy/MM/dd;
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsDate(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string pattern = @"^([12]\d{3})[-./](1[0-2]|0?[1-9])[-./]([12]\d|[0]?[1-9]|3[01])$";
                return Regex.IsMatch(input, pattern);
            }
            return false;
        }
        /// <summary>
        /// 是否为年份
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsYear(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string pattern = @"^[12]\d{3}$";
                return Regex.IsMatch(input, pattern);
            }
            return false;
        }
        /// <summary>
        /// 是否仅由中文,英文,阿拉伯数字,下划线和连字符组成
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsCEA(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return Regex.IsMatch(input, @"^(\w[\u4e00-\u9fa5]\-)+$");
            }
            return false;
        }
        /// <summary>
        /// 是否为标准URL
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsURL(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return Regex.IsMatch(input, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            }
            return false;
        }
        /// <summary>
        /// 是否为IP
        /// </summary>
        /// <param name="input">要判断的字符串</param>
        /// <returns>返回是否</returns>
        public static bool IsIP(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                string pattern = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";
                return Regex.IsMatch(input, pattern);
            }
            return false;
        }

        /// <summary>
        /// 返回指定IP是否在指定的IP数组所限定的范围内, IP数组内的IP地址可以使用*表示该IP段任意, 例如192.168.1.*
        /// </summary>
        /// <param name="ip">要判断的地址</param>
        /// <param name="iparray">地址范围</param>
        /// <returns>返回是否在范围内</returns>
        public static bool InIPArray(string ip, string[] iparray)
        {
            string[] userip = HandleString.SplitString(ip, @".");

            for (int ipIndex = 0; ipIndex < iparray.Length; ipIndex++)
            {
                string[] tmpip = HandleString.SplitString(iparray[ipIndex], @".");
                int r = 0;
                for (int i = 0; i < tmpip.Length; i++)
                {
                    if (tmpip[i] == "*")
                        return true;

                    if (userip.Length > i)
                    {
                        if (tmpip[i] == userip[i])
                        {
                            r++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (r == 4)
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}
