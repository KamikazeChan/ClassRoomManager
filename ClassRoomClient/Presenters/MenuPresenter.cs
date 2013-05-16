using System;
using System.Windows.Controls;

using ClassRoom.Views;
using ClassRoom.ViewForms.NoteManager;
using ClassRoom.Views.ArticleView;
using ClassRoom.ViewForms.PhotoManager;

namespace ClassRoom.Presenters
{
    public class MenuPresenter
    {
        private readonly ApplicationController _controller;

        public MenuPresenter(ApplicationController controller)
        {
            _controller = controller;
            //MenuView menu = new MenuView(this);
            _controller.DisplayInShell(new MenuView(this));
        }

        public void DisplayPictures()
        {
            string myPicturesPath = Environment.GetFolderPath(
                Environment.SpecialFolder.MyPictures
                );

            //Display<PictureView, Picture>(
            //    myPicturesPath,
            //    "*.jpg", "*.gif", "*.png", "*.bmp"
            //    );
        }

        public void ListenToMusic()
        {
            //Display<MusicView, Media>(
            //    Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
            //    "*.wma", "*.mp3"
            //    );
        }

        public void WatchVideo()
        {
            //Display<VideoView, Media>(
            //    _controller.RequestDirectoryFromUser(),
            //    "*.wmv"
            //    );
        }

        private void Display<View, MediaType>(
            string mediaPath,
            params string[] extensions
            )
        {


            //View view = new View();
            //view.DataContext = presenter;

            //_controller.DisplayInShell(view);
        }

        internal void WatchWordBoard()
        {
            NoteViewForm window = new NoteViewForm();
            _controller.DisplayInShell(window);

        }       

        internal void DisplayLiteratrue()
        {
            ArticleList window = new ArticleList();
            _controller.DisplayInShell(window);
        }

        internal void GotoPhoto()
        {
            PhotoViewForm window = new PhotoViewForm();
            _controller.DisplayInShell(window);
        }
    }
}