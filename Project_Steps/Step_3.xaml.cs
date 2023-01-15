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
    /// Interaction logic for Step_3.xaml
    /// </summary>
    public partial class Step_3 : Window
    {
        ObservableCollection<BlogPost> posts = new ObservableCollection<BlogPost>();

        public Step_3()
        {
            InitializeComponent();
            lbBlogPosts.ItemsSource = posts;
        }

        private void btnCreatePost_Click(object sender, RoutedEventArgs e)
        {
            string header = txtHeader.Text;
            string body = runBody.Text;

            BlogPost bp = new BlogPost(header, body);

            posts.Add(bp);
        } // btnCreatePost



        private void DisplayBlogPost(Paragraph blogPost)
        {
            fdDisplay.Blocks.Add(blogPost);
        }

        private void lbBlogPosts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearBlogDisplay();

            int selectedIndex = lbBlogPosts.SelectedIndex;
            BlogPost selectedPost = posts[selectedIndex];
            DisplayBlogPost(selectedPost.FullPost());
        }

        private void ClearBlogDisplay()
        {
            fdDisplay.Blocks.Clear();
        }
    }
}
