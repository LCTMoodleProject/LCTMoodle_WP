using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Model
{
    public class model_Captcha : ModelBase
    {
        private string _MaCaptcha;
        private string _MaCaptchaKhach;
        private byte[] _ImageCap;

        public string MaCaptcha
        {
            get
            {
                return _MaCaptcha;
            }
            set
            {
                _MaCaptcha = value;
                RaisePropertyChanged("MaCaptcha");
            }
        }
        public string MaCaptchaKhach
        {
            get
            {
                return _MaCaptchaKhach;
            }
            set
            {
                _MaCaptchaKhach = value;
                RaisePropertyChanged("MaCaptchaKhach");
            }
        }

        public byte[] ImageCap
        {
            get
            {
                return _ImageCap;
            }
            set
            {
                _ImageCap = value;
                RaisePropertyChanged("ImageCap");
            }
        }
    }
}

