using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace ClassRoom.Model
{
    /// <summary>
    /// 读取数据库对应的视图 'Articles'
    /// </summary>
    [Table(Name = "Articles")]
    [Serializable]
    public class Articles: Notifier
    {
    #region Private Member
        private int _ArticleID;
        private string _ArticleContent;
        private DateTime _UploadTime;
        private int _AUserID;
        private string _ArticleTitle;
    #endregion

    #region Constructor
        public Articles() {}
        
        public Articles(
        int ArticleID,
        string ArticleContent,
        DateTime UploadTime,
        int AUserID,
    string ArticleTitle
        )
        {
         _ArticleID = ArticleID;
         _ArticleContent = ArticleContent;
         _UploadTime = UploadTime;
         _AUserID = AUserID;
         _ArticleTitle = ArticleTitle;
        }
    #endregion

    #region Public Properties
        [Column(Storage="_ArticleID")]
        public int ArticleID
        {
            get { return _ArticleID; }
            set 
            {
                _ArticleID = value; 
                OnPropertyChanged("ArticleID");
            }
        }
        [Column(Storage="_ArticleContent")]
        public string ArticleContent
        {
            get { return _ArticleContent; }
            set 
            {
                _ArticleContent = value; 
                OnPropertyChanged("ArticleContent");
            }
        }
        [Column(Storage="_UploadTime")]
        public DateTime UploadTime
        {
            get { return _UploadTime; }
            set 
            {
                _UploadTime = value; 
                OnPropertyChanged("UploadTime");
            }
        }
        [Column(Storage="_AUserID")]
        public int AUserID
        {
            get { return _AUserID; }
            set 
            {
                _AUserID = value; 
                OnPropertyChanged("AUserID");
            }
        }
        [Column(Storage="_ArticleTitle")]
        public string ArticleTitle
        {
            get { return _ArticleTitle; }
            set 
            {
                _ArticleTitle = value; 
                OnPropertyChanged("ArticleTitle");
            }
        }
    #endregion
    }
}