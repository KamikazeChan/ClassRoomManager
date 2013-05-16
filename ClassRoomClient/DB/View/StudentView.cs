using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using ClassRoom.DB.EntityModel;
namespace ClassRoom.View
{
    /// <summary>
    /// 读取数据库对应的视图 'Student'
    /// </summary>
    public class StudentView: Student
    {
        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(Student entity)
        {
                this.StudentID = entity.StudentID;
                this.SClassID = entity.SClassID;
                this.Grade = entity.Grade;
        }
    }
}