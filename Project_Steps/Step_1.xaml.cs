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

namespace Project_Playground.Project_Steps
{
    /// <summary>
    /// Interaction logic for Step_1.xaml
    /// </summary>
    public partial class Step_1 : Window
    {
        public Step_1()
        {
            InitializeComponent();
        }

        private void btnCreatePost_Click(object sender, RoutedEventArgs e)
        {
            string header = txtHeader.Text; // Get Header Text
            string body = runBody.Text; // Get Body Run

            // Create new BlogPost instance, pass in the header and body text
            BlogPost bp = new BlogPost(header, body);

            // Call our post method to return a formatted post string

            runDisplay.Text = bp.Post();
        }
    }
}
