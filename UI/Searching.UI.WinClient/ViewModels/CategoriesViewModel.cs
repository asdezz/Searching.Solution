
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
        private List<Categories> categories;
        private Categories returnCategories;
        public CategoriesViewModel()
        {
            categories = new List<Categories>();
        }
        public List<Categories> ListCategories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
                NotifyPropertyChanged("Categories");
            }
        }
        public Categories ReturnCategories
        {
            get
            {
                return returnCategories;
            }
            set
            {
                returnCategories = value;
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
