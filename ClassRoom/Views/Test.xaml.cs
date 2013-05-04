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
using System.Data.EntityClient;
using System.Data.Common;
using System.Data;
using ClassRoom.Common;

namespace ClassRoom.Views
{
    /// <summary>
    /// Test.xaml 的交互逻辑
    /// </summary>
    public partial class Test : Window
    {
        public static string count = "我真好想你了，不是吗？靠";
        public Test()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            object source = e.Source;
            object originalSource = e.OriginalSource;
        }
        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)e.Source;
            MessageBox.Show(string.Format("You chose the {1}color {0}!", button.Content, button.Foreground));
        }
        private void Handler(object sender, KeyEventArgs e)
        {
            bool isPreview = e.RoutedEvent.Name.StartsWith("Preview");
            string direction = isPreview ? "v" : "^";
            Output.Items.Add(string.Format("{0} {1}",
            direction,
            sender.GetType().Name));
            if (sender == e.OriginalSource && isPreview)
                Output.Items.Add("-{bounce}-");
            if (sender == this && !isPreview)
                Output.Items.Add(" -end- ");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //using(ClassRoomEntities entities = new ClassRoomEntities())
        }

        private void CreateEntityClientEntitySQL()
        {
            string city = "London";

            using (EntityConnection cn = new EntityConnection("Name=ClassRoomEntities"))
            {

                cn.Open();

                EntityCommand cmd = cn.CreateCommand();

                cmd.CommandText = @"SELECT VALUE c FROM Entities.Customers AS c WHERE

c.Address.City = @city";

                cmd.Parameters.AddWithValue("city", city);

                DbDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                while (rdr.Read())

                    Console.WriteLine(rdr["CompanyName"].ToString());

                rdr.Close();

            }
        }

        private void CreateObjectContextLINQ()
        {
            string className = "235班";

            using (ClassRoomEntities entities = new ClassRoomEntities())
            {

                var query = from c in entities.Classes

                            where c.ClassName == className

                            select c;

                query = entities.Classes.Where(r => r.ClassName == className);
            }
        }


    }
}
