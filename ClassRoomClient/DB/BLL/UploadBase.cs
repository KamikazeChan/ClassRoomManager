using System;
using System.Web;
using System.IO;
using System.Configuration;
using ClassRoom.Enum;
using ClassRoom.Model;

namespace ClassRoom.BLL
{
    public class UploadBase
    {
        protected const string UPLOADERROR_FILETYPE = "文件{0}错误,只支持{1}类型的文件上传！";
        protected const string UPLOADERROR_FILESIZES = "文件{0}错误,上传文件只能小于{1}KB！";

        protected const string TEMPLATES_FORDERPATH = @"{0}\{1}";
        protected const string TEMPLATES_FILEPATH = @"{0}\{1}{2}";

        protected string rootPath = null;
        protected string rootFolder = null;//上传文件根文件夹
        protected string folderFormat = null;//格式化方式创建保存文件的文件夹


        public string RootFolder
        {
            get { return string.Format(TEMPLATES_FORDERPATH, rootPath, rootFolder); }
        }

        public string FolderName { get; set; }

        // 上传成功后的Url
        public string Url{get;set;}

        // 上传成功后的Path 物理路径
        public string Path { get; set; }

        // 文件扩展名
        public string Extension { get; set; }

        // 构造函数，初始化变量
        public UploadBase()
        {
            rootPath = @"E:\要看的书\ClassRoom\服务端图片";
            //if (System.Web.HttpContext.Current != null)
            //{
            //    //rootPath = System.Web.HttpContext.Current.Server.MapPath("~");
            //    rootPath = @"E:\要看的书\ClassRoom\服务端图片";
            //}
            //else {
            //    rootPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            //}

            rootFolder = ConfigurationManager.AppSettings["RootForder"];
            folderFormat = ConfigurationManager.AppSettings["FileUploadFolderFormat"];
        }

        public void UploadFile(FileProperty file, Stream stream, int sysUserID)
        {
            Guid serverFileName = Guid.NewGuid();
            bool result = SaveAs(string.Empty, serverFileName.ToString(), stream, file.Length); ;
        }

        private Stream GetFile(Guid ID)
        {
            if (ID == Guid.Empty) return null;

            string filePath = string.Format("{0}\\{1}\\{2}", RootFolder
                , @"E:\要看的书\ClassRoom\图片", "annon");

            if (File.Exists(filePath))
            {
                byte[] data = File.ReadAllBytes(filePath);
                MemoryStream ms = new MemoryStream(data);
                return ms;
            }
            return null;
        }

        private string GetFileServerPath(Guid FileInfoID)
        {
            if (FileInfoID == Guid.Empty) return null;

            return string.Format(@"{0}\\{1}\\{2}", RootFolder
                , @"E:\要看的书\ClassRoom\服务端图片", "服务端");

        }       

        protected bool SaveAs(string childFolder, string saveFileName, Stream stream, long length)
        {
            bool result = false;
            FileStream fs = null;
            try
            {
                //获取相对路径
                string saveFileFolderUrl = GetSaveFileFolderUrl(childFolder, folderFormat);

                //获取保存文件夹路径
                string saveFileFolderPath = string.Format(TEMPLATES_FORDERPATH, rootPath, saveFileFolderUrl);               

                Url = string.Format(TEMPLATES_FILEPATH, saveFileFolderPath, saveFileName, string.Empty);
                
                byte[] buffer = new byte[length];
                stream.Read(buffer, 0, buffer.Length);  //将流的内容读到缓冲区

                fs = new FileStream(Url, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(buffer, 0, buffer.Length - 1);
                fs.Flush();
                result = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }
            }
            return result;
        }

        public bool SaveImageAs(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat imageFormat, string childFolder, string saveFileName)
        {
            try
            {
                if (image != null)
                {
                    //获取相对路径
                    string saveFileFolderUrl = GetSaveFileFolderUrl(childFolder, folderFormat);

                    //获取保存文件夹路径
                    string saveFileFolderPath = string.Format(TEMPLATES_FORDERPATH, rootPath, saveFileFolderUrl);

                    if (!Directory.Exists(saveFileFolderPath))
                        Directory.CreateDirectory(saveFileFolderPath);


                    //获得原文件展名
                    string saveFileExtension = GetExtension(imageFormat);

                    string saveFilePath = string.Format(TEMPLATES_FILEPATH, saveFileFolderPath, saveFileName, saveFileExtension);

                    image.Save(saveFilePath, imageFormat);
                    //this.Url = string.Format(TEMPLATES_FILEPATH, saveFileFolderUrl, saveFileName, saveFileExtension);
                    this.Path = saveFilePath;
                    this.Extension = saveFileExtension;
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected string GetExtension(System.Drawing.Imaging.ImageFormat imageFormat)
        {
            string fileExtension = ".bmp";
            if (imageFormat == System.Drawing.Imaging.ImageFormat.Bmp)
            {
                fileExtension = ".bmp";
            }
            else if (imageFormat == System.Drawing.Imaging.ImageFormat.Jpeg)
            {
                fileExtension = ".jpg";
            }
            else if (imageFormat == System.Drawing.Imaging.ImageFormat.Gif)
            {
                fileExtension = ".gif";
            }
            else if (imageFormat == System.Drawing.Imaging.ImageFormat.Png)
            {
                fileExtension = ".png";
            }

            return fileExtension;
        }

        /// <summary>
        /// 获取要上传到文件夹的文件夹URL，不存在则创建
        /// </summary>
        /// <param name="childFolder"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        protected string GetSaveFileFolderUrl(string childFolder, string format)
        {
            string folderUrl = null;
            string childFolderUrl = string.Format(TEMPLATES_FORDERPATH, rootFolder, childFolder);
            string childFolderPath = string.Format(TEMPLATES_FORDERPATH, rootPath, childFolderUrl);

            try
            {
                System.IO.DirectoryInfo childDir = new System.IO.DirectoryInfo(childFolderPath);
                if (!childDir.Exists)
                     childDir.Create();

                    //FolderName = ClassRoom.Common.CommonClass.UserTicket.UserInfo.UserID.ToString();
                    FolderName = "4";
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(string.Format(TEMPLATES_FORDERPATH, childFolderPath, FolderName));
                    if (!dir.Exists)
                        dir.Create();

                    folderUrl = string.Format(TEMPLATES_FORDERPATH, childFolderUrl, FolderName);
                    return folderUrl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检测上传的合法性
        /// </summary>
        /// <param name="postedFile"></param>
        /// <param name="maxSizes"></param>
        /// <param name="fileType"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        protected bool CheckUpload(FileInfo postedFile, int maxSizes, string fileType, out string reason)
        {
            reason = null;
            if (!CheckExtension(postedFile.FullName, fileType))
            {
                reason = string.Format(UPLOADERROR_FILETYPE, postedFile.FullName, fileType);
                return false;
            }
            if (postedFile.Length > maxSizes * 1024)
            {
                reason = string.Format(UPLOADERROR_FILESIZES, postedFile.FullName, maxSizes);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检测允许上传的文件类型
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        private bool CheckExtension(string fileName, string fileType)
        {
            bool flag = false;
            string fileExtension = System.IO.Path.GetExtension(fileName);
            //分解允许上传文件的格式
            if (fileExtension != "")
            {
                fileExtension = fileExtension.ToLower();//转化为小写
            }
            string[] temp = fileType.Split('|');
           
            //判断上传的文件是否是允许的格式
            foreach (string data in temp)
            {
                if (("." + data) == fileExtension)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}