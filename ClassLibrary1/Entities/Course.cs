namespace EducationCompany.Domain.Entities;

public class Course
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = default!;
    public string? Description { get; private set; }

    private Course() { } // EF

    public Course(string title, string? description = null)
    {
        Update(title, description);
    }

    public void Update(string title, string? description)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("Title required") : title;
        Description = description;
    }
}
