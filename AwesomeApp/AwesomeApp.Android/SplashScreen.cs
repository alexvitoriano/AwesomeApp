using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System.Threading;

namespace AwesomeApp.Droid
{
    [Activity(Label = "Awesome App", Icon = "@drawable/icon", Theme = "@style/Theme.Splash",
    MainLauncher = true, NoHistory = true,
    ConfigurationChanges = ConfigChanges.ScreenSize, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Thread.Sleep(2000);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}