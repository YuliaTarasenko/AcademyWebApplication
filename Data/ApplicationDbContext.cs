using AcademyWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Department>(entity =>
            {
                //entity.ToTable("Departments").HasOne(t=>t.Faculty);
                entity.HasIndex(p => p.Name);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(250);
            });

            builder.Entity<Faculty>(entity =>
            {
                //entity.ToTable("Faculties").HasMany<Department>();
                entity.HasIndex(p => p.Name);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(250);
            });

            builder.Entity<Group>(entity =>
            {
                entity.ToTable("Groups").HasOne(t=>t.Department);
                entity.ToTable("Groups").HasMany(t => t.Lectures).WithMany(t=>t.Groups);
                entity.HasIndex(p => p.Name);
                entity.HasIndex(p => p.Rating);
                entity.HasIndex(p => p.Year);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(250);
            });

            builder.Entity<Lecture>(entity =>
            {
                entity.ToTable("Lectures").HasOne(t => t.Teacher);
                entity.ToTable("Lectures").HasOne(t => t.Subject);
                entity.HasIndex(p => p.LectureRoom);
                entity.Property(p => p.LectureRoom).HasMaxLength(500);
            });

            builder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teachers").HasMany(t=>t.Lectures);
                entity.HasIndex(p => p.Name);
                entity.HasIndex(p => p.Surname);
                entity.HasIndex(p => p.EmploymentDate);
                entity.HasIndex(p => new { p.Premium,p.Salary});
                entity.Property(p => p.Name).IsRequired().HasMaxLength(250);
                entity.Property(p => p.Surname).IsRequired().HasMaxLength(250);
                entity.Property(p => p.Premium).HasColumnType("money");
                entity.Property(p => p.Salary).HasColumnType("money");
            });

            builder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subjects").HasMany(t => t.Lectures);
                entity.HasIndex(p => p.Name);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(500);
            });

            base.OnModelCreating(builder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<GroupLecture> GroupsLectures { get; set; }
    }
}
