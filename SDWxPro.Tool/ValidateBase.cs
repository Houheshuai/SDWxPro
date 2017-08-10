using System;
using System.Collections.Generic;
using System.Text;

namespace SDWxPro.Tool
{
    public class ValidateBase : System.Web.UI.Page
    {
        public ValidateBase()
        {

        }
        /// <summary>
        /// 存放验证码值
        /// </summary>
        public string strValidate
        {
            get
            {
                if (Session["ValidateCode"] != null)
                    return Session["ValidateCode"].ToString();
                else
                    return "";
            }
            set
            {
                Session["ValidateCode"] = value;
            }
        }
        /// <summary>
        /// 存放登入信息
        /// </summary>
        public string strUser
        {
            get
            {
                if (Session["strUser"] != null)
                    return Session["strUser"].ToString();
                else
                    return "";
            }
            set
            {
                Session["strUser"] = value;
            }
        }
    }
}
