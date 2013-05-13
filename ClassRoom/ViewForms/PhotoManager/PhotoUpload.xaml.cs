using System.Windows;
using Microsoft.Win32;
using System.IO;
using ClassRoom.BLL;

namespace ClassRoom.Views.PictureView
{
    /// <summary>
    /// PhotoUpload.xaml 的交互逻辑
    /// </summary>
    public partial class PhotoUpload : Window
    {
        public PhotoUpload()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = false;

            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                long fileSize = fileInfo.Length;
                if (fileSize < 1)
                {
                    MessageBox.Show("文件为空，无法上传 ");
                    return;
                }

                if (fileSize > 10000 * 1024)
                {
                    MessageBox.Show(string.Format("文件大小超出范围，最大允许大小, {0} KB ", 10000 * 1024));
                    return;
                }

                new ImageUpload().SaveImage(fileInfo.FullName);
            }
        }        
    }
}
