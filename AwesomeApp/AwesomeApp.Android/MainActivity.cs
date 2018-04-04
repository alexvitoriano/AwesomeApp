using Android.App;
using Android.Content.PM;
using Android.OS;
using System.Net;

namespace AwesomeApp.Droid
{
    [Activity(Label = "Awesome App", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
            System.Security.Cryptography.AesCryptoServiceProvider b = new System.Security.Cryptography.AesCryptoServiceProvider();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            try
            {
                LoadApplication(new App());
            }
            catch (System.Exception ex)
            {

                throw;
            }
            
        }
    }
}

