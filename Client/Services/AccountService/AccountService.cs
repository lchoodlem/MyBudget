namespace MyBudget.Client.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _http;

        public AccountService(HttpClient _http)
        {
            this._http = _http;
        }
        public List<Account> Accounts { get; set; } = new List<Account>();

        public async Task GetAccounts()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Account>>>("api/Account");
            if(response != null && response.Data != null)
                Accounts = response.Data;

        }

        public async Task<ServiceResponse<Account>> GetAcctTypeById(int accountId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Account>>($"api/account/{accountId}");
            return result;
        }
    }
}
