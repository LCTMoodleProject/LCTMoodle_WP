using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class viewmodel_CauHoi : ViewModelBase
    {
        public ObservableCollection<model_CauHoi> lst_CauHoi { get; set; }

        public bool _HoanThanh;

        private int _DemCauHoi;

        public viewmodel_CauHoi()
        {
            lst_CauHoi = new ObservableCollection<model_CauHoi>();
            ws_LayCauHoi();
        }

        #region Webservice

        /// <summary>
        /// Hàm lấy danh sách câu hỏi từ wcf_CauHoi
        /// </summary>
        public void ws_LayCauHoi()
        {
            wcf_CauHoi.Iwcf_CauHoiClient client_CauHoi = new wcf_CauHoi.Iwcf_CauHoiClient();
            client_CauHoi.layAsync(20);
            client_CauHoi.layCompleted += (s, e) =>
            {
                if (e.Result.Count != 0)
                {
                    foreach (var cauHoi in e.Result)
                    {
                        lst_CauHoi.Add(new model_CauHoi()
                        {
                            Ma = cauHoi.ma.Value,
                            TieuDe = cauHoi.tieuDe,
                            NoiDung = cauHoi.noiDung,
                            NguoiTao = cauHoi.nguoiTao.ten,
                            SoTraLoi = cauHoi.soLuongTraLoi.Value,
                        });

                        ws_LayAnhCauHoi(lst_CauHoi.Count, cauHoi.nguoiTao.hinhDaiDien.ma + cauHoi.nguoiTao.hinhDaiDien.duoi);
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
                    if (e.Result != null)
                    {
                        lst_CauHoi[e.Result._ChiSo].HinhAnh = e.Result._HinhAnh;
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
