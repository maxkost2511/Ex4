/// <summary>
/// Represents an employee with basic information.
/// </summary>
public class Employee : IEmployee
{
    private int employeeId;
    private string name;
    private string position;
    private decimal hourlyRate;

    /// <summary>
    /// Initializes a new instance of the Employee class.
    /// </summary>
    /// <param name="employeeId">The unique identifier for the employee.</param>
    /// <param name="name">The name of the employee.</param>
    /// <param name="position">The position of the employee.</param>
    /// <param name="hourlyRate">The hourly rate of the employee's salary.</param>
    public Employee(int employeeId, string name, string position, decimal hourlyRate)
    {
        this.employeeId = employeeId;
        this.name = name;
        this.position = position;
        this.hourlyRate = hourlyRate;
    }

    /// <summary>
    /// Gets the unique identifier of the employee.
    /// </summary>
    public int EmployeeId
    {
        get { return employeeId; }
    }

    /// <summary>
    /// Gets or sets the name of the employee.
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    /// <summary>
    /// Gets or sets the position of the employee.
    /// </summary>
    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    /// <summary>
    /// Gets or sets the hourly rate of the employee's salary.
    /// </summary>
    public decimal HourlyRate
    {
        get { return hourlyRate; }
        set { hourlyRate = value; }
    }
}