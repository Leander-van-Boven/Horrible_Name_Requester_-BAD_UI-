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
using System.Windows.Shapes;

namespace BadUI
{
    /// <summary>
    /// Interaction logic for Dialogbox.xaml
    /// </summary>
    public partial class Dialogbox : Window
    {
        bool b1_submit;
        int depth;
        public Dialogbox(int _depth)
        {
            depth = _depth;
            InitializeComponent();
            contentblock.Content = "Are you sure you " + GenerateContent(depth);
            Random rnd = new Random();
            b1_submit = rnd.Next(2) == 0;
            if (b1_submit)
            {
                Button_1.Content = "Yes";
                Button_2.Content = "No";
            }
            else
            {
                Button_1.Content = "No";
                Button_2.Content = "Yes";
            }
        }

        string GenerateContent(int d)
        {
            if (d == 0)
            {
                return " want to submit?";
            }
            else
            {
                return " are sure you" + GenerateContent(d - 1);
            }
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            if (b1_submit)
            {
                if (depth == 10)
                {
                    DialogResult = true;
                    Close();
                }
                else
                {
                    DialogResult = new Dialogbox(depth + 1).ShowDialog();
                    Close();
                }
            }
            else
            {
                DialogResult = false;
                Close();
            }
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            if (b1_submit)
            {
                DialogResult = false;
                Close();
            }
            else
            {
                if (depth == 10)
                {
                    DialogResult = true;
                    Close();
                }
                else
                {
                    DialogResult = new Dialogbox(depth + 1).ShowDialog();
                    Close();
                }
            }
        }

        private void Contentblock_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            /*
            Console.WriteLine(contentblock.Width);
            Console.WriteLine(contentblock.RenderSize.Width);
            Console.WriteLine(contentblock.ActualWidth);
            Width = contentblock.Width;
            */
        }
    }
}
