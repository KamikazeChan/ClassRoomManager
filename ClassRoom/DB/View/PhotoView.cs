using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using ClassRoom.DB.EntityModel;
using System.IO;
namespace ClassRoom.View
{
    /// <summary>
    /// 读取数据库对应的视图 'Photo'
    /// </summary>
    public class PhotoView: Photo
    {
        public PhotoView(string filename)
        {
            FileInfo info = new FileInfo(filename);
            this.Size = (info.Length / 1024).ToString("N0") + " KB";
            this.UploadTime = info.LastWriteTime;
            this.PhotoName = info.Name;
            this.ImageUri = System.IO.Path.Combine(info.DirectoryName, info.Name);
        }

        public string Size { get; set; }       

        public override string ToString()
        {
            return this.ImageUri;
        }
        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(Photo entity)
        {
                this.PhotoID = entity.PhotoID;
                this.UploadTime = entity.UploadTime;
                this.PhotoName = entity.PhotoName;
                this.Description = entity.Description;
                this.PUserID = entity.PUserID;
        }
    }
}