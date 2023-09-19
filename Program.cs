using Microsoft.EntityFrameworkCore;
using todo.Data;
using todo.Controllers;
using Autofac;
using Autofac.Core.Registration;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

using todo;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, serverVersion));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


//builder.Services.Add(new ServiceDescriptor(
//    typeof(IAppDbContext),       //default IoC
//    typeof(AppDbContext),
//    ServiceLifetime.Transient)); //whenever a class asks for an IAppDbContext obj,create and pass an obj of AppDbContext


var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddXmlFile("autofac.xml");
var configuration = configBuilder.Build();

var configModule = new ConfigurationModule(configuration);
//containerBuilder.RegisterModule(configModule);
//return containerBuilder.Build();

builder.Host.ConfigureContainer<ContainerBuilder>
    (ContainerBuilder =>
    
    ContainerBuilder.RegisterModule(configModule));


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

