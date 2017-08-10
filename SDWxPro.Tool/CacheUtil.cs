using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Text.RegularExpressions;
using System.Collections;

namespace SDWxPro.Tool
{
    public class CacheUtil
    {
        /// <summary>
        /// 清空缓存
        /// </summary>
        public static void Clear()
        {
            IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Remove(enumerator.Key.ToString());
            }
        }

        /// <summary>
        /// 新增缓存
        /// </summary>
        /// <param name="strKey">键</param>
        /// <param name="valueObj">值</param>
        /// <param name="durationSecond">持续时间</param>
        /// <returns></returns>
        public static bool Insert(string strKey, object valueObj, double durationSecond)
        {
            if (((strKey != null) && (strKey.Length != 0)) && (valueObj != null))
            {
                CacheItemRemovedCallback onRemoveCallback = new CacheItemRemovedCallback(CacheUtil.onRemove);
                HttpContext.Current.Cache.Insert(strKey, valueObj, null, DateTime.Now.AddSeconds(durationSecond), Cache.NoSlidingExpiration, CacheItemPriority.Normal, onRemoveCallback);
                return true;
            }
            return false;
        }

        private static void onRemove(string strKey, object obj, CacheItemRemovedReason reason)
        {

        }

        /// <summary>
        /// 判断缓存是否存在
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static bool IsExist(string strKey)
        {
            return (HttpContext.Current.Cache[strKey] != null);
        }

        /// <summary>
        /// 通过Key来读取缓存
        /// </summary>
        /// <param name="strKey">键</param>
        /// <returns></returns>
        public static object Read(string strKey)
        {
            if (HttpContext.Current.Cache[strKey] == null)
            {
                return null;
            }
            object obj2 = HttpContext.Current.Cache[strKey];
            if (obj2 == null)
            {
                return null;
            }
            return obj2;
        }

        /// <summary>
        /// 通过Key来删除缓存
        /// </summary>
        /// <param name="strKey">键</param>
        public static void Remove(string strKey)
        {
            if (HttpContext.Current.Cache[strKey] != null)
            {
                HttpContext.Current.Cache.Remove(strKey);
            }
        }

        public static void RemoveByRegexp(string pattern)
        {
            if (pattern != "")
            {
                IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string input = enumerator.Key.ToString();
                    if (Regex.IsMatch(input, pattern))
                    {
                        Remove(input);
                    }
                }
            }
        }
    }
}
