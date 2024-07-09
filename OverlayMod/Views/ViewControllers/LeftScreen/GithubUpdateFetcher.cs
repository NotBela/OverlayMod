using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OverlayMod.Views.ViewControllers.LeftScreen
{
    internal class GithubUpdateFetcher
    {
        private HttpClient _client = new HttpClient();
        private string currentVersion => $"{IPA.Loader.PluginManager.GetPluginFromId("OverlayMod").HVersion}";

        public async Task<bool> IsModVersionUpToDateAsync()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new System.Uri("https://api.github.com/repos/NotBela/OverlayMod/releases");
            request.Headers.Add("User-Agent", "OverlayMod");
            request.Headers.Add("X-Github-Api-Version", "2022-11-28");
            request.Headers.Add("Accept", "application/vnd.github+json");

            try
            {
                var response = await _client.SendAsync(request);
                if (!response.IsSuccessStatusCode) return false;

                var releases = JArray.Parse(await response.Content.ReadAsStringAsync());
                var latest = releases[0];
                
                var latestVersion = latest["tag_name"].Value<string>();

                return latestVersion == currentVersion;
            }
            catch
            {
                return false;
            }
        }
    }
}
