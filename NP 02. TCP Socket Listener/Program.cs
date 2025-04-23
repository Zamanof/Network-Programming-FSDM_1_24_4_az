using System.Net;
using System.Net.Sockets;
using System.Text;

//var ipAddress = IPAddress.Parse("127.0.0.1");
//var ipAddress = IPAddress.Loopback;
var ipAddress = IPAddress.Parse("10.1.16.1");
var port = 27001;

Socket listener = new(
    AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp);

var endPoint = new IPEndPoint(ipAddress, port);
listener.Bind(endPoint);

var backLog = 1;
listener.Listen(backLog);

Console.WriteLine("Listener listen...");
var length = 0;
var bytes = new byte[1024];
var message = string.Empty;

Socket clientSocket = null;

while (true)
{
    Console.WriteLine($"Listener listen ad {listener.LocalEndPoint}");
    await Task.Run(() =>
    {
        clientSocket = listener.Accept();
        do
        {
            length = clientSocket.Receive(bytes);
            message = Encoding.Default.GetString(bytes, 0, length);
            Console.WriteLine($"{clientSocket.RemoteEndPoint}: {message}");
            if(message.ToLower() == "exit")
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Dispose();
                break;
            }
        } while (true);
    });
}
