using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace OpenFluentMail
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class receivedMailView : Page
    {
        
        int _mailId = mailViewPage.mailId;
        List<mailItems> _initialEmails = mailViewPage.initialEmails;
        public receivedMailView()
        {
            this.InitializeComponent();
            if (_mailId > -1)
            {
                subject.Text = _initialEmails[_mailId].Subject;
                sender.Text = _initialEmails[_mailId].MainUsername;
                senderpic.DisplayName = _initialEmails[_mailId].MainUsername;
                senderemailaddress.Text = _initialEmails[_mailId].Emailadress[0];
                otherRecipients.Text = _initialEmails[_mailId].OtherRecipients;
                maildate.Text = _initialEmails[_mailId].Timestamp;
                //Run bodyText = new Run();
                //bodyText.Text = _initialEmails[_mailId].Body;
                //mailbody.Inlines.Add(bodyText);
                setWebView();

            }
        }

        private async void setWebView()
        {
            await mailBodyView.EnsureCoreWebView2Async();
            
            mailBodyView.NavigateToString(_initialEmails[_mailId].Body);
        }

        /* private void DecreaseFontSize(object o, TappedRoutedEventArgs e)
        {
            if (overarchtextbody.FontSize - 4 <= 0)
            {
                
            }
            else
            { 
                overarchtextbody.FontSize -= 4;
            }
            
        }

        private void IncreaseFontSize(object o, TappedRoutedEventArgs e)
        {
            overarchtextbody.FontSize += 4;
        } */
    } 
}
