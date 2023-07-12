using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Hotel.Repositories.Hotels_Repository;
using Hotel.Repositories.User_Repository;
using System.Runtime.Serialization;
using System.Configuration;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add session service
builder.Services.AddSession(options =>
{
	// Configure session options as needed
	options.Cookie.Name = "YourSessionCookieName";
	options.IdleTimeout = TimeSpan.FromMinutes(30);
});


//Connection string
string connectionString = "Data source=localhost;DATABASE=HotelDB;Integrated Security=True";


//Repo registration
builder.Services.AddScoped<IUserRepository, UserRepository>(provider => new UserRepository(connectionString));
builder.Services.AddScoped<IHotelRepository, HotelRepository>(provider => new HotelRepository(connectionString));

 

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

app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
