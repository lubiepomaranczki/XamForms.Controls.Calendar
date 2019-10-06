using Xamarin.Forms;

namespace CalendarDemo
{
    public partial class CalendarDemoPage : ContentPage
    {
        public CalendarDemoPage()
        {
            InitializeComponent();
            BindingContext = new CalendarDemoViewModel();
        }
    }
}
