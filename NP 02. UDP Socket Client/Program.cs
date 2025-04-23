using System.Net;
using System.Net.Sockets;
using System.Text;

Socket client = new(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);

var connectEp = new IPEndPoint(IPAddress.Loopback, 27001);
var message = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec arcu sapien, tristique eu ullamcorper faucibus, interdum quis odio. Nam consequat imperdiet dui in ullamcorper. Cras nec ultricies arcu, vel porttitor arcu. Vestibulum non mi aliquet, pharetra sem vel, sollicitudin tortor. Morbi interdum eget urna id laoreet. Proin consectetur nisi vel dui semper, ut dapibus felis venenatis. Maecenas ac dictum massa. Fusce efficitur, tellus et elementum egestas, felis ipsum scelerisque turpis, a hendrerit justo dui id sapien. Aliquam vel laoreet eros. Donec rutrum dolor id mauris sodales, at consectetur nibh interdum. Phasellus eget lectus vitae magna condimentum ultricies ut sed risus. Fusce quis elit elementum, iaculis orci vel, mollis orci. In aliquam odio eget quam tristique, nec blandit quam venenatis. Integer nisi tortor, euismod elementum placerat vitae, consequat vitae ex. Nulla facilisi.
Suspendisse a nulla non massa dictum blandit. Donec fringilla magna convallis mauris convallis mollis. Aliquam vitae ultricies nibh. Praesent finibus rutrum odio in dignissim. Donec blandit vitae purus convallis bibendum. Vivamus varius velit non dolor posuere tincidunt. Pellentesque suscipit elit a lacinia mattis. Etiam sed tortor nulla. Donec placerat blandit enim eu tristique. Nam sodales, dolor a pellentesque suscipit, orci felis tincidunt purus, ac tempor risus felis at elit. Nam fermentum ullamcorper aliquet. Maecenas non interdum nulla. Pellentesque pharetra malesuada mi, ut lacinia augue rhoncus pretium. Quisque eu turpis sit amet erat dapibus lacinia at nec velit.
Mauris aliquam ultricies turpis a tristique. Donec scelerisque velit sed ipsum facilisis volutpat. Nunc massa libero, efficitur a nisi dictum, ultricies elementum sapien. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec nisi mauris, dignissim eget sagittis non, euismod sit amet elit. Duis enim arcu, placerat eget lacus quis, porta laoreet velit. Vestibulum nec nibh vel neque mattis tincidunt. Donec hendrerit fringilla urna, in consequat risus.
Donec et volutpat libero. Mauris posuere facilisis erat. Etiam ac lacinia elit. Cras id quam tristique, efficitur magna in, condimentum sem. Maecenas in dignissim elit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Quisque ullamcorper ac ligula vitae tristique. Duis tortor mauris, semper vitae risus ut, iaculis interdum magna. Donec viverra nunc non diam laoreet suscipit. Vivamus vel aliquam sem.
Curabitur vitae efficitur justo. Pellentesque mollis nibh at ligula lacinia, vel tincidunt mauris malesuada. Aliquam sodales odio purus, id mattis justo ullamcorper ac. Sed efficitur pharetra urna, sed accumsan ex malesuada eu. Phasellus finibus nibh eget dignissim rhoncus. Cras ultricies massa eget metus sollicitudin, ac commodo augue iaculis. Nullam sed erat vel purus blandit lobortis. Nam finibus porta tempus. Curabitur quis ligula vel est dictum lobortis. Cras quis metus varius, pellentesque tellus at, faucibus metus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nunc vel elementum neque, quis efficitur tortor. Proin accumsan bibendum scelerisque.";

int count = 0;
while (true)
{
    var bytes = Encoding.Default.GetBytes(message[count++ % message.Length].ToString());
    Thread.Sleep(100);
    client.SendTo(bytes, connectEp);
}
