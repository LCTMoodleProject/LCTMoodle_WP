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
    public partial class view_DangNhap : PhoneApplicationPage
    {
        public viewmodel_DangNhap vm_dangNhap { get; set; }
        public view_DangNhap()
        {
            InitializeComponent();
            vm_dangNhap = new viewmodel_DangNhap();
            this.DataContext = vm_dangNhap;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            login_Animation.Begin();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            vm_dangNhap = new viewmodel_DangNhap();
            this.DataContext = vm_dangNhap;
        }
    }
}