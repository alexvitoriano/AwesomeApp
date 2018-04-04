using AwesomeApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AwesomeApp.ViewModels.Repositories
{
    public class RepositoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private bool Busy;

        public bool IsBusy { get { return Busy; } set { Busy = value; OnPropertyChanged(); GetRepoCommand.ChangeCanExecute(); } }

        private int Page = 1;

        public ObservableCollection<Repository> Repo { get; set; }

        public RepositoryViewModel()
        {
            Repo = new ObservableCollection<Repository>();

            GetRepoCommand = new Command(async () => await GetRepos(), () => !IsBusy);

        }

        async Task GetRepos()
        {
            if (!IsBusy)
            {
                Exception Error = null;

                try
                {
                    IsBusy = true;

                    var Repository = new DataRepository();
                    var Item = await Repository.GetRepositoryList(Page);

                    //Repo.Clear();
                    foreach (var Rep in Item)
                    {
                        Repo.Add(Rep);
                    }

                    Page++;
                }
                catch (Exception ex)
                {
                    Error = ex;
                }
                finally
                {
                    IsBusy = false;
                }

                if (Error != null)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error!!", Error.Message, "OK");
                }
            }
            return;

        }

        public Command GetRepoCommand { get; set; }
    }
}
