using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace SDWxPro.Tool
{
    public class MailUtil
    {
        /// <summary>
        /// 发送邮件函数
        /// </summary>
        /// <param name="subject">邮件标题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="getUser">收件人</param>
        /// <param name="company">公司名称</param>
        /// <param name="smtpStr">smtp服务器</param>
        /// <param name="sendUser">发件箱</param>
        /// <param name="sendPass">发件箱密码</param>
        /// <returns>发送状态，是否成功</returns>
        public static bool SendMail(string subject, string body, string getUser, string company, string smtpStr, string sendUser, string sendPass)
        {
            try
            {
                System.Net.Mail.MailMessage mailObj = new System.Net.Mail.MailMessage();
                mailObj.IsBodyHtml = true;
                mailObj.Subject = subject;
                mailObj.Body = body;
                mailObj.To.Add(getUser);//收件人
                System.Net.Mail.SmtpClient SmtpMail = new SmtpClient(smtpStr);
                mailObj.From = new MailAddress(sendUser, company, System.Text.Encoding.UTF8);//发件人
                SmtpMail.Credentials = new System.Net.NetworkCredential(sendUser, sendPass);//认证
                SmtpMail.EnableSsl = true;
                //gmail 专有配置 结束
                SmtpMail.Send(mailObj);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 系统测试邮件
        /// </summary>
        /// <param name="mailname">邮箱用户名</param>
        /// <param name="mailpass">邮箱密码</param>
        /// <param name="mailsmtp">smtp服务器</param>
        /// <returns>是否设置成功</returns>
        public static bool SendTestMail(string mailname, string mailpass, string mailsmtp)
        {
            try
            {
                System.Net.Mail.MailMessage mailObj = new System.Net.Mail.MailMessage();
                mailObj.IsBodyHtml = true;
                mailObj.Subject = "系统测试邮件";
                mailObj.Body = "您收到该邮件是因为您在网站后台系统设置了邮件服务器，验证后发的一封验证邮件，收到此邮件说明设置正常。";
                mailObj.To.Add(mailname);//收件人
                System.Net.Mail.SmtpClient SmtpMail = new SmtpClient(mailsmtp);
                mailObj.From = new MailAddress(mailname, "后台管理系统", System.Text.Encoding.UTF8);//发件人
                SmtpMail.Credentials = new System.Net.NetworkCredential(mailname, mailpass);//认证
                SmtpMail.EnableSsl = true;
                //gmail 专有配置 结束
                SmtpMail.Send(mailObj);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
