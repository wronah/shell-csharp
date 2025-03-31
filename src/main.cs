using System.Net;
using System.Net.Sockets;

while(true)
{
    Console.Write("$ ");

    // Wait for user input
    var command = Console.ReadLine().Split(' ');

    if (command[0] == "exit" && command[1] == "0")
    {
        break;
    }
    else if (command[0] == "echo")
    {
        for (int i = 1;  i < command.Length; i++)
        {
            Console.Write($"{command[i]} ");
        }
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine($"{command[0]}: command not found");
    }
}
