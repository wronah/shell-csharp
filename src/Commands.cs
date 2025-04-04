public static class Commands
{
    public const string Exit = "exit";
    public const string Echo = "echo";
    public const string Type = "type";
    public const string Pwd = "pwd";
    public const string Cd = "cd";

    private static readonly List<string> builtinCommands = 
        [Exit, Echo, Type, Pwd, Cd];

    public static void ExitCommand(string[] arguments) 
    {
        if (arguments.Length == 1 && int.TryParse(arguments[0], out int exitCode))
        {
            Environment.Exit(exitCode);
        }
        else
        {
            Console.WriteLine("Usage: exit <code>");
        }
    }

    public static void EchoCommand(string[] arguments)
    {
        foreach(var arg in arguments)
        {
            Console.Write($"{arg} ");
        }
        Console.WriteLine();
    }

    public static void TypeCommand(string command)
    {
        if (builtinCommands.Contains(command))
        {
            Console.WriteLine($"{command} is a shell builtin");
            return;
        }

        if (Utils.FindInPath(command) is string path)
        {
            Console.WriteLine($"{command} is {path}");
            return;
        }

        Console.WriteLine($"{command}: not found");
    }

    public static void PwdCommand()
    {
        Console.WriteLine(Environment.CurrentDirectory);
    }

    public static void CdCommand(string path)
    {
        if(Path.Exists(path))
        {
            Environment.CurrentDirectory = path;
            return;
        }

        Console.WriteLine($"{Cd}: {path}: No such file or directory");
    }
}
