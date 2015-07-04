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
using System.Windows.Media.Imaging;

namespace ViewModel
{
    public class viewmodel_Captcha : ViewModelBase
    {
        public model_Captcha m_Captcha { get; set; }
        #region Contructor
        public viewmodel_Captcha()
        {
            TaoCaptcha();
            _CaptchaCommand = new RelayCommand(() =>
            {
                if (m_Captcha.MaCaptchaKhach == "" || m_Captcha.MaCaptchaKhach == null)
                {
                    MessageBox.Show("Chưa nhập mã");
                    TaoMoi();
                }
                else
                {
                    if (m_Captcha.MaCaptchaKhach == m_Captcha.MaCaptcha)
                    {
                        helper_Navigation h_Navigation = new helper_Navigation();
                        h_Navigation.NavigateTo(new Uri("/view_DangNhap.xaml", UriKind.Relative));
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã nhập sai");
                        TaoMoi();
                    }
                }
            });
            _CaptchaTaoMoi = new RelayCommand(() =>
            {
                TaoMoi();
            });

        }
        #endregion
        #region Hàm
        public void TaoCaptcha()
        {
            m_Captcha = new model_Captcha();
            helper_Captcha.LayChuoiNgauNhien();
            m_Captcha.MaCaptcha = helper_Captcha._strCaptcha;
            m_Captcha.ImageCap = helper_Captcha.drawImage();
            m_Captcha.MaCaptchaKhach = "";
        }
        public void TaoMoi()
        {
            helper_Captcha.LayChuoiNgauNhien();
            m_Captcha.MaCaptcha = helper_Captcha._strCaptcha;
            m_Captcha.ImageCap = helper_Captcha.drawImage();
            m_Captcha.MaCaptchaKhach = "";
        }
        #endregion
        #region Command

        private RelayCommand _CaptchaCommand;

        public RelayCommand CaptchaCommand
        {
            get
            {
                return _CaptchaCommand;
            }
        }

        private RelayCommand _CaptchaTaoMoi;
        public RelayCommand CaptchaTaoMoi
        {
            get
            {
                return _CaptchaTaoMoi;
            }
        }

        #endregion

    }
}
