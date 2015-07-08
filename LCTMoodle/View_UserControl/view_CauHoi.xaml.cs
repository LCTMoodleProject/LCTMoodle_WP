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

namespace LCTMoodle.View_UserControl
{
    public partial class view_CauHoi : UserControl
    {
        public viewmodel_CauHoi vm_CauHoi { get; set; }
        public view_CauHoi()
        {
            InitializeComponent();
            vm_CauHoi = new viewmodel_CauHoi();
            this.DataContext = vm_CauHoi;
        }

        

    }
}
