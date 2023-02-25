using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyBudget.Shared;

namespace MyBudget.Server.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly DataContext _context;

        public TransactionService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Transaction>>> AddTransaction(Transaction transaction)
        {
            transaction.Editing = transaction.IsNew = false;
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return await GetTransactions();
        }

        public async Task<ServiceResponse<Transaction>> GetTransactionById(int id)
        {
            var response = new ServiceResponse<Transaction>();
            var transaction = await _context.Transactions
            .Include(a => a.Account)
                .Include(tt => tt.TransactionType)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transaction == null)
            {
                response.Success = false;
                response.Message = "Sorry, Transaction not found.";
            }
            else
            {
                response.Data = transaction;
            }
            return response;
        }
        private async Task<Transaction> GetTransactionForEdit(int id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ServiceResponse<List<Transaction>>> DeleteTransaction(int id)
        {

            Transaction transaction = await GetTransactionForEdit(id);
            if (transaction == null)
            {
                return new ServiceResponse<List<Transaction>>
                {
                    Success = false,
                    Message = "Transaction not found"
                };
            }
            transaction.Deleted = true;
            await _context.SaveChangesAsync();
            return await GetTransactions();

        }


        public async Task<ServiceResponse<List<Transaction>>> GetTransactions()
        {
            var response = new ServiceResponse<List<Transaction>>
            {
                Data = await _context.Transactions.Include(a => a.Account).Include(t => t.TransactionType).ToListAsync()
            };

            var trans = await _context.Transactions.ToListAsync();
            return new ServiceResponse<List<Transaction>>
            { Data = trans };

        }

        public async Task<ServiceResponse<List<Transaction>>> GetTransactions(int budgetYrInt, int budgetMthInt)
        {
            var response = new ServiceResponse<List<Transaction>>
            {
                Data = await _context.Transactions
                .Where(t => t.YearInt == budgetYrInt && t.MonthInt == budgetMthInt)
                .Include(a => a.Account).Include(t => t.TransactionType).ToListAsync()
            };

            var trans = await _context.Transactions.ToListAsync();
            return new ServiceResponse<List<Transaction>> { Data = trans };

        }

        public async Task<ServiceResponse<List<Transaction>>> UpdateTransaction(Transaction transaction)
        {
            var dbTrans = await GetTransactionForEdit(transaction.Id);
            if (dbTrans == null)
            {
                return new ServiceResponse<List<Transaction>>
                {
                    Success = false,
                    Message = "Transaction not found"
                };
            }
            dbTrans.YearInt = transaction.YearInt;
            dbTrans.MonthInt = transaction.MonthInt;
            dbTrans.BudgetAmount = transaction.BudgetAmount;
            dbTrans.Amount = transaction.Amount;
            dbTrans.AccountId = transaction.AccountId;
            dbTrans.TransactionTypeId = transaction.TransactionTypeId;
            dbTrans.Reconciled = transaction.Reconciled;
            dbTrans.Deleted = transaction.Deleted; // this is to allow reset

            await _context.SaveChangesAsync();

            return await GetTransactions();
        }
    }
}
