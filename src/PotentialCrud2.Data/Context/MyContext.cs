using Microsoft.EntityFrameworkCore;
using PotentialCrud2.Data.Mapping;
using PotentialCrud2.Domain.Entities;

namespace PotentialCrud2.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<DesenvolvedorEntity> Desenvolvedor { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DesenvolvedorEntity>(new DesenvolvedorMap().Configure);
        }
    }
}
