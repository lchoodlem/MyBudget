namespace MyBudget.Client.Services.StartDateAmountsService
{
    public class StartDateAmountService : IStartDateAmountService
    {
        private readonly HttpClient _http;

        public StartDateAmountService(HttpClient http)
        {
            _http = http;
        }
        public List<StartDateAmount> StartDateAmounts { get; set; } = new List<StartDateAmount>();

        public event Action OnChange;

        public async Task<StartDateAmount> GetStartDateAmountById(int StartDateAmountId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<StartDateAmount>>($"api/StartDateAmount/{StartDateAmountId}");
            return result.Data;
        }

        public async Task<IEnumerable<StartDateAmount>> GetStartDateAmounts()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<StartDateAmount>>>("api/StartDateAmount");
            if (result != null && result.Data != null)
                StartDateAmounts = result.Data;
            return StartDateAmounts;
        }
        public async Task<List<StartDateAmount>> GetStartDateAmountsAsync()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<StartDateAmount>>>("api/StartDateAmount");
            if(response != null && response.Data != null)
            { StartDateAmounts =  response.Data; }
            return StartDateAmounts;
        }

        public async Task AddObject(StartDateAmount obj)
        {
            var response = await _http.PostAsJsonAsync("api/StartDateAmount", obj);
            StartDateAmounts = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<StartDateAmount>>>()).Data;
            await GetStartDateAmounts();
            OnChange.Invoke();
        }

        public StartDateAmount CreateNewObject()
        {
            // stub out a new category for the form
            var newObj = new StartDateAmount { };
            StartDateAmounts.Add(newObj);
            OnChange.Invoke();
            return newObj;
        }

        public async Task DeleteObject(int id)
        {
            var response = await _http.DeleteAsync($"api/StartDateAmount/{id}");
            StartDateAmounts = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<StartDateAmount>>>()).Data;
            await GetStartDateAmounts();
            OnChange.Invoke();
        }

        public async Task UpdateObject(StartDateAmount StartDateAmount)
        {
            var response = await _http.PutAsJsonAsync("api/StartDateAmount", StartDateAmount);
            StartDateAmounts = (await response.Content
                .ReadFromJsonAsync<ServiceResponse<List<StartDateAmount>>>()).Data;
            await GetStartDateAmounts();
            OnChange.Invoke();
        }


    }
}
