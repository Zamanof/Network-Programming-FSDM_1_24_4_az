﻿using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new UdpClient(27001);

listener.EnableBroadcast = true;

var from = new IPEndPoint(IPAddress.Any, 0);

while (true)
{
    var receiveBuffer = listener.Receive(ref from);
    var message = Encoding.UTF8.GetString(receiveBuffer);

    Console.SetCursorPosition(0, 0);
    Console.WriteLine(message);
    Thread.Sleep(100);
}
