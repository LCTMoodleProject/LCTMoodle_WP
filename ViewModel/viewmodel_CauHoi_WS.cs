using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public static class viewmodel_CauHoi_WS
    {
        public static ObservableCollection<model_CauHoi> lst_CauHoiWS { get; set; }

        public static void layDanhSachCauHoi(int SoCauHoi)
        {
            lst_CauHoiWS = new ObservableCollection<model_CauHoi>();
            ws_LayDanhSachCauHoi(SoCauHoi);
        }

        public static void lamMoi()
        {
            lst_CauHoiWS = new ObservableCollection<model_CauHoi>();
            ws_LayDanhSachCauHoi(2);
        }

        public static bool _HoanThanh;

        private static int _DemCauHoi;
        public static void ws_LayDanhSachCauHoi(int SoCauHoi)
        {
            wcf_CauHoi.Iwcf_CauHoiClient client_CauHoi = new wcf_CauHoi.Iwcf_CauHoiClient();
            client_CauHoi.layAsync(SoCauHoi);
            client_CauHoi.layCompleted += (s, e) =>
            {
                if (e.Result.Count != 0)
                {
                    foreach (var cauHoi in e.Result)
                    {
                        lst_CauHoiWS.Add(new model_CauHoi()
                        {
                            Ma = cauHoi.Ma,
                            TieuDe = cauHoi.TieuDe,
                            NoiDung = cauHoi.NoiDung,
                            NguoiTao = cauHoi.NguoiTao,
                            SoTraLoi = cauHoi.SoTraLoi,
                        });

                        ws_LayAnhCauHoi(lst_CauHoiWS.Count - 1, cauHoi.HinhAnh);
                    }
                }
                else
                {
                    _HoanThanh = true;
                }
            };
        }

        public static void ws_LayAnhCauHoi(int _ChiSo, string _Ten)
        {
            wcf_CauHoi.Iwcf_CauHoiClient client_CauHoi = new wcf_CauHoi.Iwcf_CauHoiClient();
            client_CauHoi.layHinhAnhChiSoAsync(_ChiSo, _Ten);
            client_CauHoi.layHinhAnhChiSoCompleted += (s, e) =>
            {
                if (e.Result != null)
                {
                    lst_CauHoiWS[e.Result._ChiSo].HinhAnh = e.Result._HinhAnh;
                }

                _DemCauHoi++;

                if (_DemCauHoi == lst_CauHoiWS.Count)
                {
                    _HoanThanh = true;
                }
            };
        }
    }
}
