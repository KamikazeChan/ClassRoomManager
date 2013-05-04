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
using System.IO;

namespace ClassRoom.Views.ArticleView
{
    /// <summary>
    /// ArticleList.xaml 的交互逻辑
    /// </summary>
    public partial class ArticleList : Window
    {
        public ArticleList()
        {
            InitializeComponent();
        }

        ClassRoomEntities entities;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitDataSource();
            try
            {
                entities = new ClassRoomEntities();

                var articles = from m in entities.Articles
                               where m.User.UserID == 7
                               select m;
                Article article = articles.ToList().Last();
                this.ArticleItems.ItemsSource = articles.ToList();

                //

                //FlowDocument

                //
                //TextRange range = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                //range.Load(stream, DataFormats.Rtf);
                //FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("Simple FlowDocument")));
                //this.richTextBox1.Document = flowDoc;
                //this.scrollViewer1.DataContext = articles.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void InitDataSource()
        {
            ClassRoomEntities classRoomEntities = new ClassRoomEntities();
            CollectionViewSource articlesViewSource = ((CollectionViewSource)(this.FindResource("articlesViewSource")));
            System.Data.Objects.ObjectQuery<Article> articlesQuery = classRoomEntities.Articles;
            articlesViewSource.Source = articlesQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid g = sender as Grid;

            if (g.Tag is int)
            {
                Article article = entities.Articles.First(o => o.ArticleID == (int)g.Tag);

                MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(article.ArticleContent));
                stream.ToArray();

                FlowDocument flowDocument = new FlowDocument();
                TextRange textRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);

                textRange.Load(stream, DataFormats.Rtf);

                fDoc.Document = flowDocument;
            }
        }
    }
}
