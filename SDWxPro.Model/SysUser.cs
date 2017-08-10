using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDWxPro.Model
{
    /// <summary>
    /// 系统管理员
    /// </summary>
    [Serializable()]
    public partial class SysUser
    {
        public SysUser() { }
        #region Model
        private int id;
        public int Id { set { id = value; } get { return id; } }
        private string userName;
        public string UserName { set { userName = value; } get { return userName; } }
        private string passWord;
        public string PassWord { set { passWord = value; } get { return passWord; } }
        private int? levelId;
        public int? LevelId { set { levelId = value; } get { return levelId; } }
        private int? isHidden;
        public int? IsHidden { set { isHidden = value; } get { return isHidden; } }
        private string menuStr;
        public string MenuStr { set { menuStr = value; } get { return menuStr; } }
        private string loginIp;
        public string LoginIp { set { loginIp = value; } get { return loginIp; } }
        private DateTime? loginTime;
        public DateTime? LoginTime { set { loginTime = value; } get { return loginTime; } }
        #endregion Model
    } //end of class
}
