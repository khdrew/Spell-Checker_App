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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        MobileServiceClient client = AzureManager.AzureManagerInstance.AzureClient;

        public HistoryPage()
        {
            InitializeComponent();
            init_page();
        }

        async void init_page()
        {
            List<SpellCheckHistory> info = await AzureManager.AzureManagerInstance.GetWords();
            HistoryList.ItemsSource = info;
        }
        
        async void ClearButtonClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("WARNING", "Are you sure you want to clear your history?", "Yes", "No");
            if (answer == true)
            {
                List<SpellCheckHistory> info = await AzureManager.AzureManagerInstance.GetWords();
                foreach (SpellCheckHistory element in info)
                {
                    await AzureManager.AzureManagerInstance.DeleteHistory(element);
                }
                List<SpellCheckHistory> newInfo = await AzureManager.AzureManagerInstance.GetWords();
                HistoryList.ItemsSource = newInfo;
            }
        }

        async void GetButtonClicked(object sender, EventArgs e)
        {
            List<SpellCheckHistory> info = await AzureManager.AzureManagerInstance.GetWords();
            HistoryList.ItemsSource = info;
            await DisplayAlert("Results","History successfully obtained.","OK");
            
        }


    }
}