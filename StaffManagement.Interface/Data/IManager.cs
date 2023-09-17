/// <summary>
/// Represents a manager, inheriting from the IEmployee interface, with an additional bonus property.
/// </summary>
public interface IManager : IEmployee
{
    decimal Bonus { get; set; }
}