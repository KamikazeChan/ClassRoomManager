using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClassRoom.Common
{
    enum UserRoleTypeEnum
    {
        /// <summary>
        /// 学生
        /// </summary>
        [Description("学生")]
        Student = 0,
        /// <summary>
        /// 老师
        /// </summary>
        [Description("老师")]
        Teacher = 1      
    }
}
