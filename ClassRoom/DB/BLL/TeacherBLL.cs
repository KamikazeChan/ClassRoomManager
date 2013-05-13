using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassRoom.DB.EntityModel;

namespace ClassRoom.BLL
{
    class TeacherBLL
    {
        ClassRoomEntities entities = new ClassRoomEntities();
        public bool AddTeacher(Teacher teacher)
        {
            entities.Teachers.AddObject(teacher);
            if (entities.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
