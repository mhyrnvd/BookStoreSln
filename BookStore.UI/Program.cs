using BookStore.Core.RepositoryContracts;
using BookStore.Core.ServiceContracts.CategoryContracts;
using BookStore.Core.ServiceContracts.ProductContracts;
using BookStore.Core.Services.CategoryServices;
using BookStore.Core.Services.ProductServices;
using BookStore.Core.Services.ProductsServices;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<ICategoriesAdderService, CategoriesAdderService>();
builder.Services.AddScoped<ICategoriesGetterService, CategoriesGetterService>();
builder.Services.AddScoped<ICategoryUpdaterService, CategoryUpdaterService>();
builder.Services.AddScoped<ICategoryDeleterService, CategoryDeleterService>();

builder.Services.AddScoped<IProductAdderService, ProductsAdderService>();
builder.Services.AddScoped<IProductGetterService, ProductsGetterService>();
builder.Services.AddScoped<IProductUpdaterService, ProductUpdaterService>();
builder.Services.AddScoped<IProductDeleterService, ProductsDeleterService>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
