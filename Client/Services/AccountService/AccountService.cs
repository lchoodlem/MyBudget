using MyBudget.Shared;

namespace MyBudget.Client.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _http;

        public event Action OnChange;

        public AccountService(HttpClient _http)
        {
            this._http = _http;
        }
        public List<Account> Accounts { get; set; } = new List<Account>();

   
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Account>>>("api/Account");
            if(response != null && response.Data != null)
                Accounts = response.Data;
            return Accounts;

        }

        public async Task<ServiceResponse<Account>> GetAcctTypeById(int accountId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Account>>($"api/account/{accountId}");
            return result;
        }

        public async Task AddObject(Account obj)
        {
            var response = await _http.PostAsJsonAsync("api/Account", obj);
            Accounts = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Account>>>()).Data;
            await GetAccounts();
            OnChange.Invoke();
        }

        public Account CreateNewObject()
        {
            // stub out a new category for the form
            var newObj = new Account { IsNew = true, Editing = true };
            Accounts.Add(newObj);
            OnChange.Invoke();
            return newObj;
        }

        public async Task DeleteObject(int id)
        {
            var response = await _http.DeleteAsync($"api/Account/{id}");
            Accounts = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Account>>>()).Data;
            await GetAccounts();
            OnChange.Invoke();
        }

        public async Task UpdateObject(Account obj)
        {
            var response = await _http.PutAsJsonAsync("api/Account", obj);
            Accounts = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<Account>>>()).Data;
            await GetAccounts();
            OnChange.Invoke();
        }
    }
}
