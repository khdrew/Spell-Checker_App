
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace msa_mod2
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<HistoryResultModel> historyTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("https://spellChecker2000.azurewebsites.net");
            this.historyTable = this.client.GetTable<HistoryResultModel>();
        }


        public async Task PostHistoryInformation(HistoryResultModel historyResultModel)
        {
            await this.historyTable.InsertAsync(historyResultModel);
        }


        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task<List<HistoryResultModel>> GetWords()
        {
            return await this.historyTable.ToListAsync();
        }

        public async Task DeleteHistory(HistoryResultModel historyResultModel)
        {
            await this.historyTable.DeleteAsync(historyResultModel);
        }
    }
}
