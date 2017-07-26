using System;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace msa_mod2
{
    public partial class SpellCheckPage : ContentPage
    {
        public SpellCheckPage()
        {
            InitializeComponent();
        }

        private void CheckButtonClicked(object sender, EventArgs e)
        {
            SendRequest(checkEditor.Text);
        }

        
        async Task postHistoryAsync(String s)
        {
            SpellCheckHistory model = new SpellCheckHistory()
            {
                word = s
            };

            await AzureManager.AzureManagerInstance.PostHistoryInformation(model);
        }



        private async void SendRequest(string text)
        {
            string apiUrl = "https://api.cognitive.microsoft.com/bing/v5.0/spellcheck/?";
            string apiKey = "9c087ee817c14ef3aa4c710d4081137e";
            string repUrl = apiUrl + "text=" + text + "&mkt=en-us";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
                var response = await httpClient.GetAsync(repUrl);
                var responseString = await response.Content.ReadAsStringAsync();

                var spellResults = JsonConvert.DeserializeObject<SpellCheckModel>(responseString);

                int numWrong = 0;
                string outResString = "\n";
                foreach (var flaggedToken in spellResults.FlaggedTokens)
                {
                    numWrong += 1;
                    outResString += "Incorrect: " + flaggedToken.Token + "\nSuggested Fix: " + flaggedToken.Suggestions.FirstOrDefault().Suggestion;
                    outResString += "\n\n";

                }
                if (numWrong == 0)
                {
                    await DisplayAlert("Results", "All Correct!", "OK");
                }
                else
                {
                    await DisplayAlert("Results", outResString, "OK");
                    await postHistoryAsync(outResString);
                }

            }
        }
    }
}
