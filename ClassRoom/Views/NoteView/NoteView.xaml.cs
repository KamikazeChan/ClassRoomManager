using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace ClassRoom.Views.NoteView
{
    /// <summary>
    /// NoteView.xaml 的交互逻辑
    /// </summary>
    public partial class NoteView : Window
    {
        public NoteView()
        {
            InitializeComponent();
        }

        ClassRoomEntities entities;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            entities = new ClassRoomEntities();
            var notes = from m in entities.Notes
                        where m.NUserID == 4
                        select m;
            notes.ToList().ForEach(m=>{
                ContentControl note = CreateNote(m);
                NoteCanvas.Children.Add(note);
            });
        }

        private ContentControl CreateNote(Note note)
        {
            ContentControl Note = new ContentControl();
            Note.Name = "Note" + note.NoteID;
            Style template = this.TryFindResource("DesignerItemStyle") as Style;
            Note.Style = template;
            Note.Width = 200;
            Note.Height = 200;            
            Canvas.SetTop(Note,20);
            Canvas.SetLeft(Note, 20);

            Transform rotate = new RotateTransform(30,0.0,0.0);
            Note.RenderTransform = rotate;

            Note.ApplyTemplate();

            Button btnClose = Note.Template.FindName("btnClose", Note) as Button;
            btnClose.Click += new RoutedEventHandler(btnClose_Click);
            btnClose.Tag = Note;
            return Note;
        }

        void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ContentControl control = btn.Tag as ContentControl;
            MessageBoxResult result = MessageBox.Show("确定要删除","删除留言",MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.NoteCanvas.Children.Remove(control);
            }
        }        

        private void NoteCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Control child in NoteCanvas.Children)
            {
                Selector.SetIsSelected(child, false);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SaveNotes();
        }

        private void SaveNotes()
        {
            foreach (Control control in this.NoteCanvas.Children)
            {
                if (control.Name.StartsWith("Note"))
                {
                    Note note = new Note();
                    RichTextBox rtb = control.Template.FindName("tbNoteBody", control) as RichTextBox;
                    RotateTransform rotate = control.RenderTransform as RotateTransform;
                    TextRange range = new TextRange(rtb.Document.ContentStart,rtb.Document.ContentEnd);

                    note.Body = range.Text;
                    note.RotateCenterX = rotate.CenterX;
                    note.RotateCenterY = rotate.CenterY;
                    note.RotateAngle = rotate.Angle;
                    note.X = Canvas.GetTop(control);
                    note.Y = Canvas.GetLeft(control);
                    note.Width = control.Width;
                    note.Height = control.Height;
                    note.NUserID = Common.CommonClass.UserTicket.UserNO;
                    note.Addtime = DateTime.Now;
                }
            }
        }
       
    }
}
