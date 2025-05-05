using System.Net;
using System.Net.Sockets;

var client = new TcpClient();

var ip = IPAddress.Parse("127.0.0.1");
var port = 27001;

try
{
	client.Connect(ip, port);
    Console.WriteLine("Connected to server");
    var stream = client.GetStream();
    var writer = new BinaryWriter(stream);
    var reader = new BinaryReader(stream);
    var sendingTask = Task.Run(() =>
    {
        while (true)
        {
            var message = Console.ReadLine();
            if (string.IsNullOrEmpty(message)) continue;
            try
            {
                writer.Write(message);
                writer.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sending error: {ex.Message}");
                break;
            }
        }
    });

    var receivingTask = Task.Run(() =>
    {
        while (true)
        {
            try
            {
                var received = reader.ReadString();
                Console.WriteLine($"From server: {received}");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Receiving error: {ex.Message}");
                break;
            }
        }
    });
   await Task.WhenAny(sendingTask, receivingTask);
}
catch (Exception ex)
{
    Console.WriteLine($"Connection error: {ex.Message}");
}
finally
{
    client.Close();
}