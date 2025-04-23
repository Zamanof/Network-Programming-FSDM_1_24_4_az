using System.Net.Sockets;
using System.Net;
using System.Text;

var ipAddress = IPAddress.Parse("127.0.0.1");
var port = 27001;

Socket listener = new(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);

IPAddress.TryParse("127.0.0.1", out var ip);
var connectEp = new IPEndPoint(ip, 27001);

listener.Bind(connectEp);

EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

var buffer = new byte[ushort.MaxValue];

while (true)
{
    var length = listener.ReceiveFrom(buffer, ref endPoint);
    var message = Encoding.Default.GetString(buffer, 0, length);
    Console.Write(message);
}
