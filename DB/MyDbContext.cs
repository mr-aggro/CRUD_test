using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DB
{
    public class MyDbContext: DbContext
    {
        public DbSet<Tank> Tanks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "MyDb.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }
}
