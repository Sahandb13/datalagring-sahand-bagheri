using EducationCompany.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationCompany.Application.Abstractions;

public interface IAppDbContext
{
    DbSet<Course> Courses { get; }
    DbSet<CourseInstance> CourseInstances { get; }
    DbSet<Student> Students { get; }
    DbSet<Teacher> Teachers { get; }
    DbSet<Enrollment> Enrollments { get; }
    DbSet<CourseInstanceTeacher> CourseInstanceTeachers { get; }

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
