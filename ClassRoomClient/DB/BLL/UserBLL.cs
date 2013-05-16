using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassRoom.DB.EntityModel;

namespace ClassRoom.BLL
{
   public class UserBLL
    {
        ClassRoomEntities entities = new ClassRoomEntities();

        public User GetUser(int iD)
        {
            ClassRoomEntities entities = new ClassRoomEntities();

            var u = from m in entities.Users
                    where m.UserID == Common.UserTicket.UserInfo.UserID
                    select m;

            return u.FirstOrDefault();
        }

        public bool CheckAccount(int account, string passWord)
        {    
            var result = from m in entities.Users
                         where m.UserID == account
                         && m.Password == passWord
                         select m;

            if (result.Count() > 0)
            {
                Common.UserTicket = CreateTicket(result.First());
                return true;
            }
            return false;
        }

        public bool AddUser(User user,Student student,Teacher teacher)
        {
            if(student!=null)
            entities.Students.AddObject(student);

            if(teacher !=null)
                entities.Teachers.AddObject(teacher);

            entities.Users.AddObject(user);
            if (entities.SaveChanges() > 0)
                return true;
            return false;
        }

        private TicketInfo CreateTicket(User entity)
        {
            TicketInfo ticket = null;
            ticket = new TicketInfo();
            if (entity.Student != null)
            {
                ticket.ClassName = entity.Student.Class.ClassName;
            }
            ticket.LoginTime = DateTime.Now;
            ticket.UserInfo = entity;
            return ticket;
        }
    }
}
