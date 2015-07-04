using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.ServiceModel;
using ViewModel;

namespace LCTMoodle
{
    public partial class view_TrangChu : PhoneApplicationPage
    {
        public viewmodel_TrangChu vm_TrangChu { get; set; }
        public view_TrangChu()
        {
            InitializeComponent();

            vm_TrangChu = new viewmodel_TrangChu();
            this.DataContext = vm_TrangChu;

            //sự kiện cho form info
            lst_KhoaHocThamGia.Visibility = Visibility.Collapsed;
            btn_XemKhoaHoc.Visibility = Visibility.Collapsed;

            lst_CauHoiCuaToi.Visibility = Visibility.Collapsed;
            btn_XemCauHoi.Visibility = Visibility.Collapsed;
        }
        #region Xử lý trang chủ
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            txtHeader.Text = "Trang Chủ";
        }
        private void ImageBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbiTrangChu.IsSelected)
            {
                txtHeader.Text = "Trang Chủ";
            }
            if (lbiHoiDap.IsSelected)
            {
                txtHeader.Text = "Hỏi Đáp";
            }
            if (lbiKhoaHoc.IsSelected)
            {
                txtHeader.Text = "Khóa Học";
            }
            if (lbiThongTin.IsSelected)
            {
                txtHeader.Text = "Thông Tin";
            }
        }
        #endregion
        #region Xử lý form Info

        private void lst_KhoaHocThamGia_Click(object sender, RoutedEventArgs e)
        {
            if(lst_KhoaHocThamGia.Visibility == Visibility.Visible)
            {
                lst_KhoaHocThamGia.Visibility = Visibility.Collapsed;
                btn_XemKhoaHoc.Visibility = Visibility.Collapsed;
            }
            else
            { 
                lst_KhoaHocThamGia.Visibility = Visibility.Visible;
                btn_XemKhoaHoc.Visibility = Visibility.Visible;
            }
        }

        private void btn_lst1_1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void lst_CauHoiCuaToi_Click(object sender, RoutedEventArgs e)
        {
            if (lst_CauHoiCuaToi.Visibility == Visibility.Visible)
            {
                lst_CauHoiCuaToi.Visibility = Visibility.Collapsed;
                btn_XemCauHoi.Visibility = Visibility.Collapsed;
            }
            else
            {
                lst_CauHoiCuaToi.Visibility = Visibility.Visible;
                btn_XemCauHoi.Visibility = Visibility.Visible;
            }
        }

        private void btn_XemKhoaHoc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view_XemTatCaKH.xaml", UriKind.Relative));
        }
        #endregion

        private void bar_VietBai_Click(object sender, EventArgs e)
        {

        }

        private void abr_TimKiem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/view_TimKiem.xaml", UriKind.Relative));
        }

        private void abr_DatCauHoi_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/view_DatCauHoi.xaml", UriKind.Relative));
        }

        private void abr_CaiDat_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/view_CaiDat.xaml", UriKind.Relative));
        }

        private void abr_XemTKB_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/view_ThoiKhoaBieu.xaml", UriKind.Relative));
        }
    }
}