/// <summary>
/// Represents an employee with basic information.
/// </summary>
public interface IEmployee
{
    int EmployeeId { get; }
    string Name { get; set; }
    string Position { get; set; }
    decimal HourlyRate { get; set; }
}