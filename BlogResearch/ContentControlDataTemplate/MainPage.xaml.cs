namespace ContentControlDataTemplate
{
    public class SomeViewModel
    {
        public string Data { get; set; }

        public SomeViewModel()
        {
            Data = "Hello";
        }
    }

    public partial class MainPage
    {
        public SomeViewModel Some { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Some = new SomeViewModel();
            DataContext = this;
        }
    }
}