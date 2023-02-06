﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBudget.Server.Data;

#nullable disable

namespace MyBudget.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyBudget.Shared.AcctType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AcctTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Visa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MC"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Loan"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bank"
                        });
                });

            modelBuilder.Entity("MyBudget.Shared.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address1 = "",
                            Address2 = "",
                            Description = "",
                            Name = "Chase",
                            Phone1 = "",
                            Phone2 = ""
                        },
                        new
                        {
                            Id = 2,
                            Address1 = "",
                            Address2 = "",
                            Description = "",
                            Name = "PNC",
                            Phone1 = "",
                            Phone2 = ""
                        },
                        new
                        {
                            Id = 3,
                            Address1 = "",
                            Address2 = "",
                            Description = "",
                            Name = "Cabellas",
                            Phone1 = "",
                            Phone2 = ""
                        },
                        new
                        {
                            Id = 4,
                            Address1 = "",
                            Address2 = "",
                            Description = "",
                            Name = "MLife",
                            Phone1 = "",
                            Phone2 = ""
                        },
                        new
                        {
                            Id = 5,
                            Address1 = "",
                            Address2 = "",
                            Description = "",
                            Name = "Xfinity",
                            Phone1 = "",
                            Phone2 = ""
                        },
                        new
                        {
                            Id = 6,
                            Address1 = "",
                            Address2 = "",
                            Description = "",
                            Name = "BestBuy",
                            Phone1 = "",
                            Phone2 = ""
                        },
                        new
                        {
                            Id = 7,
                            Address1 = "",
                            Address2 = "",
                            Description = "",
                            Name = "Best Egg",
                            Phone1 = "",
                            Phone2 = ""
                        },
                        new
                        {
                            Id = 8,
                            Address1 = "",
                            Address2 = "",
                            Description = "",
                            Name = "NetFlix",
                            Phone1 = "",
                            Phone2 = ""
                        },
                        new
                        {
                            Id = 9,
                            Address1 = "",
                            Address2 = "",
                            Description = "",
                            Name = "Green Mountain",
                            Phone1 = "",
                            Phone2 = ""
                        },
                        new
                        {
                            Id = 10,
                            Address1 = "",
                            Address2 = "",
                            Description = "",
                            Name = "Chesapeake",
                            Phone1 = "",
                            Phone2 = ""
                        },
                        new
                        {
                            Id = 11,
                            Address1 = "",
                            Address2 = "",
                            Description = "",
                            Name = "Progressive",
                            Phone1 = "",
                            Phone2 = ""
                        });
                });

            modelBuilder.Entity("MyBudget.Shared.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Debit")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Debit = false,
                            Description = "This is a Deposit Transation (+)",
                            TypeName = "Deposit"
                        },
                        new
                        {
                            Id = 2,
                            Debit = true,
                            Description = "This is a Paymenmt Transation (-)",
                            TypeName = "Payment"
                        },
                        new
                        {
                            Id = 3,
                            Debit = true,
                            Description = "This is a Withdrawl Payment Transation (-)",
                            TypeName = "CashWithdrawl"
                        },
                        new
                        {
                            Id = 4,
                            Debit = false,
                            Description = "This is a Withdrawl Transation (+)",
                            TypeName = "CashDep"
                        },
                        new
                        {
                            Id = 5,
                            Debit = true,
                            Description = "This is a Credit Card Paymenmt Transation (-)",
                            TypeName = "CCPayment"
                        },
                        new
                        {
                            Id = 6,
                            Debit = false,
                            Description = "This is a Salary Transation (+)",
                            TypeName = "Payroll"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
