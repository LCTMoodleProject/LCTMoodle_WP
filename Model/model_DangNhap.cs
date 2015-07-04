using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class model_DangNhap : ModelBase
    {
        private string _TenDN;
        private string _MatKhau;

        public string TenDN
        {
            get
            {
                return _TenDN;
            }
            set
            {
                _TenDN = value;
                RaisePropertyChanged("TenDN");
            }
        }

        public string MatKhau
        {
            get
            {
                return _MatKhau;
            }
            set
            {
                _MatKhau = value;
                RaisePropertyChanged("MatKhau");
            }
        }
    }
}
