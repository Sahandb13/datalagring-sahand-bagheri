using EducationCompany.Application.Abstractions;
using EducationCompany.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationCompany.Application.UseCases;

public static class RegisterStudent
{
    public sealed record Command(Guid CourseInstanceId, Guid StudentId);

    public static async Task<Guid> Handle(IAppDbContext db, Command cmd, CancellationToken ct = default)
    {
        var exists = await db.Enrollments.AnyAsync(e =>
            e.CourseInstanceId == cmd.CourseInstanceId &&
            e.StudentId == cmd.StudentId, ct);

        if (exists)
            throw new InvalidOperationException("Student is already enrolled for this instance");

        var instance = await db.CourseInstances.FirstOrDefaultAsync(i => i.Id == cmd.CourseInstanceId, ct);
        if (instance is null)
            throw new InvalidOperationException("Course instance not found");

        var current = await db.Enrollments.CountAsync(e => e.CourseInstanceId == cmd.CourseInstanceId, ct);
        instance.EnsureCapacityForNewEnrollment(current);

        var enrollment = new Enrollment(cmd.StudentId, cmd.CourseInstanceId);
        db.Enrollments.Add(enrollment);

        await db.SaveChangesAsync(ct);
        return enrollment.Id;
    }
}
