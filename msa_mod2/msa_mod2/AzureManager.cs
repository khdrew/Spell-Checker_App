using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msa_mod2
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<HistoryResultModel> wordTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("https://spellChecker2000.azurewebsites.net");
            this.wordTable = this.client.GetTable<HistoryResultModel>();
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
            return await this.wordTable.ToListAsync();
        }

        public async Task DeleteHistory(HistoryResultModel historyResultModel)
        {
            await this.wordTable.DeleteAsync(historyResultModel);
        }
    }
}
