using Xamarin.Forms;

namespace CalendarDemo
{
    public class App : Application
    {
        public App()
        {
            MainPage = new CalendarDemoPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Ob resumes
        }
    }
}
