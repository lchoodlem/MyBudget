namespace MyBudget.Server.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<ServiceResponse<Transaction>> GetTransactionById(int id);
        Task<ServiceResponse<List<Transaction>>> GetTransactions();
        Task<ServiceResponse<List<Transaction>>> GetTransactions(int budgetYrInt, int budgetMthInt);
        Task<ServiceResponse<List<Transaction>>> AddTransaction(Transaction transaction);
        Task<ServiceResponse<List<Transaction>>> UpdateTransaction(Transaction transaction);
        Task<ServiceResponse<List<Transaction>>> DeleteTransaction(int id);
    }
}
