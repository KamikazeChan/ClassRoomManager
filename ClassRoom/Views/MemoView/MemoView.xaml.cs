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

namespace ClassRoom.Views.MemoView
{
    /// <summary>
    /// MemoView.xaml 的交互逻辑
    /// </summary>
    public partial class MemoView : Window
    {
        public MemoView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ContentControl Memo = CreateMemo(1);
            MemoCanvas.Children.Add(Memo); 
        }

        private ContentControl CreateMemo(int ID)
        {
            ContentControl Memo = new ContentControl();
            Memo.Name = "Memo"+ID;
            Style template = this.TryFindResource("DesignerItemStyle") as Style;
            Memo.Style = template;
            Memo.Width = 200;
            Memo.Height = 200;            
            Canvas.SetTop(Memo,20);
            Canvas.SetLeft(Memo, 20);

            Transform rotate = new RotateTransform(30,0.0,0.0);
            Memo.RenderTransform = rotate;

            Memo.ApplyTemplate();

            Button btnClose = Memo.Template.FindName("btnClose", Memo) as Button;
            btnClose.Click += new RoutedEventHandler(btnClose_Click);
            btnClose.Tag = Memo;
            return Memo;
        }

        void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ContentControl control = btn.Tag as ContentControl;
            MessageBoxResult result = MessageBox.Show("确定要删除","删除留言",MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.MemoCanvas.Children.Remove(control);
            }
        }        

        private void MemoCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Control child in MemoCanvas.Children)
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
            foreach (Control control in this.MemoCanvas.Children)
            {
                if (control.Name.StartsWith("Memo"))
                {
                    RichTextBox rtb = control.Template.FindName("tbMemoBody", control) as RichTextBox;
                    RotateTransform rotate = control.RenderTransform as RotateTransform;
                    double centerX = rotate.CenterX;
                    double centerY = rotate.CenterY;
                    double angle = rotate.Angle;
                    double x = Canvas.GetTop(control);
                    double y = Canvas.GetLeft(control);
                    double width = control.Width;
                    double heigth = control.Height;
                    int userId = Common.CommonClass.UserTicket.UserNO;
                    DateTime addDatetime = DateTime.Now;
                }
            }
        }
       
    }
}
