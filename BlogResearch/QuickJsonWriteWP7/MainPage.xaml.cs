using System.Windows.Navigation;
using Newtonsoft.Json;

namespace QuickJsonWriteWP7
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var obj = new
            {
                user = new
                {
                    name = "John",
                    age = 21,
                    data = new[] { 1, 2, 3, 4 }
                }
            };

            txt.Text = JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}