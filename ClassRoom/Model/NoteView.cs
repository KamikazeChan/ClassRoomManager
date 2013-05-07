using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassRoom.Common;

namespace ClassRoom.Model
{
    public class NoteEntity 
    {
        public Note Note { get; set; }
        public DataStatusEnum DataStatus { set; get; }
    }
}
