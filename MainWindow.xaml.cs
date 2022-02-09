using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

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
            ori_feeling.Value = random_generator(1, Convert.ToInt32(ori_feeling.Maximum) + 1);
            ori_feeling_value.Text = ori_feeling.Value.ToString();
            ori_feeling_value_100.Text = feeling_handle(0, 0, 0, "ori", ori_feeling.Value)[0];
            rambutan_feeling.Value = random_generator(1, Convert.ToInt32(rambutan_feeling.Maximum) + 1);
            rambutan_feeling_value.Text = rambutan_feeling.Value.ToString();
            rambutan_feeling_value_100.Text = feeling_handle(0, 0, 0, "毛丹", rambutan_feeling.Value)[0];
        }

        public static void random_message(string which_json)
        {
            if (!File.Exists(which_json))
            {
                MessageBox.Show("缺少配置文件" + which_json + "，请检查程序所在目录下是否有此文件。", "", 0, MessageBoxImage.Error);
            }
            else
            {
                JObject json_read = JObject.Parse(File.ReadAllText(which_json));
                JArray random_message = JArray.Parse(json_read["random_message"].ToString());
                MessageBox.Show(random_message[random_generator(0, random_message.Count)].ToString());
            }
        }

        public static string[] feeling_handle(int min, int max, double what_number, string member_name, double preset_number)
        {
            string[] nya_meow = { "nya~", "喵~" };
            string reaction_100 = member_name + "最喜欢主人了！" + nya_meow[random_generator(0, 2)];
            if (preset_number == -1)
            {
                int feeling_change = random_generator(min, max + 1);
                string plus = (feeling_change + what_number).ToString();
                string minus = (what_number + feeling_change).ToString();
                string[] value_calculation = { plus, minus };
                double feeling_handle_final = Convert.ToDouble(value_calculation[random_generator(0, 2)]);
                if (feeling_handle_final > 100)
                {
                    string[] content_100 = { 100.ToString(), reaction_100 };
                    return content_100;
                }
                else if (feeling_handle_final < 0)
                {
                    string[] normal_content = { 0.ToString(), "" };
                    return normal_content;
                }
                else
                {
                    string[] normal_content = { feeling_handle_final.ToString(), "" };
                    return normal_content;
                }
            }
            else
            {
                if (preset_number == 100)
                {
                    string[] init_content = { reaction_100 };
                    return init_content;
                }
                else
                {
                    string[] init_content = { "" };
                    return init_content;
                }
            }
        }

        public static int random_generator(int min, int max)
        {
            var new_random_generator = new Random();
            return new_random_generator.Next(min, max);
        }

        private void ver_info_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("ori.json") || !File.Exists("rambutan.json"))
            {
                MessageBox.Show("缺少必要文件ori.json或rambutan.json，请检查程序所在目录下是否有此文件。", "", 0, MessageBoxImage.Error);
            }
            else
            {
                JObject rambutan_json_read = JObject.Parse(File.ReadAllText("rambutan.json"));
                JObject ori_json_read = JObject.Parse(File.ReadAllText("ori.json"));
                JArray rambutan_message_ver = JArray.Parse(rambutan_json_read["basicinfo"].ToString());
                JArray rambutan_random_message = JArray.Parse(rambutan_json_read["random_message"].ToString());
                JArray ori_message_ver = JArray.Parse(ori_json_read["basicinfo"].ToString());
                JArray ori_random_message = JArray.Parse(ori_json_read["random_message"].ToString());
                MessageBox.Show("毛丹词库版本：" + rambutan_message_ver[0] + "\n词库收录条数：" + rambutan_random_message.Count + "\n\nori词库版本：" + ori_message_ver[0] + "\n词库收录条数：" + ori_random_message.Count + "\n\n程序版本：" + Assembly.GetExecutingAssembly().GetName().Version.ToString(), "", 0, MessageBoxImage.Asterisk);
            }
        }

        private void rambutan_Click(object sender, RoutedEventArgs e)
        {
            string[] rambutan_feeling_final = feeling_handle(-20, 20, rambutan_feeling.Value, "毛丹", -1);
            rambutan_feeling.Value = Convert.ToDouble(rambutan_feeling_final[0]);
            rambutan_feeling_value.Text = rambutan_feeling.Value.ToString();
            rambutan_feeling_value_100.Text = rambutan_feeling_final[1];
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
            string[] ori_feeling_final = feeling_handle(-20, 20, ori_feeling.Value, "ori", -1);
            ori_feeling.Value = Convert.ToDouble(ori_feeling_final[0]);
            ori_feeling_value.Text = ori_feeling.Value.ToString();
            ori_feeling_value_100.Text = ori_feeling_final[1];
            random_message("ori.json");
        }
    }
}