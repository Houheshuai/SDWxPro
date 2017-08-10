using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SDWxPro.Tool
{
    public class CheckCookie
    {
        public CheckCookie()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public static void CheckAdminCookie()
        {
            if (CookieUtil.Exists("adminUser") == false)
            {
                HttpContext.Current.Response.Write("<script>top.location.href='/SysAdmin/Default.aspx';</script>");
                HttpContext.Current.Response.End();
            }
        }


        public static void CheckVistorCookie()
        {
            if (CookieUtil.Exists("vistor") == false)
            {
                HttpContext.Current.Response.Write("<script>top.location.href='Login.aspx';</script>");
                HttpContext.Current.Response.End();
            }
        }
    }
}
