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
using DiagramDesigner;
using ClassRoom.Model;
using ClassRoom.Common;
using System.IO;

namespace ClassRoom.Views.NoteView
{
    /// <summary>
    /// NoteView.xaml 的交互逻辑
    /// </summary>
    public partial class NoteView : Window
    {
        private int newNoteCount = 0;

        public NoteView()
        {
            InitializeComponent();
        }

        ClassRoomEntities entities;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitCanvas();
        }

        private void InitCanvas()
        {
            noteList = new List<NoteEntity>();
            entities = new ClassRoomEntities();

            var notes = from m in entities.Notes
                        where m.NUserID == 4
                        select m;

            List<Note> list = notes.ToList();

            //InitNoteResources();

            list.ForEach(m =>
            {
                NoteEntity entity = new NoteEntity { Note = m, DataStatus = DataStatusEnum.Default };
                noteList.Add(entity);
                CreateNote(entity);
            });
        }

        private void InitNoteResources()
        {
            CollectionViewSource articlesViewSource = ((CollectionViewSource)(this.FindResource("NoteDataSource")));
            articlesViewSource.Source = entities.Notes.Execute(System.Data.Objects.MergeOption.AppendOnly);
        }

        private void CreateNote(NoteEntity note)
        {
            ContentControl noteControl = new ContentControl();
            noteControl.Name = "Note" + newNoteCount++;
            noteControl.Tag = note;
            Style template = this.TryFindResource("DesignerItemStyle") as Style;
            noteControl.Style = template;
            noteControl.ApplyTemplate();
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = ColorHelpers.GetColorByName(note.Note.Color);
            noteControl.Background = brush;
            noteControl.Width = note.Note.Width;
            noteControl.Height = note.Note.Height;
            Canvas.SetTop(noteControl, note.Note.Y);
            Canvas.SetLeft(noteControl, note.Note.X);
            Transform rotate = new RotateTransform(note.Note.RotateAngle, note.Note.RotateCenterX, note.Note.RotateCenterY);
            noteControl.RenderTransform = rotate;

            Button btnClose = noteControl.Template.FindName("btnClose", noteControl) as Button;
            Button btnChangeColor = noteControl.Template.FindName("btnChangeColor", noteControl) as Button;
            RichTextBox rtbBody = noteControl.Template.FindName("rtbNoteBody", noteControl) as RichTextBox;

            rtbBody.LoadFromRTF(note.Note.Body);
            //SetValueToRichTextBox(note, rtbBody);            

            MoveThumb moveThumb = noteControl.Template.FindName("moveThumb", noteControl) as MoveThumb;
            moveThumb.ApplyTemplate();
            TextBlock txtTitle = moveThumb.Template.FindName("txtTitle", moveThumb) as TextBlock;

            txtTitle.Text = note.Note.User == null ? "新建" : note.Note.User.Realname + note.Note.AddTime.ToShortDateString();
            btnClose.Click += new RoutedEventHandler(btnClose_Click);
            btnChangeColor.Click += new RoutedEventHandler(btnChangeColor_Click);

            rtbBody.TextChanged += new TextChangedEventHandler(rtbBody_TextChanged);

            this.NoteCanvas.Children.Add(noteControl);
        }       

        void btnChangeColor_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ContentControl control = btn.TemplatedParent as ContentControl;
            Grid grid = btn.Parent as Grid;
            DockPanel panel = grid.Parent as DockPanel;

            NoteEntity note = control.Tag as NoteEntity;
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = ColorHelpers.GetRandomLightColor();

            control.Background = brush;

            note.Note.Color = ColorHelpers.GetColorName(brush.Color);
            note.DataStatus = DataStatusEnum.Updated;

        }

        void rtbBody_TextChanged(object sender, TextChangedEventArgs e)
        {
            RichTextBox text = sender as RichTextBox;
            ContentControl control = text.TemplatedParent as ContentControl;
            NoteEntity note = control.Tag as NoteEntity;
            //TextRange range = new TextRange(text.Document.ContentStart, text.Document.ContentEnd);
            note.Note.Body = text.RTF();
            note.DataStatus = DataStatusEnum.Updated;
        }

        void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ContentControl control = btn.TemplatedParent as ContentControl;
            NoteEntity note = control.Tag as NoteEntity;
            MessageBoxResult result = MessageBox.Show("确定要删除", "删除留言", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                note.DataStatus = DataStatusEnum.Deleted;
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
            noteList.ForEach(m =>
            {
                switch (m.DataStatus)
                {
                    case DataStatusEnum.Added:
                        entities.Notes.AddObject(m.Note);
                        break;
                    case DataStatusEnum.Deleted:
                        entities.Notes.DeleteObject(m.Note);
                        break;
                    case DataStatusEnum.Updated:
                        if (m.Note.NoteID == 0)
                            entities.Notes.AddObject(m.Note);
                        else
                            entities.Notes.ApplyCurrentValues(m.Note);
                        break;
                }
            });
            try
            {
                if (entities.SaveChanges() > 0)
                {
                    MessageBox.Show("保存成功");
                    entities.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void MenuItem_NewNote(object sender, RoutedEventArgs e)
        {
            NoteEntity note = new NoteEntity();
            note.Note = new Note();
            note.Note.Color = "LightBlue";
            note.Note.NoteID = 0;
            note.Note.Width = 200;
            note.Note.Height = 200;
            //note.User = Common.CommonClass.UserTicket.UserInfo;
            note.Note.NUserID = 4;
            note.Note.AddTime = DateTime.Now;
            Point position = Mouse.GetPosition(NoteCanvas);
            position.Offset(-35, -15);
            note.Note.Y = position.Y;
            note.Note.X = position.X;
            note.Note.Body = "";
            note.DataStatus = DataStatusEnum.Added;
            noteList.Add(note);

            CreateNote(note);
        }

        public List<NoteEntity> noteList { get; set; }
    }
}
