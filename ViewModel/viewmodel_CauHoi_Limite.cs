using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Windows.Threading;

namespace ViewModel
{
    public class viewmodel_CauHoi_Limite : ViewModelBase
    {
        public ObservableCollection<model_CauHoi> lst_CauHoi
        {
            get
            {
                return viewmodel_CauHoi_WS.lst_CauHoiWS;
            }
            set
            {
                viewmodel_CauHoi_WS.lst_CauHoiWS = value;
                RaisePropertyChanged();
            }
        }


        public viewmodel_CauHoi_Limite()
        {
            viewmodel_CauHoi_WS.ws_LayDanhSachCauHoi(20);
            lst_CauHoi = new ObservableCollection<model_CauHoi>();
            _LamMoiCommand = new RelayCommand(() =>
            {
                viewmodel_CauHoi_WS.lamMoi();
                //RaisePropertyChanged("lst_CauHoi");
            });
        }

        public RelayCommand _LamMoiCommand;
        public RelayCommand LamMoiCommand
        {
            get
            {
                return _LamMoiCommand;
            }
        }
    }
}
