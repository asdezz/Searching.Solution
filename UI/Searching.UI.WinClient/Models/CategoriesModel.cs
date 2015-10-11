using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinClient.Models
{
   public class CategoriesModel:INotifyPropertyChanged
    {
        private List<Categories> categories;
        private Categories returnCategories;
       public CategoriesModel()
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
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
