using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassRoom.DB.EntityModel;

namespace ClassRoom.BLL
{
   public class ClassesBLL
    {
        public List<Class> GetClasses()
        {
            ClassRoomEntities entities = new ClassRoomEntities();
            var query = from c in entities.Classes
                        select c;

            return query.ToList();
        }
    }
}
