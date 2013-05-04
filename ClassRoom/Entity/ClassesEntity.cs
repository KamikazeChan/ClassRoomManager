using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace ClassRoom.Model
{
    /// <summary>
    /// 读取数据库对应的视图 'Classes'
    /// </summary>
    [Table(Name = "Classes")]
    [Serializable]
    public class Classes: Notifier
    {
    #region Private Member
        private int _ClassID;
        private int _HeadTeacherID;
        private string _ClassName;
        private string _ClassDecription;
    #endregion

    #region Constructor
        public Classes() {}
        
        public Classes(
        int ClassID,
        int HeadTeacherID,
        string ClassName,
    string ClassDecription
        )
        {
         _ClassID = ClassID;
         _HeadTeacherID = HeadTeacherID;
         _ClassName = ClassName;
         _ClassDecription = ClassDecription;
        }
    #endregion

    #region Public Properties
        [Column(Storage="_ClassID")]
        public int ClassID
        {
            get { return _ClassID; }
            set 
            {
                _ClassID = value; 
                OnPropertyChanged("ClassID");
            }
        }
        [Column(Storage="_HeadTeacherID")]
        public int HeadTeacherID
        {
            get { return _HeadTeacherID; }
            set 
            {
                _HeadTeacherID = value; 
                OnPropertyChanged("HeadTeacherID");
            }
        }
        [Column(Storage="_ClassName")]
        public string ClassName
        {
            get { return _ClassName; }
            set 
            {
                _ClassName = value; 
                OnPropertyChanged("ClassName");
            }
        }
        [Column(Storage="_ClassDecription")]
        public string ClassDecription
        {
            get { return _ClassDecription; }
            set 
            {
                _ClassDecription = value; 
                OnPropertyChanged("ClassDecription");
            }
        }
    #endregion
    }
}