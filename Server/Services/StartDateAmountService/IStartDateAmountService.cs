namespace MyBudget.Server.Services.StartDateAmountService
{
    public interface IStartDateAmountService
    {
        Task<ServiceResponse<List<StartDateAmount>>> GetAllStartDateAmountsAsync();
        Task<ServiceResponse<StartDateAmount>> GetStartDateAmountsAsync(int startDateAmountsId);

        Task<ServiceResponse<List<StartDateAmount>>> AddStartDateAmount(StartDateAmount startDateAmount);
        Task<ServiceResponse<List<StartDateAmount>>> UpdateStartDateAmount(StartDateAmount startDateAmount);
        Task<ServiceResponse<List<StartDateAmount>>> DeleteStartDateAmount(int id);
    }
}
