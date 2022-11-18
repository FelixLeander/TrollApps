using System.Runtime.InteropServices;

namespace OperationPocketGoose;
public class Program
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);
    private static int SetWallpaper(string filePath) => SystemParametersInfo(20, 1, filePath, 0x1);

    private static readonly bool IsConsoleApplication = Console.OpenStandardInput(1) != Stream.Null;
    private static FileInfo? lastFile;

    public static async Task Main()
    {
        while (true)
        {
            DriveInfo drive;
            try
            {
                drive = DriveInfo.GetDrives().First(f => f.VolumeLabel.Equals("DATA01"));
            }
            catch (Exception ex)
            {
                ConsoleWriteInfo($"Drive not found, error: '{ex.Message}'");
                await Task.Delay(30000);
                continue;
            }

            string path = Path.Combine(drive.Name, @"Shared (NoSecure)\Felix K\GooseWorker");
            if (!Directory.Exists(path))
            {
                ConsoleWriteInfo($"Path not found: '{path}'");
                await Task.Delay(30000);
                continue;
            }

            FileSystemWatcher? fileSystemWatcher = null;
            try
            {
                fileSystemWatcher = new FileSystemWatcher
                {
                    Path = path,
                    NotifyFilter = NotifyFilters.LastWrite,
                    EnableRaisingEvents = true,
                };
                fileSystemWatcher.Changed += WatcherOnChanged;
                ConsoleWriteInfo("Successfully created Watcher");

                await Task.Delay(1000 * 60 * 10); //Recreating the watcher all 10minutes
                ConsoleWriteInfo("Throwing away the watcher.");
                fileSystemWatcher.Changed -= WatcherOnChanged;
                fileSystemWatcher.Dispose();
            }
            catch (Exception ex)
            {
                if (fileSystemWatcher is not null)
                    fileSystemWatcher.Changed -= WatcherOnChanged;

                ConsoleWriteInfo($"Cant create Watcher:{Environment.NewLine}{ex.Message}");
                await Task.Delay(3000);
            }
        }
    }

    private static async void WatcherOnChanged(object sender, FileSystemEventArgs e)
    {
        ConsoleWriteInfo($"Triggered by:{e.ChangeType} '{e.FullPath}'");

        var currentFile = new FileInfo(e.FullPath);

        if (lastFile is not null && currentFile.FullName.Equals(lastFile.FullName))
            return;

        lastFile = currentFile;

        if (!(currentFile.Extension.Contains("jpg", StringComparison.OrdinalIgnoreCase) || currentFile.Extension.Contains("png", StringComparison.OrdinalIgnoreCase)))
            return;

        SetWallpaper(currentFile.FullName);
        ConsoleWriteInfo($"Wallpaper was set: '{currentFile.FullName}'");
        await Task.Delay(5000);

        try
        {
            currentFile.Delete();
            ConsoleWriteInfo($"File '{currentFile.FullName}' deleted");
        }
        catch (Exception ex)
        {
            ConsoleWriteInfo($"Could not delete file '{ex.Message}'");
        }
    }

    private static void ConsoleWriteInfo(string text)
    {
        if (IsConsoleApplication)
            Console.WriteLine($"{DateTime.Now:g}: {text}");
    }
}