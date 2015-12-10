
using Caliburn.Micro;
using Searching.UI.WinPhoneClient.Logics.Client;
using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace Searching.UI.WinClient.ViewModels
{
   public class CategoriesViewModel:Screen
    {
        private List<Categories> _categories;
        
        public CategoriesViewModel()
        {
            _categories = new List<Categories>();
        }
        public List<Categories> ListCategories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
                NotifyPropertyChanged("Categories");
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
