using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace ClassRoom.Model
{
    /// <summary>
    /// 读取数据库对应的视图 'Messages'
    /// </summary>
    [Table(Name = "Messages")]
    [Serializable]
    public class Messages: Notifier
    {
    #region Private Member
        private int _MessageID;
        private int _UserID;
        private DateTime _Time;
        private string _WordContent;
        private int _MessageConnectID;
        private int _MessageType;
    #endregion

    #region Constructor
        public Messages() {}
        
        public Messages(
        int MessageID,
        int UserID,
        DateTime Time,
        string WordContent,
        int MessageConnectID,
    int MessageType
        )
        {
         _MessageID = MessageID;
         _UserID = UserID;
         _Time = Time;
         _WordContent = WordContent;
         _MessageConnectID = MessageConnectID;
         _MessageType = MessageType;
        }
    #endregion

    #region Public Properties
        [Column(Storage="_MessageID")]
        public int MessageID
        {
            get { return _MessageID; }
            set 
            {
                _MessageID = value; 
                OnPropertyChanged("MessageID");
            }
        }
        [Column(Storage="_UserID")]
        public int UserID
        {
            get { return _UserID; }
            set 
            {
                _UserID = value; 
                OnPropertyChanged("UserID");
            }
        }
        [Column(Storage="_Time")]
        public DateTime Time
        {
            get { return _Time; }
            set 
            {
                _Time = value; 
                OnPropertyChanged("Time");
            }
        }
        [Column(Storage="_WordContent")]
        public string WordContent
        {
            get { return _WordContent; }
            set 
            {
                _WordContent = value; 
                OnPropertyChanged("WordContent");
            }
        }
        [Column(Storage="_MessageConnectID")]
        public int MessageConnectID
        {
            get { return _MessageConnectID; }
            set 
            {
                _MessageConnectID = value; 
                OnPropertyChanged("MessageConnectID");
            }
        }
        [Column(Storage="_MessageType")]
        public int MessageType
        {
            get { return _MessageType; }
            set 
            {
                _MessageType = value; 
                OnPropertyChanged("MessageType");
            }
        }
    #endregion
    }
}