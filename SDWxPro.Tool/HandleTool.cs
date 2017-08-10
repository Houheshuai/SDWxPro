using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SDWxPro.Tool
{
    /// <summary>
    /// 常用程序处理工具
    /// </summary>
    public class HandleTool : IHttpHandler
    {
        /// <summary>
        /// 图片防盗链
        /// </summary>
        /// <param name="context">图片路径</param>
        public static void ProcessRequest(HttpContext context)
        {
            string FileName = context.Server.MapPath(context.Request.FilePath);
            if (context.Request.UrlReferrer.Host == null)
            {
                context.Response.ContentType = "image/JPEG";
                context.Response.WriteFile("~/images/no.png");//被替换图片 
            }
            else
            {
                if (context.Request.UrlReferrer.Host.IndexOf("localhost") > -1)//这里是你的域名 
                {
                    context.Response.ContentType = "image/JPEG";
                    context.Response.WriteFile(FileName);
                }
                else
                {
                    context.Response.ContentType = "image/JPEG";
                    context.Response.WriteFile("~/images/no.png");
                }
            }
        }

        /// <summary>
        /// 裁切图片
        /// </summary>
        /// <param name="originalImagePath">原图位置</param>
        /// <param name="thumbnailPath">新图位置</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <param name="mode">裁切模式（指定最高宽度和最高高度、指定高宽缩放、指定宽，高按比例、指定高，宽按比例、指定高宽裁减）</param>
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "WorH": //指定最大宽度和最大高度（不变形）
                    int htemp = originalImage.Height * width / originalImage.Width;
                    int wtemp = originalImage.Width * height / originalImage.Height;
                    if (wtemp > width)
                    {
                        toheight = originalImage.Height * width / originalImage.Width;
                    }
                    else if (htemp > height)
                    {
                        towidth = originalImage.Width * height / originalImage.Height;
                    }
                    break;
                case "HW"://指定高宽缩放（可能变形） 
                    break;
                case "W"://指定宽，高按比例 
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形） 
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }


            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充Transparent
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分towidth, toheight
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }

        #region IHttpHandler 成员

        bool IHttpHandler.IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
