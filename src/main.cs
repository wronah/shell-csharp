while (true)
{
    Console.Write("$ ");

    var input = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries); ;

    if (input == null || input.Length == 0)
    {
        continue;
    }

    var command = input[0];
    var arguments = input.Length > 1 ? input[1..] : Array.Empty<string>();

    switch (command)
    {
        case Commands.Exit:
            Commands.ExitCommand(arguments);
            break;
        case Commands.Echo:
            Commands.EchoCommand(arguments);
            break;
        case Commands.Type:
            Commands.TypeCommand(arguments[0]);
            break;
        default:
            Console.WriteLine($"{command}: command not found");
            break;
    }
}

