using EducationCompany.Application.Abstractions;
using EducationCompany.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationCompany.Infrastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseInstance> CourseInstances => Set<CourseInstance>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<CourseInstanceTeacher> CourseInstanceTeachers => Set<CourseInstanceTeacher>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Unik email
        modelBuilder.Entity<Student>()
            .HasIndex(s => s.Email)
            .IsUnique();

        modelBuilder.Entity<Teacher>()
            .HasIndex(t => t.Email)
            .IsUnique();

        // Stoppa dubblettregistrering (Student + Instance)
        modelBuilder.Entity<Enrollment>()
            .HasIndex(e => new { e.StudentId, e.CourseInstanceId })
            .IsUnique();

        // Join-tabell för många-till-många: CourseInstance <-> Teacher
        modelBuilder.Entity<CourseInstanceTeacher>()
            .HasKey(x => new { x.CourseInstanceId, x.TeacherId });

        modelBuilder.Entity<CourseInstanceTeacher>()
            .HasOne(x => x.CourseInstance)
            .WithMany()
            .HasForeignKey(x => x.CourseInstanceId);

        modelBuilder.Entity<CourseInstanceTeacher>()
            .HasOne(x => x.Teacher)
            .WithMany()
            .HasForeignKey(x => x.TeacherId);

        base.OnModelCreating(modelBuilder);
    }
}
