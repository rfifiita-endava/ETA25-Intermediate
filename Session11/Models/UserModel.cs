namespace ETA25_Intermediate.Session11.Models;

public record UserModel
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public Enums.Gender Gender { get; init; }
    public int Mobile { get; init; }
    public DateOnly DateOfBirth { get; init; }
    public List<string>? Subjects { get; init; }
    public List<Enums.Hobby>? Hobbies { get; init; }
    public string Address { get; init; } = string.Empty!;
}
