﻿
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.JSInterop.Infrastructure;
using MyBudget.Server.Controllers;

namespace MyBudget.Server.Data
{
    public class DataContext : DbContext
    {

        // dotnet ef migrations add <<<SomeName>>>
        // dotnet ef database update
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcctType>()
                .HasData(
                    new AcctType
                    {
                        Id = 1,
                        Name = "Visa"
                    },
                    new AcctType
                    {
                        Id = 2,
                        Name = "MC"
                    },
                    new AcctType
                    {
                        Id = 3,
                        Name = "Loan"
                    },
                    new AcctType
                    {
                        Id = 4,
                        Name = "Bank"
                    }
                );

            modelBuilder.Entity<Organization>()
                .HasData(
                new Organization
                {
                    Id = 1,
                    Name = "Chase"
                },
                new Organization
                {
                    Id = 2,
                    Name = "PNC"
                },
                new Organization
                {
                    Id = 3,
                    Name = "Cabellas"
                },
                new Organization
                {
                    Id = 4,
                    Name = "MLife"
                },
                new Organization
                {
                    Id = 5,
                    Name = "Xfinity"
                },
                new Organization
                {
                    Id = 6,
                    Name = "BestBuy"
                },
                new Organization
                {
                    Id = 7,
                    Name = "Best Egg"
                },
                new Organization
                {
                    Id = 8,
                    Name = "NetFlix"
                },
                new Organization
                {
                    Id = 9,
                    Name = "Green Mountain"
                },
                new Organization
                {
                    Id = 10,
                    Name = "Chesapeake"
                },
                new Organization
                {
                    Id = 11,
                    Name = "Progressive"
                }


                );

            modelBuilder.Entity<TransactionType>()
              .HasData(
                 new TransactionType
                 {
                     Id = 1,
                     TypeName = "Deposit",
                     Debit = false,
                     Description = "This is a Deposit Transation (+)"

                 },
                new TransactionType
                {
                    Id = 2,
                    TypeName = "Payment",
                    Debit = true,
                    Description = "This is a Paymenmt Transation (-)"

                },
                new TransactionType
                {
                    Id = 3,
                    TypeName = "CashWithdrawl",
                    Debit = true,
                    Description = "This is a Withdrawl Payment Transation (-)"

                },
                 new TransactionType
                 {
                     Id = 4,
                     TypeName = "CashDep",
                     Debit = false,
                     Description = "This is a Withdrawl Transation (+)"

                 },
                new TransactionType
                {
                    Id = 5,
                    TypeName = "CCPayment",
                    Debit = true,
                    Description = "This is a Credit Card Paymenmt Transation (-)"

                },
                new TransactionType
                {
                    Id = 6,
                    TypeName = "Payroll",
                    Debit = false,
                    Description = "This is a Salary Transation (+)"

                }
             );
            modelBuilder.Entity<Account>()
                .HasData(
                  new Account
                  {
                      Id = 1,
                      AcctNum = "...0000",
                      Name = "Egg1",
                      OrganizationId = 7,
                      AcctTypeId = 3
                  },
                  new Account
                  {
                      Id = 2,
                      AcctNum = "...0000",
                      Name = "Egg2",
                      OrganizationId = 7,
                      AcctTypeId = 3
                  },
                  new Account
                  {
                      Id = 3,
                      AcctNum = "...0000",
                      Name = "Bronco",
                      OrganizationId = 2,
                      AcctTypeId = 3
                  },
                  new Account
                  {
                      Id = 4,
                      AcctNum = "...0000",
                      Name = "Harley",
                      OrganizationId = 1,
                      AcctTypeId = 3
                  }

               );
        }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<AcctType> AcctTypes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ReconcileBalance> ReconcileBalances { get; set;}
        public DbSet<StartDateAmount> StartDateAmounts { get; set;}    
        public DbSet<BudgetYear> BudgetYears { get; set;}
    }
}
