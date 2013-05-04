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
            MemoCanvas.Children.Add(CreateMemo());
            MemoCanvas.Children.Add(CreateMemo()); 
        }

        private ContentControl CreateMemo()
        {
            ContentControl Memo = new ContentControl();
            Style template = this.TryFindResource("DesignerItemStyle") as Style;
            Memo.Style = template;
            Memo.Width = 200;
            Memo.Height = 200;
            Canvas.SetTop(Memo,20);
            Canvas.SetLeft(Memo, 20);
            return Memo;
        }        

        private void MemoCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Control child in MemoCanvas.Children)
            {
                Selector.SetIsSelected(child, false);
            }
        }
       
    }
}
