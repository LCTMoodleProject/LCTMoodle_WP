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
    public partial class view_NhacNho : PhoneApplicationPage
    {
        public viewmodel_NhacNho vm_NhacNho { get; set; }
        public view_NhacNho()
        {
            InitializeComponent();
            vm_NhacNho = new viewmodel_NhacNho();
            this.DataContext = vm_NhacNho;
        }

    }
}