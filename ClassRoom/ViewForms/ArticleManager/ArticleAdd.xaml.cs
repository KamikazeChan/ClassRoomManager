using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;
using System.IO;
using System;
using ClassRoom.Views.ArticleView;
using Util;
using ClassRoom;
using Util.DataProcess;
using ClassRoom.DB.EntityModel;
namespace ClassRoom.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ArticleAddView : Window
    {
        private readonly DocumentManager _documentManager;

        public ArticleAddView()
        {
            InitializeComponent();
            _documentManager = new DocumentManager(rtbArticleBody);
        }           

        private void ApplicationClose(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void TextEditorToolbar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (toolbar.IsSynchronizing) return;

            ComboBox source = e.OriginalSource as ComboBox;
            if (source == null) return;

            switch (source.Name)
            {
                case "fonts":
                    _documentManager.ApplyToSelection(TextBlock.FontFamilyProperty, source.SelectedItem);
                    break;
                case "fontSize":
                    _documentManager.ApplyToSelection(TextBlock.FontSizeProperty, source.SelectedItem);
                    break;
            }

            rtbArticleBody.Focus();
        }

        private void body_SelectionChanged(object sender, RoutedEventArgs e)
        {
            toolbar.SynchronizeWith(rtbArticleBody.Selection);
        }

        private void SaveDocument_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _documentManager.CanSaveDocument();
        }

        private void btnSaveArticle_Click(object sender, RoutedEventArgs e)
        {
            //if (_documentManager.SaveDocument())
            //{

            //    MessageBox.Show("保存成功！");
            //}

            //TextRange range = new TextRange(body.Document.ContentStart, body.Document.ContentEnd);
            Article article = new Article();
            article.ArticleTitle = tbArticleTitle.Text;
            article.ArticleContent = rtbArticleBody.RTF();
            //article.AUserID = ClassRoom.Common.TicketInfo.UserNO;
            article.AUserID = 4;
            article.UploadTime = DateTime.Now;
            ClassRoomEntities entities = new ClassRoomEntities();
              try
                {  
                entities.Articles.AddObject(article);

                int result =entities.SaveChanges();
                if (result > 0)
                    MessageBox.Show("保存成功");
            }
            catch (Exception ee)
            {
                throw ee.InnerException;
            }
        }

        private void btnViewArticle_Click(object sender, RoutedEventArgs e)
        {
            ArticleList window = new ArticleList();
            window.Show();
            this.Close();
        }
        
    }
}