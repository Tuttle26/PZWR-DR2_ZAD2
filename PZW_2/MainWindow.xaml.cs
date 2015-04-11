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
using PZW_2.Controls;

namespace PZW_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.AddLeft.Click += AddLeft_Click;
            this.AddRight.Click += AddRight_Click;

            RegisterUserItemDelete();
            RegisterUserItemEdit();
            RegisterPostItemDelete();
            RegisterPostItemEdit();

        }
        private void RegisterUserItemDelete()
        {
            foreach (var child in this.RectangleContainer1.Children)
            {
                if (child is User)
                {
                    var userItem = (User)child;
                    userItem.Delete += new RoutedEventHandler(user_Delete);
                }
            }
        }

        private void RegisterPostItemDelete()
        {
            foreach (var child in this.RectangleContainer2.Children)
            {
                if (child is Post)
                {
                    var postItem = (Post)child;
                    postItem.Delete2 += new RoutedEventHandler(post_Delete);
                }
            }
        }

        private void RegisterUserItemEdit()
        {
            foreach (var child in this.RectangleContainer1.Children)
            {
                if (child is User)
                {
                    var userItem = (User)child;
                    userItem.Edit += new RoutedEventHandler(user_Edit);
                }
            }
        }

        private void RegisterPostItemEdit()
        {
            foreach (var child in this.RectangleContainer2.Children)
            {
                if (child is Post)
                {
                    var postItem = (Post)child;
                    postItem.Edit2 += new RoutedEventHandler(post_Edit);
                }
            }
        }

        void user_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }
            var userItem = (User)sender;
            this.RectangleContainer1.Children.Remove(userItem);
        }

        void post_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post)) { return; }
            var postItem = (Post)sender;
            this.RectangleContainer2.Children.Remove(postItem);
        }

        void user_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }
            var userItem = (User)sender;
            // edit event
        }

        void post_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post)) { return; }
            var postItem = (Post)sender;
            // edit event
        }

        void AddLeft_Click(object sender, RoutedEventArgs e)
        {
            var userControlItem = new User()
            {
                Width = 80,
                Height = 128
            };

            this.RectangleContainer1.Children.Add(userControlItem);
            // !!!
            RegisterUserItemDelete();
            RegisterUserItemEdit();
        }

        void AddRight_Click(object sender, RoutedEventArgs e)
        {
            var postControlItem = new Post()
            {
                Width = 350,
                Height = 128,
            };

            this.RectangleContainer2.Children.Add(postControlItem);
            // !!!
            RegisterPostItemDelete();
            RegisterPostItemEdit();
        }
    }
}
