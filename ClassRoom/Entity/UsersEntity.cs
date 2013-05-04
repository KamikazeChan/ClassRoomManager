using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace ClassRoom.Model
{
    /// <summary>
    /// 读取数据库对应的视图 'Users'
    /// </summary>
    [Table(Name = "Users")]
    [Serializable]
    public class Users: Notifier
    {
    #region Private Member
        private int _UserID;
        private string _Password;
        private int _UserRoleID;
        private int _UserRole;
    #endregion

    #region Constructor
        public Users() {}
        
        public Users(
        int UserID,
        string Password,
        int UserRoleID,
    int UserRole
        )
        {
         _UserID = UserID;
         _Password = Password;
         _UserRoleID = UserRoleID;
         _UserRole = UserRole;
        }
    #endregion

    #region Public Properties
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
        [Column(Storage="_Password")]
        public string Password
        {
            get { return _Password; }
            set 
            {
                _Password = value; 
                OnPropertyChanged("Password");
            }
        }
        [Column(Storage="_UserRoleID")]
        public int UserRoleID
        {
            get { return _UserRoleID; }
            set 
            {
                _UserRoleID = value; 
                OnPropertyChanged("UserRoleID");
            }
        }
        [Column(Storage="_UserRole")]
        public int UserRole
        {
            get { return _UserRole; }
            set 
            {
                _UserRole = value; 
                OnPropertyChanged("UserRole");
            }
        }
    #endregion
    }
}