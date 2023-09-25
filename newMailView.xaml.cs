using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
//using ABI.Windows.ApplicationModel.Contacts;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
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
    public sealed partial class newMailView : Page
    {
        public newMailView()
        {
            this.InitializeComponent();
        }

        private void FontSize_OnValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            int FontSize = Convert.ToInt32(fontSize.Value);
            if (mailBody.Document.Selection == null)
            {
                mailBody.FontSize = FontSize;
            }
            else if (mailBody.Document.Selection != null)
            {
                mailBody.Document.Selection.CharacterFormat.Size = FontSize;
            }
            //Currently this only works with selected text, needs to be fixed in bugfix patch
            
        }

        private async void Browsecontacts_OnClick(object sender, RoutedEventArgs e)
        {
            var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();
            Contact contact = await contactPicker.PickContactAsync();
        }
    }
}
