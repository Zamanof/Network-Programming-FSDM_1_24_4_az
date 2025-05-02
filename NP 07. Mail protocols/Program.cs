// SMTP, POP3, IMAP

using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MimeKit;



//SMTP();
//IMAP();

SMTPMailKit();
//void SMTP() // SmtpClient is deprecated
//{
//    var client = new SmtpClient("smtp.gmail.com", 587);
//    client.EnableSsl = true;
//    client.Credentials = new NetworkCredential("fbms.1223@gmail.com", "xecewltmennciaba");

//    var message = new MailMessage{
//        Subject = "Test",
//        Body = "WINTER IS COMING!!! (WINTER = EXAM)",
//    };

//    message.From = new MailAddress("fbms.1223@gmail.com", "Your nightmare");

//    message.To.Add(new MailAddress("huseynliakramdevv1@gmail.com"));
//    message.To.Add(new MailAddress("cavadovabanu79@gmail.com"));
//    message.To.Add(new MailAddress("muradvaliyev023@gmail.com"));
//    message.To.Add(new MailAddress("crazyiboq2002@gmail.com"));

//    client.Send(message);
//}

void IMAP()
{
    var imapClient = new ImapClient();
    imapClient.Connect("imap.gmail.com", 993, true);
    imapClient.Authenticate("fbms.1223@gmail.com", "xecewltmennciaba");

    var inbox = imapClient.Inbox;
    inbox.Open(FolderAccess.ReadWrite);

    var ids = inbox.Search(SearchQuery.All);

    foreach (var id in ids)
    {
        Console.WriteLine($"{id}. {inbox.GetMessage(id).TextBody}");
    }

    //inbox.SetFlags(new UniqueId(54), MessageFlags.Deleted, true);

    //inbox.AddFlags(ids, MessageFlags.Deleted, true);
    //inbox.AddFlags(ids, MessageFlags.Seen, true);

    //inbox.AddFlags(ids, MessageFlags.Answered, true);

    //inbox.Expunge();
    //inbox.Close();
}

void SMTPMailKit() // SmtpClient MailKit recommended
{
    var smtpClient = new SmtpClient();
    smtpClient.Connect("smtp.gmail.com", 465, true);
    smtpClient.Authenticate("fbms.1223@gmail.com", "xecewltmennciaba");
    var message = new MimeKit.MimeMessage();
    message.From.Add(new MailboxAddress("NightMare", "fbms.1223@gmail.com"));
    message.To.AddRange(new[]
    {
        //MailboxAddress.Parse("huseynliakramdevv1@gmail.com"),
        //MailboxAddress.Parse("cavadovabanu79@gmail.com"),
        //MailboxAddress.Parse("muradvaliyev023@gmail.com"),
        //MailboxAddress.Parse("crazyiboq2002@gmail.com"),
        MailboxAddress.Parse("zamanov@itstep.org")

    });
    message.Subject = "Exam";
    //message.Body = new TextPart("plain")
    //{
    //    Text = "WINTER IS COMING!!! (WINTER = EXAM)"
    //};

    message.Body = new TextPart("html")
    {
        Text = @" <h1 style='color: red;'>WINTER IS COMING!!! (WINTER = EXAM)</h1>
    <img src='https://ichef.bbci.co.uk/ace/standard/976/cpsprodpb/168BA/production/_95064329_ap_thrones_ice.jpg.webp' >"
    };
    smtpClient.Send(message);

    smtpClient.Disconnect(true);


}
