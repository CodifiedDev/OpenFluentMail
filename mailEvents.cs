using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFluentMail
{
    public class mailEvents
    {
        //Format is List<List<Username, Subject, Body, Emailadress, PrimaryImage, Timestamp,>>
        public static List<mailItems> RefreshMail()
        {
            //TODO: Add code to connect to IMAP server, receive mail, and add to list
            //Connects to IMAP server
            //Foreach email (Replace in range)
            List<mailItems> emails = new List<mailItems>();
            for (int i = 0; i < 10; i++)
            {
                //Variables set using data from emails
                string[] username = { "Test" };
                string subject = "Test";
                string body = "Test";
                string[] emailadress = { "Test" };
                string primaryImage = "Test";
                string timestamp = "Test";
                mailItems newMail = new mailItems(username, subject, body, emailadress, primaryImage, timestamp, i);
                emails.Add(newMail);
            }  
            return emails;
        }
    }
}
