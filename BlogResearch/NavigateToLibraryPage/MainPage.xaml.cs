using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace NavigateToLibraryPage
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/wp7.library;component/Page.xaml", UriKind.Relative));
        }
    }
}