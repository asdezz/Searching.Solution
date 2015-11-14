using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinClient.ViewModels
{
    public class FilterViewModel: INotifyPropertyChanged
    {
        private AnnFilter _filter;
       public FilterViewModel()
        {
            _filter = new AnnFilter();
        }
        public AnnFilter TakeFilter
        { get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                NotifyPropertyChanged("Filter");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
