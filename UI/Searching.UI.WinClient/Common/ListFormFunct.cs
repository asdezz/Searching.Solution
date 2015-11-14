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


namespace Searching.UI.WinClient
{
   partial class MainPage
    {   
        private async  void DataBoundListBox1_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            LoadIndicator.IsRunning = true;
            
            _returnC.ReturnCategories = CategoriesListBox.SelectedItem as Categories;
            _filter.TakeFilter.Category_id = _returnC.ReturnCategories.Categories_id;
            var json = JsonConvert.SerializeObject(_filter.TakeFilter);
            _ann.ListAnnouncing = await QueryList.GetAnnouncingFilter(_filter.TakeFilter);
            CategoriesGrid.Visibility = Visibility.Collapsed;
            AnnouncingGrid.Visibility = Visibility.Visible;
            AnnouncingListBox.ItemsSource = _ann.ListAnnouncing;
            LoadIndicator.IsRunning = false;

        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Forms/Filter.xaml", UriKind.Relative));
        }
    }
}
