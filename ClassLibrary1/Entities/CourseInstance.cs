namespace EducationCompany.Domain.Entities;

public class CourseInstance
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid CourseId { get; private set; }
    public Course Course { get; private set; } = default!;

    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public int Capacity { get; private set; }

    private CourseInstance() { } // EF

    public CourseInstance(Guid courseId, DateOnly startDate, DateOnly endDate, int capacity)
    {
        if (endDate < startDate) throw new ArgumentException("EndDate must be after StartDate");
        if (capacity <= 0) throw new ArgumentException("Capacity must be > 0");

        CourseId = courseId;
        StartDate = startDate;
        EndDate = endDate;
        Capacity = capacity;
    }

    public void EnsureCapacityForNewEnrollment(int currentEnrollments)
    {
        if (currentEnrollments >= Capacity)
            throw new InvalidOperationException("Course instance is full");
    }
}
