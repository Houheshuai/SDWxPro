using SDWxPro.Model;
using SDWxPro.Service;
using SDWxPro.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDWxPro.Web
{
    public partial class FilmList : System.Web.UI.Page
    {
        public string flag = "0";
        protected void Page_Load(object sender, EventArgs e)
        {

            flag = Security.ToStr(RequestHelper.GetParamValue("flag", "Get"));
            int totalRecord = 0;
            var list = ProcedureService.GetDataTableProce("SDFilm", "*", " Sort asc, Id asc ", "  IsDel=0 and Type=" + flag, 12, 1, out totalRecord);
            if (list != null && list.Rows.Count > 0)
            {
                this.rpFilm.DataSource = list;
                this.rpFilm.DataBind();
            }

        }


        public string GetType(int type)
        {
            var resType = "";

            var list = SDFilmCategoryService.GetSDFilmCategorysByStr("");
            if (list != null && list.Rows.Count > 0)
            {
                foreach (DataRow row in list.Rows)
                {
                    if (Security.ToNum(row["Id"]) == type)
                    {
                        resType = Security.ToStr(row["Name"]);
                    }
                }
            }

            return resType;


        }


        public string GetMainImage(int fileId)
        {
            var imgUrl = "";
            var imgModel = SDFileImageService.GetSDFileImageByStr(" and IsDel=0 and IsMain=1 and SDFileId=" + fileId + " order by Sort asc");
            if (imgModel!=null)
            {
                imgUrl = Security.ToStr(imgModel.ImageUrl);
            }
            return imgUrl;
        }
    }
}