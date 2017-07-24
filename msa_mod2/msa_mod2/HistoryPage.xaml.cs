using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;

namespace msa_mod2
{
    public partial class HistoryPage : ContentPage
    {
        MobileServiceClient client = AzureManager.AzureManagerInstance.AzureClient;

        Button historyButton = new Button
        {
            Text = "Get History",
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        Button clearButton = new Button
        {
            Text = "Clear History",
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        public HistoryPage()
        {
            InitializeComponent();
            historyButton.Clicked += HistoryButtonClicked;
            clearButton.Clicked += ClearHistory;
            var layout = new StackLayout();

            layout.Children.Add(historyButton);
            layout.Children.Add(clearButton);

            Content = layout;
        }

        async void HistoryButtonClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("DEBUG", "GetWords", "OK");
            var info = await AzureManager.AzureManagerInstance.GetWords();
            await DisplayAlert("DEBUG", "info", "OK");
            //string outResString = "";
            //await DisplayAlert("History", "hello", "OK");

            //foreach (var wordGet in info)
            //{
            //    outResString += "> " + wordGet;
            //    outResString += "\n===\n";
            //}
            //await DisplayAlert("History", outResString, "OK");
        }

        async void ClearHistory(object sender, System.EventArgs e)
        {
            var answer = await DisplayAlert("WARNING", "Are you sure you want to clear your history?", "Yes", "No");
            if (answer == true)
            {
                List<HistoryResultModel> info = await AzureManager.AzureManagerInstance.GetWords();
                foreach (HistoryResultModel element in info)
                {
                    await AzureManager.AzureManagerInstance.DeleteHistory(element);
                }
                List<HistoryResultModel> newInfo = await AzureManager.AzureManagerInstance.GetWords();
                await DisplayAlert("Done", "History cleared.", "OK");
            }
        }
    }
}