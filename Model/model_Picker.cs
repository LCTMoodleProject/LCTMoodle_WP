using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class model_Picker : ModelBase
    {
        private string _Item;

        public string Item
        {
            get
            {
                return _Item;
            }
            set
            {
                _Item = value;
                RaisePropertyChanged("Item");
            }
        }
    }
}
