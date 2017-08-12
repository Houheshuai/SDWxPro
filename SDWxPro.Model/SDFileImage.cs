//SDFileImage 表的实体类

//创建日期: 2017/8/10 星期四 10:04:05

using System;
using System.Collections.Generic;
using System.Text;

namespace SDWxPro.Model
{

[Serializable()]
public partial class SDFileImage
{
public SDFileImage() { }
#region Model
private int id;
public int Id { set { id = value; } get { return id; } }
private string imageUrl;
public string ImageUrl { set { imageUrl = value; } get { return imageUrl; } }
private int? isDel;
public int? IsDel { set { isDel = value; } get { return isDel; } }
private int? sort;
public int? Sort { set { sort = value; } get { return sort; } }
private int? isMain;
public int? IsMain { set { isMain = value; } get { return isMain; } }
private int? sDFileId;
public int? SDFileId { set { sDFileId = value; } get { return sDFileId; } }
private DateTime? addTime;
public DateTime? AddTime { set { addTime = value; } get { return addTime; } }
#endregion Model
    } //end of class
} //end of namespace
