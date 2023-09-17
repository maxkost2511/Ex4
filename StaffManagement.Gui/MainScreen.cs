using Workers.Enum;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor


    /// <summary>
    /// Manager screen.
    /// </summary>
    private ManagerScreen _managerScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    public MainScreen(ICompany company, ManagerScreen managerScreen) : base(company)
    { 
        _managerScreen = managerScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Manager Menu");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.ManagerMenu:
                        _managerScreen.Show();
                        break;

                    case MainScreenChoices.Exit:
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
}