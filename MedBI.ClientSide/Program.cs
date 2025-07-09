using MedBI.ClientSide.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddRazorPages();
// Register HttpClient for calling the API
builder.Services.AddHttpClient("MedBI.API", client =>
{
    var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
    client.BaseAddress = new Uri(apiBaseUrl!);
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<NavigationApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();