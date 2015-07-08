using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Coding4Fun.Toolkit.Controls;
using ViewModel;

namespace LCTMoodle
{
    public partial class view_ChiTietCH : PhoneApplicationPage
    {
        public viewmodel_CauHoi_ChiTiet vm_CauHoi_ChiTiet { get; set; }
        public view_ChiTietCH()
        {
            InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            int MaCauHoi = Int32.Parse(NavigationContext.QueryString["ma"]);
            vm_CauHoi_ChiTiet = new viewmodel_CauHoi_ChiTiet(MaCauHoi);
            this.DataContext = vm_CauHoi_ChiTiet;
        }

        void txt_CauTraLoi_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            MessageBox.Show("Bạn đã trả lời xong");
        }

        private void btn_TraLoi_Click(object sender, RoutedEventArgs e)
        {
            gid_bao.IsHitTestVisible = false;
            gid_bao.Opacity = 0.5;
            popup.Visibility = Visibility.Visible;
            popup.Completed += popup_Completed;
        }

        void popup_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            //string chuoi = e.Result;
            popup.Visibility = Visibility.Collapsed;
            gid_bao.IsHitTestVisible = true;
            gid_bao.Opacity = 1;
            //MessageBox.Show(chuoi);
        }
    }
}