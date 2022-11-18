using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace NuclearBonk;

internal class Program
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);
    private static FileInfo? _fileToSet;
    static async Task<int> Main(string[] args)
    {
        args = new string[] { "C:\\_delete\\grass_side.png" };

        if (!OperatingSystem.IsWindows())
            return 1;
        if (args.Length != 1)
            return 2;

        _fileToSet = new(string.Join("", args));
        if (!_fileToSet.Exists)
            return 3;

        if (!new string[] { ".jpg", ".png" }.Any(a => a.Equals(_fileToSet.Extension, StringComparison.OrdinalIgnoreCase)))
            return 4;

        SystemEvents.SessionEnded += SystemEvents_SessionEnded;

        await Task.Delay(Timeout.Infinite);
        return 0;
    }

    private static void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
    {
        if (_fileToSet is null)
            return;
        try
        {
            File.WriteAllText(@"C:\Users\Felix Kreuzberger\Desktop\BONK.txt", _fileToSet.FullName);
            //SystemParametersInfo(20, 1, _fileToSet.FullName, 0x1);
        }
        catch (Exception)
        {

        }
        finally
        {
            if (OperatingSystem.IsWindows())
                SystemEvents.SessionEnded -= SystemEvents_SessionEnded;
        }
    }
}