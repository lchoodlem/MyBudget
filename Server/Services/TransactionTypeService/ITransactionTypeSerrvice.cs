namespace MyBudget.Server.Services.TransactionTypeService
{
    public interface ITransactionTypeSerrvice
    {
        Task<ServiceResponse<List<TransactionType>>> GetTransactionTypes(); // don't worry about lack of async in name
        Task<ServiceResponse<TransactionType>> GetTransactionTypeById(int transactionTypeId);
        Task<ServiceResponse<List<TransactionType>>> AddTransactionType(TransactionType transactionType);
        Task<ServiceResponse<List<TransactionType>>> UpdateTransactionType(TransactionType transactionType);
        Task<ServiceResponse<List<TransactionType>>> DeleteTransactionType(int id);
    }
}
