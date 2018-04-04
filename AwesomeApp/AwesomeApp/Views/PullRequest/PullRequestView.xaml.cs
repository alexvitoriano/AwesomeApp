using AwesomeApp.ViewModels.PullRequests;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp.Views.PullRequest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PullRequestView : ContentPage
    {
        PullRequestViewModel pullVm;
        
        public PullRequestView(string Owner, string Repo)
        {
            InitializeComponent();

            pullVm = new PullRequestViewModel(Owner,Repo);

            BindingContext = pullVm;

            pullVm.GetPullRequest.Execute(null);

            lstPullRqt.ItemsSource = pullVm.Pulls;

        }

        private void lstPullRqt_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var pull = (Models.PullRequest)e.SelectedItem;
            var page = new Site(pull.html_url);

            Navigation.PushAsync(page);
        }
    }
}