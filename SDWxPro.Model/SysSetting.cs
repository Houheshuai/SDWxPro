using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDWxPro.Model
{
    [Serializable()]
    public partial class SysSetting
    {
        public SysSetting() { }
        #region Model
        private int id;
        public int Id { set { id = value; } get { return id; } }
        private string webName;
        public string WebName { set { webName = value; } get { return webName; } }
        private string webSite;
        public string WebSite { set { webSite = value; } get { return webSite; } }
        private string wxSite;
        public string WxSite { set { wxSite = value; } get { return wxSite; } }
        private string wapSite;
        public string WapSite { set { wapSite = value; } get { return wapSite; } }
        private string mailName;
        public string MailName { set { mailName = value; } get { return mailName; } }
        private string mailPass;
        public string MailPass { set { mailPass = value; } get { return mailPass; } }
        private string mailSmtp;
        public string MailSmtp { set { mailSmtp = value; } get { return mailSmtp; } }
        private int? integralConvert;
        public int? IntegralConvert { set { integralConvert = value; } get { return integralConvert; } }
        private string jsCode;
        public string JsCode { set { jsCode = value; } get { return jsCode; } }
        private string wxTokenKey;
        public string WxTokenKey { set { wxTokenKey = value; } get { return wxTokenKey; } }
        private DateTime? wxTokenTimeOut;
        public DateTime? WxTokenTimeOut { set { wxTokenTimeOut = value; } get { return wxTokenTimeOut; } }

        public int? CustomerCount { get; set; }
        #endregion Model
    } //end of class
}
