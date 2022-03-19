using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedicalAppointments.Data.Models
{
    public partial class DoctorDBContext : DbContext
    {
        public DoctorDBContext()
        {
            
        }

        public DoctorDBContext(DbContextOptions<DoctorDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<BloodGroups> BloodGroups { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<MedicalCenterTypes> MedicalCenterTypes { get; set; }
        public virtual DbSet<MedicalCenters> MedicalCenters { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=COMP2\\NEWSERVER;Initial Catalog=DoctorDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.TimeAndDate)
                    .HasColumnName("time_and_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Appointme__docto__68487DD7");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Appointme__patie__6754599E");
            });

            modelBuilder.Entity<BloodGroups>(entity =>
            {
                entity.ToTable("Blood_Groups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BloodType)
                    .IsRequired()
                    .HasColumnName("blood_type")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RhFactor).HasColumnName("rh_factor");
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcademicDegree)
                    .HasColumnName("academic_degree")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CenterId).HasColumnName("center_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialPosition)
                    .HasColumnName("special_position")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Specialty)
                    .IsRequired()
                    .HasColumnName("specialty")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Center)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.CenterId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Doctors__center___66603565");
            });

            modelBuilder.Entity<MedicalCenterTypes>(entity =>
            {
                entity.ToTable("Medical_Center_Types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CenterType)
                    .IsRequired()
                    .HasColumnName("center_type")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicalCenters>(entity =>
            {
                entity.ToTable("Medical_Centers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CenterAddress)
                    .IsRequired()
                    .HasColumnName("center_address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CenterName)
                    .IsRequired()
                    .HasColumnName("center_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CenterTypeId).HasColumnName("center_type_id");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CenterType)
                    .WithMany(p => p.MedicalCenters)
                    .HasForeignKey(d => d.CenterTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Medical_C__cente__656C112C");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.BloodGroupId).HasColumnName("blood_group_id");

                entity.Property(e => e.Diagnose)
                    .IsRequired()
                    .HasColumnName("diagnose")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.BloodGroup)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.BloodGroupId)
                    .HasConstraintName("FK__Patients__blood___6477ECF3");
            });
        }
    }
}
