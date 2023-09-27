using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Imaging;

namespace OpenFluentMail
{
    internal class launchWindow
    {
        private static Window m_window = new Window();
        [Obsolete("LaunchWelcomeWindow is a testing function made to initally test window opening, Please use OpenPage")]
        public static void LaunchWelcomeWindow()
        {
            //This function has been deprecated in favor of the below function
            Frame rootFrame = new Frame();
            m_window.Content = rootFrame;
            m_window.Title = "Welcome to OpenFluentMail";
            m_window.Activate();
            rootFrame.Navigate(typeof(welcomePage), null, new EntranceNavigationTransitionInfo());
        }

        public static Grid titleBar()
        {
            Grid newTitleBar = new Grid();
            RowDefinition rowdef = new RowDefinition();
            rowdef.Height = new GridLength(28);
            newTitleBar.RowDefinitions.Add(rowdef);
            newTitleBar.Background = new SolidColorBrush(Colors.Transparent);
            Image icon = new Image();
            icon.HorizontalAlignment = HorizontalAlignment.Left;
            icon.Height = 16;
            icon.Width = 16;
            icon.Margin = new Thickness(8, 8, 0, 0);
            icon.Source = new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png"));
            TextBlock title = new TextBlock();
            title.Text = "OpenFluentMail";
            title.VerticalAlignment = VerticalAlignment.Center;
            title.TextWrapping = TextWrapping.NoWrap;
            title.Margin = new Thickness(32, 0, 0, 0);
            newTitleBar.Children.Add(icon);
            newTitleBar.Children.Add(title);
            return newTitleBar;
        }

        public static void OpenPage(Window window, String title, Type pagename, Frame frame)
        {
            

            //Window window = MainWindow.m_window();
            if (window == null)
            {
                window = new Window();
                
            }
            //window.ExtendsContentIntoTitleBar = true;
            //var titlebar = titleBar();
            
            if (frame == null)
            {
                Frame newframe = new Frame();
                window.AppWindow.MoveAndResize(new Windows.Graphics.RectInt32(0, 0, 1920, 1080));
                window.Content = newframe;
                window.Title = title;
                //titlebar.Children.Add(newframe);
                //Grid.SetRow(newframe, 1);
                //window.Content = titlebar;
                //window.SetTitleBar(titlebar);
                
                window.Activate();
                newframe.Navigate(pagename, null, new EntranceNavigationTransitionInfo());
            }
            else
            {
                window.Content = frame;
                window.AppWindow.MoveAndResize(new Windows.Graphics.RectInt32(0, 0, 1920, 1080));
                window.Title = title;
                window.Activate();
                frame.Navigate(pagename, null, new EntranceNavigationTransitionInfo());
            }
        }

    }
}
