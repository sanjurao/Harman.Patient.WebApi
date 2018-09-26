using Harman.Data.Entity.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harman.Data.Entity.DataAccess
{
    public class entityDBContext : DbContext
    {
        public entityDBContext()
        {

        }
        public entityDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PatientEntity> PatientsEntity { get; set; }
        // public DbSet<TelephoneEntity> TelephoneEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Data Source=gajarsan-3;Initial Catalog=HealthCareMainDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientEntity>(p => {
                p.ToTable("tblPatient");
                p.HasKey("PatientId");
               
            });

          modelBuilder.Entity<TelephoneEntity>(p => {               
                p.ToTable("tblTelephone");
                p.HasKey("TelephoneId");               

          });
            base.OnModelCreating(modelBuilder);
        }
    }
}
