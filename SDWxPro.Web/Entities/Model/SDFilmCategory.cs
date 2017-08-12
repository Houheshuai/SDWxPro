//SDFilmCategory 表的实体类

//创建日期: 2017/8/10 星期四 10:04:05

using System;
using System.Collections.Generic;
using System.Text;

namespace SDWxPro.Model
{

[Serializable()]
public partial class SDFilmCategory
{
public SDFilmCategory() { }
#region Model
private int id;
public int Id { set { id = value; } get { return id; } }
private string name;
public string Name { set { name = value; } get { return name; } }
private int? isDel;
public int? IsDel { set { isDel = value; } get { return isDel; } }
private int? sort;
public int? Sort { set { sort = value; } get { return sort; } }
private DateTime? addTime;
public DateTime? AddTime { set { addTime = value; } get { return addTime; } }
#endregion Model
    } //end of class
} //end of namespace
