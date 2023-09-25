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
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace OpenFluentMail
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class mailViewPage : Page
    {
        public static List<mailItems> initialEmails;
        public static int mailId;
        public mailViewPage()
        {
            this.InitializeComponent();
            refreshlist();
            
        }

        private void refreshlist()
        {
            mailContentFrame.ClearValue(Frame.ContentProperty);
            mailItems.Items.Clear();
            initialEmails = mailEvents.RefreshMail();
            foreach (mailItems email in initialEmails)
            {
                mailItems.Items.Add(email);
            }
            mailContentFrame.ClearValue(Frame.ContentProperty);
            mailId = 0;
            
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            refreshlist();
        }
        private void NewMail_Tapped(object sender, TappedRoutedEventArgs args)
        {
            mailContentFrame.Navigate(typeof(newMailView));
        }
        private void MailItems_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mailId = mailItems.SelectedIndex;
            mailContentFrame.Navigate(typeof(receivedMailView));
        }
    }
}
