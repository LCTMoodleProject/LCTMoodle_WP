using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class model_CauHoi : ModelBase
    {
        private int _Ma;
        private string _TieuDe;
        private string _NoiDung;
        private string _NguoiTao;
        private int _SoTraLoi;
        private string _ThoiGianTao;
        private bool _Duyet;
        private byte[] _HinhAnh;

        public int Ma
        {
            get
            {
                return _Ma;
            }
            set
            {
                _Ma = value;
                RaisePropertyChanged("Ma");
            }
        }

        public string TieuDe
        {
            get
            {
                return _TieuDe;
            }
            set
            {
                _TieuDe = value;
                RaisePropertyChanged("TieuDe");
            }
        }

        public string NoiDung
        {
            get
            {
                return _NoiDung;
            }
            set
            {
                _NoiDung = value;
                RaisePropertyChanged("NoiDung");
            }
        }

        public string NguoiTao
        {
            get
            {
                return _NguoiTao;
            }
            set
            {
                _NguoiTao = value;
                RaisePropertyChanged("NguoiTao");
            }
        }

        public bool Duyet
        {
            get
            {
                return _Duyet;
            }
            set
            {
                _Duyet = value;
                RaisePropertyChanged("Duyet");
            }
        }

        public int SoTraLoi
        {
            get
            {
                return _SoTraLoi;
            }
            set
            {
                _SoTraLoi = value;
                RaisePropertyChanged("SoTraLoi");
            }
        }

        public string ThoiGianTao
        { 
            get
            {
                return _ThoiGianTao;
            }
            set
            {
                _ThoiGianTao = value;
                RaisePropertyChanged("ThoiGianTao");
            }
        }

        public byte[] HinhAnh
        {
            get
            {
                return _HinhAnh;
            }
            set
            {
                _HinhAnh = value;
                RaisePropertyChanged("HinhAnh");
            }
        }
    }
}
