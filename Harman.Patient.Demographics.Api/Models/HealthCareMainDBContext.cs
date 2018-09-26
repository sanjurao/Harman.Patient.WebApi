using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Harman.Data.Entity.Models
{
    public partial class HealthCareMainDBContext : DbContext
    {
        public HealthCareMainDBContext()
        {
        }

        public HealthCareMainDBContext(DbContextOptions<HealthCareMainDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CodeTable> TblCodeDesc { get; set; }
        public virtual DbSet<TblPatient> TblPatient { get; set; }
        public virtual DbSet<TblTelephone> TblTelephone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=gajarsan-3;Initial Catalog=HealthCareMainDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodeTable>(entity =>
            {
                entity.HasKey(e => e.CodeTableId);

                entity.ToTable("tblCodeDesc");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.Updatedate).HasMaxLength(10);
            });

            modelBuilder.Entity<TblPatient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.ToTable("tblPatient");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblTelephone>(entity =>
            {
                entity.HasKey(e => e.TelephoneId);

                entity.ToTable("tblTelephone");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblTelephone)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_tblTelephone_tblPatient");
            });
        }

        public async Task<TblPatient> AddPatientAsync(TblPatient TblPatientObj)
        {
            if (TblPatientObj == null)
            {
                throw new ArgumentNullException();
            }          

            var patientsEntityAdded = TblPatient.Add(TblPatientObj);

            if (patientsEntityAdded?.Entity == null)
            {
                return null;
            }

            await SaveChangesAsync();
            return patientsEntityAdded.Entity;
        }
    }
}
