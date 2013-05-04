using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace ClassRoom.Model
{
    /// <summary>
    /// 读取数据库对应的视图 'Teachers'
    /// </summary>
    [Table(Name = "Teachers")]
    [Serializable]
    public class Teachers: Notifier
    {
    #region Private Member
        private int _TeacherID;
        private string _Realname;
        private int _ClassID;
        private string _Email;
        private string _Office;
        private string _Mobile;
        private string _Address;
        private string _Course;
    #endregion

    #region Constructor
        public Teachers() {}
        
        public Teachers(
        int TeacherID,
        string Realname,
        int ClassID,
        string Email,
        string Office,
        string Mobile,
        string Address,
    string Course
        )
        {
         _TeacherID = TeacherID;
         _Realname = Realname;
         _ClassID = ClassID;
         _Email = Email;
         _Office = Office;
         _Mobile = Mobile;
         _Address = Address;
         _Course = Course;
        }
    #endregion

    #region Public Properties
        [Column(Storage="_TeacherID")]
        public int TeacherID
        {
            get { return _TeacherID; }
            set 
            {
                _TeacherID = value; 
                OnPropertyChanged("TeacherID");
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
        [Column(Storage="_Office")]
        public string Office
        {
            get { return _Office; }
            set 
            {
                _Office = value; 
                OnPropertyChanged("Office");
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
        [Column(Storage="_Course")]
        public string Course
        {
            get { return _Course; }
            set 
            {
                _Course = value; 
                OnPropertyChanged("Course");
            }
        }
    #endregion
    }
}