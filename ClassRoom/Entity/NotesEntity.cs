using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace ClassRoom.Model
{
    /// <summary>
    /// 读取数据库对应的视图 'Notes'
    /// </summary>
    [Table(Name = "Notes")]
    [Serializable]
    public class Notes: Notifier
    {
    #region Private Member
        private int _NoteID;
        private string _Body;
        private DateTime _Addtime;
        private string _Title;
        private int _NUserID;
    #endregion

    #region Constructor
        public Notes() {}
        
        public Notes(
        int NoteID,
        string Body,
        DateTime Addtime,
        string Title,
    int NUserID
        )
        {
         _NoteID = NoteID;
         _Body = Body;
         _Addtime = Addtime;
         _Title = Title;
         _NUserID = NUserID;
        }
    #endregion

    #region Public Properties
        [Column(Storage="_NoteID")]
        public int NoteID
        {
            get { return _NoteID; }
            set 
            {
                _NoteID = value; 
                OnPropertyChanged("NoteID");
            }
        }
        [Column(Storage="_Body")]
        public string Body
        {
            get { return _Body; }
            set 
            {
                _Body = value; 
                OnPropertyChanged("Body");
            }
        }
        [Column(Storage="_Addtime")]
        public DateTime Addtime
        {
            get { return _Addtime; }
            set 
            {
                _Addtime = value; 
                OnPropertyChanged("Addtime");
            }
        }
        [Column(Storage="_Title")]
        public string Title
        {
            get { return _Title; }
            set 
            {
                _Title = value; 
                OnPropertyChanged("Title");
            }
        }
        [Column(Storage="_NUserID")]
        public int NUserID
        {
            get { return _NUserID; }
            set 
            {
                _NUserID = value; 
                OnPropertyChanged("NUserID");
            }
        }
    #endregion
    }
}