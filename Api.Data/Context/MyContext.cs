using System;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<LegalCaseEntity> LegalCase { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LegalCaseEntity>(new LegalCaseMap().Configure);

            modelBuilder.Entity<LegalCaseEntity>().HasData(
                new LegalCaseEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    CourtName = "",
                    RegistrationDate = DateTime.Now,
                }
            );
        }

    }
}
