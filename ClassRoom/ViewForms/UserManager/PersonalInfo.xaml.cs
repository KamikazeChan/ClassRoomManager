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
using ClassRoom;
using ClassRoom.DB.EntityModel;
using ClassRoom.BLL;

namespace ClassRoom.Views
{
    /// <summary>
    /// PersonalInfo.xaml 的交互逻辑
    /// </summary>
    public partial class PersonalInfo : Window
    {
        public PersonalInfo()
        {
            InitializeComponent();
        }
     
        ClassRoomEntities ClassRoomEntities;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserBLL bll = new UserBLL();

            this.DataContext = bll.GetUser(Common.UserTicket.UserInfo.UserID);
            //InitRoleCombo();
        }

        //private void InitRoleCombo()
        //{
        //    this.cbUserRole.DisplayMemberPath = "Key";
        //    this.cbUserRole.SelectedValuePath = "Value";
        //    this.cbUserRole.ItemsSource = CommonClass.ListTypeForEnum(typeof(UserRoleTypeEnum));
        //}



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //User user = (User)this.DataContext;

            //ClassRoomEntities.Users.ApplyCurrentValues(user);

            if (ClassRoomEntities.SaveChanges() > 0)
            {
                MessageBox.Show("更新成功");
            }
            //ClassRoomEntities.Users.AddObject(user);
        }
    }
}
