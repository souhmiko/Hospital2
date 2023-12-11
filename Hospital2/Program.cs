
using Hospital2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("hospital2db") ?? throw new InvalidOperationException("Connection string 'Hospital2ContextPartialConnection' not found.");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddDbContext<Hospital2Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("hospital2db")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Hospital2Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
