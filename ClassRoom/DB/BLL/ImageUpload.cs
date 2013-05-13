using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ClassRoom.BLL
{
    /// <summary>
    /// ImageUpload 的摘要说明
    /// </summary>
    public class ImageUpload : UploadBase
    {
        protected static string childPath;
        protected static string imageUploadFileNameFormat;
        protected long sizes;
        protected int width;
        protected int height;

        // 图片大小，单位为KB
        public long Sizes
        {
            get { return sizes; }
            set { sizes = value; }
        }

        // 图片宽度
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        // 图片高度
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public ImageUpload()
        {
            childPath = ConfigurationManager.AppSettings["Images"];
            imageUploadFileNameFormat = ConfigurationManager.AppSettings["ImageUploadFileNameFormat"];
        }

        public bool SaveImage(string imageFileName)
        {
            FileInfo postedFile = new FileInfo(imageFileName);

            string fileName = Guid.NewGuid().ToString();

            sizes = postedFile.Length;

            Image image = Image.FromStream(postedFile.OpenRead());

            width = image.Width;
            height = image.Height;

            base.SaveImageAs(image, Util.CommonHelper.GetImageFormat(postedFile.Extension), childPath, fileName);

            string thumbnailPath = GetThumbanilPath(base.Path, base.Extension, "_t");

            ImageThumbnail.MakeThumbnail(image, thumbnailPath, 100, 80, "W");

            return true;
        }

        public bool SaveImage(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            return SaveImage(image, imageFormat, true);
        }

        public bool SaveImage(System.Drawing.Image image, string fileExtension, bool hasThumbanil)
        {
            return SaveImage(image, Util.CommonHelper.GetImageFormat(fileExtension), hasThumbanil);
        }

        public bool SaveImage(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat imageFormat, bool hasThumbanil)
        {
            string fileName = Guid.NewGuid().ToString();
            base.SaveImageAs(image, imageFormat, childPath, fileName);
            width = image.Width;
            height = image.Height;

            if (hasThumbanil)
            {
                string thumbnailPath = GetThumbanilPath(base.Path, base.Extension, "_t");
                ImageThumbnail.MakeThumbnail(image, thumbnailPath, 100, 80, "W");
            }
            return true;
        }

        public bool SaveImage(System.Collections.Specialized.NameValueCollection Request)
        {
            int width = int.Parse(Request["width"]);
            int height = int.Parse(Request["height"]);
            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Rectangle rect = new Rectangle(0, 0, width, height);

            int iBytes = width * height * 3;//宽*长 *3是因为每一点都需要rgb三种色值填充
            byte[] PixelValues = new byte[iBytes];

            int iPoint = 0;

            bmp.MakeTransparent(Color.White);

            for (int i = 0; i < height; i++)//填充每一行的色值
            {
                try
                {
                    string[] ss = Request["px" + i].Split(','); //解析行数据分组
                    for (int j = 0; j < width; j++)
                    {
                        string values = ss[j];
                        while (values.Length < 6)
                        {
                            values = "0" + values; //位不足填充
                        }
                        string s1, s2, s3;//获取RGB
                        s1 = values.Substring(0, 2);
                        s2 = values.Substring(2, 2);
                        s3 = values.Substring(4, 2);

                        PixelValues[iPoint] = Convert.ToByte(Convert.ToInt32(s1, 16));
                        PixelValues[iPoint + 1] = Convert.ToByte(Convert.ToInt32(s2, 16));
                        PixelValues[iPoint + 2] = Convert.ToByte(Convert.ToInt32(s3, 16));
                        //设置点陈color
                        bmp.SetPixel(j, i, Color.FromArgb(PixelValues[iPoint], PixelValues[iPoint + 1], PixelValues[iPoint + 2]));

                        iPoint += 3;
                    }
                }
                catch
                { }
            }

            return SaveImage(bmp, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private string GetThumbanilPath(string path, string extension, string mark)
        {
            return path.Insert(path.IndexOf(extension), mark);
        }

        public new bool CheckUpload(FileInfo postedFile, int maxSizes, string fileType, out string reason)
        {
            return base.CheckUpload(postedFile, maxSizes, fileType, out reason); ;
        }
    }
}

