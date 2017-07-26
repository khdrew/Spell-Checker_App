
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace msa_mod2
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<SpellCheckHistory> historyTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("https://spellChecker2000.azurewebsites.net");
            this.historyTable = this.client.GetTable<SpellCheckHistory>();
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

        public async Task<List<SpellCheckHistory>> GetWords()
        {
            return await this.historyTable.ToListAsync();
        }

        public async Task PostHistoryInformation(SpellCheckHistory historyResultModel)
        {

            await this.historyTable.InsertAsync(historyResultModel);
        }

        public async Task DeleteHistory(SpellCheckHistory historyResultModel)
        {
            await this.historyTable.DeleteAsync(historyResultModel);
        }
    }
}
