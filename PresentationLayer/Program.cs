using Business_Layer.Service;
using BusinessLayer.Service;
using Data_Access_Layer.Repository;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SWDContext>();
builder.Services.AddScoped<ProductDAO>();
builder.Services.AddScoped<UserDAO>();
builder.Services.AddScoped<BlogDAO>();
builder.Services.AddScoped<HomeService>();
builder.Services.AddScoped<BlogService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductService>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
