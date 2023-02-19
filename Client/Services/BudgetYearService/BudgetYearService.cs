namespace MyBudget.Client.Services.BudgetYearService
{
    public class BudgetYearService : IBudgetYearService
    {
        private readonly HttpClient _http;

        public BudgetYearService(HttpClient http)
        {
            _http = http;
        }
        public List<BudgetYear> BudgetYears { get; set; } = new List<BudgetYear>();

        public event Action OnChange;

        public async Task<BudgetYear> GetBudgetYearById(int BudgetYearId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<BudgetYear>>($"api/BudgetYear/{BudgetYearId}");
            return result.Data;
        }
        public async Task<BudgetYear> GetBudgetYearByYear(int year)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<BudgetYear>>($"api/BudgetYearYear/{year}");
            return result.Data;
        }
        public async Task<BudgetYear> GetBudgetYearByYr(string year)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<BudgetYear>>($"api/BudgetYearYr/{year}");
            return result.Data;
        }

        public async Task<IEnumerable<BudgetYear>> GetBudgetYears()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<BudgetYear>>>("api/BudgetYear");
            if (result != null && result.Data != null)
                BudgetYears = result.Data;
            return BudgetYears;
        }
        public async Task<List<BudgetYear>> GetBudgetYearsAsync()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<BudgetYear>>>("api/BudgetYear");
            if(response != null && response.Data != null)
            { BudgetYears =  response.Data; }
            return BudgetYears;
        }

        public async Task AddObject(BudgetYear obj)
        {
            var response = await _http.PostAsJsonAsync("api/BudgetYear", obj);
            BudgetYears = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<BudgetYear>>>()).Data;
            await GetBudgetYears();
            OnChange.Invoke();
        }

        public BudgetYear CreateNewObject()
        {
            // stub out a new category for the form
            var newObj = new BudgetYear { };
            BudgetYears.Add(newObj);
            OnChange.Invoke();
            return newObj;
        }

        public async Task DeleteObject(int id)
        {
            var response = await _http.DeleteAsync($"api/BudgetYear/{id}");
            BudgetYears = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<BudgetYear>>>()).Data;
            await GetBudgetYears();
            OnChange.Invoke();
        }

        public async Task UpdateObject(BudgetYear BudgetYear)
        {
            var response = await _http.PutAsJsonAsync("api/BudgetYear", BudgetYear);
            BudgetYears = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<BudgetYear>>>()).Data;
            await GetBudgetYears();
            OnChange.Invoke();
        }


    }
}
