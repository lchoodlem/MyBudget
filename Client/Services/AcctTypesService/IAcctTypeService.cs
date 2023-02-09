namespace MyBudget.Client.Services.AcctTypesService
{
    public interface IAcctTypeService
    {
        event Action OnChange;
        List<AcctType> AcctTypes { get; set; }

        Task<IEnumerable<AcctType>> GetAcctTypes();
        Task<ServiceResponse<AcctType>> GetAcctTypeById(int acctTypeId);
        Task AddObject(AcctType obj);
        Task DeleteObject(int id);
        Task UpdateObject(AcctType obj);
        AcctType CreateNewObject();
    }
}
