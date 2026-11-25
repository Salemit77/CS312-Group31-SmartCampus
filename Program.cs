using SmartCampus.Client.Forms;
using SmartCampus.Client.Services;

namespace SmartCampus.Client;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, args) =>
        {
            ClientLog.Write($"FATAL UI: {args.Exception}");
            ShowFatalError(args.Exception);
        };
        AppDomain.CurrentDomain.UnhandledException += (_, args) =>
        {
            if (args.ExceptionObject is Exception exception)
            {
                ClientLog.Write($"FATAL DOMAIN: {exception}");
                ShowFatalError(exception);
            }
        };
        TaskScheduler.UnobservedTaskException += (_, args) => args.SetObserved();

        ApplicationConfiguration.Initialize();

        var dataService = new InMemoryCampusDataService();
        using var login = new LoginForm(dataService);
        if (login.ShowDialog() != DialogResult.OK || login.AuthenticatedUser is null)
        {
            return;
        }

        Application.Run(new MainForm(dataService, login.AuthenticatedUser));
    }

    private static void ShowFatalError(Exception exception)
    {
        MessageBox.Show(
            $"The application encountered an unexpected error:\n\n{exception.Message}",
            "Integrated Smart Campus System",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}

