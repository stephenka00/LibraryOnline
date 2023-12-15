using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LibraryRespositories.Data;
using LibraryModels;
using LibraryUtilities.Seeding;
using Microsoft.AspNetCore.Identity.UI.Services;
using LibraryUtilities;
using LibraryRespositories.UnitOfWork;
using LibraryViewModels.Utility;
using LibraryServices;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LibraryWebContextConnection") ?? throw new InvalidOperationException("Connection string 'LibraryWebContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<ICategoryService, CategoryService>();
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
DataSeeding();
app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{Area=Users}/{controller=Home}/{action=Index}/{id?}");

app.Run();
void DataSeeding()
{
    using( var scope = app.Services.CreateScope())
    {
        var DbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        DbInitializer.Initialize();
    }
}
