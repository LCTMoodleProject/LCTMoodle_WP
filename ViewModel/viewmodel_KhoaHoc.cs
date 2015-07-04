using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class viewmodel_KhoaHoc : ViewModelBase
    {
        public ObservableCollection<model_KhoaHoc> lst_KhoaHoc { get; set; }

        private model_KhoaHoc _KhoaHocSelected;
        public model_KhoaHoc KhoaHocSelected
        {
            get
            {
                return _KhoaHocSelected;
            }
            set
            {
                if (value.Loai == 1)
                {
                    layTheoChuDe(value.Ma);
                    RaisePropertyChanged("lst_KhoaHoc");
                }
            }
        }

        public viewmodel_KhoaHoc()
        {
            layTheoChuDe(0);
        }

        public void layTheoChuDe(int _ChuDe)
        {
            _HoanThanh = false;
            _Dem = 0;
            lst_KhoaHoc = new ObservableCollection<model_KhoaHoc>();
            ws_layChuDeTheoMaCha(_ChuDe);
        }

        #region Webservice

        public bool _HoanThanh;

        private int _Dem;

        private int _Ma;

        #region Webservice chủ đề

        /// <summary>
        /// Hàm lấy chủ đề từ wcf_ChuDe
        /// </summary>
        /// <param name="_MaCha"></param>
        public void ws_layChuDeTheoMaCha(int _MaCha)
        {
            _Ma = _MaCha;
            wcf_ChuDe.Iwcf_ChuDeClient client_ChuDe = new wcf_ChuDe.Iwcf_ChuDeClient();
            client_ChuDe.layTheoMaChaAsync(_MaCha);
            client_ChuDe.layTheoMaChaCompleted += (s, e) =>
            {
                if (e.Result.Count != 0)
                {
                    foreach (var chuDe in e.Result)
                    {             
                        lst_KhoaHoc.Add(new model_KhoaHoc()
                        {
                            Ma = chuDe.ma.Value,
                            Ten = chuDe.ten,
                            MoTa = chuDe.moTa,
                            Loai = 1,
                        });

                        if (chuDe.duLieuThem.ContainsKey("SLChuDeCon"))
                        { 
                            if(chuDe.duLieuThem.ContainsKey("SLKhoaHocCon"))
                            {
                                if((int)chuDe.duLieuThem["SLChuDeCon"] == 0)
                                {
                                    if((int)chuDe.duLieuThem["SLKhoaHocCon"] == 0)
                                    {
                                        lst_KhoaHoc[lst_KhoaHoc.Count - 1].ThongKeKhoaHocCon = "Không có chủ đề, khóa học";
                                    }
                                    else
                                    {
                                        lst_KhoaHoc[lst_KhoaHoc.Count - 1].ThongKeKhoaHocCon = string.Format("Có {0} khóa học", chuDe.duLieuThem["SLKhoaHocCon"].ToString());
                                    }
                                }
                                else
                                {
                                    if((int)chuDe.duLieuThem["SLKhoaHocCon"] == 0)
                                    {
                                        lst_KhoaHoc[lst_KhoaHoc.Count - 1].ThongKeKhoaHocCon = string.Format("Có {0} chủ đề", chuDe.duLieuThem["SLChuDeCon"].ToString());
                                    }
                                    else
                                    {
                                        lst_KhoaHoc[lst_KhoaHoc.Count - 1].ThongKeKhoaHocCon = string.Format("Có {0} chủ đề, {1} khóa học", chuDe.duLieuThem["SLChuDeCon"].ToString(), chuDe.duLieuThem["SLKhoaHocCon"].ToString());
                                    }
                                }
                            }
                        }

                        ws_LayAnhChuDe(lst_KhoaHoc.Count - 1, chuDe.hinhDaiDien.ma + chuDe.hinhDaiDien.duoi);
                    }
                }
                else
                {
                    ws_LayKhoaHocTheoChuDe(_Ma);
                }
            };
        }

        /// <summary>
        /// Hàm trả về hình ảnh và chỉ số từ wcf_ChuDe
        /// </summary>
        /// <param name="_ChiSo"></param>
        /// <param name="_Ten"></param>
        public void ws_LayAnhChuDe(int _ChiSo, string _Ten)
        {
            wcf_ChuDe.Iwcf_ChuDeClient client_ChuDe = new wcf_ChuDe.Iwcf_ChuDeClient();
            client_ChuDe.layHinhAnhChiSoAsync(_ChiSo, _Ten);
            client_ChuDe.layHinhAnhChiSoCompleted += (s, e) =>
            {
                if (e.Result != null)
                {
                    lst_KhoaHoc[e.Result._ChiSo].HinhAnh = e.Result._HinhAnh;
                }
                else
                {

                }

                _Dem++;

                if (_Dem == lst_KhoaHoc.Count)
                {
                    ws_LayKhoaHocTheoChuDe(_Ma);
                }
            };
        }

        #endregion

        #region Webservice khóa học

        /// <summary>
        /// Hàm lấy khóa học theo mã chủ đề từ wcf_KhoaHoc
        /// </summary>
        /// <param name="_MaChuDe"></param>
        public void ws_LayKhoaHocTheoChuDe(int _MaChuDe)
        {
            wcf_KhoaHoc.Iwcf_KhoaHocClient client_KhoaHoc = new wcf_KhoaHoc.Iwcf_KhoaHocClient();
            client_KhoaHoc.layTheoMaChuDeAsync(_MaChuDe);
            client_KhoaHoc.layTheoMaChuDeCompleted += (s, e) =>
            {
                if (e.Result.Count != 0)
                {
                    foreach (var khoaHoc in e.Result)
                    {
                        lst_KhoaHoc.Add(new model_KhoaHoc()
                        {
                            Ma = khoaHoc.ma.Value,
                            Ten = khoaHoc.ten,
                            MoTa = khoaHoc.moTa,
                            Loai = 2,
                        });

                        ws_LayAnhKhoaHoc(lst_KhoaHoc.Count - 1, khoaHoc.hinhDaiDien.ma + khoaHoc.hinhDaiDien.duoi);
                    }
                }
                else
                {
                    _HoanThanh = true;
                }
            };
        }

        /// <summary>
        /// Hàm lấy hình ảnh và chỉ số từ wcf_KhoaHoc
        /// </summary>
        /// <param name="_ChiSo"></param>
        /// <param name="_Ten"></param>
        public void ws_LayAnhKhoaHoc(int _ChiSo, string _Ten)
        {
            wcf_KhoaHoc.Iwcf_KhoaHocClient client_KhoaHoc = new wcf_KhoaHoc.Iwcf_KhoaHocClient();
            client_KhoaHoc.layHinhAnhChiSoAsync(_ChiSo, _Ten);
            client_KhoaHoc.layHinhAnhChiSoCompleted += (s, e) =>
            {
                if (e.Result != null)
                {
                    lst_KhoaHoc[e.Result._ChiSo].HinhAnh = e.Result._HinhAnh;
                }
                else
                {

                }

                _Dem++;

                if (_Dem == lst_KhoaHoc.Count)
                {
                    _HoanThanh = true;
                }
            };
        }

        #endregion

        #endregion
    }
}
