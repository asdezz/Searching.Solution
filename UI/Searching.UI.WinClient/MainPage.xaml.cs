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
    public partial class MainPage : PhoneApplicationPage
    {
        public string categories_id;
        CategoriesViewModel _Categories = new CategoriesViewModel();
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data


            //Shows the rate reminder message, according to the settings of the RateReminder.

        }

       
        
        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            _Categories.ListCategories = await QueryList.GetCategories();
            CategoriesListBox.ItemsSource = _Categories.ListCategories;
            
            LoadIndicator.IsRunning = false;
            
        }

        private async void DataBoundListBox1_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            _Categories.ReturnCategories = CategoriesListBox.SelectedItem as Categories;
            categories_id = JsonConvert.SerializeObject(_Categories.ReturnCategories.Categories_id);
            var Announcing = await QueryList.GetAnnouncingFilter(categories_id);
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Forms/Filter.xaml", UriKind.Relative));
        }
    }
}
