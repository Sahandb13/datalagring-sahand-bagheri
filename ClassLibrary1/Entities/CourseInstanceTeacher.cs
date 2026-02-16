namespace EducationCompany.Domain.Entities;

public class CourseInstanceTeacher
{
    public Guid CourseInstanceId { get; set; }
    public CourseInstance CourseInstance { get; set; } = default!;

    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; } = default!;
}
