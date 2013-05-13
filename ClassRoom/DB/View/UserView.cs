using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using ClassRoom.DB.EntityModel;
namespace ClassRoom.View
{
    /// <summary>
    /// 读取数据库对应的视图 'User'
    /// </summary>
    public class UserView: User
    {
        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(User entity)
        {
                this.UserID = entity.UserID;
                this.Sex = entity.Sex;
                this.Realname = entity.Realname;
                this.Birthday = entity.Birthday;
                this.Email = entity.Email;
                this.Mobile = entity.Mobile;
                this.Address = entity.Address;
                this.Introduction = entity.Introduction;
                this.QQ = entity.QQ;
                this.Password = entity.Password;
                this.UserRoleID = entity.UserRoleID;
                this.UserRole = entity.UserRole;
        }
    }
}