using System.Collections.ObjectModel;
using System.Linq;
using AwesomeApp.ViewModels.Repositories;
using AwesomeApp.Views.PullRequest;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomeApp.Views.Repository
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepositoryPage : ContentPage
    {

        RepositoryViewModel repVm;
        ObservableCollection<Models.Repository> tempdata;

        public RepositoryPage()
        {
            InitializeComponent();
            repVm = new RepositoryViewModel();

            BindingContext = repVm;

            repVm.GetRepoCommand.Execute(null);

            lstRepository.ItemsSource = repVm.Repo;
            tempdata = repVm.Repo;
            lstRepository.ItemAppearing += (sender, e) =>
            {
                if (repVm.IsBusy || repVm.Repo.Count == 0)
                    return;

                //hit bottom!
                if ((Models.Repository)e.Item == repVm.Repo[repVm.Repo.Count - 1])
                {
                    repVm.GetRepoCommand.Execute(null);
                }
            };

            lstRepository.ItemSelected += LstRepository_ItemSelected;

        }

        private void LstRepository_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var Repo = (Models.Repository)e.SelectedItem;
            var page = new PullRequestView(Repo.owner.login, Repo.name);

            Navigation.PushAsync(page);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //thats all you need to make a search  
            
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                lstRepository.ItemsSource = tempdata;
            }

            else
            {
                var name = tempdata.Where(x => x.name.StartsWith(e.NewTextValue));
                var user = tempdata.Where(x => x.owner.login.StartsWith(e.NewTextValue));

                lstRepository.ItemsSource = name.Union(user);
            }
        }
    }
}