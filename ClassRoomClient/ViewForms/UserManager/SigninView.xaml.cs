using System;
using System.Windows;
using ClassRoom.Presenters;
using ClassRoom;
using ClassRoom.ViewForms.UserManager;
using ClassRoom.BLL;

namespace ClassRoom.ViewForms.UserManager
{
    /// <summary>
    /// SigninView.xaml 的交互逻辑
    /// </summary>
    public partial class SigninView : Window
    {

        public ApplicationController Controller
        {
            get { return (ApplicationController)DataContext; }
        }

        public SigninView()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            int account = Convert.ToInt32(this.tbAccount.Text);
            string passWord = this.tbPassword.Text;
            UserBLL bll = new UserBLL();
            if (bll.CheckAccount(account, passWord))
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
        }
       
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            LoginView window = new LoginView();
            window.Show();
            this.Close();
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
