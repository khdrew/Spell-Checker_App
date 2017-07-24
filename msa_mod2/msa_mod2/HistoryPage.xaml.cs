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

        public HistoryPage()
        {
            InitializeComponent();

        }
        
        private void ClearButtonClicked(object sender, EventArgs e)
        {

        }

        public async void GetButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("DEBUG", "Getting", "OK");
            List<HistoryResultModel> info = await AzureManager.AzureManagerInstance.GetWords();
            await DisplayAlert("DEBUG","Got info","OK");
            HistoryList.ItemsSource = info;


        }


    }
}