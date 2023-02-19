namespace MyBudget.Client.Services.StartDateAmountsService
{
    public interface IStartDateAmountService
    {
        event Action OnChange;
        List<StartDateAmount> StartDateAmounts { get; set; }

        Task<IEnumerable<StartDateAmount>> GetStartDateAmounts();
        Task<List<StartDateAmount>> GetStartDateAmountsAsync();
        Task<StartDateAmount> GetStartDateAmountById(int StartDateAmountId);
        Task AddObject(StartDateAmount obj);
        Task DeleteObject(int id);
        Task UpdateObject(StartDateAmount obj);
        StartDateAmount CreateNewObject();
    }
}
