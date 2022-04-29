using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DB
{
    public class MyDbContext: DbContext
    {
        public DbSet<Tank> Tanks { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

    }
}
