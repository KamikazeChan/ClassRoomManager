using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using ClassRoom.DB.EntityModel;
namespace ClassRoom.View
{
    /// <summary>
    /// 读取数据库对应的视图 'Message'
    /// </summary>
    public class MessageView: Message
    {
        /// <summary>
        /// 复制
        /// </summary>
        public void Clone(Message entity)
        {
                this.MessageID = entity.MessageID;
                this.UserID = entity.UserID;
                this.Time = entity.Time;
                this.WordContent = entity.WordContent;
                this.MessageConnectID = entity.MessageConnectID;
                this.MessageType = entity.MessageType;
        }
    }
}