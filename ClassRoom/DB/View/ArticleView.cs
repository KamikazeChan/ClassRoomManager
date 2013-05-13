using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using ClassRoom.DB.EntityModel;
namespace ClassRoom.View
{
    /// <summary>
    /// 读取数据库对应的视图 'Article'
    /// </summary>
    public class ArticleView: Article
    {
        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(Article entity)
        {
                this.ArticleID = entity.ArticleID;
                this.ArticleContent = entity.ArticleContent;
                this.UploadTime = entity.UploadTime;
                this.AUserID = entity.AUserID;
                this.ArticleTitle = entity.ArticleTitle;
        }
    }
}