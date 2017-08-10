using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace SDWxPro.Tool
{
   public class PageHelper
    {
       public static void WriteScript(Page page, string script)
       {
           page.ClientScript.RegisterClientScriptBlock(typeof(Page), Guid.NewGuid().ToString(), script, true);
       }
    }
}
