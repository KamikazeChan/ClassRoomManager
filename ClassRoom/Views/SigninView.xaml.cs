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
using System.Windows.Navigation;
using ClassRoom.Presenters;
using ClassRoom.Common;

namespace ClassRoom.Views
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
            if (CheckAccount(account, passWord))
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
        }

        #region 用户票据

        private TicketInfo CreateTicket(User entity)
        {
            TicketInfo ticket = null;
            ticket = new TicketInfo();
            if (entity.Student != null)
            {
                ticket.ClassName = entity.Student.Class.ClassName;
            }
            ticket.LoginTime = DateTime.Now;
            ticket.UserNO = entity.UserID;
            ticket.UserName = entity.Realname;
            ticket.UserTypeID = entity.UserRole.Value;
            return ticket;
        }
        #endregion

        private bool CheckAccount(int account ,string passWord)
        {
            using (ClassRoomEntities entities = new ClassRoomEntities())
            {
                var result = from m in entities.Users
                             where m.UserID == account
                             && m.Password == passWord
                             select m;
                if (result.Count() > 0) {
                   CommonClass.UserTicket = CreateTicket(result.First());
                    return true;
                }
                return false;
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
