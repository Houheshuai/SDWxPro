//SDUser 表的实体类

//创建日期: 2017/8/8 19:26:15

using System;
using System.Collections.Generic;
using System.Text;

namespace SDWxPro.Model
{

[Serializable()]
public partial class SDUser
{
public SDUser() { }
#region Model
private int id;
public int Id { set { id = value; } get { return id; } }
private string nickName;
public string NickName { set { nickName = value; } get { return nickName; } }
private string photo;
public string Photo { set { photo = value; } get { return photo; } }
private string wxTokenId;
public string WxTokenId { set { wxTokenId = value; } get { return wxTokenId; } }
private int? gender;
public int? Gender { set { gender = value; } get { return gender; } }
private int? isDel;
public int? IsDel { set { isDel = value; } get { return isDel; } }
private string lastLoginIp;
public string LastLoginIp { set { lastLoginIp = value; } get { return lastLoginIp; } }
private DateTime? addTime;
public DateTime? AddTime { set { addTime = value; } get { return addTime; } }
private string realName;
public string RealName { set { realName = value; } get { return realName; } }
private string phone;
public string Phone { set { phone = value; } get { return phone; } }
private string userName;
public string UserName { set { userName = value; } get { return userName; } }
private string password;
public string Password { set { password = value; } get { return password; } }
private string email;
public string Email { set { email = value; } get { return email; } }
#endregion Model
    } //end of class
} //end of namespace
