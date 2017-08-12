using SDWxPro.Service;
using SDWxPro.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SDWxPro.Web.ashx
{
    /// <summary>
    /// getFileList 的摘要说明
    /// </summary>
    public class getFileList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var type = RequestHelper.GetParamValue("type", "get");
            var page = RequestHelper.GetParamValue("page", "get");
            if (!string.IsNullOrEmpty(type)&&!string.IsNullOrEmpty(page))
            {
                int totalRecord = 0;
                var list = ProcedureService.GetDataTableProce("SDFilm", "*", " Sort asc, Id asc ", "  IsDel=0 and Type="+type, Security.ToNum(12), Security.ToNum(page), out totalRecord);
                if (list!=null&&list.Rows.Count>0)
                {
                    List<ResultEntity> resutList = new List<ResultEntity>();

                    ResultEntity entity = null;
                    foreach (DataRow item in list.Rows)
                    {
                        entity = new ResultEntity();
                        entity.flag = Security.ToStr(item["Type"]);
                        entity.title = Security.ToStr(item["Name"]);
                        entity.keyword = Security.ToStr(item["Name"]);
                        entity.page = page;
                        entity.sum = Security.ToStr(Security.ToNum(Math.Ceiling(Security.ToDouble(totalRecord) / 12)));
                        entity.image = GetMainImage(Security.ToNum(item["Id"]));


                        resutList.Add(entity);
                    }
                   var json= JsonHelper.Instance.Serialize(resutList);
                   context.Response.Write(json);
                   return;
                }
            }
            else
            {
                context.Response.Write("");
            }
                    
        }
        public string GetMainImage(int fileId)
        {
            var imgUrl = "";
            var imgModel = SDFileImageService.GetSDFileImageByStr(" and IsDel=0 and IsMain=1 and SDFileId=" + fileId + " order by Sort asc");
            if (imgModel != null)
            {
                imgUrl = Security.ToStr(imgModel.ImageUrl);
            }
            return imgUrl;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }


  
    class ResultEntity {

        public string title { get; set; }
        public string keyword { get; set; }
        public string flag { get; set; }
        public string image { get; set; }
        public string sum { get; set; }
        public string page { get; set; }
    }
}