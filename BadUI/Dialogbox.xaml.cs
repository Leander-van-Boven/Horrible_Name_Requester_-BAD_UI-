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
        double minimum = 5.0;   // How many dialogs the victim mimimal should accept. (double to prevent integer division)
        bool b1_submit;         // Determines whether button1 should be the submit button.
        int depth;              // How many dialogboxes are already open
        Random rnd;
        public Dialogbox(int _depth)
        {
            depth = _depth;
            InitializeComponent();
            contentblock.Content = "Are you very sure you " + GenerateContent(depth);
            rnd = new Random();
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
                return " are very sure you" + GenerateContent(d - 1);
            }
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            if (b1_submit) TrySubmit();
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
            else TrySubmit();
        }

        private void TrySubmit()
        {
            double val = rnd.NextDouble();
            double tobeat = depth == 0 ? minimum : minimum / depth;
            if (val > tobeat)
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
