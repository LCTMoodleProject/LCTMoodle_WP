using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class model_TimKiem : ModelBase
    {
        private string _TieuDe;
        private string _NguoiTao;
        private byte[] _HinhDaiDien;

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

        public byte[] HinhDaiDien
        {
            get
            {
                return _HinhDaiDien;
            }
            set
            {
                _HinhDaiDien = value;
                RaisePropertyChanged("HinhDaiDien");
            }
        }
    }
}
