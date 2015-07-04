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
                //RaisePropertyChanged("selectedIndex");
            }
        }

        public viewmodel_TrangChu()
        {
            TaiLaiVisible = true;
            TimKiemVisible = true;
            ThemVisible = false;
            CaiDatVisible = true;
            BaoThucVisible = false;
            TaiKhoanVisible = false;
            TinNhanVisible = false;
        }

        /// <summary>
        /// Hàm xử lý hiển thị button trên app bar tại view_TrangChu
        /// </summary>
        /// <param name="_selectedIndex"></param>
        public void XuLyThayDoiTrang(int _selectedIndex)
        {
            TaiLaiVisible = false;
            TimKiemVisible = false;
            ThemVisible = false;
            CaiDatVisible = false;
            BaoThucVisible = false;
            TaiKhoanVisible = false;
            TinNhanVisible = false;

            switch(_selectedIndex)
            {
                case 0:
                    {
                        TaiLaiVisible = true;
                        TimKiemVisible = true;
                        CaiDatVisible = true;
                        break;
                    }
                case 1:
                    {
                        TaiLaiVisible = true;
                        TimKiemVisible = true;
                        ThemVisible = true;
                        break;
                    }
                case 2:
                    {
                        TaiLaiVisible = true;
                        TimKiemVisible = true;
                        ThemVisible = true;
                        break;
                    }
                case 3:
                    {
                        TaiKhoanVisible = true;
                        TaiKhoanVisible = true;
                        BaoThucVisible = true;
                        TaiLaiVisible = true;
                        break;
                    }
            }
        }


        #region thuộc tính appbar
        private bool _TaiLaiVisible;
        private bool _TimKiemVisible;
        private bool _ThemVisible;
        private bool _CaiDatVisible;
        private bool _BaoThucVisible;
        private bool _TaiKhoanVisible;
        private bool _TinNhanVisible;

        public bool TaiLaiVisible
        {
            get
            {
                return _TaiLaiVisible;
            }
            set
            {
                _TaiLaiVisible = value;
                RaisePropertyChanged("TaiLaiVisible");
            }
        }

        public bool TimKiemVisible
        {
            get
            {
                return _TimKiemVisible;
            }
            set
            {
                _TimKiemVisible = value;
                RaisePropertyChanged("TimKiemVisible");
            }
        }

        public bool ThemVisible
        {
            get
            {
                return _ThemVisible;
            }
            set
            {
                _ThemVisible = value;
                RaisePropertyChanged("ThemVisible");
            }
        }

        public bool CaiDatVisible
        {
            get
            {
                return _CaiDatVisible;
            }
            set
            {
                _CaiDatVisible = value;
                RaisePropertyChanged("CaiDatVisible");
            }
        }

        public bool BaoThucVisible
        {
            get
            {
                return _BaoThucVisible;
            }
            set
            {
                _BaoThucVisible = value;
                RaisePropertyChanged("BaoThucVisible");
            }
        }

        public bool TaiKhoanVisible
        {
            get
            {
                return _TaiKhoanVisible;
            }
            set
            {
                _TaiKhoanVisible = value;
                RaisePropertyChanged("TaiKhoanVisible");
            }
        }

        public bool TinNhanVisible
        {
            get
            {
                return _TinNhanVisible;
            }
            set
            {
                _TinNhanVisible = value;
                RaisePropertyChanged("TinNhanVisible");
            }
        }

        #endregion
    }
}
