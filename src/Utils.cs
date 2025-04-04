public static class Utils
{
    public static bool IsExecutable(string filePath)
    {
        if (OperatingSystem.IsWindows())
        {
            string ext = Path.GetExtension(filePath).ToLower();
            return ext == ".exe" || ext == ".bat" || ext == ".cmd";
        }
        else
        {
            return new FileInfo(filePath).Exists &&
                   (new FileInfo(filePath).Attributes & FileAttributes.Directory) == 0;
        }
    }

    public static string? FindCommandInPath(string command)
    {
        var paths = Environment.GetEnvironmentVariable("PATH")?
            .Split(Path.PathSeparator) ?? Array.Empty<string>();

        foreach (var path in paths)
        {
            string fullPath = Path.Combine(path, command);
            if (File.Exists(fullPath) && IsExecutable(fullPath))
            {
                return fullPath;
            }
        }

        return null;
    }
}
