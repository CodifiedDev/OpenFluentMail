using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFluentMail
{
    public class mailItems
    {
        public string[] Username { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string[] Emailadress { get; set; }
        public string PrimaryImage { get; set; }
        public string Timestamp { get; set; }
        public int EmailID { get; set; }
        public string MainUsername => Username[0];

        public mailItems(string[] username, string subject, string body, string[] emailadress, string primaryImage, string timestamp,
            int emailID)
        {
            Username = username;
            Subject = subject;
            Body = body;
            Emailadress = emailadress;
            PrimaryImage = primaryImage;
            Timestamp = timestamp;
            EmailID = emailID;
        }
    }
}
