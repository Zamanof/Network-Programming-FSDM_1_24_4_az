using System.Net;

var listener = new HttpListener();

listener.Prefixes.Add(@"http://localhost:27001/");

listener.Start();

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;
    //Console.WriteLine(request);
    var rawUrl = request.RawUrl;
    //Console.WriteLine(rawUrl);


    // ?login=Nadir&password=qwerty - query string (?key1=value1&key2=val2&...)
    //var queryString = rawUrl.Split('?')[1];
    //var strings = queryString.Split("&");
    //for ( int i = 0; i < strings.Length; i++)
    //{
    //    var data = strings[i].Split('=');
    //    Console.WriteLine($"Key = {data[0]} - value = {data[1]}");
    //}
    //Console.WriteLine(request.QueryString);

    //foreach(string key in request.QueryString.Keys)
    //{
    //    Console.WriteLine($"key = {key} - value = {request.QueryString[key]}");
    //}

    //response.AddHeader("Content-Type", "text/plain");

    StreamWriter writer = new StreamWriter(response.OutputStream);
    //writer.Write($"Salam {request.QueryString["login"]}");
    var login = request.QueryString["login"];

    writer.WriteLine(@$"<h1>Salam {login}</h1>");
    writer.WriteLine(@$"<a href='https://google.com?q={login}'>Search</a>");
    writer.WriteLine(@$"<img src='https://avatars.githubusercontent.com/u/123265575?v=4'/>");

    writer.Close();
}
