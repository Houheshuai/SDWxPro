//SDFilm 表的实体类

//创建日期: 2017/8/10 星期四 10:04:05

using System;
using System.Collections.Generic;
using System.Text;

namespace SDWxPro.Model
{

[Serializable()]
public partial class SDFilm
{
public SDFilm() { }
#region Model
private int id;
public int Id { set { id = value; } get { return id; } }
private string linkUrl;
public string LinkUrl { set { linkUrl = value; } get { return linkUrl; } }
private int? isDel;
public int? IsDel { set { isDel = value; } get { return isDel; } }
private int? type;
public int? Type { set { type = value; } get { return type; } }
private DateTime? addTime;
public DateTime? AddTime { set { addTime = value; } get { return addTime; } }
private int? sort;
public int? Sort { set { sort = value; } get { return sort; } }
private string description;
public string Description { set { description = value; } get { return description; } }
private string password;
public string Password { set { password = value; } get { return password; } }
private string name;
public string Name { set { name = value; } get { return name; } }
#endregion Model
    } //end of class
} //end of namespace
