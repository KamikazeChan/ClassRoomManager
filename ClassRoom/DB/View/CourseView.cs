using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using ClassRoom.DB.EntityModel;
namespace ClassRoom.View
{
    /// <summary>
    /// 读取数据库对应的视图 'Course'
    /// </summary>
    public class CourseView: Course
    {
        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(Course entity)
        {
                this.CourseID = entity.CourseID;
                this.CourseName = entity.CourseName;
        }
    }
}