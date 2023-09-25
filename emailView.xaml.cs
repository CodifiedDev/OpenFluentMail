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
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace OpenFluentMail
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class emailView : Page
    {
        public static int accountid;
        public emailView()
        {
            this.InitializeComponent();
            NavigationViewItem newaccountItem = createAccountItem("Outlook", 1);
            NavigationViewItem newaccountItem2 = createAccountItem("Gmail", 2);
            accountViewItem.MenuItems.Add(newaccountItem);
            accountViewItem.MenuItems.Add(newaccountItem2);
            SplitView mainSplitView = new SplitView();
            ListView emailList = new ListView();
            Canvas emailCanvas = new Canvas();
            emailList.Items.Add("Test");
            mainSplitView.Pane = emailList;
            mainSplitView.Content = emailCanvas;
            mainView.Navigate(typeof(mailViewPage));



        }

        public NavigationViewItem createAccountItem(string name, int id)
        {
            NavigationViewItem newaccountItem = new NavigationViewItem();
            newaccountItem.Content = name;
            newaccountItem.Tag = id;
            newaccountItem.Icon = new SymbolIcon(Symbol.Mail);
            return newaccountItem;
        }

        private void MailNav_OnSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                mainView.Navigate(typeof(settings));
            }
            else
            {
                NavigationViewItem selectedItem = (NavigationViewItem)args.SelectedItem;
                //if (selectedItem.Tag.ToString() == "1")
                //{
                //mainView.Navigate(typeof(mailViewPage));
                //}
                accountid = Convert.ToInt32(selectedItem.Tag);
                mainView.Navigate(typeof(mailViewPage));
            }
        }

       
    }
    }
