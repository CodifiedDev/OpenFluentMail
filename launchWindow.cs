using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;

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

        public static void OpenPage(Window window, String title, Type pagename, Frame frame)
        {
            if (window == null)
            {
                window = new Window();
            }
            if (frame == null)
            {
                Frame newframe = new Frame();
                window.AppWindow.MoveAndResize(new Windows.Graphics.RectInt32(0, 0, 1920, 1080));
                window.Content = newframe;
                window.Title = title;
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
