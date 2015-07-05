using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using ViewModel;

namespace LCTMoodle
{
    public partial class view_Captcha : PhoneApplicationPage
    {
        public viewmodel_Captcha vm_Captcha { get; set; }
        public view_Captcha()
        {
            InitializeComponent();
            vm_Captcha = new viewmodel_Captcha();
            this.DataContext = vm_Captcha;
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            vm_Captcha = new viewmodel_Captcha();
            this.DataContext = vm_Captcha;
        }
    }
}