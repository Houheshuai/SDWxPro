using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SDWxPro.Tool
{
    public class UserTool
    {
        public static void SetCookies(string strUserName,string strUserId)
        {
            string strEncryptUserName = DES.EncryptString(strUserName, DES.strKey); //把用户名解密
            string strEncryptUserId = DES.EncryptString(strUserId, DES.strKey);

            //同时在Cookies中存放用户名和用户ID(加密过的)
            HttpContext.Current.Response.Cookies["UserInfo"]["UserName"] = strEncryptUserName;  //表示已经成功登陆，以后判断用户是否登陆就用这个值来判断。
            HttpContext.Current.Response.Cookies["UserInfo"]["UserId"] = strEncryptUserId;
            HttpContext.Current.Response.Cookies["UserInfo"].Expires = DateTime.Now.AddDays(1); //一天后失效
        }
    }
}
