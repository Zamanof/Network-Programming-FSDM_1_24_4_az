using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new UdpClient(27001);
var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

var message = string.Empty;

while (true)
{
    var bytes = listener.Receive(ref remoteEndPoint);
    message = Encoding.UTF8.GetString(bytes);
    Console.WriteLine($"{remoteEndPoint.Address}-{remoteEndPoint.Port}: {message}");
    Thread.Sleep(100);
    Console.Clear();
}
