
using BlogApp.ClassLib.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.Data
{
    public class SqlServerDbContext : DbContext
    {
      public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
     : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Blog> Blog { get; set; }
    }
}
