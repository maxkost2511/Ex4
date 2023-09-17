using Newtonsoft.Json;
/// <summary>
/// Represents a company with a list of employees and methods to manage them.
/// </summary>
public class Company : ICompany
{
    private List<IEmployee> employees = new List<IEmployee>();
    private int nextEmployeeId = 1;

    public int GenerateEmployeeId()
    {
        return nextEmployeeId++;
    }

    public IEmployee GetEmployeeById(int employeeId)
    {
        return employees.FirstOrDefault(e => e.EmployeeId == employeeId);
    }

    /// <summary>
    /// Adds an employee to the company's employee list.
    /// </summary>
    /// <param name="employee">The employee to be added.</param>
    void ICompany.AddEmployee(IEmployee employee)
    {
        employees.Add(employee);
    }

    /// <summary>
    /// Removes an employee from the company by their EmployeeId.
    /// </summary>
    /// <param name="employeeId">The EmployeeId of the employee to be removed.</param>
    public bool RemoveEmployee(int employeeId)
    {
        IEmployee? employeeToRemove = employees.Find(e => e.EmployeeId == employeeId);
        if (employeeToRemove != null)
        {
            return employees.Remove(employeeToRemove);
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Modifies the information of an existing employee by their EmployeeId.
    /// </summary>
    /// <param name="employeeId">The EmployeeId of the employee to be modified.</param>
    /// <param name="name">The new name of the employee.</param>
    /// <param name="position">The new position of the employee.</param>
    /// <param name="hourlyRate">The new hourly rate of the employee's salary.</param>
    public void ModifyEmployee(int employeeId, string name, string position, decimal hourlyRate)
    {
        IEmployee? employeeToModify = employees.Find(e => e.EmployeeId == employeeId);
        if (employeeToModify != null)
        {
            employeeToModify.Name = name;
            employeeToModify.Position = position;
            employeeToModify.HourlyRate = hourlyRate;
        }
    }

    /// <summary>
    /// Calculates the salary of an employee based on their EmployeeId and hours worked.
    /// </summary>
    /// <param name="employeeId">The EmployeeId of the employee for salary calculation.</param>
    /// <param name="hoursWorked">The number of hours worked by the employee.</param>
    /// <returns>The calculated salary for the employee.</returns>
    public decimal CalculateSalary(int employeeId, decimal hoursWorked)
    {
        IEmployee? employee = employees.Find(e => e.EmployeeId == employeeId);
        if (employee != null)
        {
            decimal baseSalary = employee.HourlyRate * hoursWorked;
            if (employee is IManager manager)
            {
                baseSalary += manager.Bonus;
            }
            return baseSalary;
        }
        else
        {
            throw new ArgumentException("Employee with the specified EmployeeId not found.");
        }
    }

    public void SaveToJson(string fileName)
    {
        var companyData = new CompanyData
        {
            Employees = employees.Cast<Employee>().ToList()
        };

        JsonDataService.SaveToJson(fileName, companyData);
    }

    public void LoadFromJson(string fileName)
    {
        var companyData = JsonDataService.LoadFromJson<CompanyData>(fileName);

        if (companyData != null)
        {
            employees = companyData.Employees.Cast<IEmployee>().ToList();
        }
    }
}