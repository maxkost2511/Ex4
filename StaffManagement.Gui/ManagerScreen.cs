using Workers.Enum;
/// <summary>
/// Represents the manager menu screen for employee management.
/// </summary>
public class ManagerScreen : Screen
{
    #region Properties And Ctor


    /// <summary>
    /// Manager screen.
    /// </summary>
    private ManagerScreen _managerScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    public ManagerScreen(ICompany company) : base(company) {}

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.WriteLine("Manager Menu");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Remove Employee");
            Console.WriteLine("3. Modify Employee");
            Console.WriteLine("4. Calculate Salary");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                ManagerScreenChoices choice = (ManagerScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case ManagerScreenChoices.AddEmployee:
                        AddEmployee();
                        break;

                    case ManagerScreenChoices.RemoveEmployee: 
                        RemoveEmployee(); 
                        break;

                    case ManagerScreenChoices.ModifyEmployee:
                        ModifyEmployee();
                        break;

                    case ManagerScreenChoices.CalculateSalary:
                        CalculateSalary();
                        break;

                    case ManagerScreenChoices.Exit:
                        Console.WriteLine("Goodbye.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    #endregion // Public Methods

    private void AddEmployee()
    {
        Console.Clear();
        Console.WriteLine("Add Employee");
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Employee Position: ");
        string position = Console.ReadLine();
        Console.Write("Enter Hourly Rate: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal hourlyRate))
        {
            IEmployee newEmployee = new Employee(Company.GenerateEmployeeId(), name, position, hourlyRate);
            Company.AddEmployee(newEmployee);
            Console.WriteLine($"Employee {name} has been added.");
        }
        else
        {
            Console.WriteLine("Invalid hourly rate input.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }

    private void RemoveEmployee()
    {
        Console.Clear();
        Console.WriteLine("Remove Employee");
        Console.Write("Enter Employee ID to Remove: ");
        if (int.TryParse(Console.ReadLine(), out int employeeId))
        {
            if (Company.RemoveEmployee(employeeId))
            {
                Console.WriteLine($"Employee with ID {employeeId} has been removed.");
            }
            else
            {
                Console.WriteLine($"Employee with ID {employeeId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid employee ID input.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }

    private void ModifyEmployee()
    {
        Console.Clear();
        Console.WriteLine("Modify Employee");
        Console.Write("Enter Employee ID to Modify: ");
        if (int.TryParse(Console.ReadLine(), out int modifyEmployeeId))
        {
            IEmployee existingEmployee = Company.GetEmployeeById(modifyEmployeeId);
            if (existingEmployee != null)
            {
                Console.Write("Enter New Employee Name: ");
                existingEmployee.Name = Console.ReadLine();
                Console.Write("Enter New Employee Position: ");
                existingEmployee.Position = Console.ReadLine();
                Console.Write("Enter New Hourly Rate: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal newHourlyRate))
                {
                    existingEmployee.HourlyRate = newHourlyRate;
                    Console.WriteLine($"Employee with ID {modifyEmployeeId} has been modified.");
                }
                else
                {
                    Console.WriteLine("Invalid hourly rate input.");
                }
            }
            else
            {
                Console.WriteLine($"Employee with ID {modifyEmployeeId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid employee ID input.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }

    private void CalculateSalary()
    {
        Console.Clear();
        Console.WriteLine("Calculate Salary");
        Console.Write("Enter Employee ID: ");
        if (int.TryParse(Console.ReadLine(), out int calculateEmployeeId))
        {
            Console.Write("Enter Hours Worked: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal hoursWorked))
            {
                decimal salary = Company.CalculateSalary(calculateEmployeeId, hoursWorked);
                if (salary >= 0)
                {
                    Console.WriteLine($"Salary for Employee with ID {calculateEmployeeId}: ${salary}");
                }
                else
                {
                    Console.WriteLine("Invalid employee ID input or insufficient hours worked.");
                }
            }
            else
            {
                Console.WriteLine("Invalid hours worked input.");
            }
        }
        else
        {
            Console.WriteLine("Invalid employee ID input.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}

