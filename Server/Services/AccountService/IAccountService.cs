namespace MyBudget.Server.Services.AccountService
{
    public interface IAccountService
    {

        Task<ServiceResponse<Account>> GetAccountById(int accountId);
        Task<ServiceResponse<List<Account>>> GetAccounts();
        Task<ServiceResponse<List<Account>>> AddAccount(Account account);
        Task<ServiceResponse<List<Account>>> UpdateAccount(Account account);
        Task<ServiceResponse<List<Account>>> DeleteAccount(int id);

    }
}
