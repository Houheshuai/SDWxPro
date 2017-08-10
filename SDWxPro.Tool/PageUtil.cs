using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace SDWxPro.Tool
{
    public class PageUtil
    {
        /// <summary>
        /// 后台存诸过程分页，新样式
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="total"></param>
        /// <param name="str_condition"></param>
        /// <returns></returns>
        public static string GetPageNumHt(Int32 pagesize, Int32 total, string str_condition)
        {
            string str_programme_name = HttpContext.Current.Request.CurrentExecutionFilePath;
            Int32 page;
            page = Security.ToNum(HttpContext.Current.Request["page"]);
            Int32 allpage = 0;
            if (page < 1) { page = 1; }
            //计算总页数
            if (pagesize != 0)
            {
                allpage = (total / pagesize);
                allpage = ((total % pagesize) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }

            if (page > allpage) page = allpage; //如果地址栏中的page数大于最大页面数

            Int32 next = 0;
            Int32 pre = 0;
            Int32 startcount = 0;
            Int32 endcount = 0;
            StringBuilder pagestr = new StringBuilder();


            next = page + 1;
            pre = page - 1;

            if (page % 3 == 0)
            {
                startcount = (Security.ToNum(((page - 3)) / 3) * 3 + 1);
            }
            else
            {
                startcount = (Security.ToNum(page / 3) * 3 + 1);
            }


            //中间页终止序号

            if (page % 3 == 0)
            {
                endcount = (Security.ToNum((page - 3) / 3) * 3 + 3);
            }
            else
            {
                endcount = (Security.ToNum(page / 3) * 3 + 3);
            }
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内


            if (page > 1)
            {
                pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=1\" class=\"prev1\"></a>");
                pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + pre + "\" class=\"prev\"></a>");
            }
            else
            {
                pagestr.Append("<a href=\"javascript:;\" class=\"prev1\"></a>");
                pagestr.Append("<a href=\"javascript:;\" class=\"prev\"></a>");
            }

            if (page > 3 && allpage > 3)
            {
                if ((Security.ToNum(page / 3) * 3) > 0)
                {
                    if (page % 3 == 0)
                    {
                        pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum((page - 3) / 3) * 3) + "\">...</a>");
                    }
                    else
                    {
                        pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3) + "\">...</a>");
                    }
                }
            }

            //中间页处理，这个增加时间复杂度，减小空间复杂度
            for (int i = startcount; i <= endcount; i++)
            {
                if (page == i)
                {
                    pagestr.Append("<a href=\"javascript:;\" class=\"active\">" + i + "</a>");
                }
                else
                {
                    pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + i + "\">" + i + "</a>");
                }
            }

            if (allpage - page >= 3)
            {
                if (page >= 3)
                {
                    if (page % 3 == 0)
                    {
                        pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3 + 1) + "\">...</a>");
                    }
                    else
                    {
                        pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3 + 4) + "\">...</a>");
                    }
                }
                else
                {
                    pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3 + 4) + "\">...</a>");
                }
            }
            else
            {
                if (page % 3 == 0 && allpage != 3)
                {
                    pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3 + 1) + "\">...</a>");
                }
                else
                {
                    if (allpage > page && allpage != 3 && allpage > 3)
                    {
                        pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3 + 4) + "\">...</a>");
                    }
                }
            }

            if (page != allpage)
            {
                pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + next + "\" class=\"next\"></a>");
                pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + allpage + "\" class=\"next1\"></a>");
            }
            else
            {
                pagestr.Append("<a href=\"javascript:;\" class=\"next\"></a>");
                pagestr.Append("<a href=\"javascript:;\" class=\"next1\"></a>");
            }
            return pagestr.ToString();
        }

        /// <summary>
        /// 存诸过程分页，Ajax调用
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="total"></param>
        /// <param name="str_condition"></param>
        /// <returns></returns>
        public static string GetPageProAjax(Int32 pagesize, Int32 total, Int32 page)
        {
            string str_programme_name = HttpContext.Current.Request.CurrentExecutionFilePath;
            Int32 allpage = 0;
            if (page < 1) { page = 1; }
            //计算总页数
            if (pagesize != 0)
            {
                allpage = (total / pagesize);
                allpage = ((total % pagesize) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }

            if (page > allpage) page = allpage; //如果地址栏中的page数大于最大页面数

            Int32 next = 0;
            Int32 pre = 0;
            StringBuilder pagestr = new StringBuilder();

            next = page + 1;
            pre = page - 1;

            //中间页处理，这个增加时间复杂度，减小空间复杂度
            if (page != allpage)
            {
                pagestr.Append("" + next + "");
            }
            else
            {
                pagestr.Append("0");
            }
            return pagestr.ToString();
        }


        /// <summary>
        /// 普通分页 - 后台样式
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="datalistname"></param>
        /// <param name="pagesize"></param>
        /// <param name="str_u_loginName"></param>
        /// <param name="str_u_email"></param>
        /// <returns></returns>
        public static string GetPageNumsHt(DataTable dt, Repeater datalistname, int pagesize, string str_condition)
        {
            string str_programme_name = HttpContext.Current.Request.CurrentExecutionFilePath;

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = dt.DefaultView;
            objPds.AllowPaging = true;
            int total = dt.Rows.Count;
            objPds.PageSize = pagesize;
            int page;
            if (HttpContext.Current.Request.QueryString["page"] != null)
                page = Security.ToNum(HttpContext.Current.Request.QueryString["page"]);
            else
                page = 1;

            string str_temp_page = HttpContext.Current.Request.QueryString["page"];
            if (!string.IsNullOrEmpty(str_temp_page))
            {
                page = Security.ToNum(str_temp_page);
            }
            else
            {
                page = 1;
            }
            int allpage = 0;
            if (page < 1) { page = 1; }
            //计算总页数
            if (pagesize != 0)
            {
                allpage = (total / pagesize);
                allpage = ((total % pagesize) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }

            if (page > allpage) page = allpage; //如果地址栏中的page数大于最大页面数

            objPds.CurrentPageIndex = page - 1;
            datalistname.DataSource = objPds;
            datalistname.DataBind();

            Int32 next = 0;
            Int32 pre = 0;
            Int32 startcount = 0;
            Int32 endcount = 0;
            StringBuilder pagestr = new StringBuilder();


            next = page + 1;
            pre = page - 1;

            if (page % 3 == 0)
            {
                startcount = (Security.ToNum(((page - 3)) / 3) * 3 + 1);
            }
            else
            {
                startcount = (Security.ToNum(page / 3) * 3 + 1);
            }


            //中间页终止序号

            if (page % 3 == 0)
            {
                endcount = (Security.ToNum((page - 3) / 3) * 3 + 3);
            }
            else
            {
                endcount = (Security.ToNum(page / 3) * 3 + 3);
            }
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内


            if (page > 1)
            {
                pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=1\" class=\"prev1\"></a>");
                pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + pre + "\" class=\"prev\"></a>");
            }
            else
            {
                pagestr.Append("<a href=\"javascript:;\" class=\"prev1\"></a>");
                pagestr.Append("<a href=\"javascript:;\" class=\"prev\"></a>");
            }

            if (page > 3 && allpage > 3)
            {
                if ((Security.ToNum(page / 3) * 3) > 0)
                {
                    if (page % 3 == 0)
                    {
                        pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum((page - 3) / 3) * 3) + "\">...</a>");
                    }
                    else
                    {
                        pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3) + "\">...</a>");
                    }
                }
            }

            //中间页处理，这个增加时间复杂度，减小空间复杂度
            for (int i = startcount; i <= endcount; i++)
            {
                if (page == i)
                {
                    pagestr.Append("<a href=\"javascript:;\" class=\"active\">" + i + "</a>");
                }
                else
                {
                    pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + i + "\">" + i + "</a>");
                }
            }

            if (allpage - page >= 3)
            {
                if (page >= 3)
                {
                    if (page % 3 == 0)
                    {
                        pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3 + 1) + "\">...</a>");
                    }
                    else
                    {
                        pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3 + 4) + "\">...</a>");
                    }
                }
                else
                {
                    pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3 + 4) + "\">...</a>");
                }
            }
            else
            {
                if (page % 3 == 0)
                {
                    pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3 + 1) + "\">...</a>");
                }
                else
                {
                    if (allpage > page)
                    {
                        pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + (Security.ToNum(page / 3) * 3 + 4) + "\">...</a>");
                    }
                }
            }

            if (page != allpage)
            {
                pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + next + "\" class=\"next\"></a>");
                pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + allpage + "\" class=\"next1\"></a>");
            }
            else
            {
                pagestr.Append("<a href=\"javascript:;\" class=\"next\"></a>");
                pagestr.Append("<a href=\"javascript:;\" class=\"next1\"></a>");
            }
            return pagestr.ToString();
        }

        /// <summary>
        /// 存诸过程普通分页
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="total"></param>
        /// <param name="str_condition"></param>
        /// <returns></returns>
        public static string GetPageNum(Int32 pagesize, Int32 total, string str_condition)
        {
            string str_programme_name = HttpContext.Current.Request.CurrentExecutionFilePath;
            Int32 page;
            page = Security.ToNum(HttpContext.Current.Request["page"]);
            Int32 allpage = 0;
            if (page < 1) { page = 1; }
            //计算总页数
            if (pagesize != 0)
            {
                allpage = (total / pagesize);
                allpage = ((total % pagesize) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }

            if (page > allpage) page = allpage; //如果地址栏中的page数大于最大页面数

            Int32 next = 0;
            Int32 pre = 0;
            Int32 startcount = 0;
            Int32 endcount = 0;
            StringBuilder pagestr = new StringBuilder();

            next = page + 1;
            pre = page - 1;
            startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
            //中间页终止序号
            endcount = page < 5 ? 10 : page + 5;
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内


            if (page > 1)
            {
                pagestr.Append("<a class=\"prev\" href=\"" + str_programme_name + "?" + str_condition + "&page=" + pre + "\" title=\"上一页\"></a>");
            }
            else
            {
                pagestr.Append("<a class=\"prev\" href=\"javascript:void(0);\" title=\"上一页\"></a>");
            }

            //中间页处理，这个增加时间复杂度，减小空间复杂度
            for (int i = startcount; i <= endcount; i++)
            {
                if (page == i)
                {
                    pagestr.Append("<a class=\"current\" href=\"javascript:void(0);\">" + i + "</a>");
                }
                else
                {
                    pagestr.Append("<a class=\"\" href=\"" + str_programme_name + "?" + str_condition + "&page=" + i + "\">" + i + "</a>");
                }
            }

            if (page != allpage)
            {
                pagestr.Append("<a href=\"" + str_programme_name + "?" + str_condition + "&page=" + next + "\" class=\"next\"></a>");
            }
            else
            {
                pagestr.Append("<a href=\"javascript:void(0);\" class=\"next\"></a>");
            }

            return pagestr.ToString();
        }

        /// <summary>
        /// 前台存诸过程普通分页
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="total"></param>
        /// <param name="str_condition"></param>
        /// <returns></returns>
        public static string GetPageNumWjt(string pname, Int32 pagesize, Int32 total, string str_condition)
        {
            Int32 page;
            page = Security.ToNum(HttpContext.Current.Request["page"]);
            Int32 allpage = 0;
            if (page < 1) { page = 1; }
            //计算总页数
            if (pagesize != 0)
            {
                allpage = (total / pagesize);
                allpage = ((total % pagesize) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }

            if (page > allpage) page = allpage; //如果地址栏中的page数大于最大页面数

            Int32 next = 0;
            Int32 pre = 0;
            Int32 startcount = 0;
            Int32 endcount = 0;
            StringBuilder pagestr = new StringBuilder();

            next = page + 1;
            pre = page - 1;
            startcount = (page + 5) > allpage ? allpage - 9 : page - 4;//中间页起始序号
            //中间页终止序号
            endcount = page < 5 ? 10 : page + 5;
            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; } //页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内


            if (page > 1)
            {
                pagestr.Append("<a class=\"prev\" href=\"/" + pname + "/" + str_condition + "-" + pre + ".html\" title=\"上一页\">&lt;</a>");
            }
            else
            {
                pagestr.Append("<a class=\"prev\" href=\"javascript:void(0);\" title=\"上一页\">&lt;</a>");
            }

            //中间页处理，这个增加时间复杂度，减小空间复杂度
            for (int i = startcount; i <= endcount; i++)
            {
                if (page == i)
                {
                    pagestr.Append("<a class=\"current\" href=\"javascript:void(0);\">" + i + "</a>");
                }
                else
                {
                    pagestr.Append("<a class=\"\" href=\"/" + pname + "/" + str_condition + "-" + i + ".html\">" + i + "</a>");
                }
            }

            if (page != allpage)
            {
                pagestr.Append("<a href=\"/" + pname + "/" + str_condition + "-" + next + ".html\" class=\"next\">&gt;</a>");
            }
            else
            {
                pagestr.Append("<a href=\"javascript:void(0);\" class=\"next\">&gt;</a>");
            }

            return pagestr.ToString();
        }

    }
}
