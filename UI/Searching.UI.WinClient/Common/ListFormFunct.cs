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
        
       public  CategoriesViewModel _Categories = new CategoriesViewModel();
        AnnFilter filt = new AnnFilter();
        private async  void DataBoundListBox1_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            LoadIndicator.IsRunning = true;
            _Categories.ReturnCategories = CategoriesListBox.SelectedItem as Categories;
            filt.Category_id = _Categories.ReturnCategories.Categories_id;
            var json = JsonConvert.SerializeObject(filt);
            var Announcing = await QueryList.GetAnnouncingFilter(filt);
            CategoriesGrid.Visibility = Visibility.Collapsed;
            AnnouncingGrid.Visibility = Visibility.Visible;
            AnnouncingListBox.ItemsSource = Announcing;
            LoadIndicator.IsRunning = false;

        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Forms/Filter.xaml", UriKind.Relative));
        }
    }
}
