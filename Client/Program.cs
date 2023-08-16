global using MudBlazor.Services;
global using MyBudget.Client.Services.AccountService;
global using MyBudget.Client.Services.AcctTypesService;
global using MyBudget.Client.Services.BudgetYearService;
global using MyBudget.Client.Services.OrganizationService;
global using MyBudget.Client.Services.StartDateAmountsService;
global using MyBudget.Client.Services.TransactionTypeService;
global using MyBudget.Client.Services.TransactionService;
global using MyBudget.Shared;
global using System.Net.Http.Json;
global using System.Globalization;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBudget.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IStartDateAmountService, StartDateAmountService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionTypeService, TransactionTypeService>();
builder.Services.AddScoped<IBudgetYearService, BudgetYearService>();
builder.Services.AddScoped<IAcctTypeService, AcctTypeService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();