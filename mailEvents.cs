using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace OpenFluentMail
{
    public class mailEvents
    {
        //Format is List<List<Username, Subject, Body, Emailadress, PrimaryImage, Timestamp,>>
        public static List<mailItems> RefreshMail(ImapClient client)
        {
            //TODO: Add code to connect to IMAP server, receive mail, and add to list
            //Connects to IMAP server
            //Foreach email (Replace in range)
            //TODO: Add code to check which mailbox to get info from
            List<mailItems> emails = new List<mailItems>();
            //Inbox mail Items
            var inbox = client.Inbox;
            inbox.Open(MailKit.FolderAccess.ReadOnly);
            //for (int i = 0; i < inbox.Count; i++)
            for (int i = inbox.Count-1; i > inbox.Count-25; i--)
            {
                try
                {
                    var message = inbox.GetMessage(i);
                    string[] username = { message.From[0].Name.ToString() };
                    string sunbect = message.Subject.ToString();
                    //string body = message.TextBody.ToString();
                    string body = message.HtmlBody;
                    //remove image tag for security
                    body = body.Replace("<img", "<p");
                    string[] emailadress = { message.From[0].ToString() };
                    string primaryimage = message.From[0].Name.ToString();
                    string timestamp = message.Date.ToString();
                    mailItems newMail = new mailItems(username, sunbect, body, emailadress, primaryimage, timestamp, i);
                    emails.Add(newMail);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return emails;
                }

            }
            return emails;
        }

        public static List<mailItems> inboxLoadMore(ImapClient client, int start)
        {
            List<mailItems> emails = new List<mailItems>();
            var inbox = client.Inbox;
            inbox.Open(MailKit.FolderAccess.ReadOnly);
            for (int i = inbox.Count - 1 - start; i > inbox.Count - 25 - start; i--)
            {
                try
                {
                    var message = inbox.GetMessage(i);
                    string[] username = { message.From[0].Name.ToString() };
                    string sunbect = message.Subject.ToString();
                    //string body = message.TextBody.ToString();
                    string body = message.HtmlBody;
                    //remove image tag for security
                    body = body.Replace("<img", "<p");
                    string[] emailadress = { message.From[0].ToString() };
                    string primaryimage = message.From[0].Name.ToString();
                    string timestamp = message.Date.ToString();
                    mailItems newMail = new mailItems(username, sunbect, body, emailadress, primaryimage, timestamp, i);
                    emails.Add(newMail);
                }
                catch (Exception e)
                {
                    Console.Write(e);
                    return emails;
                }

            }
            return emails;
        }
        public static string generateOtherRecipients(string[] usernames, string[] emails)
        {
            if (usernames.Length != emails.Length)
            {
                throw new Exception("Usernames and emails are not the same length");
                //This error should only happen when something has gone catastrophically wrong, and therefore should just error out
            }

            string otherRecipients = "";
            for (int i = 0; i < usernames.Length; i++)
            {
                if (i == 0)
                {
                    otherRecipients += "Me";
                    otherRecipients += "; ";
                }
                else
                {
                    otherRecipients += usernames[i];
                    otherRecipients += " ";
                    otherRecipients += emails[i];
                    otherRecipients += " ; ";
                }
            }

            return otherRecipients;

        }

        public static ImapClient authenticateClient(string host, int port, string username, string password)
        {
            ImapClient client = new ImapClient();
            try
            {
                client.Connect(host, 993, true);
                try
                {
                    client.Authenticate(username, password);
                    return client;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return client;
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return client;
            }
        }

        public static SmtpClient AuthentiSmtpClient(string host, int port, string username, string password)
        {
            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect(host, 587, SecureSocketOptions.StartTls);
                try
                {
                    client.Authenticate(username, password);
                    return client;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return client;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return client;
            }
        }
    }
}
