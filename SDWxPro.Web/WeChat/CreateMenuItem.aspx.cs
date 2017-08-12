using SDWxPro.Tool;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDWxPro.Web.WeChat
{
    public partial class CreateMenuItem : System.Web.UI.Page
    {
        int sid = 0;
        int menuid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            sid = Security.ToNum(Request["sid"]);

            string appid = ConfigurationManager.AppSettings["WeChatAppId"].ToString();
            string secret = ConfigurationManager.AppSettings["WeChatAppSecret"].ToString();

            if (sid == 0) //创建菜单
            {
                try
                {
                    string postUrl = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";
                    postUrl = string.Format(postUrl, Web.WeChatUtil.GetAccessToken(1, appid, secret));
                    string menuInfo = getMenuInfo();
                    string str = Web.WeChatUtil.PostWebRequest(postUrl, menuInfo);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Dictionary<string, object> dic = (Dictionary<string, object>)js.DeserializeObject(str);
                    if (dic["errcode"].ToString() == "0")
                    {
                        JsUtil.ShowMsg("创建成功！");
                    }
                    else
                    {
                        string errcode = dic["errcode"].ToString();
                        string msg = dic["errmsg"].ToString();
                        JsUtil.ShowMsg("系统错误:" + msg + "");
                    }
                }
                catch (Exception ex)
                {
                    //错误处理
                }
            }
            else if (sid == 1) //删除菜单
            {
                try
                {
                    string postUrl = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";
                    postUrl = string.Format(postUrl, Web.WeChatUtil.GetAccessToken(1, appid, secret));
                    string menuInfo = getMenuInfo();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string str = Web.WeChatUtil.PostWebRequest(postUrl, menuInfo);
                    Dictionary<string, object> dic = (Dictionary<string, object>)js.DeserializeObject(str);
                    if (dic["errcode"].ToString() == "0")
                    {
                        JsUtil.ShowMsg("删除成功！");
                    }
                    else
                    {
                        string msg = dic["errmsg"].ToString();
                        JsUtil.ShowMsg("系统错误:" + msg + "");
                    }
                }
                catch (Exception ex)
                {
                    //错误处理
                }



            }
        }

        private string getMenuInfo()
        {
            string strs = "";
            //strs = "{\"button\":[{\"type\":\"click\",\"name\":\"今日歌曲\",\"key\":\"V1001_TODAY_MUSIC\"},{\"name\":\"菜单\",\"sub_button\":[{\"type\":\"view\",\"name\":\"搜索\",\"url\":\"http://www.soso.com/\"},{\"type\":\"view\",\"name\":\"视频\",\"url\":\"http://v.qq.com\"},{\"type\":\"click\",\"name\":\"赞一下我们\",\"key\":\"V1001_GOOD\"}]}]}";


            strs = "{\"button\":[{\"type\":\"click\",\"name\":\"资源\",\"key\":\"V1001_TODAY_MUSIC\"},{\"name\":\"菜单\",\"sub_button\":[{\"type\":\"view\",\"name\":\"影视资源\",\"url\":\"http://wx.sudiny.ltd/FilmList.aspx?m=wap&c=index&a=wx_movie&flag=1\"}]}]}";
            return strs;
        }
    }


    
}