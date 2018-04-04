using AwesomeApp.Utils;
using AwesomeApp.Views.Repository;

using Xamarin.Forms;

namespace AwesomeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navi = new NavigationPage(new RepositoryPage());

            navi.BarBackgroundColor = Palette.Header;

            MainPage = navi;
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
            // Handle when your app resumes
        }
    }
}
