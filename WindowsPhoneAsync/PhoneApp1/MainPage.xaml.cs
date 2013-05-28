using System.Threading.Tasks;

namespace PhoneApp1
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        public async Task FooAsync()
        {
            await TaskEx.Delay(1000);
        }
    }
}