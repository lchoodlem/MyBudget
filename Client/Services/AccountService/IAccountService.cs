﻿namespace MyBudget.Client.Services.AccountService
{
    public interface IAccountService
    {
        event Action OnChange;
        List<Account> Accounts {get; set;}

        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccountById(int acctTypeId);
        Task AddObject(Account obj);
        Task DeleteObject(int id);
        Task UpdateObject(Account obj);
        Account CreateNewObject();
    }
}
