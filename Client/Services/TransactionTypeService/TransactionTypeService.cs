namespace MyBudget.Client.Services.TransactionTypeService
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly HttpClient _http;

        public TransactionTypeService(HttpClient http)
        {
            _http = http;
        }
        public List<TransactionType> TransactionTypes { get; set; } = new List<TransactionType>();

        public event Action OnChange;

        public async Task AddTransactionType(TransactionType transactionType)
        {
            var response = await _http.PostAsJsonAsync("api/TransactionType", transactionType);
            TransactionTypes = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<TransactionType>>>()).Data;
            await GetTransactionTypes();
            OnChange.Invoke();
        }

        public TransactionType CreateNewTransactionType()
        {
            // stub out a new category for the form
            var newTransType = new TransactionType { IsNew = true, Editing = true };
            TransactionTypes.Add(newTransType);
            OnChange.Invoke();
            return newTransType;
        }

        public async Task DeleteTransactionType(int transactionTypeId)
        {
            var response = await _http.DeleteAsync($"api/TransactionType/{transactionTypeId}");
            TransactionTypes = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<TransactionType>>>()).Data;
            await GetTransactionTypes();
            OnChange.Invoke();
        }

        public async Task<ServiceResponse<TransactionType>> GetTransactionTypeById(int transactionTypeId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<TransactionType>>($"api/transactionType/{transactionTypeId}");
            return result;
        }

        public async Task<IEnumerable<TransactionType>> GetTransactionTypes()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<TransactionType>>>("api/transactionType");
            if(response != null && response.Data != null) 
                TransactionTypes= response.Data;
            return TransactionTypes;
        }

        public async Task UpdateTransactionType(TransactionType transactionType)
        {
            var response = await _http.PutAsJsonAsync("api/TransactionType", transactionType);
            TransactionTypes = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<TransactionType>>>()).Data;
            await GetTransactionTypes();
            OnChange.Invoke();
        }
    }
}
