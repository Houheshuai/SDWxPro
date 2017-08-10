using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace SDWxPro.Tool
{
    /// <summary>
    /// 图片水印类
    /// </summary>
    public class Watermark
    {
        /// <summary>
        /// 在图片上增加文字水印
        /// </summary>
        /// <param name="wtext">水印文字</param>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_sy">生成的带文字水印的图片路径</param>
        public static void AddWater(string wtext, string Path, string Path_sy)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);

            Graphics g = Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            Font f = new Font("Verdana", 60);
            Brush b = new SolidBrush(Color.Green);

            g.DrawString(wtext, f, b, 35, 35);
            g.Dispose();

            image.Save(Path_sy);
            image.Dispose();
        }

        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_syp">生成的带图片水印的图片路径</param>
        /// <param name="Path_sypf">水印图片路径</param>
        /// <param name="loactionId">水印位置</param>
        public static void AddWaterPic(string Path, string Path_syp, string Path_sypf, int loactionId)
        {
            float transparence = 0.5f;//透明度  越小越透明。
            float[][] floatArray = 
            {
                new float[] { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f }, 
                new float[] { 0.0f, 1.0f, 0.0f, 0.0f, 0.0f }, 
                new float[] { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f }, 
                new float[] { 0.0f, 0.0f, 0.0f, transparence, 0.0f },
                new float[] { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f } 
            };
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(new ColorMatrix(floatArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
            Graphics g = Graphics.FromImage(image);
            int x_lc = 0;
            int y_lc = 0;

            int x_lq = image.Width - copyImage.Width;
            int y_lq = image.Height - copyImage.Height;
            if (image.Width - copyImage.Width < 0)
            {
                x_lq = 0;
            }
            if (image.Height - copyImage.Height < 0)
            {
                y_lq = 0;
            }

            switch (loactionId)
            {
                case 2:
                    //左上
                    x_lc = 0;
                    y_lc = 0;
                    break;
                case 3:
                    //右上
                    x_lc = x_lq;
                    y_lc = 0;
                    break;
                case 4:
                    //左下
                    x_lc = 0;
                    y_lc = y_lq;
                    break;
                case 5:
                    //右下
                    x_lc = x_lq;
                    y_lc = y_lq;
                    break;
                case 6:
                    //随机
                    Random rd = new Random();
                    x_lc = rd.Next(0, x_lq);
                    y_lc = rd.Next(0, y_lq);
                    break;
                default:
                    break;
            }
            Rectangle rect = new Rectangle(x_lc, y_lc, copyImage.Width, copyImage.Height);
            g.DrawImage(copyImage, rect, 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel, imageAttributes);
            g.Dispose();
            image.Save(Path_syp);
            image.Dispose();
            imageAttributes.Dispose();
        }
    }
}
