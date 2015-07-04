using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class model_KhoaHoc : ModelBase
    {
        private int _Ma;
        private string _Ten;
        private string _MoTa;
        private byte[] _HinhAnh;
        private string _ThongKeKhoaHocCon;
        private int _Loai;

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

        public string Ten
        {
            get
            {
                return _Ten;
            }
            set
            {
                _Ten = value;
            }
        }

        public string MoTa
        {
            get
            {
                return _MoTa;
            }
            set
            {
                _MoTa = value;
                RaisePropertyChanged("MoTa");
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

        public string ThongKeKhoaHocCon
        {
            get
            {
                return _ThongKeKhoaHocCon;
            }
            set
            {
                _ThongKeKhoaHocCon = value;
                RaisePropertyChanged("SoKhoaHocCon");
            }
        }

        public int Loai
        {
            get
            {
                return _Loai;
            }
            set
            {
                _Loai = value;
                RaisePropertyChanged("Loai");
            }
        }
    }
}
