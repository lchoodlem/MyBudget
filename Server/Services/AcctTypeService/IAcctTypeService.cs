namespace MyBudget.Server.Services.AcctTypeService
{
    public interface IAcctTypeService
    {
        Task<ServiceResponse<List<AcctType>>> GetAllAcctTypesAsync();
        Task<ServiceResponse<AcctType>> GetAcctTypeAsync(int acctTypeId);

        Task<ServiceResponse<List<AcctType>>> AddAccountType(AcctType accountType);
        Task<ServiceResponse<List<AcctType>>> UpdateAccountType(AcctType accountType);
        Task<ServiceResponse<List<AcctType>>> DeleteAccountType(int id);
    }
}
