namespace EducationCompany.Domain.Entities;

public class Teacher
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    private Teacher() { } // EF

    public Teacher(string firstName, string lastName, string email)
    {
        FirstName = string.IsNullOrWhiteSpace(firstName) ? throw new ArgumentException("FirstName required") : firstName;
        LastName = string.IsNullOrWhiteSpace(lastName) ? throw new ArgumentException("LastName required") : lastName;
        Email = string.IsNullOrWhiteSpace(email) ? throw new ArgumentException("Email required") : email;
    }
}
