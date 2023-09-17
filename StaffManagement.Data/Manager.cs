/// <summary>
/// Represents a manager, inheriting from the Employee class, with an additional bonus property.
/// </summary>
public class Manager : Employee, IManager
{
    private decimal bonus;

    /// <summary>
    /// Initializes a new instance of the Manager class.
    /// </summary>
    /// <param name="employeeId">The unique identifier for the manager.</param>
    /// <param name="name">The name of the manager.</param>
    /// <param name="position">The position of the manager.</param>
    /// <param name="hourlyRate">The hourly rate of the manager's salary.</param>
    /// <param name="bonus">The bonus amount for the manager.</param>
    public Manager(int employeeId, string name, string position, decimal hourlyRate, decimal bonus)
        : base(employeeId, name, position, hourlyRate)
    {
        this.bonus = bonus;
    }

    /// <summary>
    /// Gets or sets the bonus amount for the manager.
    /// </summary>
    public decimal Bonus
    {
        get { return bonus; }
        set { bonus = value; }
    }
}
