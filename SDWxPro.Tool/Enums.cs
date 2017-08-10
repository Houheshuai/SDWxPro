using System;
using System.Collections.Generic;
using System.Text;

namespace SDWxPro.Tool
{
    public class Enums
    {
        /// <summary>
        /// 自定义枚举
        /// </summary>
        public enum DataProviderType
        {
            Access = 0,
            SQLServer
        }

        public enum ConfigList
        {
        }

        public enum ConfigFile : int
        {
            PageInfo = 0,

        }

        public enum PageInfo : int
        {
            Title = 0,
            Description,
            Keywords,
        }
    }
}
