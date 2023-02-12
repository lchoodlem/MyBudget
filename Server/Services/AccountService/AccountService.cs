using Microsoft.AspNetCore.Components.QuickGrid;
using MyBudget.Shared;

namespace MyBudget.Server.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _context;

        public AccountService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Account>>> GetAccounts()
        {
            var response = new ServiceResponse<List<Account>>
            {
                Data = await _context.Accounts.Include(o => o.Organization).Include(t => t.AcctType).ToListAsync()
            };

            var accounts = await _context.Accounts.ToListAsync();
            return new ServiceResponse<List<Account>>
            {
                Data = accounts
            };

        }
        private async Task<Account> GetAccountForEdit(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ServiceResponse<Account>> GetAccountById(int accountId)
        {
            var response = new ServiceResponse<Account>();
            var account = await _context.Accounts
                .Include(o => o.Organization)
                .Include(t => t.AcctType)
                .FirstOrDefaultAsync(a => a.Id == accountId);

            if (account == null)
            {
                response.Success = false;
                response.Message = "Sorry, Account not found.";
            }
            else
            {
                response.Data = account;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Account>>> AddAccount(Account account)
        {
            account.Editing = account.IsNew = false;
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return await GetAccounts();
        }

        public async Task<ServiceResponse<List<Account>>> DeleteAccount(int id)
        {
            Account account = await GetAccountForEdit(id);
            if (account == null)
            {
                return new ServiceResponse<List<Account>>
                {
                    Success = false,
                    Message = "Account not found"
                };
            }
            account.Deleted = true;
            await _context.SaveChangesAsync();
            return await GetAccounts();

        }



        public async Task<ServiceResponse<List<Account>>> UpdateAccount(Account account)
        {
            var dbAccount = await GetAccountForEdit(account.Id);
            if (dbAccount == null)
            {
                return new ServiceResponse<List<Account>>
                {
                    Success = false,
                    Message = "Account not found"
                };
            }
            dbAccount.Name = account.Name;
            dbAccount.AcctNum = account.AcctNum;
            dbAccount.OrganizationId = account.OrganizationId;
            dbAccount.AcctTypeId = account.AcctTypeId;
            dbAccount.Visible = account.Visible;
            dbAccount.Deleted = account.Deleted;// this is to allow reset

            await _context.SaveChangesAsync();

            return await GetAccounts();
        }
    }
}

