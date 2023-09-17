using System.Windows.Input;
/// <summary>
/// Represents a base screen class for managing the console application screens.
/// </summary>
public abstract class Screen
{
    protected ICompany Company; // Reference to your company

    protected List<string> History = new List<string>();

    public Screen(ICompany company)
    {
        Company = company;
    }

    /// <summary>
    /// Show the screen.
    /// </summary>
    public abstract void Show();
}
