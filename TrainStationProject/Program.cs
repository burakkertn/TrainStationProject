using Microsoft.AspNetCore.Identity;
using TrainStationProject.Abstract;
using TrainStationProject.Concrete.EntityFramework;
using TrainStationProject.Models.Context;
using TrainStationProject.Models.Entites;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StationContext>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IStationDal, EfStationDal>();
builder.Services.AddScoped<IVoyageDal, EfVoyageDal>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
