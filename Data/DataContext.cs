using Checkpont2.Models;
using Microsoft.EntityFrameworkCore;


namespace Checkpont2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> TB_USERS { get; set; }
    }
}
