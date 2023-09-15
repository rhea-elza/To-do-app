using Microsoft.EntityFrameworkCore;
using todo.Models;

namespace todo.Data
{
    public interface IAppDbContext
    {
        DbSet<Todo> Todo { get; set; }
        int SaveChanges();
    }
}