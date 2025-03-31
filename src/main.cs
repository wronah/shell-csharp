using System.Net;
using System.Net.Sockets;

while (true)
{
    Console.Write("$ ");

    // Wait for user input
    var command = Console.ReadLine().Split(' ');
    var builtinCommands = new List<string> { "exit", "echo", "type" };
    

    if (command[0] == builtinCommands[0] && command[1] == "0")
    {
        break;
    }
    else if (command[0] == builtinCommands[1])
    {
        for (int i = 1;  i < command.Length; i++)
        {
            Console.Write($"{command[i]} ");
        }
        Console.WriteLine();
    }
    else if (command[0] == builtinCommands[2])
    {
        if(builtinCommands.Contains(command[1]))
        {
            Console.WriteLine($"{command[1]} is a shell builtin");
        }
        else
        {
            var pathsArr = System.Environment.GetEnvironmentVariable("PATH")!.Split(":");
            var isFound = false;
            foreach (var path in pathsArr)
            {
                var joinedPath = Path.Join(path, command[1]);
                if(File.Exists(joinedPath))
                {
                    isFound = true;
                    Console.WriteLine($"{command[1]} is {joinedPath}");
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{command[1]}: not found");
            }
        }
    }
    else
    {
        Console.WriteLine($"{command[0]}: command not found");
    }
}
