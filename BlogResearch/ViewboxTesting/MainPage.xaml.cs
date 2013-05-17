using Microsoft.Phone.Controls;

namespace ViewboxTesting
{
    public partial class MainPage : PhoneApplicationPage
    {
        public string FullName
        {
            get { return "At the\r\nworld's end"; }
        }

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}