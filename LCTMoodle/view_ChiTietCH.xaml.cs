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

namespace LCTMoodle
{
    public partial class view_ChiTietCH : PhoneApplicationPage
    {
        public view_ChiTietCH()
        {
            InitializeComponent();
        }

        //private txt_CauTraLoi = new InputPrompt();
        //private void btn_TraLoi_Click(object sender, RoutedEventArgs e)
        //{
        //    //var txt_CauTraLoi = new InputPrompt();
        //    txt_CauTraLoi.Completed += txt_CauTraLoi_Completed;
        //    txt_CauTraLoi.Title = "Trả lời";
        //    txt_CauTraLoi.Message = "Câu trả lời của bạn sẽ được kiểm duyệt";
        //    txt_CauTraLoi.Show();
        //}

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