using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork4Test
{
    internal class SupportClass
    {
        public static void NavigateFrame(string pagePath)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).FrameMain.NavigationService.Navigate(new Uri(pagePath, UriKind.Relative));
                }
            }
        }

        public static void NavigateFrameBack()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).FrameMain.NavigationService.GoBack();
                }
            }
        }
    }
}
