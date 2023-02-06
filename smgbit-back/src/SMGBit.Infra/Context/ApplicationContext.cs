using Microsoft.EntityFrameworkCore;
using SMGBit.Domain.Entities;
using SMGBit.Infra.Configuration;

namespace SMGBit.Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Travel> Travels { get; set; }

        public ApplicationContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityTravelConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
