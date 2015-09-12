using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Searching.UI.WinPhoneClient.ViewModels
{
    public partial class CategoriesList : PhoneApplicationPage
    {
        private MainViewModel _vm = new MainViewModel();
        public CategoriesList()
        {
            InitializeComponent();
            DataContext = _vm;
        }
    }
}