using Classroom.TodoMigration.Api.Db.Entities;
using Classroom.TodoMigration.Api.Db.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Classroom.TodoMigration.Api.Db
{
    public class AppDbContext : DbContext
    {

        public DbSet<TodoEntity> Todos { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.ApplyConfiguration(new TodoEntityConfiguration());

            base.OnModelCreating(builder);
        }



    }
}
