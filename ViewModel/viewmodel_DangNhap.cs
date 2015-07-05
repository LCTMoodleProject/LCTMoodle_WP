using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model;
using Helper;

namespace ViewModel
{
    public class viewmodel_DangNhap : ViewModelBase
    {
        public model_DangNhap m_DangNhap { get; set; }
        private int i_NhapSai = 0;

        #region Constructor

        public viewmodel_DangNhap()
        {
            //KiemTraCaptcha();
            m_DangNhap = new model_DangNhap();
            _DangNhapCommand = new RelayCommand(() =>
            {
                if(m_DangNhap.TenDN == "" || m_DangNhap.TenDN == null)
                {
                    MessageBox.Show("Tên đăng nhập trống");
                }
                else
                {
                    if(m_DangNhap.MatKhau == "" || m_DangNhap.MatKhau == null)
                    {
                        MessageBox.Show("Mật khẩu trống");
                    }
                    else
                    {
                        ws_KiemTraDangNhap(m_DangNhap.TenDN, m_DangNhap.MatKhau);
                    }
                }
            });
        }
        public void XuLyNhapSai(int i_DonViSai)
        {
            if(helper_DangNhap.KiemTraSoLanNhapSai(i_DonViSai) == false)
            {
                helper_DangNhap.GhiFileDangNhap(i_DonViSai);
                helper_Navigation h_Navigation = new helper_Navigation();
                h_Navigation.NavigateTo(new Uri("/view_Captcha.xaml", UriKind.Relative));
            }
        }
        //public void KiemTraCaptcha()
        //{
        //    if(helper_DangNhap.DocFileDangNhap() != "")
        //    {
        //        helper_Navigation h_Navigation = new helper_Navigation();
        //        h_Navigation.NavigateTo(new Uri("/view_Captcha.xaml", UriKind.Relative));
        //    }
        //}
        #endregion

        #region Command

        private RelayCommand _DangNhapCommand;

        public RelayCommand DangNhapCommand
        {
            get
            {
                return _DangNhapCommand;
            }
        }

        #endregion

        #region Webservice

        /// <summary>
        /// Hàm kiểm tra đăng nhập từ wcf_NguoiDung
        /// </summary>
        /// <param name="_TenDN"></param>
        /// <param name="_MatKhau"></param>
        public void ws_KiemTraDangNhap(string _TenDN,string _MatKhau)
        {
            wcf_NguoiDung.Iwcf_NguoiDungClient client_NguoiDung = new wcf_NguoiDung.Iwcf_NguoiDungClient();
            client_NguoiDung.kiemTraDangNhapAsync(_TenDN, _MatKhau);
            client_NguoiDung.kiemTraDangNhapCompleted += (s, e) =>
                {
                    switch (e.Result)
                    {
                        case 1:
                            {
                                MessageBox.Show("Tên đăng nhập không tồn tại");
                                i_NhapSai += 1;
                                XuLyNhapSai(i_NhapSai);
                                break;
                            }
                        case 2:
                            {
                                MessageBox.Show("Mật khẩu không chính xác");
                                i_NhapSai += 1;
                                XuLyNhapSai(i_NhapSai);
                                break;
                            }
                        case 3:
                            {
                                helper_Navigation h_Navigation = new helper_Navigation();
                                h_Navigation.NavigateTo(new Uri("/view_TrangChu.xaml", UriKind.Relative));
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Đăng nhập không thành công");
                                break;
                            }
                    }
                };
        }

        #endregion
    }
}
