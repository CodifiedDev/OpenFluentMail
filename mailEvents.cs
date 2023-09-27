using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;

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
            /* for (int i = 0; i < 10; i++)
            {
                //Variables set using data from emails
                //Debug data
                string[] username = { "Test", "Test Friend" };
                string subject = "Test";
                string body =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. \n";
                string[] emailadress = { "Test", "Friendtest@email.com" };
                string primaryImage = "Test";
                string timestamp = "Test";
                mailItems newMail = new mailItems(username, subject, body, emailadress, primaryImage, timestamp, i);
                emails.Add(newMail);
            } */
            //Inbox mail Items
            var inbox = client.Inbox;
            inbox.Open(MailKit.FolderAccess.ReadOnly);
            //for (int i = 0; i < inbox.Count; i++)
            for (int i = inbox.Count-1; i > inbox.Count-12; i--)
            {
                var message = inbox.GetMessage(i);
                string[] username = { message.From[0].Name.ToString() };
                string sunbect = message.Subject.ToString();
                //string body = message.TextBody.ToString();
                string body = message.HtmlBody;
                string[] emailadress = { message.From[0].ToString() };
                string primaryimage = message.From[0].Name.ToString();
                string timestamp = message.Date.ToString();
                mailItems newMail = new mailItems(username, sunbect, body, emailadress, primaryimage, timestamp, i);
                emails.Add(newMail);

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
    }
}
