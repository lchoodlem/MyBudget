namespace MyBudget.Server.Services.TransactionTypeService
{
    public class TransactionTypeService : ITransactionTypeSerrvice
    {
        private readonly DataContext _context;

        public TransactionTypeService(DataContext context)
        {
            _context = context;
        }

        private async Task<TransactionType> GetTransactionTypeForEdit(int id)
        {
            return await _context.TransactionTypes.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ServiceResponse<TransactionType>> GetTransactionTypeById(int transactionTypeId)
        {
            var response = new ServiceResponse<TransactionType>();
            var transactionType = await _context.TransactionTypes.FindAsync(transactionTypeId);
            if (transactionType == null)
            {
                response.Success = false;
                response.Message = $"Sorry, but this Transaction Type: '{transactionTypeId}' does not exist";
            }
            else
            {
                response.Data = transactionType;
            }
            return response;
        }

        public async Task<ServiceResponse<List<TransactionType>>> GetTransactionTypes()
        {
            var transactionTypes = await _context.TransactionTypes.ToListAsync();
            return new ServiceResponse<List<TransactionType>>
            {
                Data = transactionTypes
            };

        }

        public async Task<ServiceResponse<List<TransactionType>>> AddTransactionType(TransactionType transactionType)
        {
            var foundTransType = await _context.TransactionTypes.FirstOrDefaultAsync(t => t.TypeName == transactionType.TypeName);
            if (foundTransType != null)
            {
                return new ServiceResponse<List<TransactionType>>
                {
                    Success = false,
                    Message = $"Organization: '{transactionType.TypeName}' already exists"
                };
            }
            transactionType.Editing = transactionType.IsNew = false;
            await _context.SaveChangesAsync();

            return await GetTransactionTypes();
        }

        public async Task<ServiceResponse<List<TransactionType>>> UpdateTransactionType(TransactionType transactionType)
        {
            var dbTransType = await GetTransactionTypeForEdit(transactionType.Id);
            if (dbTransType == null)
            {
                return new ServiceResponse<List<TransactionType>>
                {
                    Success = false,
                    Message = "Transaction Type not found"
                };
            }
            dbTransType.TypeName = transactionType.TypeName;
            dbTransType.Debit = transactionType.Debit;
            dbTransType.Description = transactionType.Description;
            dbTransType.Visible = transactionType.Visible;
            dbTransType.Deleted = transactionType.Deleted;// this is to allow reset

            await _context.SaveChangesAsync();

            return await GetTransactionTypes();

        }

        public async Task<ServiceResponse<List<TransactionType>>> DeleteTransactionType(int id)
        {
            var dbTransType = await GetTransactionTypeForEdit(id);
            if (dbTransType == null)
            {
                return new ServiceResponse<List<TransactionType>>
                {
                    Success = false,
                    Message = "Transaction Type not found"
                };
            }
            dbTransType.Deleted = true;
            await _context.SaveChangesAsync();

            return await GetTransactionTypes();

        }
    }
}
