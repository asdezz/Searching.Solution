using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Searching.UI.WinClient.ViewModels;
using Newtonsoft.Json;
using Searching.UI.WinPhoneClient.Logics.Client;
using SearchingLibrary;
using Searching.UI.WinClient.ViewModels;

namespace Searching.UI.WinClient
{
   partial class MainPage
    {
        
       public  CategoriesViewModel _Categories = new CategoriesViewModel();
        
        private async  void DataBoundListBox1_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            ViewModels.CategoriesViewModel _filter = new ViewModels.CategoriesViewModel();
            LoadIndicator.IsRunning = true;
            
            _Categories.ReturnCategories = CategoriesListBox.SelectedItem as Categories;
            _filter.Filter.Category_id = _Categories.ReturnCategories.Categories_id;
            var json = JsonConvert.SerializeObject(_filter.Filter);
            _filter.Ann = await QueryList.GetAnnouncingFilter(_filter.Filter);
            CategoriesGrid.Visibility = Visibility.Collapsed;
            AnnouncingGrid.Visibility = Visibility.Visible;
            AnnouncingListBox.ItemsSource = _filter.Ann;
            LoadIndicator.IsRunning = false;

        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Forms/Filter.xaml", UriKind.Relative));
        }
    }
}
