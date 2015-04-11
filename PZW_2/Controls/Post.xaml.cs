using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PZW_2.Controls
{
    /// <summary>
    /// Interaction logic for MediaItem.xaml
    /// </summary>
    public partial class Post : UserControl
    {
        public Post()
        {
            InitializeComponent();

            this.DeleteImage2.MouseDown += new MouseButtonEventHandler(DeleteImage_MouseDown);
            this.EditImage2.MouseDown += new MouseButtonEventHandler(EditImage_MouseDown);
            // this  this.DeleteImage.MouseDown += (Sender e) => 
        }

        public String Status
        {
            get { return (String)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Status.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(String), typeof(Post), new PropertyMetadata("Defaultni status tekst"));
        
        void DeleteImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeleteEvent();
        }

        void EditImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEditEvent();
        }

        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete2", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post) //tip elementa koji posjeduje event
        );

        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
        (
           "Edit2", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Delete2 //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        public event RoutedEventHandler Edit2 //za registraciju/deregistraciju 
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.EditEvent);
            RaiseEvent(newEventArgs);
        }
    }
}
