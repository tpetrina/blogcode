using System;
using System.Threading.Tasks;
using System.Windows;

namespace SlXnaApp1
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        // Simple button Click event handler to take us to the second page
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GamePage.xaml", UriKind.Relative));
        }

        public async Task FooAsync()
        {
            await TaskEx.Delay(1000);
        }
    }
}