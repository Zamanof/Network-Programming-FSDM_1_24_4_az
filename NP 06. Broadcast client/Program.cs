using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();
client.EnableBroadcast = true;

var endPoint = new IPEndPoint(IPAddress.Parse("10.1.16.255"), 27001);

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