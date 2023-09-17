using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prism.Events;

namespace StaffManagement.App;

/// <summary>
/// Main class for starting up program.
/// </summary>
internal static class Program
{
    #region Main Method

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    /// <param name="args">Arguments</param>
    [STAThread]
    static void Main(string[] args)
    {
        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        var mainScreen = ServiceProvider.GetRequiredService<MainScreen>();
        mainScreen.Show();
    }

    #endregion // Main Method

    #region Properties And Methods

    /// <summary>
    /// Service provider.
    /// </summary>
    public static IServiceProvider? ServiceProvider { get; private set; } = null;

    /// <summary>
    /// Creates a host builder.
    /// </summary>
    /// <returns></returns>
    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IEventAggregator, EventAggregator>();
                services.AddSingleton<MainScreen, MainScreen>();
                services.AddSingleton<ManagerScreen, ManagerScreen>();
            });
    }

    #endregion // Properties And Methods
}

