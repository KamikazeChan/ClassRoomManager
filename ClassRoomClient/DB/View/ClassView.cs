using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using ClassRoom.DB.EntityModel;
namespace ClassRoom.View
{
    /// <summary>
    /// 读取数据库对应的视图 'Class'
    /// </summary>
    public class ClassView: Class
    {
        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(Class entity)
        {
                this.ClassID = entity.ClassID;
                this.HeadTeacherID = entity.HeadTeacherID;
                this.ClassName = entity.ClassName;
                this.ClassDecription = entity.ClassDecription;
                this.ChineseTeacher = entity.ChineseTeacher;
                this.MathTeacher = entity.MathTeacher;
        }
    }
}