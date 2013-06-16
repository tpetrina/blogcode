using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using testapp.portable;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace testapp.win8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = new ViewModel();
            viewModel.Load();
        }
    }
}
