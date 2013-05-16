using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ClassRoom.Enum;
using System.Windows.Forms;
using ClassRoom.DB.EntityModel;
using ClassRoom.View;

namespace ClassRoom.BLL
{
   public class NoteBLL
    {
        //public NoteBLL()
        //{
        //    try
        //    {
                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.InnerException.ToString());
        //    }
        //}

        public List<NoteView> GetUserNotes(int ID)
        {
            List<NoteView>  noteList = new List<NoteView>();

            try
            {
                using (ClassRoomEntities entities = new ClassRoomEntities())
                {
                    var notes = from m in entities.Notes
                                where m.NUserID == ID
                                select m;
                    List<Note> list = notes.ToList();

                    list.ForEach(m =>
                    {
                        NoteView view = new NoteView ();
                        Note entityInfo = view.Clone(m);

                        view.Clone(m);
                        noteList.Add(view);
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
             
            return noteList;
        }
    }
}
