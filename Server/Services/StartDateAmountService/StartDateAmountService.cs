namespace MyBudget.Server.Services.StartDateAmountService
{
    public class StartDateAmountService : IStartDateAmountService
    {
        private readonly DataContext _context;

        public StartDateAmountService(DataContext context)
        {
            _context = context;
        }
        private async Task<StartDateAmount> GetStartDateAmountForEdit(int id)
        {
            return await _context.StartDateAmounts.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<ServiceResponse<List<StartDateAmount>>> GetAllStartDateAmountsAsync()
        {

            var startDateAmounts = await _context.StartDateAmounts.ToListAsync();
            return new ServiceResponse<List<StartDateAmount>>()
            {
                Data = startDateAmounts
            };
        }

        public async Task<ServiceResponse<StartDateAmount>> GetStartDateAmountsAsync(int startDateAmountsId)
        {
            var response = new ServiceResponse<StartDateAmount>();
            var acctType = await _context.StartDateAmounts.FindAsync(startDateAmountsId);
            if (acctType == null)
            {
                response.Success = false;
                response.Message = $"Sorry, but this Acctount Type id{startDateAmountsId} does not exist";
            }
            else
            {
                response.Data = acctType;
            }
            return response;
        }

        public async Task<ServiceResponse<List<StartDateAmount>>> AddStartDateAmount(StartDateAmount startDateAmount)
        {
            // see if year already exists !!
            var response = new ServiceResponse<StartDateAmount>();
            var checkAllStartDateAmounts = await _context.StartDateAmounts
                   .Where(x => x.Year == startDateAmount.Year &&
                               x.OrganizationId == startDateAmount.OrganizationId).ToListAsync();
            if (checkAllStartDateAmounts.Count > 0)
            {
                response.Success = false;
                response.Message = $"Sorry, but {checkAllStartDateAmounts[0].Year} for org {checkAllStartDateAmounts[0].Organization.Name} and is active= {checkAllStartDateAmounts[0].Active}!";
                return await GetAllStartDateAmountsAsync();
            }
            else
            {
                _context.StartDateAmounts.Add(startDateAmount);
                await _context.SaveChangesAsync();
                return await GetAllStartDateAmountsAsync();
            }

        }

        public async Task<ServiceResponse<List<StartDateAmount>>> DeleteStartDateAmount(int id)
        {
            var deleteStartDateAmount = await GetStartDateAmountForEdit(id);
            _context.StartDateAmounts.Remove(deleteStartDateAmount); /// ?
            await _context.SaveChangesAsync();
            return await GetAllStartDateAmountsAsync();
        }

        public async Task<ServiceResponse<List<StartDateAmount>>> UpdateStartDateAmount(StartDateAmount startDateAmount)
        {
            var dbStartDateAmount = await GetStartDateAmountForEdit(startDateAmount.Id);
            if (dbStartDateAmount == null)
            {
                return new ServiceResponse<List<StartDateAmount>>
                {
                    Success = false,
                    Message = "Start Date Amount not found"
                };
            }
            dbStartDateAmount.Year = startDateAmount.Year;
            dbStartDateAmount.Day = startDateAmount.Day;
            dbStartDateAmount.StartDate = startDateAmount.StartDate;
            dbStartDateAmount.OrganizationId = startDateAmount.OrganizationId;
            dbStartDateAmount.Amount = startDateAmount.Amount;
            dbStartDateAmount.Active = startDateAmount.Active;

            await _context.SaveChangesAsync();
            return await GetAllStartDateAmountsAsync();
        }
    }
}
