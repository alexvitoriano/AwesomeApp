using Newtonsoft.Json;
using Octokit;
using Octokit.Internal;
using ReactiveUI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeApp.Models
{
    public class DataRepository
    {
        string URLWebAPI = "https://api.github.com";


        public async Task<List<PullRequest>> GetPullRequestList(string Owner, string Repo)
        {
            List<PullRequest> Pulls;
            var Client = new System.Net.Http.HttpClient();
            Client.DefaultRequestHeaders.Add("User-Agent", "AwesomeApp");

            using (Client)
            {
                var JSON = await Client.GetStringAsync(string.Format("{0}/repos/{1}/{2}/pulls?state=all", URLWebAPI, Owner,Repo));
                
                Pulls = JsonConvert.DeserializeObject<List<PullRequest>>(JSON);
            }
            return Pulls;
        }


        public async Task<List<Repository>> GetRepositoryList(int page)
        {

            List<Repository> Repo = new List<Repository>();

            var Client = new System.Net.Http.HttpClient();
            Client.DefaultRequestHeaders.Add("User-Agent", "com.AlexVitoriano.Awesomeapp");

            using (Client)
            {
                try
                {
                    var JSON = await Client.GetStringAsync(string.Format("{0}/search/repositories?q=language:JavaScript&sort=stars&page={1}", URLWebAPI, page));
                    
                    SearchRepoResult internalItems = JsonConvert.DeserializeObject<SearchRepoResult>(JSON);

                    Repo = internalItems.items;
                    
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

            }

            return Repo;
        }

    }
}
