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
using ClassRoom.Model;
using System.Data.Objects;
using ClassRoom.Common;

namespace ClassRoom.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }
        ClassRoomEntities entities;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitCombo();
                     
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User itemUser = new User();
                
                if (radStudent.IsChecked.Value)
                {
                   Student itemStudent = new Student();
                   itemStudent.SClassID = Convert.ToInt32(this.cboData.SelectedValue);
                   entities.Students.AddObject(itemStudent);
                   itemUser.UserRole = (int)UserRoleTypeEnum.Student;
                   itemUser.Student = itemStudent;
                }

                if (radTeacher.IsChecked.Value)
                {
                    Teacher itemTeacher = new Teacher();
                    itemTeacher.CourseID = Convert.ToInt32(this.cboData.SelectedValue);
                    itemUser.UserRole = (int)UserRoleTypeEnum.Teacher;
                    itemUser.Teacher = itemTeacher;
                    entities.Teachers.AddObject(itemTeacher);
                }
                
                itemUser.Sex = this.radioButton1.IsChecked;
                itemUser.Realname = this.tbRealName.Text;
                itemUser.Email = this.tbEmail.Text;
                itemUser.Password = this.tbPassword.Text;
                entities.Users.AddObject(itemUser);

                if (entities.SaveChanges() > 0)
                {
                    MessageBox.Show("保存成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void radTeacher_Checked(object sender, RoutedEventArgs e)
        {
            InitCombo();
        }

        private void radStudent_Checked(object sender, RoutedEventArgs e)
        {
            InitCombo();
        }

        private void InitCombo()
        {
            if (radStudent.IsChecked.Value)
            {
                lblChangeType.Content = "班级";
                cboData.DisplayMemberPath = "ClassName";
                cboData.SelectedValuePath = "ClassID";

                entities = new ClassRoomEntities();
                var query = from c in entities.Classes

                            select new { c.ClassID, c.ClassName };
                cboData.ItemsSource = query;
            }

            if (radTeacher.IsChecked.Value)
            {
                lblChangeType.Content = "课程";
                cboData.DisplayMemberPath = "CourseName";
                cboData.SelectedValuePath = "CourseID";

                entities = new ClassRoomEntities();
                var query = from c in entities.Courses
                            select new { c.CourseID, c.CourseName };

                cboData.ItemsSource = query;
            }
        }

       
    }
}
