using MyBudget.Shared;

namespace MyBudget.Server.Services.AcctTypeService
{
    public class AcctTypeService : IAcctTypeService
    {
        private readonly DataContext _context;

        public AcctTypeService(DataContext context)
        {
            _context = context;
        }

        private async Task<AcctType> GetAccountTypeForEdit(int id)
        {
            return await _context.AcctTypes.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<ServiceResponse<AcctType>> GetAcctTypeAsync(int acctTypeId)
        {
            var response = new ServiceResponse<AcctType>();
            var acctType = await _context.AcctTypes.FindAsync(acctTypeId);
            if(acctType == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this Acctount Type does not exist";
            }
            else
            {
                response.Data = acctType;
            }
            return response;
        }

        public async Task<ServiceResponse<List<AcctType>>> GetAllAcctTypesAsync()
        {
            var acctTypes = await _context.AcctTypes.ToListAsync();
            return new ServiceResponse<List<AcctType>>()
            {
                Data = acctTypes
            };
            
        }

        public async Task<ServiceResponse<List<AcctType>>> AddAccountType(AcctType accountType)
        {
            accountType.Editing = accountType.IsNew = false;
            _context.AcctTypes.Add(accountType);
            await _context.SaveChangesAsync();
            return await GetAllAcctTypesAsync();
        }

        public async Task<ServiceResponse<List<AcctType>>> UpdateAccountType(AcctType accountType)
        {
            var dbAccountType = await GetAccountTypeForEdit(accountType.Id);
            if (dbAccountType == null)
            {
                return new ServiceResponse<List<AcctType>>
                {
                    Success = false,
                    Message = "Account Type not found"
                };
            }
            dbAccountType.Name = accountType.Name;
            dbAccountType.Visible = accountType.Visible;


            await _context.SaveChangesAsync();

            return await GetAllAcctTypesAsync();
        }

        public async Task<ServiceResponse<List<AcctType>>> DeleteAccountType(int id)
        {
            AcctType accountType = await GetAccountTypeForEdit(id);
            if (accountType == null)
            {
                return new ServiceResponse<List<AcctType>>
                {
                    Success = false,
                    Message = "Account Type not found"
                };
            }
            accountType.Deleted = true;
            await _context.SaveChangesAsync();
            return await GetAllAcctTypesAsync();
        }
    }

}

