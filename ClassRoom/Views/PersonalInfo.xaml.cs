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
using ClassRoom.Common;

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
     
        ClassRoomEntities classRoomEntities;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            classRoomEntities = new ClassRoom.ClassRoomEntities();

            var u = from m in classRoomEntities.Users
                               where m.UserID == CommonClass.UserTicket.UserInfo.UserID
                               select m;
            this.DataContext = u.ToList().First();
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

            //classRoomEntities.Users.ApplyCurrentValues(user);

            if (classRoomEntities.SaveChanges() > 0)
            {
                MessageBox.Show("更新成功");
            }
            //classRoomEntities.Users.AddObject(user);
        }
    }
}
