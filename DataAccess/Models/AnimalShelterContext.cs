using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class AnimalShelterContext : DbContext
{
    public AnimalShelterContext()
    {
    }

    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adopter> Adopters { get; set; }

    public virtual DbSet<Adoption> Adoptions { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Breed> Breeds { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventAttendance> EventAttendances { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Species> Species { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<SupplyOrder> SupplyOrders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Vaccination> Vaccinations { get; set; }

    public virtual DbSet<Volunteer> Volunteers { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adopter>(entity =>
        {
            entity.HasKey(e => e.AdopterId).HasName("PK__Adopters__499FD2EDCC552BF4");

            entity.Property(e => e.AdopterId).HasColumnName("AdopterID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Adoption>(entity =>
        {
            entity.HasKey(e => e.AdoptionId).HasName("PK__Adoption__38BABF0C102C76A9");

            entity.Property(e => e.AdoptionId).HasColumnName("AdoptionID");
            entity.Property(e => e.AdopterId).HasColumnName("AdopterID");
            entity.Property(e => e.AdoptionDate).HasColumnType("date");
            entity.Property(e => e.AnimalId).HasColumnName("AnimalID");

            entity.HasOne(d => d.Adopter).WithMany(p => p.Adoptions)
                .HasForeignKey(d => d.AdopterId)
                .HasConstraintName("FK__Adoptions__Adopt__4316F928");

            entity.HasOne(d => d.Animal).WithMany(p => p.Adoptions)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK__Adoptions__Anima__4222D4EF");
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK__Animals__A21A732785DFBB29");

            entity.Property(e => e.AnimalId).HasColumnName("AnimalID");
            entity.Property(e => e.AdmissionDate).HasColumnType("date");
            entity.Property(e => e.BreedId).HasColumnName("BreedID");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SpeciesId).HasColumnName("SpeciesID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Breed).WithMany(p => p.Animals)
                .HasForeignKey(d => d.BreedId)
                .HasConstraintName("FK__Animals__BreedID__3D5E1FD2");

            entity.HasOne(d => d.Species).WithMany(p => p.Animals)
                .HasForeignKey(d => d.SpeciesId)
                .HasConstraintName("FK__Animals__Species__3C69FB99");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AuditLog__5E5499A8065A2B35");

            entity.ToTable("AuditLog");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.Action).HasMaxLength(100);
            entity.Property(e => e.ActionDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__AuditLog__UserID__6754599E");
        });

        modelBuilder.Entity<Breed>(entity =>
        {
            entity.HasKey(e => e.BreedId).HasName("PK__Breeds__D1E9AEBD4A778596");

            entity.Property(e => e.BreedId).HasColumnName("BreedID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SpeciesId).HasColumnName("SpeciesID");

            entity.HasOne(d => d.Species).WithMany(p => p.Breeds)
                .HasForeignKey(d => d.SpeciesId)
                .HasConstraintName("FK__Breeds__SpeciesI__398D8EEE");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PK__Donation__C5082EDB451840BE");

            entity.Property(e => e.DonationId).HasColumnName("DonationID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonationDate).HasColumnType("date");
            entity.Property(e => e.DonorName).HasMaxLength(100);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__7944C870EE38317F");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventDate).HasColumnType("date");
            entity.Property(e => e.EventName).HasMaxLength(100);
        });

        modelBuilder.Entity<EventAttendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__EventAtt__8B69263C69ECB661");

            entity.ToTable("EventAttendance");

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventAttendances)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__EventAtte__Event__534D60F1");

            entity.HasOne(d => d.Volunteer).WithMany(p => p.EventAttendances)
                .HasForeignKey(d => d.VolunteerId)
                .HasConstraintName("FK__EventAtte__Volun__5441852A");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK__Expenses__1445CFF3AA218300");

            entity.Property(e => e.ExpenseId).HasColumnName("ExpenseID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ExpenseDate).HasColumnType("date");
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.HasKey(e => e.IncomeId).HasName("PK__Income__60DFC66CB2641682");

            entity.ToTable("Income");

            entity.Property(e => e.IncomeId).HasColumnName("IncomeID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IncomeDate).HasColumnType("date");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__MedicalR__FBDF78C94DDEAD67");

            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.AnimalId).HasColumnName("AnimalID");
            entity.Property(e => e.RecordDate).HasColumnType("date");

            entity.HasOne(d => d.Animal).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK__MedicalRe__Anima__48CFD27E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AB76301EA");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Species>(entity =>
        {
            entity.HasKey(e => e.SpeciesId).HasName("PK__Species__A938047FC77B7BF1");

            entity.Property(e => e.SpeciesId).HasColumnName("SpeciesID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF751EB2EEE");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Position).HasMaxLength(100);
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.SupplyId).HasName("PK__Supplies__7CDD6C8E79F354E4");

            entity.Property(e => e.SupplyId).HasColumnName("SupplyID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Unit).HasMaxLength(50);
        });

        modelBuilder.Entity<SupplyOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__SupplyOr__C3905BAF82BF2753");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.SupplyId).HasColumnName("SupplyID");

            entity.HasOne(d => d.Supply).WithMany(p => p.SupplyOrders)
                .HasForeignKey(d => d.SupplyId)
                .HasConstraintName("FK__SupplyOrd__Suppl__59063A47");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC49458A16");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.PasswordHash).HasMaxLength(200);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A5593690190");

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserRoles__RoleI__6477ECF3");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserRoles__UserI__6383C8BA");
        });

        modelBuilder.Entity<Vaccination>(entity =>
        {
            entity.HasKey(e => e.VaccinationId).HasName("PK__Vaccinat__466BCFA791303D76");

            entity.Property(e => e.VaccinationId).HasColumnName("VaccinationID");
            entity.Property(e => e.AnimalId).HasColumnName("AnimalID");
            entity.Property(e => e.VaccinationDate).HasColumnType("date");
            entity.Property(e => e.VaccineName).HasMaxLength(100);

            entity.HasOne(d => d.Animal).WithMany(p => p.Vaccinations)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK__Vaccinati__Anima__45F365D3");
        });

        modelBuilder.Entity<Volunteer>(entity =>
        {
            entity.HasKey(e => e.VolunteerId).HasName("PK__Voluntee__716F6FCC41A27D56");

            entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");
            entity.Property(e => e.Availability).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
