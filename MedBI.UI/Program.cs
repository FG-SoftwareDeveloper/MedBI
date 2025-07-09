using MedBI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// ? Connection string: MedClaims database
var connectionString = builder.Configuration.GetConnectionString("MedBIDb")
    ?? throw new InvalidOperationException("Connection string 'MedBIDb' not found.");

// ? Register EF Core context
builder.Services.AddDbContext<MedBIContext>(options =>
    options.UseSqlServer(connectionString));

// ? Register Identity with the correct context
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MedBIContext>();


// ? Add HttpClient for API calls

builder.Services.AddHttpClient("MedBI.API", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("MedBI:ApiBaseUrl") ?? "https://localhost:5170/");
});

builder.Services.AddScoped<MedBI.UI.Services.ClaimApiService>();
// ? Add Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
