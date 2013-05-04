using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace ClassRoom.Model
{
    /// <summary>
    /// 读取数据库对应的视图 'Students'
    /// </summary>
    [Table(Name = "Students")]
    [Serializable]
    public class Students: Notifier
    {
    #region Private Member
        private int _StudentID;
        private bool _Sex;
        private string _Realname;
        private DateTime _Birthday;
        private string _Email;
        private string _Mobile;
        private string _Address;
        private string _Introduction;
        private string _QQ;
        private int _SClassID;
    #endregion

    #region Constructor
        public Students() {}
        
        public Students(
        int StudentID,
        bool Sex,
        string Realname,
        DateTime Birthday,
        string Email,
        string Mobile,
        string Address,
        string Introduction,
        string QQ,
    int SClassID
        )
        {
         _StudentID = StudentID;
         _Sex = Sex;
         _Realname = Realname;
         _Birthday = Birthday;
         _Email = Email;
         _Mobile = Mobile;
         _Address = Address;
         _Introduction = Introduction;
         _QQ = QQ;
         _SClassID = SClassID;
        }
    #endregion

    #region Public Properties
        [Column(Storage="_StudentID")]
        public int StudentID
        {
            get { return _StudentID; }
            set 
            {
                _StudentID = value; 
                OnPropertyChanged("StudentID");
            }
        }
        [Column(Storage="_Sex")]
        public bool Sex
        {
            get { return _Sex; }
            set 
            {
                _Sex = value; 
                OnPropertyChanged("Sex");
            }
        }
        [Column(Storage="_Realname")]
        public string Realname
        {
            get { return _Realname; }
            set 
            {
                _Realname = value; 
                OnPropertyChanged("Realname");
            }
        }
        [Column(Storage="_Birthday")]
        public DateTime Birthday
        {
            get { return _Birthday; }
            set 
            {
                _Birthday = value; 
                OnPropertyChanged("Birthday");
            }
        }
        [Column(Storage="_Email")]
        public string Email
        {
            get { return _Email; }
            set 
            {
                _Email = value; 
                OnPropertyChanged("Email");
            }
        }
        [Column(Storage="_Mobile")]
        public string Mobile
        {
            get { return _Mobile; }
            set 
            {
                _Mobile = value; 
                OnPropertyChanged("Mobile");
            }
        }
        [Column(Storage="_Address")]
        public string Address
        {
            get { return _Address; }
            set 
            {
                _Address = value; 
                OnPropertyChanged("Address");
            }
        }
        [Column(Storage="_Introduction")]
        public string Introduction
        {
            get { return _Introduction; }
            set 
            {
                _Introduction = value; 
                OnPropertyChanged("Introduction");
            }
        }
        [Column(Storage="_QQ")]
        public string QQ
        {
            get { return _QQ; }
            set 
            {
                _QQ = value; 
                OnPropertyChanged("QQ");
            }
        }
        [Column(Storage="_SClassID")]
        public int SClassID
        {
            get { return _SClassID; }
            set 
            {
                _SClassID = value; 
                OnPropertyChanged("SClassID");
            }
        }
    #endregion
    }
}