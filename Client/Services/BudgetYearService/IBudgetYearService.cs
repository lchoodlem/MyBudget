namespace MyBudget.Client.Services.BudgetYearService
{
    public interface IBudgetYearService
    {
        event Action OnChange;
        List<BudgetYear> BudgetYears { get; set; }

        Task<IEnumerable<BudgetYear>> GetBudgetYears();
        Task<List<BudgetYear>> GetBudgetYearsAsync();
        Task<BudgetYear> GetBudgetYearById(int BudgetYearId);
        Task AddObject(BudgetYear obj);
        Task DeleteObject(int id);
        Task UpdateObject(BudgetYear obj);
        BudgetYear CreateNewObject();
    }
}
