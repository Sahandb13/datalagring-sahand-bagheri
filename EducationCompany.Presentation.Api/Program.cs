using EducationCompany.Application.UseCases;
using EducationCompany.Domain.Entities;
using EducationCompany.Infrastructure.DependencyInjection;
using EducationCompany.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DB + Infrastructure
var cs = builder.Configuration.GetConnectionString("Default")!;
builder.Services.AddInfrastructure(cs);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS (för React senare)
builder.Services.AddCors(p => p.AddPolicy("dev", x =>
    x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("dev");

// Auto-migrate (ok för skolprojekt)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// ---- BASIC ----
app.MapGet("/", () => "API is running");

// ---- COURSES CRUD ----
app.MapGet("/courses", async (AppDbContext db) =>
{
    var items = await db.Courses.AsNoTracking().ToListAsync();
    return Results.Ok(items);
});

app.MapGet("/courses/{id:guid}", async (AppDbContext db, Guid id) =>
{
    var item = await db.Courses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    return item is null ? Results.NotFound() : Results.Ok(item);
});

app.MapPost("/courses", async (AppDbContext db, CourseCreateDto dto) =>
{
    var course = new Course(dto.Title, dto.Description);
    db.Courses.Add(course);
    await db.SaveChangesAsync();
    return Results.Created($"/courses/{course.Id}", course);
});

app.MapPut("/courses/{id:guid}", async (AppDbContext db, Guid id, CourseCreateDto dto) =>
{
    var course = await db.Courses.FindAsync(id);
    if (course is null) return Results.NotFound();

    course.Update(dto.Title, dto.Description);
    await db.SaveChangesAsync();
    return Results.Ok(course);
});

app.MapDelete("/courses/{id:guid}", async (AppDbContext db, Guid id) =>
{
    var course = await db.Courses.FindAsync(id);
    if (course is null) return Results.NotFound();

    db.Courses.Remove(course);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// ---- COURSE INSTANCES ----
app.MapPost("/courses/{courseId:guid}/instances", async (AppDbContext db, Guid courseId, CourseInstanceCreateDto dto) =>
{
    var courseExists = await db.Courses.AnyAsync(c => c.Id == courseId);
    if (!courseExists) return Results.NotFound(new { error = "Course not found" });

    var instance = new CourseInstance(courseId, dto.StartDate, dto.EndDate, dto.Capacity);
    db.CourseInstances.Add(instance);
    await db.SaveChangesAsync();

    return Results.Created($"/instances/{instance.Id}", instance);
});

app.MapGet("/instances", async (AppDbContext db) =>
{
    var items = await db.CourseInstances.AsNoTracking().ToListAsync();
    return Results.Ok(items);
});

app.MapGet("/instances/{id:guid}", async (AppDbContext db, Guid id) =>
{
    var item = await db.CourseInstances.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    return item is null ? Results.NotFound() : Results.Ok(item);
});

app.MapDelete("/instances/{id:guid}", async (AppDbContext db, Guid id) =>
{
    var item = await db.CourseInstances.FindAsync(id);
    if (item is null) return Results.NotFound();

    db.CourseInstances.Remove(item);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// ---- STUDENTS ----
app.MapPost("/students", async (AppDbContext db, StudentCreateDto dto) =>
{
    var s = new Student(dto.FirstName, dto.LastName, dto.Email);
    db.Students.Add(s);
    await db.SaveChangesAsync();
    return Results.Created($"/students/{s.Id}", s);
});

app.MapGet("/students", async (AppDbContext db) =>
{
    var items = await db.Students.AsNoTracking().ToListAsync();
    return Results.Ok(items);
});

app.MapGet("/students/{id:guid}", async (AppDbContext db, Guid id) =>
{
    var item = await db.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    return item is null ? Results.NotFound() : Results.Ok(item);
});

// ---- TEACHERS ----
app.MapPost("/teachers", async (AppDbContext db, TeacherCreateDto dto) =>
{
    var t = new Teacher(dto.FirstName, dto.LastName, dto.Email);
    db.Teachers.Add(t);
    await db.SaveChangesAsync();
    return Results.Created($"/teachers/{t.Id}", t);
});

app.MapGet("/teachers", async (AppDbContext db) =>
{
    var items = await db.Teachers.AsNoTracking().ToListAsync();
    return Results.Ok(items);
});

// ---- ENROLLMENT (via Application use case) ----
app.MapPost("/instances/{instanceId:guid}/enroll", async (AppDbContext db, Guid instanceId, EnrollDto dto) =>
{
    try
    {
        var enrollmentId = await RegisterStudent.Handle(db, new RegisterStudent.Command(instanceId, dto.StudentId));
        return Results.Created($"/enrollments/{enrollmentId}", new { EnrollmentId = enrollmentId });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.MapGet("/instances/{instanceId:guid}/enrollments", async (AppDbContext db, Guid instanceId) =>
{
    var items = await db.Enrollments.AsNoTracking()
        .Where(e => e.CourseInstanceId == instanceId)
        .Select(e => new { e.Id, e.StudentId, e.CourseInstanceId, e.EnrolledAtUtc })
        .ToListAsync();

    return Results.Ok(items);
});

app.Run();


// ---- DTOs (MÅSTE ligga efter app.Run() i top-level Program.cs) ----
record CourseCreateDto(string Title, string? Description);
record CourseInstanceCreateDto(DateOnly StartDate, DateOnly EndDate, int Capacity);
record StudentCreateDto(string FirstName, string LastName, string Email);
record TeacherCreateDto(string FirstName, string LastName, string Email);
record EnrollDto(Guid StudentId);
