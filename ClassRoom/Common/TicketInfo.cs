using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassRoom.Common
{
    public  class TicketInfo
    {
        //
        // 摘要:
        //     登陆时间
        public  DateTime LoginTime { get; set; }      
        //
        // 摘要:
        //     用户名
        public  string UserName { get; set; }
        //
        // 摘要:
        //     用户编号
        public  int UserNO { get; set; }
        //
        // 摘要:
        //     用户类型ID
        public  int UserTypeID { get; set; }

        // 摘要:
        //     班级名
        public  string ClassName { get; set; }
    }
}
