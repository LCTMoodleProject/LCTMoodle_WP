using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class model_NhacNho : ModelBase
    {
        private DateTime _NgayNhacNho;
        private DateTime _GioNhacNho;
        private string _NoiDung;

        public DateTime NgayNhacNho
        {
            get
            {
                return _NgayNhacNho;
            }
            set
            {
                _NgayNhacNho = value;
                RaisePropertyChanged("NgayNhacNho");
            }
        }
        public DateTime GioNhacNho
        {
            get
            {
                return _GioNhacNho;
            }
            set
            {
                _GioNhacNho = value;
                RaisePropertyChanged("GioNhacNho");
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
                RaisePropertyChanged("_NoiDung");
            }
        }
    }
}
