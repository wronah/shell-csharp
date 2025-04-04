﻿public static class Commands
{
    public const string Exit = "exit";
    public const string Echo = "echo";
    public const string Type = "type";

    private static readonly List<string> builtinCommands = 
        [Exit, Echo, Type];

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

        if (Utils.FindCommandInPath(command) is string path)
        {
            Console.WriteLine($"{command} is {path}");
            return;
        }

        Console.WriteLine($"{command}: not found");
    }
}
