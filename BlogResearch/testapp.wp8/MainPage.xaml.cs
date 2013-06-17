using System;
using System.Windows;
using core;

namespace testapp.wp8
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
            Utilities.ShowMessage("Hello from WP8");
        }
    }
}