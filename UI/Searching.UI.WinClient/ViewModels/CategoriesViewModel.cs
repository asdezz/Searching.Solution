
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
   public class CategoriesViewModel:INotifyPropertyChanged
    {
        private List<Categories> _categories;
        private Categories _returnCategories;
        private List<Announcing> _ann;
        private AnnFilter _filter;
        public List<Announcing> Ann
        {
            get
            {
                return _ann;
            }
            set
            {
                _ann = value;
                NotifyPropertyChanged("Ann");
            }
        }
        public AnnFilter Filter
        { get { return _filter; } set { _filter = value; NotifyPropertyChanged("ilter"); } }
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
            if(null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
