namespace MyBudget.Client.Services.AccountService
{
    public interface IAccountService
    {
        List<Account> Accounts {get; set;}

        Task GetAccounts();
        Task<ServiceResponse<Account>> GetAcctTypeById(int acctTypeId);
    }
}
