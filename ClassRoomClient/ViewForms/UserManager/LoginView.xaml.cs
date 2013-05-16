using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using ClassRoom.UserManager;
using ClassRoom;
using ClassRoom.BLL;
using ClassRoom.DB.EntityModel;

namespace ClassRoom.ViewForms.UserManager
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitCombo();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserBLL bll = new UserBLL();
            try
            {
                User itemUser = new User();
                Student itemStudent = null;
                Teacher itemTeacher = null;

                if (radStudent.IsChecked.Value)
                {
                    itemStudent = new Student();
                    itemStudent.SClassID = Convert.ToInt32(this.cboData.SelectedValue);
                    itemUser.UserRole = (int)ClassRoom.Enum.UserRoleTypeEnum.Student;
                    itemUser.Student = itemStudent;
                }

                if (radTeacher.IsChecked.Value)
                {
                    itemTeacher = new Teacher();
                    itemTeacher.CourseID = Convert.ToInt32(this.cboData.SelectedValue);
                    itemUser.UserRole = (int)ClassRoom.Enum.UserRoleTypeEnum.Teacher;
                    itemUser.Teacher = itemTeacher;
                    //TeacherBLL.AddTeacher(itemTeacher);
                }

                itemUser.Sex = this.radioButton1.IsChecked;
                itemUser.Realname = this.tbRealName.Text;
                itemUser.Email = this.tbEmail.Text;
                itemUser.Password = this.tbPassword.Text;

                bool result = bll.AddUser(itemUser, itemStudent, itemTeacher);

                if (result)
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
            ClassesBLL bll = new ClassesBLL();
            if (radStudent.IsChecked.Value)
            {
                lblChangeType.Content = "班级";
                cboData.DisplayMemberPath = "ClassName";
                cboData.SelectedValuePath = "ClassID";


                cboData.ItemsSource = bll.GetClasses();
            }

            if (radTeacher.IsChecked.Value)
            {
                lblChangeType.Content = "课程";
                cboData.DisplayMemberPath = "CourseName";
                cboData.SelectedValuePath = "CourseID";

                cboData.ItemsSource = bll.GetClasses();
            }
        }

        private void btnUploadHeadPortrait_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
            List<string> allowableFileTypes = new List<string>();
            allowableFileTypes.AddRange(new string[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" });
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!ofd.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(ofd.FileName);
                    if (allowableFileTypes.Contains(f.Extension.ToLower()))
                    {
                        UcImageCropper window = new UcImageCropper();
                        window.ImageUrl = f.FullName;
                        window.ShowDialog();
                        ImageSourceConverter converter = new ImageSourceConverter();

                        try
                        {
                            var imageSource = new BitmapImage();
                            window.ImageStream.Seek(0, SeekOrigin.Begin);
                            imageSource.BeginInit();
                            imageSource.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                            imageSource.StreamSource = window.ImageStream;
                            imageSource.EndInit();

                            imgHeadPortrait.Source = imageSource;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.InnerException.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid file type");
                    }
                }
                else
                {
                    MessageBox.Show("You did pick a file to use");
                }
            }
        }


    }
}
