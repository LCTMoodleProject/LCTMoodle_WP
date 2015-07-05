using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Animation;

namespace LCTMoodle
{
    public partial class view_ChiTietKH : PhoneApplicationPage
    {
        public view_ChiTietKH()
        {
            InitializeComponent();
        }
        private void OpenClose_Right(object sender, RoutedEventArgs e)
        {
            var left = Canvas.GetLeft(LayoutRoot);
            if (left > -300)
            {
                //ApplicationBar.IsVisible = false;
                MoveViewWindow(-300);
            }
            else
            {
                //ApplicationBar.IsVisible = true;
                MoveViewWindow(0);

            }
        }
        void MoveViewWindow(double left)
        {
            //if (left == -420)
            //    ApplicationBar.IsVisible = true;
            //else
            //    ApplicationBar.IsVisible = false;
            ((Storyboard)canvas.Resources["moveAnimation"]).SkipToFill();
            ((DoubleAnimation)((Storyboard)canvas.Resources["moveAnimation"]).Children[0]).To = left;
            ((Storyboard)canvas.Resources["moveAnimation"]).Begin();
        }

        private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}