using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();
client.MulticastLoopback = true;

var ip = IPAddress.Parse("224.0.0.1");
var endPoint = new IPEndPoint(ip, 27001);

List<string> messages = [
    @"/\_______",
    @"_/\______",
    @"__/\_____",
    @"___/\____",
    @"____/\___",
    @"_____/\__",
    @"______/\_",
    @"_______/\",
    @"________/",
    @"_________",
    @"\________"
    ];

int i = 0;
int length = messages.Count;

while (true)
{
    var data = Encoding.UTF8.GetBytes(messages[i++ % length]);
    client.Send(data, data.Length, endPoint);
    Thread.Sleep(100);
}
