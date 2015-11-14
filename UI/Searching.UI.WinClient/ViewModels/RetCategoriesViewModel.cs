using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinClient.ViewModels
{
    class RetCategoriesViewModel: INotifyPropertyChanged
    {
        private Categories _returnCategories;
        public RetCategoriesViewModel()
        {
            _returnCategories = new Categories();
        }
        public Categories ReturnCategories
        {
            get
            {
                return _returnCategories;
            }
            set
            {
                _returnCategories = value;
                NotifyPropertyChanged("returnCategories");
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
