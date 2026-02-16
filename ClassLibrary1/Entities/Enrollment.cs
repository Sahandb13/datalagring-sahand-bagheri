namespace EducationCompany.Domain.Entities;

public class Enrollment
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid StudentId { get; private set; }
    public Student Student { get; private set; } = default!;

    public Guid CourseInstanceId { get; private set; }
    public CourseInstance CourseInstance { get; private set; } = default!;

    public DateTime EnrolledAtUtc { get; private set; } = DateTime.UtcNow;

    private Enrollment() { } // EF

    public Enrollment(Guid studentId, Guid courseInstanceId)
    {
        StudentId = studentId;
        CourseInstanceId = courseInstanceId;
    }
}
