using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using ClassRoom.DB.EntityModel;
namespace ClassRoom.View
{
    /// <summary>
    /// 读取数据库对应的视图 'Note'
    /// </summary>
    public class NoteView: Note
    {
        /// <summary>
        /// 复制
        /// </summary>
        public NoteView Clone(Note entity)
        {
                this.NoteID = entity.NoteID;
                this.Body = entity.Body;
                this.AddTime = entity.AddTime;
                this.Title = entity.Title;
                this.NUserID = entity.NUserID;
                this.RotateAngle = entity.RotateAngle;
                this.RotateCenterX = entity.RotateCenterX;
                this.RotateCenterY = entity.RotateCenterY;
                this.X = entity.X;
                this.Y = entity.Y;
                this.Width = entity.Width;
                this.Height = entity.Height;
                this.Color = entity.Color;
                return this;
        }

        public Enum.DataStatusEnum DataStatus { get; set; }
    }
}