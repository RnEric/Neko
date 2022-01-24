using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Neko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ver_info_Click(object sender, RoutedEventArgs e)
        {
            JObject rambutan_json_read = JObject.Parse(File.ReadAllText("rambutan.json"));
            JObject ori_json_read = JObject.Parse(File.ReadAllText("ori.json"));
            JArray rambutan_message_ver = JArray.Parse(rambutan_json_read["basicinfo"].ToString());
            JArray rambutan_random_message = JArray.Parse(rambutan_json_read["random_message"].ToString());
            JArray ori_message_ver = JArray.Parse(ori_json_read["basicinfo"].ToString());
            JArray ori_random_message = JArray.Parse(ori_json_read["random_message"].ToString());
            MessageBox.Show("毛丹词库版本：" + rambutan_message_ver[0] + "\n词库收录条数：" + rambutan_random_message.Count + "\n\nori词库版本：" + ori_message_ver[0] + "\n词库收录条数：" + ori_random_message.Count);
        }

        private void rambutan_Click(object sender, RoutedEventArgs e)
        {
            JObject rambutan_json_read = JObject.Parse(File.ReadAllText("rambutan.json"));
            JArray rambutan_random_message = JArray.Parse(rambutan_json_read["random_message"].ToString());
            var new_random_generator = new Random();
            int random_generator = new_random_generator.Next(0, rambutan_random_message.Count);
            MessageBox.Show(rambutan_random_message[random_generator].ToString());
        }

        private void neko_Topmost(object sender, RoutedEventArgs e)
        {
            if (neko_topmost_check.IsChecked == true)
            {
                this.Topmost = true;
            }
            else
            {
                this.Topmost = false;
            }
        }

        private void ori_Click(object sender, RoutedEventArgs e)
        {
            JObject ori_json_read = JObject.Parse(File.ReadAllText("ori.json"));
            JArray ori_random_message = JArray.Parse(ori_json_read["random_message"].ToString());
            var new_random_generator = new Random();
            int random_generator = new_random_generator.Next(0, ori_random_message.Count);
            MessageBox.Show(ori_random_message[random_generator].ToString());
        }
    }
}
