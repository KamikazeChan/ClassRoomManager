using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using ClassRoom;
using ClassRoom.Enum;

using Util;
using Util.DataProcess;
using ClassRoom.DrawCanvas;
using ClassRoom.DB.EntityModel;
using ClassRoom.View;

namespace ClassRoom.ViewForms.NoteManager
{
    /// <summary>
    /// NoteView.xaml 的交互逻辑
    /// </summary>
    public partial class NoteViewForm : Window
    {
        private int newNoteCount = 0;

        public NoteViewForm()
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
            ClassRoom.BLL.NoteBLL bll = new ClassRoom.BLL.NoteBLL();

            noteList = bll.GetUserNotes(4);

            noteList.ForEach(o => {
                CreateNote(o);
            });
            
        }

        private void InitNoteResources()
        {
            CollectionViewSource articlesViewSource = ((CollectionViewSource)(this.FindResource("NoteDataSource")));
            articlesViewSource.Source = entities.Notes.Execute(System.Data.Objects.MergeOption.AppendOnly);
        }

        private void CreateNote(NoteView note)
        {
            ContentControl noteControl = new ContentControl();
            noteControl.Name = "Note" + newNoteCount++;
            noteControl.Tag = note;
            Style template = this.TryFindResource("DesignerItemStyle") as Style;
            noteControl.Style = template;
            noteControl.ApplyTemplate();
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = ColorHelpers.GetColorByName(note.Color);
            noteControl.Background = brush;
            noteControl.Width = note.Width;
            noteControl.Height = note.Height;
            Canvas.SetTop(noteControl, note.Y);
            Canvas.SetLeft(noteControl, note.X);
            Transform rotate = new RotateTransform(note.RotateAngle, note.RotateCenterX, note.RotateCenterY);
            noteControl.RenderTransform = rotate;

            Button btnClose = noteControl.Template.FindName("btnClose", noteControl) as Button;
            Button btnChangeColor = noteControl.Template.FindName("btnChangeColor", noteControl) as Button;
            RichTextBox rtbBody = noteControl.Template.FindName("rtbNoteBody", noteControl) as RichTextBox;

            rtbBody.LoadFromRTF(note.Body);
            //SetValueToRichTextBox(note, rtbBody);            

            MoveThumb moveThumb = noteControl.Template.FindName("moveThumb", noteControl) as MoveThumb;
            moveThumb.ApplyTemplate();
            TextBlock txtTitle = moveThumb.Template.FindName("txtTitle", moveThumb) as TextBlock;

            txtTitle.Text = note.User == null ? "新建" : note.User.Realname + note.AddTime.ToShortDateString();
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

            NoteView note = control.Tag as NoteView;
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = ColorHelpers.GetRandomLightColor();

            control.Background = brush;

            note.Color = ColorHelpers.GetColorName(brush.Color);
            note.DataStatus = DataStatusEnum.Updated;

        }

        void rtbBody_TextChanged(object sender, TextChangedEventArgs e)
        {
            RichTextBox text = sender as RichTextBox;
            ContentControl control = text.TemplatedParent as ContentControl;
            NoteView note = control.Tag as NoteView;
            //TextRange range = new TextRange(text.Document.ContentStart, text.Document.ContentEnd);
            note.Body = text.RTF();
            note.DataStatus = DataStatusEnum.Updated;
        }

        void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ContentControl control = btn.TemplatedParent as ContentControl;
            NoteView note = control.Tag as NoteView;
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
                        entities.Notes.AddObject(m);
                        break;
                    case DataStatusEnum.Deleted:
                        entities.Notes.DeleteObject(m);
                        break;
                    case DataStatusEnum.Updated:
                        if (m.NoteID == 0)
                            entities.Notes.AddObject(m);
                        else
                            entities.Notes.ApplyCurrentValues(m);
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
            NoteView note = new NoteView();            
            note.Color = "LightBlue";
            note.NoteID = 0;
            note.Width = 200;
            note.Height = 200;
            //note.User = Common.CommonClass.UserTicket.UserInfo;
            note.NUserID = 4;
            note.AddTime = DateTime.Now;
            Point position = Mouse.GetPosition(NoteCanvas);
            position.Offset(-35, -15);
            note.Y = position.Y;
            note.X = position.X;
            note.Body = "";
            note.DataStatus = DataStatusEnum.Added;
            noteList.Add(note);

            CreateNote(note);
        }

        public List<NoteView> noteList { get; set; }
    }
}
