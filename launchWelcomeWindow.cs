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
    internal class launchWelcomeWindow
    {
        private static Window m_window = new Window();
        public static void LaunchWelcomeWindow()
        {
            Frame rootFrame = new Frame();
            m_window.Content = rootFrame;
            m_window.Title = "Welcome to OpenFluentMail";
            m_window.Activate();
            rootFrame.Navigate(typeof(welcomePage), null, new EntranceNavigationTransitionInfo());
        }
    }
}
