using System;
using Microsoft.EntityFrameworkCore;
using todo.Models;
namespace todo.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Todo> Todo { get; set; }


    }
}
