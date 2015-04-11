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
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();

            this.DeleteImage.MouseDown += new MouseButtonEventHandler(DeleteImage_MouseDown);
            this.EditImage.MouseDown += new MouseButtonEventHandler(EditImage_MouseDown);
            // this  this.DeleteImage.MouseDown += (Sender e) => 
        }

        void DeleteImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeleteEvent();
        }

        void EditImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEditEvent();
        }

        // propdp
        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(String), typeof(User), new UIPropertyMetadata("Default"));


        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(User) //tip elementa koji posjeduje event
        );

        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
        (
           "Edit", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(User) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        public event RoutedEventHandler Edit //za registraciju/deregistraciju 
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.EditEvent);
            RaiseEvent(newEventArgs);
        }

    }
}
