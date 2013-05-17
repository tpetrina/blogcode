using Microsoft.Phone.Controls;

namespace ViewboxTesting
{
    public partial class MainPage2 : PhoneApplicationPage
    {
        public string FullName
        {
            get { return "At the\r\nworld's end"; }
        }

        // Constructor
        public MainPage2()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}