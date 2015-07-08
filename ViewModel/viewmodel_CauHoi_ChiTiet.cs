using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.ObjectModel;
using Helper;

namespace ViewModel
{
    public class viewmodel_CauHoi_ChiTiet : ViewModelBase
    {
        public model_CauHoi m_CauHoi { get; set; }

        public ObservableCollection<model_CauHoi> lst_TraLoi { get; set; }

        public viewmodel_CauHoi_ChiTiet(int Ma)
        {
            m_CauHoi = new model_CauHoi();
            lst_TraLoi = new ObservableCollection<model_CauHoi>();
            ws_LayCauHoiTheoMa(Ma);
            ws_LayDanhSachTraLoi(Ma);
        }

        public void ws_LayCauHoiTheoMa(int Ma)
        {
            wcf_CauHoi.Iwcf_CauHoiClient client_CauHoi = new wcf_CauHoi.Iwcf_CauHoiClient();
            client_CauHoi.layTheoMaAsync(Ma);
            client_CauHoi.layTheoMaCompleted += (s, e) =>
                {
                    if (e.Result != null)
                    {
                        m_CauHoi.NguoiTao = e.Result.nguoiTao.ten;
                        m_CauHoi.NoiDung = e.Result.noiDung;
                        m_CauHoi.ThoiGianTao = e.Result.thoiDiemTao.Value.ToString();
                    }

                    ws_LayAnhCauHoi(e.Result.nguoiTao.hinhDaiDien.ma + e.Result.nguoiTao.hinhDaiDien.duoi);
                };
        }

        public void ws_LayAnhCauHoi(string Ten)
        {
            wcf_CauHoi.Iwcf_CauHoiClient client_CauHoi = new wcf_CauHoi.Iwcf_CauHoiClient();
            client_CauHoi.layHinhAnhAsync(Ten);
            client_CauHoi.layHinhAnhCompleted += (s, e) =>
                {
                    if (e.Result != null)
                    {
                        m_CauHoi.HinhAnh = e.Result;
                    }
                    else
                    {
                        m_CauHoi.HinhAnh = helper_HinhAnh.layHinhMacDinh_NguoiDung();
                    }
                };
        }

        public void ws_LayDanhSachTraLoi(int Ma)
        {
            wcf_CauHoi.Iwcf_CauHoiClient client_CauHoi = new wcf_CauHoi.Iwcf_CauHoiClient();
            client_CauHoi.layTraLoiTheoMaCauHoiAsync(Ma);
            client_CauHoi.layTraLoiTheoMaCauHoiCompleted += (s, e) =>
                {
                    if(e.Result.Count != 0)
                    {
                        foreach(var traLoi in e.Result)
                        {
                            lst_TraLoi.Add(new model_CauHoi()
                            {
                                Ma = traLoi.ma.Value,
                                NguoiTao = traLoi.nguoiTao.ten,
                                NoiDung = traLoi.noiDung,
                                ThoiGianTao = traLoi.thoiDiemTao.Value.ToString(),
                            });

                            string Ten = traLoi.nguoiTao.hinhDaiDien.ma + traLoi.nguoiTao.hinhDaiDien.duoi;

                            ws_LayAnhTraLoi(lst_TraLoi.Count - 1, Ten);
                        }
                    }
                };
        }

        public void ws_LayAnhTraLoi(int _ChiSo, string _Ten)
        {
            wcf_CauHoi.Iwcf_CauHoiClient client_CauHoi = new wcf_CauHoi.Iwcf_CauHoiClient();
            client_CauHoi.layHinhAnhChiSoAsync(_ChiSo, _Ten);
            client_CauHoi.layHinhAnhChiSoCompleted += (s, e) =>
                {
                    if (e.Result._HinhAnh != null)
                    {
                        lst_TraLoi[e.Result._ChiSo].HinhAnh = e.Result._HinhAnh;
                    }
                    else
                    {
                        lst_TraLoi[e.Result._ChiSo].HinhAnh = helper_HinhAnh.layHinhMacDinh_NguoiDung();
                    }
                };
        }

    }
}
