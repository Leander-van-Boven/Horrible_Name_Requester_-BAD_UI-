using System;
using System.Collections.Generic;
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
using System.Threading;

namespace BadUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            keybuttons = new Button[] {
                b_97, b_98, b_99, b_100, b_101, b_102, b_103, b_104, b_105, b_106, b_107, b_108, b_109,
                b_110, b_111, b_112, b_113, b_114, b_115, b_116, b_117, b_118, b_119, b_120, b_121, b_122
            };
            b_106.Visibility = Visibility.Hidden;
            RandomizeKeys();
        }

        int keyint = 0;
        Button[] keybuttons;
        private void Keybutton_CLick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            namebox.Text += (char)int.Parse(b.Name.Split('_')[1]);
            /*int b_num = (int.Parse(b.Name.Split('_')[1]) + keyint);
            if (b_num > 122) b_num -= 26;
            namebox.Text = namebox.Text + (char)b_num;*/
            RandomizeKeys();
        }

        private void RandomizeKeys()
        {
            Random rnd = new Random();
            keyint = rnd.Next(0, 26);
            List<int> chars = new List<int>()
            {
                97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
                110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122
            };
            foreach (Button b in keybuttons)
            {
                int i = chars[rnd.Next(0, chars.Count)];
                b.Name = "b_" + i;
                b.Content = (char)i;
                chars.Remove(i);
                /*int b_num = (int.Parse(b.Name.Split('_')[1]) + keyint);
                if (b_num > 122) b_num -= 26;
                b.Content = (char)b_num;*/
            }
            ShuffleSubmit();
        }

        bool button1submit = true;
        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            if (button1submit) Submit();
            else BackSpace();
            ShuffleSubmit();
        }
        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            if (button1submit) BackSpace();
            else Submit();
            ShuffleSubmit();
        }
        
        private void Submit()
        {
            bool? res = new Dialogbox(0).ShowDialog();
            if (res == true)
            {
                string name = namebox.Text;
                if (DoCaptcha()) messagelabel.Content = "Congratulations!!! You submitted your name:\n" + name;
            }
        }
        
        private void BackSpace()
        {
            if (namebox.Text.Length == 0) return;
            namebox.Text = namebox.Text.Remove(namebox.Text.Length - 1);
        }

        private void ShuffleSubmit()
        {
            Random rnd = new Random();
            double i = rnd.NextDouble();
            if (i < 0.125)
            {
                Console.WriteLine("Shuffling submit..");
                string b1 = button_1.Content.ToString();
                string b2 = button_2.Content.ToString();
                button1submit = !button1submit;
                button_1.Content = b2;
                button_2.Content = b1;
            }
        }

        #region Captcha
        string[] captchaoperations = { "+", "-", "*", "/", "%" };
        bool DoCaptcha()
        {
            return true;
        }

        private void SubmitCaptcha_Click(object sender, RoutedEventArgs e)
        {
            SetupCaptchaGrid();
            CaptchaGrid.Visibility = Visibility.Visible;
        }
        void SetupCaptchaGrid()
        {
            Random rnd = new Random();
            int op = rnd.Next(5);
            int num1 = rnd.Next(int.MaxValue);
            int num2 = rnd.Next(int.MaxValue);
            switch (op)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
        #endregion

    }
}
