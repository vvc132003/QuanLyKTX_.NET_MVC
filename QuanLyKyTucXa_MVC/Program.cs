using Microsoft.Extensions.FileProviders;
using QuanLyKyTucXa_MVC.Repository;
using QuanLyKyTucXa_MVC.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<PhongService>();
builder.Services.AddScoped<SinhVienService>();
builder.Services.AddScoped<TraPhongService>();
builder.Services.AddScoped<NguoiDungService>();
builder.Services.AddScoped<ChuyenPhongService>();
builder.Services.AddScoped<ThuePhongService>();
builder.Services.AddScoped<DichVuService>();
builder.Services.AddScoped<ThueDichVuService>();
builder.Services.AddScoped<KyLuatService>();
builder.Services.AddScoped<ThongTinKhenThuongService>();
builder.Services.AddScoped<BoPhanService>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseSession();
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