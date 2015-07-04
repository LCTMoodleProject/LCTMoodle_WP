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
    public partial class view_KhoaHoc : UserControl
    {
        public viewmodel_KhoaHoc vm_KhoaHoc;
        public view_KhoaHoc()
        {
            InitializeComponent();
            vm_KhoaHoc = new viewmodel_KhoaHoc();
            this.DataContext = vm_KhoaHoc;
        }
    }
}
