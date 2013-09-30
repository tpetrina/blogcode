using System;
using System.Windows;

namespace UriMapper1
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("SettingsPage.xaml", UriKind.Relative));
        }
    }
}