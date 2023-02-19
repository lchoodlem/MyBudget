namespace MyBudget.Server.Services.BudgetYearService
{
    public interface IBudgetYearService
    {
        Task<ServiceResponse<List<BudgetYear>>> GetAllBudgetYearAsync();
        Task<ServiceResponse<BudgetYear>> GetBudgetYearByIdAsync(int budgetYearId);
        Task<ServiceResponse<BudgetYear>> GetBudgetYearByYearAsync(int year);       
        Task<ServiceResponse<List<BudgetYear>>> AddBudgetYear(BudgetYear budgetYear);
        Task<ServiceResponse<List<BudgetYear>>> UpdateBudgetYear(BudgetYear budgetYear);
        Task<ServiceResponse<List<BudgetYear>>> DeleteBudgetYear(int id);
    }
}
