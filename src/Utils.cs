﻿using System.Diagnostics;

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

    public static void RunProcess(string path, string[] arguments)
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = path,
            Arguments = string.Join(" ", arguments),
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true,
        };

        var process = Process.Start(processInfo);
        string output = process!.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        process.WaitForExit();
    }
}
