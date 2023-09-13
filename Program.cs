using Microsoft.EntityFrameworkCore;
using todo.Data;
var builder = WebApplication.CreateBuilder(args); var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, serverVersion));
//builder.Services.AddRazorPages().
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
    pattern: "{controller=Todo}/{action=Index}/{id?}");
app.Run();