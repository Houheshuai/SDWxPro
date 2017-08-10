using SDWxPro.Model;
using SDWxPro.Service;
using SDWxPro.Tool;
using SDWxPro.Web.OAtuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace SDWxPro.Web
{
    public partial class WeChatApi : System.Web.UI.Page
    {
        const string Token = "test";


        public void WriteLog(string tes)
        {
            using (FileStream fs = new FileStream(Server.MapPath("~") + "log.txt", FileMode.Append, FileAccess.Write))
            {
                var byteStr = System.Text.Encoding.UTF8.GetBytes(tes);
                fs.Write(byteStr, 0, byteStr.Length);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
         
            string postStr = "";
            if (Request.HttpMethod.ToLower() == "post")
            {
                Stream s = System.Web.HttpContext.Current.Request.InputStream;
                byte[] b = new byte[s.Length];
                s.Read(b, 0, (int)s.Length);
                postStr = Encoding.UTF8.GetString(b);
                if (!string.IsNullOrEmpty(postStr))
                {
                    WriteLog(postStr);

                }
                if (!string.IsNullOrEmpty(postStr))
                {
                    
                    //封装请求类
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(postStr);
                    XmlElement rootElement = doc.DocumentElement;
                    XmlNode MsgType = rootElement.SelectSingleNode("MsgType");
                    WeixinReg wr = new WeixinReg();
                    wr.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                    wr.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                    wr.CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;
                    wr.MsgType = MsgType.InnerText;
                    //if (wr.MsgType == "text")
                    //{
                    //    wr.Content = rootElement.SelectSingleNode("Content").InnerText;
                    //    wr.MsgId = rootElement.SelectSingleNode("MsgId").InnerText;
                    //}
                    //else if (wr.MsgType == "location")
                    //{
                    //    wr.Location_X = rootElement.SelectSingleNode("Location_X").InnerText;
                    //    wr.Location_Y = rootElement.SelectSingleNode("Location_Y").InnerText;
                    //    wr.Scale = rootElement.SelectSingleNode("Scale").InnerText;
                    //    wr.Label = rootElement.SelectSingleNode("Label").InnerText;
                    //}
                    //else if (wr.MsgType == "image")
                    //{
                    //    wr.PicUrl = rootElement.SelectSingleNode("PicUrl").InnerText;
                    //}
                    //else if (wr.MsgType == "event")
                    //{
                    //    wr.Wxevent = rootElement.SelectSingleNode("Event").InnerText;
                    //    wr.EventKey = rootElement.SelectSingleNode("EventKey").InnerText;
                    //}

                    if (wr.MsgType == "event")
                    {
                        wr.Wxevent = rootElement.SelectSingleNode("Event").InnerText;
                        wr.EventKey = rootElement.SelectSingleNode("EventKey").InnerText;

                        ResponseMsg(wr);
                    }
                    //回复消息
                }
            }
            else
            {
                Valid();
            }
        }

        private void Valid()
        {
            string echoStr = Request.QueryString["echoStr"];
            if (!string.IsNullOrEmpty(echoStr))
            {
                WriteLog(echoStr);
                
            }
           
            if (CheckSignature())
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    Response.Write(echoStr);
                    Response.End();
                }
            }
        }
        /// <summary>
        /// 验证微信签名
        /// </summary>
        /// * 将token、timestamp、nonce三个参数进行字典序排序
        /// * 将三个参数字符串拼接成一个字符串进行sha1加密
        /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
        /// <returns></returns>
        private bool CheckSignature()
        {
            string signature = Request.QueryString["signature"];
            string timestamp = Request.QueryString["timestamp"];
            string nonce = Request.QueryString["nonce"];
            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 回复消息(微信信息返回)
        /// </summary>
        /// <param name="weixinXML"></param>
        private void ResponseMsg(WeixinReg wr)
        {
            //SysSetting ss = SysSettingService.GetSysSettingById(1);
            //if (ss == null)
            //{
            //    ss = new SysSetting();
            //}
            string resxml = "<xml><ToUserName><![CDATA[" + wr.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + wr.ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime>";
            try
            {
                //if (wr.MsgType == "text")
                //{
                //    string MyAppid = Web.Tool.ConfigHelper.GetConfigAppSetting("WeChatAppId");
                //    string RedirectUri = "http://wxc.zjapps.com/WeChat/WxLogin2.aspx";
                //    string URL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + MyAppid + "&redirect_uri=" + RedirectUri + "&response_type=code&scope=snsapi_userinfo&state=aa#wechat_redirect";
                //    string Str = "<a href='" + URL + "'>授权页面</a>";
                //    resxml += "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + Str + "]]></Content>";

                //}
                //else if (wr.MsgType == "location")
                //{

                //    resxml += "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[你发过来的是地理消息\n哈哈]]></Content>";
                //}
                //else if (wr.MsgType == "image")
                //{
                //    resxml += "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[图片我可不认识哦！]]></Content>";
                //}
                //else if (wr.MsgType == "voice")
                //{
                //    resxml += "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[你说的什么我听不懂！]]></Content>";
                //}
                //else if (wr.MsgType == "event")
                //{
                //    if (wr.Wxevent == "unsubscribe")
                //    {
                //        string fname = wr.FromUserName;
                //        RegUser regUser = RegUserService.GetRegUserByStr(" and WXTokenId = '" + fname + "' ");
                //        if (regUser != null)
                //        {
                //            regUser.IsDel = 1;
                //            RegUserService.ModifyRegUser(regUser);
                //        }
                //    }
                //    else if (wr.Wxevent == "CLICK")
                //    {

                //    }
                //    else if (wr.Wxevent == "subscribe")
                //    {
                //        try
                //        {
                //            string openId = wr.FromUserName.ToString();
                //            string appid = ConfigHelper.GetConfigAppSetting("WeChatAppId");
                //            string wxkey = ConfigHelper.GetConfigAppSetting("WeChatAppSecret");

                //            string token = WeChatUtil.GetAccessToken(1, appid, wxkey);

                //            OAuthonUserMobile OAuthUser_Model = OAuth_MobileToken.GetUser(token, openId);

                //            RegUser regUser = RegUserService.GetRegUserByStr(" and WXTokenId = '" + openId + "' ");
                //            if (regUser == null)
                //            {
                //                regUser = new RegUser();
                //                regUser.RoleId = 0;
                //                regUser.NickName = OAuthUser_Model.nickname;
                //                regUser.Gender = OAuthUser_Model.sex;
                //                regUser.Photo = OAuthUser_Model.headimgurl;

                //                regUser.WXTokenId = openId;
                //                regUser.Status = 0;
                //                regUser.IsDel = 0;
                //                regUser.RegTime = DateTime.Now;
                //                RegUser newReg = RegUserService.AddRegUser(regUser);

                //                #region 11月5号送券
                //                //CouponQuota quota = new CouponQuota();
                //                //quota.UserId = newReg.Id;
                //                //quota.FromTypeId = 1;
                //                //quota.ObjectId = 1;
                //                //quota.Status = 1;
                //                //quota.Amount = 2000;
                //                //quota.Used = 0;
                //                //quota.IsDel = 0;
                //                //quota.AddTime = DateTime.Now;
                //                //DateTime dtime = new DateTime(2016, 12, 5);
                //                //quota.EndTime = dtime;
                //                //CouponQuotaService.AddCouponQuota(quota);
                //                #endregion 11月5号送券结束

                //                RegUser temp = new RegUser();
                //                string comCode = "";
                //                do
                //                {
                //                    comCode = HandleString.GenRndString(6);
                //                    temp = RegUserService.GetRegUserByStr(" and CommendCode = '" + comCode + "' ");
                //                    if (temp == null)
                //                    {
                //                        temp = new RegUser();
                //                    }
                //                } while (Security.ToNum(temp.Id) > 0);
                //                newReg.CommendCode = comCode;
                //                RegUserService.ModifyRegUser(newReg);
                //            }
                //            else
                //            {
                //                regUser.NickName = OAuthUser_Model.nickname;
                //                regUser.Gender = OAuthUser_Model.sex;
                //                regUser.Photo = OAuthUser_Model.headimgurl;

                //                regUser.IsDel = 0;
                //                RegUserService.ModifyRegUser(regUser);
                //            }

                //            resxml += "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[嗨，等你很久了。你为热爱生活而来。回归中国最初的美，带你发现中国精致生活，执匠愿一直陪伴你...]]></Content>";

                //        }
                //        catch (Exception e)
                //        {

                //        }
                //    }
                //}





                if (wr.MsgType == "event")
                {
                    if (wr.Wxevent == "unsubscribe")
                    {
                        string fname = wr.FromUserName;
                        //RegUser regUser = RegUserService.GetRegUserByStr(" and WXTokenId = '" + fname + "' ");
                        //if (regUser != null)
                        //{
                        //    regUser.IsDel = 1;
                        //    RegUserService.ModifyRegUser(regUser);
                        //}
                    }
                    else if (wr.Wxevent == "CLICK")
                    {

                    }
                    else if (wr.Wxevent == "subscribe")
                    {
                        try
                        {
                            string openId = wr.FromUserName.ToString();
                            string appid = ConfigHelper.GetConfigAppSetting("WeChatAppId");
                            string wxkey = ConfigHelper.GetConfigAppSetting("WeChatAppSecret");

                            string token = WeChatUtil.GetAccessToken(1, appid, wxkey);
                            //获取是否关注
                            OAuthonUserMobile OAuthUser_Model = OAuth_MobileToken.GetUser(token, openId);

                            //RegUser regUser = RegUserService.GetRegUserByStr(" and WXTokenId = '" + openId + "' ");


                            SDUser regUser = SDUserService.GetSDUserByStr(" and WxTokenId='" + openId + "' ");

                            if (regUser == null)
                            {
                                regUser = new SDUser();
                                //regUser.RoleId = 0;
                                regUser.NickName = OAuthUser_Model.nickname;
                                regUser.Gender = Security.ToNum(OAuthUser_Model.sex);
                                regUser.Photo = OAuthUser_Model.headimgurl;

                                regUser.WxTokenId = openId;
                                //regUser.Status = 0;
                                regUser.IsDel = 0;
                                regUser.AddTime = DateTime.Now;

                                if (!string.IsNullOrEmpty(openId))
                                {
                                    SDUser newReg = SDUserService.AddSDUser(regUser);
                                    #region 11月5号送券
                                    //CouponQuota quota = new CouponQuota();
                                    //quota.UserId = newReg.Id;
                                    //quota.FromTypeId = 1;
                                    //quota.ObjectId = 1;
                                    //quota.Status = 1;
                                    //quota.Amount = 2000;
                                    //quota.Used = 0;
                                    //quota.IsDel = 0;
                                    //quota.AddTime = DateTime.Now;
                                    //DateTime dtime = new DateTime(2016, 12, 5);
                                    //quota.EndTime = dtime;
                                    //CouponQuotaService.AddCouponQuota(quota);
                                    #endregion 11月5号送券结束

                                    //RegUser temp = new RegUser();
                                    //string comCode = "";
                                    //do
                                    //{
                                    //    comCode = HandleString.GenRndString(6);
                                    //    temp = RegUserService.GetRegUserByStr(" and CommendCode = '" + comCode + "' ");
                                    //    if (temp == null)
                                    //    {
                                    //        temp = new RegUser();
                                    //    }
                                    //} while (Security.ToNum(temp.Id) > 0);
                                    //newReg.CommendCode = comCode;
                                    //RegUserService.ModifyRegUser(newReg);
                                }
                            }
                            else
                            {
                                regUser.NickName = OAuthUser_Model.nickname;
                                regUser.Gender = Security.ToNum(OAuthUser_Model.sex);
                                regUser.Photo = OAuthUser_Model.headimgurl;

                                regUser.IsDel = 0;
                                SDUserService.ModifySDUser(regUser);
                            }
                            //嗨，等你很久了。你为热爱生活而来。回归中国最初的美，带你发现中国精致生活，执匠愿一直陪伴你...
                            //执匠——翡翠源头扫货直播进行中，对翡翠感兴趣的朋友可以前往713观看大屏直播（11：00-13：00），或直接点击进入以下链接参与 http://mudu.tv/?c=activity&a=live&id=25065 
                            resxml += "<MsgType><![CDATA[text]]></MsgType><Content><![CDATA[嗨，等你很久了。你为热爱生活而来。愿夙迪一直陪伴你...]]></Content>";
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            resxml += "<FuncFlag>0</FuncFlag></xml>";
            Response.Write(resxml);
            Response.End();
        }



        private int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }


      

    }
}