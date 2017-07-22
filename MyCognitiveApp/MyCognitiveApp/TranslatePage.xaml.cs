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

namespace MyCognitiveApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TranslatePage : ContentPage
	{
        int clickTotal = 0;
        Editor editor = new Editor
        {
            Text = "temp",
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        Button checkButton = new Button
        {
            Text = "Check",
            HorizontalOptions = LayoutOptions.FillAndExpand
        };
        

        Label tempLabel = new Label
        {
            Text = "0 button clicks",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };

        public object HttpUtility { get; private set; }

        public TranslatePage ()
		{
			InitializeComponent ();

            var layout = new StackLayout();
            checkButton.Clicked += OnButtonClicked;
            var label = new Label
            {
                Text = "Enter your text to be spell checked bellow.",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
            };
            
            var filltop = new BoxView
            {
                Color = Color.Black,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 100
            };

            var fillbot = new BoxView
            {
                Color = Color.Black,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 100
            };


            layout.Children.Add(filltop);
            layout.Children.Add(label);
            layout.Children.Add(editor);
            layout.Children.Add(checkButton);
            layout.Children.Add(tempLabel);
            layout.Children.Add(fillbot);
            layout.Spacing = 50;
            Content = layout;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            clickTotal += 1;
            tempLabel.Text = String.Format("{0} button click{1}",
                            clickTotal, clickTotal == 1 ? "" : "s");

            //var response = 
            SendRequest(editor.Text);
        }

        async void SendRequest(string text)
        {
            string apiUrl = "https://api.cognitive.microsoft.com/bing/v5.0/spellcheck/?";
            string apiKey = "9c087ee817c14ef3aa4c710d4081137e";
            string repUrl = apiUrl + "text=" + editor.Text + "&mkt=en-us";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
                var response = await httpClient.GetAsync(repUrl);
                var responseString = await response.Content.ReadAsStringAsync();

                var spellResults = JsonConvert.DeserializeObject<SpellCheckResult>(responseString);
                //return spellResults;

                int numWrong = 0;
                string outResString = "";
                foreach (var flaggedToken in spellResults.FlaggedTokens)
                {
                    numWrong += 1;
                    outResString += "Incorrect: " + flaggedToken.Token + "\nSuggested Fix: " + flaggedToken.Suggestions.FirstOrDefault().Suggestion;
                    outResString += "\n===\n";

                }
                if (numWrong == 0)
                {
                    await DisplayAlert("Results", "All Correct!", "OK");
                }
                else
                {
                    await DisplayAlert("Results", outResString, "OK");
                }
                
            }
        }
    }
}