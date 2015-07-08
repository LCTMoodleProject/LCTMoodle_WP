using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ViewModel;

namespace LCTMoodle
{
    public partial class view_TimKiem : PhoneApplicationPage
    {
        public viewmodel_TimKiem vm_TimKiem { get; set; }
        public view_TimKiem()
        {
            InitializeComponent();
            vm_TimKiem = new viewmodel_TimKiem();
            this.DataContext = vm_TimKiem;
        }
    }
}