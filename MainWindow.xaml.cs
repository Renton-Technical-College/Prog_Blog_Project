using Project_Playground.Project_Steps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Project_Playground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<BlogPost> blogPosts = new ObservableCollection<BlogPost>();

        public MainWindow()
        {
            InitializeComponent();
            lbBlogPosts.ItemsSource = blogPosts;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string header = txtHeader.Text;
            string body = rtbBody.Text;
            MessageBox.Show(btnHeaderColor.Foreground.ToString());


            BlogPost blogPost = new BlogPost(header, body, btnHeaderColor.Foreground, btnBodyColor.Foreground);

            blogPosts.Add(blogPost);

        }

        private void ClearBlogColumn()
        {
            fdDisplay.Blocks.Clear();
        }

        private void lbBlogPosts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearBlogColumn();
            int selectedIndex = lbBlogPosts.SelectedIndex;

            fdDisplay.Blocks.Add(blogPosts[selectedIndex].Post());
        }

        private void btnGenColor_Click(object sender, RoutedEventArgs e)
        {
            string r = txtR.Text;
            string g = txtG.Text;
            string b = txtB.Text;

            btnGenColor.Foreground = GenerateColor(r, g, b);
        }

        private void btnHeaderColor_Click(object sender, RoutedEventArgs e)
        {
            btnHeaderColor.Foreground = btnGenColor.Foreground;
        }

        private void btnBodyColor_Click(object sender, RoutedEventArgs e)
        {
            btnBodyColor.Foreground = btnGenColor.Foreground;
        }

        public Brush GenerateColor(string red, string green, string blue)
        {
            byte r = CheckColor(red);
            byte g = CheckColor(green);
            byte b = CheckColor(blue);

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        public byte CheckColor(string color)
        {
            byte rgb = 0;
            bool isANumber = byte.TryParse(color, out rgb);
            bool isBetween0And25 = rgb < 0 || rgb > 255;

            if (!isANumber && !isBetween0And25)
            {
                MessageBox.Show($"{color} needs to be a number between 0 and 255");
            }

            return rgb;

        }

        private void OpenWindow_Click(object sender, RoutedEventArgs e)
        {
            Button btnWindow = (Button)sender;
            string btnText = btnWindow.Content.ToString();
            string lastNumber = btnText[btnText.Length - 1].ToString();
            

            switch(lastNumber)
            {
                case "1":
                    new Step_1().Show();
                    break;
                case "2":
                    new Step_2().Show();
                    break;
                case "3":
                    new Step_3().Show();
                    break;
                case "4":
                    new Step_4().Show();
                    break;
                default:
                    MessageBox.Show("Show Me Something");
                    break;
            }


        }
    }
}
