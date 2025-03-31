using System.Net;
using System.Net.Sockets;

while(true)
{
    Console.Write("$ ");

    // Wait for user input
    var command = Console.ReadLine();

    if(command == "exit 0")
    {
        break;
    }

    Console.WriteLine($"{command}: command not found");
}
