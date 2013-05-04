using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace ClassRoom.Model
{
    /// <summary>
    /// 读取数据库对应的视图 'Photos'
    /// </summary>
    [Table(Name = "Photos")]
    [Serializable]
    public class Photos: Notifier
    {
    #region Private Member
        private int _PhotoID;
        private DateTime _UploadTime;
        private string _PhotoName;
        private string _Description;
        private int _PUserID;
    #endregion

    #region Constructor
        public Photos() {}
        
        public Photos(
        int PhotoID,
        DateTime UploadTime,
        string PhotoName,
        string Description,
    int PUserID
        )
        {
         _PhotoID = PhotoID;
         _UploadTime = UploadTime;
         _PhotoName = PhotoName;
         _Description = Description;
         _PUserID = PUserID;
        }
    #endregion

    #region Public Properties
        [Column(Storage="_PhotoID")]
        public int PhotoID
        {
            get { return _PhotoID; }
            set 
            {
                _PhotoID = value; 
                OnPropertyChanged("PhotoID");
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
        [Column(Storage="_PhotoName")]
        public string PhotoName
        {
            get { return _PhotoName; }
            set 
            {
                _PhotoName = value; 
                OnPropertyChanged("PhotoName");
            }
        }
        [Column(Storage="_Description")]
        public string Description
        {
            get { return _Description; }
            set 
            {
                _Description = value; 
                OnPropertyChanged("Description");
            }
        }
        [Column(Storage="_PUserID")]
        public int PUserID
        {
            get { return _PUserID; }
            set 
            {
                _PUserID = value; 
                OnPropertyChanged("PUserID");
            }
        }
    #endregion
    }
}