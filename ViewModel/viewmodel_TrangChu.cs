using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model;

namespace ViewModel
{
    public class viewmodel_TrangChu : ViewModelBase
    {
        private int _selectedIndex;

        public int selectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                XuLyThayDoiTrang(value);
                RaisePropertyChanged("M_TrangChu");
            }
        }

        public viewmodel_TrangChu()
        {
            TimKiem = true;
            Them = false;
            Xoa = false;
            Sua = false;
        }

        /// <summary>
        /// Hàm xử lý hiển thị button trên app bar tại view_TrangChu
        /// </summary>
        /// <param name="_selectedIndex"></param>
        public void XuLyThayDoiTrang(int _selectedIndex)
        {
            TimKiem = false;
            Them = false;
            Xoa = false;
            Sua = false;

            switch(_selectedIndex)
            {
                case 0:
                    {
                        TimKiem = true;
                        break;
                    }
                case 1:
                    {
                        TimKiem = true;
                        Them = true;
                        Xoa = true;
                        Sua = true;
                        break;
                    }
                case 2:
                    {
                        TimKiem = true;
                        Them = true;
                        Xoa = true;
                        Sua = true;
                        break;
                    }
                case 3:
                    {
                        TimKiem = true;
                        break;
                    }
            }
        }


        #region thuộc tính appbar
        private bool _TimKiem;
        private bool _Them;
        private bool _Xoa;
        private bool _Sua;

        public bool TimKiem
        {
            get
            {
                return _TimKiem;
            }
            set
            {
                _TimKiem = value;
                RaisePropertyChanged("TimKiem");
            }
        }

        public bool Them
        {
            get
            {
                return _Them;
            }
            set
            {
                _Them = value;
                RaisePropertyChanged("Them");
            }
        }

        public bool Xoa
        {
            get
            {
                return _Xoa;
            }
            set
            {
                _Xoa = value;
                RaisePropertyChanged("Xoa");
            }
        }

        public bool Sua
        {
            get
            {
                return _Sua;
            }
            set
            {
                _Sua = value;
                RaisePropertyChanged("Sua");
            }
        }
        #endregion
    }
}
