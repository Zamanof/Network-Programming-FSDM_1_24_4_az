using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new UdpClient(27001);
var multiCastIP = IPAddress.Parse("224.0.0.1");

listener.JoinMulticastGroup(multiCastIP);

var endPoint = new IPEndPoint(IPAddress.Any, 0);

while (true)
{
    var receiveBuffer = listener.Receive(ref endPoint);
    var message = Encoding.UTF8.GetString(receiveBuffer);

    Console.Clear();
    Console.WriteLine(message);
    Thread.Sleep(100);

}
