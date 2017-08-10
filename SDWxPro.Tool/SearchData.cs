using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDWxPro.Tool
{
    public class SearchData
    {
        private int m_TypeId;//导航
        private String m_Title;//标题
        private String m_Content;//内容
        private String m_Abstract;//简述概要
        private DateTime m_Time;//时间
        private String m_TitleHighLighter;//高亮字段
        private int id;//逻辑Id

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public int TypeId
        {
            get
            {
                return m_TypeId;
            }

            set
            {
                m_TypeId = value;
            }
        } 
        public String Title
        {
            get
            {
                return m_Title;
            }

            set
            {
                m_Title = value;
            }
        }  
        public String Content
        {
            get
            {
                return m_Content;
            }

            set
            {
                m_Content = value;
            }
        }  
        public String Abstract
        {
            get
            {
                return m_Abstract;
            }

            set
            {
                m_Abstract = value;
            }
        }
        public String TitleHighLighter
        {
            get
            {
                return m_TitleHighLighter;
            }

            set
            {
                m_TitleHighLighter = value;
            }
        }      
        public DateTime Time
        {
            get
            {
                return m_Time;
            }

            set
            {
                m_Time = value;
            }
        }
        //通过typeid获取链接的页面
        public string GetHrefByTypeid(int typeid)
        {
            string linkname = "";
            switch (Security.ToNum(typeid))
            {
                case 0:
                    linkname = "ProductDetailed";
                    break;
                case 1:
                    linkname = "NewsDetailed";
                    break;
                case 2:
                    linkname = "About";
                    break;
                case 3:
                    linkname = "Server";
                    break;
                case 4:
                    linkname = "ProductApplication";
                    break;
                case 5:
                    linkname = "Case";
                    break;
                case 6:
                    linkname = "Contact";
                    break;
                case 7:
                    linkname = "Recruitment";
                    break;
            }
            return linkname;
        }
    }
}
