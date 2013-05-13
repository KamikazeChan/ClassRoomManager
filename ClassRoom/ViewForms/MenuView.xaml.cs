using System.Windows;
using System.Windows.Controls;
using ClassRoom.Presenters;

namespace ClassRoom.Views
{
    public partial class MenuView : UserControl
    {

        public MenuView(MenuPresenter presenter)
        {
            InitializeComponent();
            DataContext = presenter;
        }

        public MenuPresenter Presenter
        {
            get { return (MenuPresenter) DataContext; }
        }

        private void WordBoard_Click(object sender, RoutedEventArgs e)
        {
            Presenter.WatchWordBoard();
        }

        private void Photo_Click(object sender, RoutedEventArgs e)
        {
            Presenter.GotoPhoto();
        }

        private void Literatrue_Click(object sender, RoutedEventArgs e)
        {
            Presenter.DisplayLiteratrue();
        }

        private void btnPersonInfoUpdate_Click(object sender, RoutedEventArgs e)
        {
            PersonalInfo window = new PersonalInfo();
            window.ShowDialog();
        }
    }
}