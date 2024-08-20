using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IProductService, ProductService>(c =>
    c.BaseAddress = new Uri(configuration["ServiceUrls:ProductAPI"])
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
