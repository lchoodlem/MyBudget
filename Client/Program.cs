global using MyBudget.Shared;
global using System.Net.Http.Json;
global using MudBlazor.Services;
global using MyBudget.Client.Services.AcctTypesService;
global using MyBudget.Client.Services.OrganizationService;
global using MyBudget.Client.Services.TransactionTypeService;
global using MyBudget.Client.Services.AccountService;

global using MyBudget.Client.Pages.DialogService;
global using Microsoft.AspNetCore.Components.QuickGrid;
using System.Net.NetworkInformation;




using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBudget.Client;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAcctTypeService, AcctTypeService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionTypeService, TransactionTypeService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();