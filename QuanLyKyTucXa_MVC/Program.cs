using Microsoft.Extensions.FileProviders;
using QuanLyKyTucXa_MVC.Repository;
using QuanLyKyTucXa_MVC.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<PhongService>();
builder.Services.AddScoped<SinhVienService>();
builder.Services.AddScoped<TraPhongService>();
builder.Services.AddScoped<ThuePhongService>();
var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Content/static")),
    RequestPath = "/static"
});


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
