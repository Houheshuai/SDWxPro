using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SDWxPro.Tool
{
    /// <summary>
    /// JS 弹框操作
    /// </summary>
    public class JsUtil
    {
        /// <summary>
        /// 关闭窗口
        /// </summary>
        public static void CloseWindow()
        {
            string s = "<Script language='JavaScript'>\r\n                    parent.opener=null;window.close();  \r\n                  </Script>";
            HttpContext.Current.Response.Write(s);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 后退
        /// </summary>
        /// <param name="value">后退级数</param>
        public static void GoHistory(int value)
        {
            string format = "<Script language='JavaScript'>\r\n                    history.go({0});  \r\n                  </Script>";
            HttpContext.Current.Response.Write(string.Format(format, value));
        }

        /// <summary>
        /// 打开新窗口
        /// </summary>
        /// <param name="url">要跳转的路径</param>
        public static void LocationNewHref(string url)
        {
            string format = "<Script language='JavaScript'>\r\n                    window.location.replace('{0}');\r\n                  </Script>";
            format = string.Format(format, url);
            HttpContext.Current.Response.Write(format);
        }

        /// <summary>
        /// 打开一个指定大小的新窗口
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="top">上边距</param>
        /// <param name="left">左边距</param>
        public static void OpenWindow(string url, int width, int heigth, int top, int left)
        {
            string s = string.Concat(new object[] { "<Script language='JavaScript'>window.open('", url, "','','height=", heigth, ",width=", width, ",top=", top, ",left=", left, ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>" });
            HttpContext.Current.Response.Write(s);
        }

        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshOpener()
        {
            string s = "<Script language='JavaScript'>\r\n                    opener.location.reload();\r\n                  </Script>";
            HttpContext.Current.Response.Write(s);
        }

        /// <summary>
        /// 在父窗口打开一个新地址
        /// </summary>
        /// <param name="url">地址</param>
        public static void RefreshParent(string url)
        {
            string s = "<Script language='JavaScript'>\r\n                    window.opener.location.href='" + url + "';window.close();</Script>";
            HttpContext.Current.Response.Write(s);
        }

        /// <summary>
        /// 弹出模式窗口
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="top">上边距</param>
        /// <param name="left">左边距</param>
        public static void ShowModalDialog(string url, int width, int height, int top, int left)
        {
            string str = "dialogWidth:" + width.ToString() + "px;dialogHeight:" + height.ToString() + "px;dialogLeft:" + left.ToString() + "px;dialogTop:" + top.ToString() + "px;center:yes;help=no;resizable:no;status:no;scroll=yes";
            string s = "<script language=javascript>\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\tshowModalDialog('" + url + "','','" + str + "');</script>";
            HttpContext.Current.Response.Write(s);
        }

        /// <summary>
        /// 提示消息，不跳转页面
        /// </summary>
        /// <param name="msg">提示消息</param>
        public static void ShowMsg(string msg)
        {
            string s = "<Script language='JavaScript'>\r\n                    alert('" + msg + "');</Script>";
            HttpContext.Current.Response.Write(s);
        }

        /// <summary>
        /// 提示消息，跳转页面
        /// </summary>
        /// <param name="msg">提示消息</param>
        /// <param name="toURL">地址</param>
        public static void ShowMsg(string msg, string toURL)
        {
            string format = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(format, msg, toURL));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="toURL">地址</param>
        public static void JumpUrl(string toURL)
        {
            string format = "<script language=javascript>window.location.replace('{0}')</script>";
            HttpContext.Current.Response.Write(string.Format(format, toURL));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 点击跳转
        /// </summary>
        /// <param name="msg">提示消息</param>
        /// <param name="goUrl">地址</param>
        /// <param name="second">时间</param>
        public static void TipAndRedirect(string msg, string goUrl, string second)
        {
            HttpContext.Current.Response.Write("<meta http-equiv='refresh' content='" + second + ";url=" + goUrl + "'>");
            HttpContext.Current.Response.Write("<br/><br/><p align=center><div style=\"size:12px\">&nbsp;&nbsp;&nbsp;&nbsp;" + msg.Replace("!", "") + ",页面2秒内跳转!<br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"" + goUrl + "\">如果没有跳转，请点击!</a></div></p>");
            HttpContext.Current.Response.End();
        }

    }
}
