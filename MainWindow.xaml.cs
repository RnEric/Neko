using Newtonsoft.Json.Linq;
using System;
using System.IO;
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
            var new_random_generator_ori = new Random();
            int random_generator_ori = new_random_generator_ori.Next(0, Convert.ToInt32(ori_feeling.Maximum) + 1);
            ori_feeling.Value = random_generator_ori;
            ori_feeling_value.Text = ori_feeling.Value.ToString();
            var new_random_generator_rambutan = new Random();
            int random_generator_rambutan = new_random_generator_rambutan.Next(0, Convert.ToInt32(rambutan_feeling.Maximum) + 1);
            rambutan_feeling.Value = random_generator_rambutan;
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
            var new_random_generator = new Random();
            int random_generator = new_random_generator.Next(0, 1);
            return member_name + "最喜欢主人了！" + nya_meow[random_generator];
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
            var rambutan_click_random = new Random();
            int rambutan_feeling_change = rambutan_click_random.Next(-20, 20);
            string rambutan_plus = (rambutan_feeling_change + Convert.ToInt32(rambutan_feeling.Value)).ToString();
            string rambutan_minus = (Convert.ToInt32(rambutan_feeling.Value) + rambutan_feeling_change).ToString();
            string[] value_calculation = { rambutan_plus, rambutan_minus };
            var new_random_result = new Random();
            int random_result = new_random_result.Next(0, 1);
            double rambutan_feeling_final = Convert.ToDouble(value_calculation[random_result]);
            if (Convert.ToInt32(rambutan_feeling_final) > 100)
            {
                rambutan_feeling.Value = 100;
                rambutan_feeling_value.Text = rambutan_feeling.Value.ToString();
                rambutan_feeling_value_100.Text = value_100("毛丹");
            }
            else if (Convert.ToInt32(rambutan_feeling_final) < 0)
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
            var ori_click_random = new Random();
            int ori_feeling_change = ori_click_random.Next(-20, 20);
            string ori_plus = (ori_feeling_change + Convert.ToInt32(ori_feeling.Value)).ToString();
            string ori_minus = (Convert.ToInt32(ori_feeling.Value) + ori_feeling_change).ToString();
            string[] value_calculation = { ori_plus, ori_minus };
            var new_random_result = new Random();
            int random_result = new_random_result.Next(0, 1);
            double ori_feeling_final = Convert.ToDouble(value_calculation[random_result]);
            if (Convert.ToInt32(ori_feeling_final) > 100)
            {
                ori_feeling.Value = 100;
                ori_feeling_value.Text = ori_feeling.Value.ToString();
                ori_feeling_value_100.Text = value_100("ori");
            }
            else if (Convert.ToInt32(ori_feeling_final) < 0)
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
            JObject ori_json_read = JObject.Parse(File.ReadAllText("ori.json"));
            JArray ori_random_message = JArray.Parse(ori_json_read["random_message"].ToString());
            var new_random_generator = new Random();
            int random_generator = new_random_generator.Next(0, ori_random_message.Count);
            MessageBox.Show(ori_random_message[random_generator].ToString());
        }
    }
}
