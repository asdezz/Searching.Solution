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
        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            _Categories.ListCategories = await QueryList.GetCategories();
            CategoriesListBox.ItemsSource = _Categories.ListCategories;
            LoadIndicator.IsRunning = false;

        }
        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            e.Cancel = true;
            if (CategoriesGrid.Visibility == Visibility.Visible)
            {
                e.Cancel = false;
            }           
            AnnouncingGrid.Visibility = Visibility.Collapsed;
            CategoriesGrid.Visibility = Visibility.Visible;
            

        }
        
    }
}
