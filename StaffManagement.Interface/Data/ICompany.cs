/// <summary>
/// Represents a company with a list of employees and methods to manage them.
/// </summary>
public interface ICompany
{
    void AddEmployee(IEmployee employee);
    bool RemoveEmployee(int employeeId);
    void ModifyEmployee(int employeeId, string name, string position, decimal hourlyRate);
    decimal CalculateSalary(int employeeId, decimal hoursWorked);

    /// <summary>
    /// Saves company and employee data to a JSON file.
    /// </summary>
    /// <param name="fileName">The name of the JSON file to save to.</param>
    void SaveToJson(string fileName);

    /// <summary>
    /// Loads company and employee data from a JSON file.
    /// </summary>
    /// <param name="fileName">The name of the JSON file to load from.</param>
    void LoadFromJson(string fileName);

    int GenerateEmployeeId();

    IEmployee GetEmployeeById(int employeeId);
}