namespace MyBudget.Client.Services.TransactionService
{
    public interface ITransactionService
    {
        event Action OnChange;
        List<Transaction> Transactions { get; set; }

        Task<IEnumerable<Transaction>> GetTransactions();
        Task<IEnumerable<Transaction>> GetTransactions(int yrInt, int mnthInt);
        Task<Transaction> GetTransactionById(int transactionId);
        Task AddTransaction(Transaction transaction);
        Task DeleteTransaction(int id);
        Task UpdateTransaction(Transaction transaction);
        Transaction CreateNewTranaction();
    }
}
