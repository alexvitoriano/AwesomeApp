using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Site : ContentPage
    {
        public Site(string URL)
        {
            InitializeComponent();

            Browser.Source = new UrlWebViewSource { Url = new Uri(URL).ToString() };
        }
    }
}