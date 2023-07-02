using TrustBank_BusinessLayer.Abstract;
using TrustBank_BusinessLayer.Concrete;
using TrustBank_BusinessLayer.Container;
using TrustBank_DataAccessLayer.Abstract;
using TrustBank_DataAccessLayer.Concrete;
using TrustBank_DataAccessLayer.EntityFramework;
using TrustBank_EntityLayer.Concrete;
using TrustBank_PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.CustomValidator();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddScoped<ICustomerAccountActivityDal, EfCustomerAccountActivityDal>();
builder.Services.AddScoped<ICustomerAccountActivityService, CustomerAccountActivityManager>();

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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
