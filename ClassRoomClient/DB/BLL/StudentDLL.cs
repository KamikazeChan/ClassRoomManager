using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassRoom.DB.EntityModel;

namespace ClassRoom.BLL
{
    class StudentDLL
    {
        ClassRoomEntities entities = new ClassRoomEntities();
        public bool AddStudent(Student student)
        {
            entities.Students.AddObject(student);
            if (entities.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
