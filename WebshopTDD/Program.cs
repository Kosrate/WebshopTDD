using Microsoft.Extensions.Options;
using WebshopTDD.Services;
using WebshopTDD.Service;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.Configure<ProductServiceOptions>(builder.Configuration.GetSection("ProductService"));
builder.Services.AddScoped<IProductCategoryRelationService, ProductCategoryRelationService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IService, Services>();

// Register other dependencies
builder.Services.AddScoped<IOptions<ProductServiceOptions>, OptionsManager<ProductServiceOptions>>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();