using Core.Models.Serialization;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Core.EonixDBContext
{
    public class EonixContext : DbContext
    {
        public EonixContext(DbContextOptions<EonixContext> options) 
            : base(options)
        {
        }

        //Tables
        public virtual DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(prs => prs.FirstName)
                      .IsRequired();
                entity.Property(prs => prs.Name )
                      .IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }

    }

}
