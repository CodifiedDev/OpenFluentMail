using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using MailKit.Net.Smtp;
using Microsoft.UI.Text;
//using ABI.Windows.ApplicationModel.Contacts;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MimeKit;
using Org.BouncyCastle.Security;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace OpenFluentMail
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class newMailView : Page
    {
        public newMailView()
        {
            this.InitializeComponent();
        }

        private void FontSize_OnValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            int FontSize = Convert.ToInt32(fontSize.Value);
            mailBody.FontSize = FontSize;
            //Currently this only works with selected text, needs to be fixed in bugfix patch
            
        }

        private async void Browsecontacts_OnClick(object sender, RoutedEventArgs e)
        {
            var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();
            Contact contact = await contactPicker.PickContactAsync();
        }

        private void Send_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            SmtpClient client = welcomePage.InitalLoggiedinSmtpClient;
            var message = new MimeMessage();
            //TODO: Gather actual username of sender and recpient from user.
            message.From.Add(new MailboxAddress("OpenFluentMail", welcomePage.userEmailAddress));
            message.To.Add(new MailboxAddress("Intended Recipient", mailrecipients.Text));
            message.Subject = mailSubject.Text;
            string text = mailBody.Text;
            //TODO: Make sure body works
            message.Body = new TextPart("plain")
            {
                
            Text = text
            };
            //client.Send(message);
            writeOut.Children.Clear();
        }
    }
}
