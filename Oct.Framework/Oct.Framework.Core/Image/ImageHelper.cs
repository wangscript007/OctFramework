using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace Oct.Framework.Core.Image
{
    public static class ImageHelper
    {

        #region 图片格式转换
        /// <summary>
        /// 图片格式转换
        /// </summary>
        /// <param name="OriFilename">原始文件相对路径</param>
        /// <param name="DesiredFilename">生成目标文件相对路径</param>
        /// <returns></returns>
        ///  JPG采用的是有损压缩所以JPG图像有可能会降低图像清晰度，而像素是不会降低的   
        ///  GIF采用的是无损压缩所以GIF图像是不会降低原图图像清晰度和像素的，但是GIF格式只支持256色图像。
        public static bool ConvertImage(string OriFilename, string DesiredFilename)
        {
            string extname = DesiredFilename.Substring(DesiredFilename.LastIndexOf('.') + 1).ToLower();
            ImageFormat DesiredFormat;
            //根据扩张名，指定ImageFormat
            switch (extname)
            {
                case "bmp":
                    DesiredFormat = ImageFormat.Bmp;
                    break;
                case "gif":
                    DesiredFormat = ImageFormat.Gif;
                    break;
                case "jpeg":
                    DesiredFormat = ImageFormat.Jpeg;
                    break;
                case "ico":
                    DesiredFormat = ImageFormat.Icon;
                    break;
                case "png":
                    DesiredFormat = ImageFormat.Png;
                    break;
                default:
                    DesiredFormat = ImageFormat.Jpeg;
                    break;
            }
            try
            {
                System.Drawing.Image imgFile = System.Drawing.Image.FromFile(WebPathTran(OriFilename));
                imgFile.Save(WebPathTran(DesiredFilename), DesiredFormat);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        #region 图片缩放
        /// <summary>
        /// 图片固定大小缩放
        /// </summary>
        /// <param name="OriFileName">源文件相对地址</param>
        /// <param name="DesiredFilename">目标文件相对地址</param>
        /// <param name="IntWidth">目标文件宽</param>
        /// <param name="IntHeight">目标文件高</param>
        /// <param name="imageFormat">图片文件格式</param>
        public static bool ChangeImageSize(string OriFileName, string DesiredFilename, int IntWidth, int IntHeight, ImageFormat imageFormat)
        {
            string SourceFileNameStr = WebPathTran(OriFileName); //来源图片名称路径
            string TransferFileNameStr = WebPathTran(DesiredFilename); //目的图片名称路径
            FileStream myOutput = null;
            try
            {
                System.Drawing.Image.GetThumbnailImageAbort myAbort = new System.Drawing.Image.GetThumbnailImageAbort(imageAbort);
                System.Drawing.Image SourceImage = System.Drawing.Image.FromFile(OriFileName);//来源图片定义
                System.Drawing.Image TargetImage = SourceImage.GetThumbnailImage(IntWidth, IntHeight, myAbort, IntPtr.Zero);  //目的图片定义
                //将TargetFileNameStr的图片放宽为IntWidth，高为IntHeight 
                myOutput = new FileStream(TransferFileNameStr, FileMode.Create, FileAccess.Write, FileShare.Write);
                TargetImage.Save(myOutput, imageFormat);
                myOutput.Close();
                return true;
            }
            catch
            {
                myOutput.Close();
                return false;
            }


        }

        private static bool imageAbort()
        {
            return false;
        }
        #endregion


        #region 文字水印
        /// <summary>
        /// 文字水印
        /// </summary>
        /// <param name="wtext">水印文字</param>
        /// <param name="source">原图片物理文件名</param>
        /// <param name="target">生成图片物理文件名</param>
        public static bool ImageWaterText(string wtext, string source, string target)
        {
            bool resFlag = false;
            System.Drawing.Image image = System.Drawing.Image.FromFile(source);
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                graphics.DrawImage(image, 0, 0, image.Width, image.Height);
                Font font = new System.Drawing.Font("Verdana", 60);
                Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
                graphics.DrawString(wtext, font, brush, 35, 35);
                image.Save(target);
                resFlag = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                graphics.Dispose();
                image.Dispose();

            }
            return resFlag;
        }


        #endregion


        #region 图片水印

        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_syp">生成的带图片水印的图片路径</param>
        /// <param name="Path_sypf">水印图片路径</param>
        public static bool ImageWaterPic(string source, string target, string waterPicSource)
        {
            bool resFlag = false;
            System.Drawing.Image sourceimage = System.Drawing.Image.FromFile(source);
            Graphics sourcegraphics = Graphics.FromImage(sourceimage);
            System.Drawing.Image waterPicSourceImage = System.Drawing.Image.FromFile(waterPicSource);
            try
            {
                sourcegraphics.DrawImage(waterPicSourceImage, new System.Drawing.Rectangle(sourceimage.Width - waterPicSourceImage.Width, sourceimage.Height - waterPicSourceImage.Height, waterPicSourceImage.Width, waterPicSourceImage.Height), 0, 0, waterPicSourceImage.Width, waterPicSourceImage.Height, GraphicsUnit.Pixel);
                sourceimage.Save(target);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sourcegraphics.Dispose();
                sourceimage.Dispose();
                waterPicSourceImage.Dispose();
            }
            return resFlag;

        }

        #endregion


        /// <summary>
        /// 路径转换（转换成绝对路径）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string WebPathTran(string path)
        {
            try
            {
                return HttpContext.Current.Server.MapPath(path);
            }
            catch
            {
                return path;
            }
        }

        /// <summary>
        /// 通用缩略图
        /// </summary>
        /// <param name="originalImagePath"></param>
        /// <param name="thumbnailPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="mode"></param>
        /// <param name="type"></param>
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height,
             string mode, string type)
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
                case "HW": //指定高宽缩放（可能变形） 
                    break;
                case "W": //指定宽，高按比例 
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H": //指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut": //指定高宽裁减（不变形） 
                    if (originalImage.Width / (double)originalImage.Height > towidth / (double)toheight)
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
                case "DB": //等比缩放（不变形，如果高大按高，宽大按宽缩放） 
                    if (originalImage.Width / (double)towidth < originalImage.Height / (double)toheight)
                    {
                        toheight = height;
                        towidth = originalImage.Width * height / originalImage.Height;
                    }
                    else
                    {
                        towidth = width;
                        toheight = originalImage.Height * width / originalImage.Width;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new Bitmap(towidth, toheight);
            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);

            try
            {
                //保存缩略图
                if (type == "JPG")
                {
                    bitmap.Save(thumbnailPath, ImageFormat.Jpeg);
                }
                if (type == "BMP")
                {
                    bitmap.Save(thumbnailPath, ImageFormat.Bmp);
                }
                if (type == "GIF")
                {
                    bitmap.Save(thumbnailPath, ImageFormat.Gif);
                }
                if (type == "PNG")
                {
                    bitmap.Save(thumbnailPath, ImageFormat.Png);
                }
            }
            catch (Exception e)
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
    }
}
