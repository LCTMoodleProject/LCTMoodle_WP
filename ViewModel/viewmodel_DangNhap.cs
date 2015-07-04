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

        #region Constructor

        public viewmodel_DangNhap()
        {
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
                                break;
                            }
                        case 2:
                            {
                                MessageBox.Show("Mật khẩu không chính xác");
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
