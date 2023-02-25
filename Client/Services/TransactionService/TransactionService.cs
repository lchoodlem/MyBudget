using MyBudget.Shared;

namespace MyBudget.Client.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly HttpClient _http;

        public event Action OnChange;
        public TransactionService(HttpClient http)
        {
            _http = http;
        }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public async Task AddTransaction(Transaction transaction )
        {
            var response = await _http.PostAsJsonAsync("api/Transaction", transaction);
            Transactions = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Transaction>>>()).Data;
            await GetTransactions();
            OnChange.Invoke();
        }

        public Transaction CreateNewTranaction()
        {
            // stub out a new category for the form
            var newTransaction = new Transaction { IsNew = true, Editing = true };
            Transactions.Add(newTransaction);
            OnChange.Invoke();
            return newTransaction;
        }

        public async Task DeleteTransaction(int id)
        {
            var response = await _http.DeleteAsync($"api/transaction/{id}");
            Transactions = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Transaction>>>()).Data;
            await GetTransactions();
            OnChange.Invoke();
        }

        public async Task<Transaction> GetTransactionById(int transactionId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Transaction>>($"api/transaction/{transactionId}");
            return result.Data;

        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Transaction>>>("api/Transaction");
            if (response != null && response.Data != null)
                Transactions = response.Data;
            return Transactions;

        }

        public async Task<IEnumerable<Transaction>> GetTransactions(int yrInt, int mnthInt)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Transaction>>>("api/Transaction/yrInt/mnthInt");
            if (response != null && response.Data != null)
                Transactions = response.Data;
            return Transactions;

        }

        public async Task UpdateTransaction(Transaction transaction)
        {
            var response = await _http.PutAsJsonAsync("api/Transaction", transaction);
            Transactions = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Transaction>>>()).Data;
            await GetTransactions();
            OnChange.Invoke();
        }
    }
}
