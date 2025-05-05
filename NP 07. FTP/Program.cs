using System.Net;

getFTP();
//DownloadFTP();
//UploadFTP();

void getFTP()
{
    var request =WebRequest.Create("ftp://localhost:21") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

    var response = request.GetResponse() as FtpWebResponse;

    var stream = response.GetResponseStream();
    var reader = new StreamReader(stream);
    var data = reader.ReadToEnd();
    Console.WriteLine(data);
}


void DownloadFTP()
{
    var request = WebRequest.Create("ftp://localhost:21/CodeAccessSecurity.pdf") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.DownloadFile;

    var response = request.GetResponse() as FtpWebResponse;
    var stream = response.GetResponseStream();
    var fileStream = new FileStream("CodeAccessSecurity.pdf", FileMode.Create);
    stream.CopyTo(fileStream);
    fileStream.Close();
}

void UploadFTP()
{
    var request = WebRequest.Create("ftp://localhost:21/Salam.pdf") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.UploadFile;
    var fileStream = new FileStream("CodeAccessSecurity.pdf", FileMode.Open);
    var stream = request.GetRequestStream();
    fileStream.CopyTo(stream);
    stream.Close();
    fileStream.Close();
}
