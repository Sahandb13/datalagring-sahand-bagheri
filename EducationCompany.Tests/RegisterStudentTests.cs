using EducationCompany.Application.UseCases;
using EducationCompany.Domain.Entities;
using EducationCompany.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class RegisterStudentTests
{
    [Fact]
    public async Task RegisterStudent_Should_Fail_When_Instance_Is_Full()
    {
        // SQLite in-memory
        var conn = new SqliteConnection("Data Source=:memory:");
        await conn.OpenAsync();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(conn)
            .Options;

        await using var db = new AppDbContext(options);
        await db.Database.EnsureCreatedAsync();

        var course = new Course("C# Backend");
        db.Courses.Add(course);

        var instance = new CourseInstance(course.Id, new DateOnly(2026, 3, 1), new DateOnly(2026, 3, 10), capacity: 1);
        db.CourseInstances.Add(instance);

        var s1 = new Student("A", "One", "a1@test.com");
        var s2 = new Student("B", "Two", "b2@test.com");
        db.Students.AddRange(s1, s2);

        await db.SaveChangesAsync();

        // första går igenom
        await RegisterStudent.Handle(db, new RegisterStudent.Command(instance.Id, s1.Id));

        // andra ska faila pga full
        await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await RegisterStudent.Handle(db, new RegisterStudent.Command(instance.Id, s2.Id)));
    }
}
