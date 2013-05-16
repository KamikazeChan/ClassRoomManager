using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassRoom.DB.EntityModel;

namespace ClassRoom
{
    public  class TicketInfo
    {
        /// <summary>
        /// 登录用户信息
        /// </summary>
        public User UserInfo { get; set; }
        /// <summary>
        /// 登陆时间
        /// </summary>
        public  DateTime LoginTime { get; set; }                   
        /// <summary>
        /// 班级名
        /// </summary>
        public  string ClassName { get; set; }
    }
}
