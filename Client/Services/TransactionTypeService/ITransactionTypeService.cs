namespace MyBudget.Client.Services.TransactionTypeService
{
    public interface ITransactionTypeService
    {
        event Action OnChange;
        List<TransactionType> TransactionTypes { get; set; }

        Task GetTransactionTypes();
        Task<ServiceResponse<TransactionType>> GetTransactionTypeById(int transactionTypeId);
        Task AddTransactionType(TransactionType transactionType);
        Task DeleteTransactionType(int transactionTypeId);
        Task UpdateTransactionType(TransactionType transactionType);
        TransactionType CreateNewTransactionType();
    }
}
