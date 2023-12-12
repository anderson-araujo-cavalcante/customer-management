using CustomerManagement.Web.DependencyInjections;
using CustomerManagement.Domain.DependencyInjections;
using CustomerManagement.Data.DependencyInjections;
using CustomerManagement.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.AddDbContext();
builder.Services.MapperConfig();
builder.Services.ResolveDataDependencies();
builder.Services.ResolveWebDependencies();
builder.Services.ResolveDomainDependencies();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient("ViaCepClient", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://viacep.com.br/");
});

var app = builder.Build();

DatabaseManagementService.MigrationInitialisation(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();
