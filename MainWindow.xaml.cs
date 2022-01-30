using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

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
            ori_feeling.Value = random_generator(0, Convert.ToInt32(ori_feeling.Maximum) + 1);
            ori_feeling_value.Text = ori_feeling.Value.ToString();
            rambutan_feeling.Value = random_generator(0, Convert.ToInt32(rambutan_feeling.Maximum) + 1);
            rambutan_feeling_value.Text = rambutan_feeling.Value.ToString();
            if (ori_feeling.Value == 100)
            {
                ori_feeling_value_100.Text = value_100("ori");
            }
            else
            {
                ori_feeling_value_100.Text = "";
            }
            if (rambutan_feeling.Value == 100)
            {
                rambutan_feeling_value_100.Text = value_100("毛丹");
            }
            else
            {
                rambutan_feeling_value_100.Text = "";
            }
        }

        public static string value_100(string member_name)
        {
            string[] nya_meow = { "nya~", "喵~" };
            return member_name + "最喜欢主人了！" + nya_meow[random_generator(0, 2)];
        }

        public static void random_message(string which_json)
        {
            JObject json_read = JObject.Parse(File.ReadAllText(which_json));
            JArray random_message = JArray.Parse(json_read["random_message"].ToString());
            MessageBox.Show(random_message[random_generator(0, random_message.Count)].ToString());
        }

        public static int random_generator(int min, int max)
        {
            var new_random_generator = new Random();
            return new_random_generator.Next(min, max);
        }

        public static double random_feeling(int min, int max, double what_number)
        {
            int feeling_change = random_generator(min, max);
            string plus = (feeling_change + what_number).ToString();
            string minus = (what_number + feeling_change).ToString();
            string[] value_calculation = { plus, minus };
            return Convert.ToDouble(value_calculation[random_generator(0, 2)]);
        }

        private void ver_info_Click(object sender, RoutedEventArgs e)
        {
            JObject rambutan_json_read = JObject.Parse(File.ReadAllText("rambutan.json"));
            JObject ori_json_read = JObject.Parse(File.ReadAllText("ori.json"));
            JArray rambutan_message_ver = JArray.Parse(rambutan_json_read["basicinfo"].ToString());
            JArray rambutan_random_message = JArray.Parse(rambutan_json_read["random_message"].ToString());
            JArray ori_message_ver = JArray.Parse(ori_json_read["basicinfo"].ToString());
            JArray ori_random_message = JArray.Parse(ori_json_read["random_message"].ToString());
            MessageBox.Show("毛丹词库版本：" + rambutan_message_ver[0] + "\n词库收录条数：" + rambutan_random_message.Count + "\n\nori词库版本：" + ori_message_ver[0] + "\n词库收录条数：" + ori_random_message.Count + "\n\n程序版本：" + Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        private void rambutan_Click(object sender, RoutedEventArgs e)
        {
            double rambutan_feeling_final = random_feeling(-20, 20, rambutan_feeling.Value);
            if (rambutan_feeling_final > 100)
            {
                rambutan_feeling.Value = 100;
                rambutan_feeling_value.Text = rambutan_feeling.Value.ToString();
                rambutan_feeling_value_100.Text = value_100("毛丹");
            }
            else if (rambutan_feeling_final < 0)
            {
                rambutan_feeling.Value = 0;
                rambutan_feeling_value.Text = rambutan_feeling.Value.ToString();
                rambutan_feeling_value_100.Text = "";
            }
            else
            {
                rambutan_feeling.Value = rambutan_feeling_final;
                rambutan_feeling_value.Text = rambutan_feeling.Value.ToString();
                if (rambutan_feeling.Value == 100)
                {
                    rambutan_feeling_value_100.Text = value_100("毛丹");
                }
                else
                {
                    rambutan_feeling_value_100.Text = "";
                }
            }
            random_message("rambutan.json");
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
            double ori_feeling_final = random_feeling(-20, 20, ori_feeling.Value);
            if (ori_feeling_final > 100)
            {
                ori_feeling.Value = 100;
                ori_feeling_value.Text = ori_feeling.Value.ToString();
                ori_feeling_value_100.Text = value_100("ori");
            }
            else if (ori_feeling_final < 0)
            {
                ori_feeling.Value = 0;
                ori_feeling_value.Text = ori_feeling.Value.ToString();
                ori_feeling_value_100.Text = "";
            }
            else
            {
                ori_feeling.Value = ori_feeling_final;
                ori_feeling_value.Text = ori_feeling.Value.ToString();
                if (ori_feeling.Value == 100)
                {
                    ori_feeling_value_100.Text = value_100("ori");
                }
                else
                {
                    ori_feeling_value_100.Text = "";
                }
            }
            random_message("ori.json");
        }
    }
}
