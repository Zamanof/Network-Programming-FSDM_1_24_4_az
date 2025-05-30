﻿using System.Net;
using System.Net.Sockets;
using System.Text;

var ipAddress = IPAddress.Parse("127.0.0.1");
var port = 27001;

Socket client = new(
    AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp);


IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
var message = string.Empty;

try
{
    client.Connect(endPoint);
    if (client.Connected)
    {
        Console.WriteLine("Connected to server...");
        while (true)
        {
            message = Console.ReadLine();
            var bytes = Encoding.Default.GetBytes(message);
            client.Send(bytes);
        }
    }
    else Console.WriteLine("Can not connected to server...");
}
catch (Exception)
{

    Console.WriteLine("Can not connected to server...");
}
