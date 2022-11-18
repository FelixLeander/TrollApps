namespace OperationBlueThunderBird.FakeBlueScreen;

internal static class FakeBsod
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    internal static void Run(bool custom = false)
    {
        ApplicationConfiguration.Initialize();


        if (custom)
            Application.Run(new CustomBsod());
        else
            Application.Run(new PremadeBsod());
    }
}