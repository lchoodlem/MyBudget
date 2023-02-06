
namespace MyBudget.Server.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TransactionType> TransactionTypes { get; set; }
    }
}
