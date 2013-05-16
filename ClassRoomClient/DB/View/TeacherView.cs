using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using ClassRoom.DB.EntityModel;
namespace ClassRoom.View
{
    /// <summary>
    /// 读取数据库对应的视图 'Teacher'
    /// </summary>
    public class TeacherView: Teacher
    {
        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(Teacher entity)
        {
                this.TeacherID = entity.TeacherID;
                this.Office = entity.Office;
                this.CourseID = entity.CourseID;
        }
    }
}