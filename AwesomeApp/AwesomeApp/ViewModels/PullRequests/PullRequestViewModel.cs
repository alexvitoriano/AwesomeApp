using AwesomeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AwesomeApp.ViewModels.PullRequests
{
    public class PullRequestViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private bool Busy;

        public bool IsBusy { get { return Busy; } set { Busy = value;OnPropertyChanged(); GetPullRequest.ChangeCanExecute(); } }

        public ObservableCollection<PullRequest> Pulls { get; set; }

        public PullRequestViewModel(string Owner, string Repo)
        {
            Pulls = new ObservableCollection<PullRequest>();
            GetPullRequest = new Command(async () => await GetPullRequests(Owner,Repo), () => !IsBusy);
        }

        async Task GetPullRequests(string owner, string repo)
        {
            if (!IsBusy)
            {
                Exception Error = null;

                try
                {
                    IsBusy = true;
                    
                    var Repository = new DataRepository();
                    var Item = await Repository.GetPullRequestList(owner, repo);

                    foreach (var Pull in Item)
                    {
                        Pulls.Add(Pull);
                    }
                    
                }
                catch (Exception ex)
                {

                    Error = ex;
                }
                finally
                {
                    IsBusy = false;
                }

            }
            return;
        }

        public Command GetPullRequest { get; set; }
    }
}
