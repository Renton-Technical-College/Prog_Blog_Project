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
using System.Windows.Shapes;

namespace Project_Playground.Project_Steps
{
    /// <summary>
    /// Interaction logic for Step_4.xaml
    /// </summary>
    public partial class Step_4 : Window
    {
        ObservableCollection<BlogPost> posts = new ObservableCollection<BlogPost>();
        BlogPost bp = null;

        public Step_4()
        {
            InitializeComponent();
            lbBlogPosts.ItemsSource = posts;
        }

        private void btnCreatePost_Click(object sender, RoutedEventArgs e)
        {
            string header = txtHeader.Text;
            string body = runBody.Text;
            Brush headerColor = btnHeaderColor.Foreground;
            Brush bodyColor = btnBodyColor.Foreground;

            BlogPost bp = new BlogPost(header, body, headerColor, bodyColor);

            posts.Add(bp);

            DefaultColors();
        } // btnCreatePost

        private void DefaultColors()
        {
            btnHeaderColor.Foreground = txtR.Foreground;
            btnBodyColor.Foreground = txtR.Foreground;
            btnGenColor.Foreground = txtR.Foreground;
        }



        private void DisplayBlogPost(Paragraph blogPost)
        {
            fdDisplay.Blocks.Add(blogPost);
        }

        private void lbBlogPosts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearBlogDisplay();

            int selectedIndex = lbBlogPosts.SelectedIndex;
            bp = posts[selectedIndex];

            DisplayBlogPost(bp.FullPost());
        }

        private void ClearBlogDisplay()
        {
            fdDisplay.Blocks.Clear();
        }

        private void btnGenColor_Click(object sender, RoutedEventArgs e)
        {
            string rValueString = txtR.Text;
            string gValueString = txtG.Text;
            string bValueString = txtB.Text;

            byte r = ColorFormat(rValueString);
            byte g = ColorFormat(gValueString);
            byte b = ColorFormat(bValueString);

            SolidColorBrush color = new SolidColorBrush(Color.FromRgb(r, g, b));

            btnGenColor.Foreground = color;

        }

        private void btnBodyColor_Click(object sender, RoutedEventArgs e)
        {
            btnBodyColor.Foreground = btnGenColor.Foreground;
        }

        private void btnHeaderColor_Click(object sender, RoutedEventArgs e)
        {
            btnHeaderColor.Foreground = btnGenColor.Foreground;

        }

        public byte ColorFormat(string value)
        {

            byte colorValue = 0;
            byte defaultValue = 0;
            bool isANumber = byte.TryParse(value, out colorValue);

            // If the value is not a number, display and return 0
            if (!isANumber) {
                MessageBox.Show($"{value} is not a valid number in between 0 and 255");
                return defaultValue;
            }
            
            // Otherwise return value
            return colorValue;

        }
    }
}
