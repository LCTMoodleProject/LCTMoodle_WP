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
using Microsoft.Phone.Scheduler;

namespace ViewModel
{
    public class viewmodel_NhacNho : ViewModelBase
    {
        #region đối tượng
        public model_NhacNho m_NhacNho {get; set; }

        private string _BaoThucVisible;

        public string BaoThucVisible
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
        private string _TatBaoThucVisible;

        public string TatBaoThucVisible
        {
            get
            {
                return _TatBaoThucVisible;
            }
            set
            {
                _TatBaoThucVisible = value;
                RaisePropertyChanged("TatBaoThucVisible");
            }
        }

        private string _GioBaoThuc;
        public string GioBaoThuc
        {
            get
            {
                return _GioBaoThuc;
            }
            set
            {
                _GioBaoThuc = value;
                RaisePropertyChanged("GioBaoThuc");
            }
        }

        private string _NgayBaoThuc;
        public string NgayBaoThuc
        {
            get
            {
                return _NgayBaoThuc;
            }
            set
            {
                _NgayBaoThuc = value;
                RaisePropertyChanged("NgayBaoThuc");
            }
        }
        #endregion
        public viewmodel_NhacNho()
        {
            m_NhacNho = new model_NhacNho();
            CaiDatThuocTinh();
            _NhacNhoCommand = new RelayCommand(() =>
            {
                DateTime dt = m_NhacNho.NgayNhacNho.Date + m_NhacNho.GioNhacNho.TimeOfDay;
                if (dt < DateTime.Now)
                {
                    MessageBox.Show("Thời gian không đúng");
                }
                else if (string.IsNullOrEmpty(m_NhacNho.NoiDung))
                    MessageBox.Show("Chưa nhập nội dung");
                else
                {
                    helper_NhacNho.DatNhacNho(m_NhacNho.NgayNhacNho, m_NhacNho.GioNhacNho, m_NhacNho.NoiDung);
                    MessageBox.Show("Đã đặt nhắc nhở");
                    CaiDatThuocTinh();
                }
            });
            _DatLaiCommand = new RelayCommand(() =>
            {
                helper_NhacNho.BoNhacNho();
                MessageBox.Show("Đã bỏ nhắc nhở");
                CaiDatThuocTinh();
            });
        }
        #region Hàm
        /// <summary>
        /// Ẩn và hiện form đặt nhắc nhở hoặc tắt nhắc nhở, đặt thời gian hiển thị cho các control picker (ngày và giờ)
        /// </summary>
        public void CaiDatThuocTinh()
        {
            if(helper_NhacNho.KiemTraThoiGianNhacNho().TimeOfDay <= DateTime.Now.TimeOfDay)
            {
                TatBaoThucVisible = "Collapsed";
                BaoThucVisible = "Visible";
                m_NhacNho.NgayNhacNho = DateTime.Now;
                m_NhacNho.GioNhacNho = DateTime.Now;
            }
            else
            {
                TatBaoThucVisible = "Visible";
                BaoThucVisible = "Collapsed";
                GioBaoThuc = helper_NhacNho.KiemTraThoiGianNhacNho().TimeOfDay.ToString();
                NgayBaoThuc = helper_NhacNho.KiemTraThoiGianNhacNho().DayOfWeek.ToString() + ", " + helper_NhacNho.KiemTraThoiGianNhacNho().Date.ToString("dd/MM/yyyy");
            }
        }
        #endregion
        #region Command
        private RelayCommand _NhacNhoCommand;
        public RelayCommand NhacNhoCommand
        {
            get
            {
                return _NhacNhoCommand;
            }
        }
        private RelayCommand _DatLaiCommand;
        public RelayCommand DatLaiCommand
        {
            get
            {
                return _DatLaiCommand;
            }
        }
        #endregion
    }
}
