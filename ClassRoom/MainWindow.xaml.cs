using System.Windows;
using ClassRoom.Presenters;
using ClassRoom.Common;
using System;

namespace ClassRoom
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationController(this);
        }

       
        public ApplicationController Controller
        {
            get { return (ApplicationController)DataContext; }
        }

        public void TransitionTo(object view)
        {
            currentView.Content = view;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Controller.ShowMenu();
        }

        private void Header_Click(object sender, RoutedEventArgs e)
        {
            Controller.ShowMenu();
        }
    }
}