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
        public emailView()
        {
            this.InitializeComponent();
            NavigationViewItem newaccountItem = createAccountItem("Outlook", 1);
            
            accountViewItem.MenuItems.Add(newaccountItem);
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
        }
    }
