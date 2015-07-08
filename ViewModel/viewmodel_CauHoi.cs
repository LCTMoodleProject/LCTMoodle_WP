using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using Helper;

namespace ViewModel
{
    public class viewmodel_CauHoi : ViewModelBase
    {
        public ObservableCollection<model_CauHoi> lst_CauHoi { get; set; }

        private model_CauHoi _CauHoiSelected;

        public model_CauHoi CauHoiSelected
        {
            get
            {
                return _CauHoiSelected;
            }
            set
            {
                string DuongDan = "/view_CauHoi_ChiTiet.xaml?ma=" + value.Ma;
                helper_Navigation h_Navigation = new helper_Navigation();
                h_Navigation.NavigateTo(new Uri(DuongDan, UriKind.Relative));
                _CauHoiSelected = value;
                RaisePropertyChanged("CauHoiSelected");
            }
        }

        public bool _HoanThanh;

        private int _DemCauHoi;

        public viewmodel_CauHoi()
        {
            lst_CauHoi = new ObservableCollection<model_CauHoi>();
            layDanhSachCauHoi(20);
            _LamMoiCommand = new RelayCommand(() =>
            {
                lamMoi();
            });
        }

        private RelayCommand _LamMoiCommand;
        public RelayCommand LamMoiCommand
        {
            get
            {
                return _LamMoiCommand;
            }
        }

        public void lamMoi()
        {
            lst_CauHoi = new ObservableCollection<model_CauHoi>();
            layDanhSachCauHoi(2);
            RaisePropertyChanged("lst_CauHoi");
        }

        DispatcherTimer timer;

        public void layDanhSachCauHoi(int SoCauHoi)
        {
            ws_LayCauHoi(SoCauHoi);
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Start();
            timer.Tick += (s, e) =>
                {
                    if (_HoanThanh)
                    {
                        RaisePropertyChanged("lst_CauHoi");
                        timer.Stop();
                    }
                };
        }

        #region Webservice

        /// <summary>
        /// Hàm lấy danh sách câu hỏi từ wcf_CauHoi
        /// </summary>
        public void ws_LayCauHoi(int SoCauHoi)
        {
            wcf_CauHoi.Iwcf_CauHoiClient client_CauHoi = new wcf_CauHoi.Iwcf_CauHoiClient();
            client_CauHoi.layAsync(SoCauHoi);
            client_CauHoi.layCompleted += (s, e) =>
            {
                if (e.Result.Count != 0)
                {
                    foreach (var cauHoi in e.Result)
                    {
                        lst_CauHoi.Add(new model_CauHoi()
                        {
                            Ma = cauHoi.Ma,
                            TieuDe = cauHoi.TieuDe,
                            NoiDung = cauHoi.NoiDung,
                            NguoiTao = cauHoi.NguoiTao,
                            SoTraLoi = cauHoi.SoTraLoi,
                        });

                        ws_LayAnhCauHoi(lst_CauHoi.Count - 1, cauHoi.HinhAnh);
                    }
                }
                else
                {
                    _HoanThanh = true;
                }
            };
        }

        /// <summary>
        /// Hàm lấy hình ảnh và chỉ số từ wcf_CauHoi
        /// </summary>
        /// <param name="_ChiSo"></param>
        /// <param name="_Ten"></param>
        public void ws_LayAnhCauHoi(int _ChiSo, string _Ten)
        {
            wcf_CauHoi.Iwcf_CauHoiClient client_CauHoi = new wcf_CauHoi.Iwcf_CauHoiClient();
            client_CauHoi.layHinhAnhChiSoAsync(_ChiSo, _Ten);
            client_CauHoi.layHinhAnhChiSoCompleted += (s, e) =>
                {
                    if (e.Result._HinhAnh != null)
                    {
                        lst_CauHoi[e.Result._ChiSo].HinhAnh = e.Result._HinhAnh;
                    }
                    else
                    {
                        lst_CauHoi[e.Result._ChiSo].HinhAnh = helper_HinhAnh.layHinhMacDinh_NguoiDung();
                    }

                    _DemCauHoi++;

                    if(_DemCauHoi == lst_CauHoi.Count)
                    {
                        _HoanThanh = true;
                    }
                };
        }

        #endregion
    }
}
