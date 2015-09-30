using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using SearchingLibrary;

namespace Searching.UI.WInPhoneClient.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Categories> categories;
        public MainViewModel()
        {
            categories = new List<Categories>();
        }
        public List<Categories> listCategories
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
        public Categories returnCategories
        {
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
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
