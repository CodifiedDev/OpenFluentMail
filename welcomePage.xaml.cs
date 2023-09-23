using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml.Shapes;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace OpenFluentMail
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class welcomePage : Page
    {
        public List<Tuple<string, string, string, string, string, string>> EmailProviders { get;  } = new List<Tuple<string, string, string, string,string,string>>()
        {
            //Create Tuples for most commonly used WebMail Services in the format of (Service Name, IMAP IP, IMAP Port, SMTP IP, SMTP Port, Logo Path)
            new Tuple<string, string, string, string, string, string>("Gmail", "imap.gmail.com", "993", "smtp.gmail.com", "587", "Assets/gmail.png"),
            new Tuple<string, string, string, string, string, string>("Outlook", "imap-mail.outlook.com", "993", "smtp-mail.outlook.com", "587", "Assets/outlook.png"),
            new Tuple<string, string, string, string, string, string>("Yahoo", "imap.mail.yahoo.com", "993", "smtp.mail.yahoo.com", "587", "Assets/yahoo.png"),
            new Tuple<string, string, string, string, string, string>("iCloud", "imap.mail.me.com", "993", "smtp.mail.me.com", "587", "Assets/icloud.png"),
            new Tuple<string, string, string, string, string, string>("AOL", "imap.aol.com", "993", "smtp.aol.com", "587", "Assets/aol.png"),
            new Tuple<string, string, string, string, string, string>("Zoho", "imap.zoho.com", "993", "smtp.zoho.com", "587", "Assets/zoho.png"),
            new Tuple<string, string, string, string, string, string>("Custom", "127.0.0.1", "993", "127.0.0.1", "587", "Assets/custom.png"),

        };
        

        public welcomePage()
        {
            this.InitializeComponent();
            MainCanvas.Translation += new Vector3(0, 0, 32);
            

            
        }
        void Submit(object sender, RoutedEventArgs e)
        {
            var test = EmailProviderBox.SelectionBoxItem;
            String testString = test.ToString();
            testString = testString.Replace("(", "");
            testString = testString.Replace(")", "");
            Array emailProviderArray = testString.Split(",");
            String userEmail = IMAPUsername.Text;
            String userPassword = IMAPPassword.Password;
            //TODO : Implement IMAP and SMTP Connection and Login
            //Add User Information to JSON File if Login is Successful, Hash Password
            var obj = new
            {
                activelogins = new[]
                {
                    new
                    {
                        email = userEmail,
                        password = userPassword,
                        imap = new
                        {
                            ip = emailProviderArray.GetValue(1),
                            port = emailProviderArray.GetValue(2)
                        },
                        smtp = new
                        {
                            ip = emailProviderArray.GetValue(3),
                            port = emailProviderArray.GetValue(4)
                        }
                    }
                }
            };
            var json = System.Text.Json.JsonSerializer.Serialize(obj);
            //Write JSON to File in Documents

            //Launch emailView
            Window  viewWindow = App.MainWindow;
           
            launchWindow.OpenPage(viewWindow, "OpenFluentMail", typeof(emailView), null);
            

        }

    }
}
