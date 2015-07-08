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
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class viewmodel_TimKiem : ViewModelBase
    {
        public ObservableCollection<model_TimKiem> lst_KetQuaTim { get; set; }
        private string _TuKhoa;

        public string TuKhoa
        {
            get
            {
                return _TuKhoa;
            }
            set
            {
                _TuKhoa = value;
                RaisePropertyChanged("TuKhoa");
            }
        }

        public viewmodel_TimKiem()
        {
            lst_KetQuaTim = new ObservableCollection<model_TimKiem>();
            _TimKiemKhoaHocCommand = new RelayCommand(() =>
            {
                lst_KetQuaTim = new ObservableCollection<model_TimKiem>();
                ws_TimKiemKhoaHoc(_TuKhoa);
                RaisePropertyChanged("lst_KetQuaTim");
            });
            _TimKiemCauHoiCommand = new RelayCommand(() =>
            {
                lst_KetQuaTim = new ObservableCollection<model_TimKiem>();
                ws_TimKiemCauHoi(_TuKhoa);
                RaisePropertyChanged("lst_KetQuaTim");
            });
        }

        public void RemoveItem(ObservableCollection<model_TimKiem> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                collection.RemoveAt(i);
            }
        }
        public void ws_TimKiemKhoaHoc(string _Text)
        {
            wcf_KhoaHoc.Iwcf_KhoaHocClient client_NguoiDung = new wcf_KhoaHoc.Iwcf_KhoaHocClient();
            client_NguoiDung.timKiemAsync(_Text);
            client_NguoiDung.timKiemCompleted += (s, e) =>
                {
                    if (e.Result.Count != 0)
                    {
                        foreach (var timKiem in e.Result)
                        {
                            lst_KetQuaTim.Add(new model_TimKiem()
                            {
                                TieuDe = timKiem.ten,
                                NguoiTao = timKiem.nguoiTao.ten,
                            });

                            //ws_LayAnhKhoaHoc(lst_KetQuaTim.Count - 1, timKiem.hinhDaiDien.ma + timKiem.hinhDaiDien.duoi);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có kết quả được tìm thấy");
                    }
                };
        }
        public void ws_TimKiemCauHoi(string _Text)
        {
            wcf_CauHoi.Iwcf_CauHoiClient client_NguoiDung = new wcf_CauHoi.Iwcf_CauHoiClient();
            client_NguoiDung.timKiemAsync(_Text);
            client_NguoiDung.timKiemCompleted += (s, e) =>
            {
                if (e.Result.Count != 0)
                {
                    foreach (var timKiem in e.Result)
                    {
                        lst_KetQuaTim.Add(new model_TimKiem()
                        {
                            //TieuDe = timKiem.TieuDe,
                            //NguoiTao = timKiem.NguoiTao,
                        });

                        //ws_LayAnhKhoaHoc(lst_KetQuaTim.Count - 1, timKiem.hinhDaiDien.ma + timKiem.hinhDaiDien.duoi);
                    }
                }
                else
                {
                    MessageBox.Show("Không có kết quả được tìm thấy");
                }
            };
        }
        private RelayCommand _TimKiemKhoaHocCommand;
        public RelayCommand TimKiemKhoaHocCommand
        {
            get
            {
                return _TimKiemKhoaHocCommand;
            }
        }
        private RelayCommand _TimKiemCauHoiCommand;
        public RelayCommand TimKiemCauHoiCommand
        {
            get
            {
                return _TimKiemCauHoiCommand;
            }
        }
    }
}
