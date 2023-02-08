namespace MyBudget.Client.Services.AcctTypesService
{
    public interface IAcctTypeService
    {
        List<AcctType> AcctTypes { get; set; }

        Task GetAcctTypes();
        Task<ServiceResponse<AcctType>> GetAcctTypeById(int acctTypeId);
    }
}
