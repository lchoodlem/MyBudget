using Azure;
using MyBudget.Shared;

namespace MyBudget.Server.Services.BudgetYearService
{
    public class BudgetYearService : IBudgetYearService
    {
        private readonly DataContext _context;

        public BudgetYearService(DataContext context)
        {
            _context = context;
        }

        private async Task<BudgetYear> GetBudgetYearForEdit(int id)
        {
            return await _context.BudgetYears.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<ServiceResponse<List<BudgetYear>>> GetAllBudgetYearAsync()
        {
            var budgetYears = await _context.BudgetYears.ToListAsync();
            return new ServiceResponse<List<BudgetYear>>()
            {
                Data = budgetYears
            };
        }

        public async Task<ServiceResponse<BudgetYear>> GetBudgetYearByIdAsync(int budgetYearId)
        {
            var response = new ServiceResponse<BudgetYear>();
            var budgetYear = await _context.BudgetYears.FindAsync(budgetYearId);
            if (budgetYear == null)
            {
                response.Success = false;
                response.Message = $"Sorry, but this Budget year id{budgetYearId} does not exist";
            }
            else
            {
                response.Data = budgetYear;
            }
            return response;
        }

        public async Task<ServiceResponse<BudgetYear>> GetBudgetYearByYearAsync(int year)
        {
            var response = new ServiceResponse<BudgetYear>();
            var budgetYear = await _context.BudgetYears.FindAsync(year);
            if (budgetYear == null)
            {
                response.Success = false;
                response.Message = $"Sorry, but this Budget year(year): '{year}' does not exist";
            }
            else
            {
                response.Data = budgetYear;
            }
            return response;
        }
        public async Task<ServiceResponse<List<BudgetYear>>> AddBudgetYear(BudgetYear budgetYear)
        {
            // see if year already exists !!
            var response = new ServiceResponse<BudgetYear>();
            var checkAllBudgetYears = await _context.BudgetYears.Where(x => x.Year ==budgetYear.Year).ToListAsync();
            if(checkAllBudgetYears.Count > 0)
            {
                response.Success = false;
                response.Message = $"Sorry, but this Budget year(year): '{budgetYear.Year}' Exists!";
                return await GetAllBudgetYearAsync();
            }
            else
            {
                _context.BudgetYears.Add(budgetYear);
                await _context.SaveChangesAsync();
                return await GetAllBudgetYearAsync();
            }

        }

        public async Task<ServiceResponse<List<BudgetYear>>> DeleteBudgetYear(int id)
        {   // this should not be done ever
            BudgetYear budgetYear = await GetBudgetYearForEdit(id);
            if (budgetYear == null)
            {
                return new ServiceResponse<List<BudgetYear>>
                {
                    Success = false,
                    Message = "Budget Year not found"
                };
            }
            budgetYear.Deleted = true;
            await _context.SaveChangesAsync();
            return await GetAllBudgetYearAsync();
        }

        public async Task<ServiceResponse<List<BudgetYear>>> UpdateBudgetYear(BudgetYear budgetYear)
        {
            var dbBudgetYear = await GetBudgetYearForEdit(budgetYear.Id);
            if (dbBudgetYear == null)
            {
                return new ServiceResponse<List<BudgetYear>>
                {
                    Success = false,
                    Message = "Budget Year not found!"
                };
            }
            dbBudgetYear.Year = budgetYear.Year;
            dbBudgetYear.ReconcileBalanceId = budgetYear.ReconcileBalanceId;
            dbBudgetYear.CurrentYear = budgetYear.CurrentYear;
            dbBudgetYear.Deleted = budgetYear.Deleted;// this is to allow reset


            await _context.SaveChangesAsync();

            return await GetAllBudgetYearAsync();
        }
    }

}
