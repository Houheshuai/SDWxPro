using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace SDWxPro.Tool
{
    public partial class CheckAdmin : Page
    {
        public CheckAdmin()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            CheckCookie.CheckAdminCookie();
        }
    }
}
