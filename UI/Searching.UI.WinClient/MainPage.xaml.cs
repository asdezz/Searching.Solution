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
        MainViewModel vm = new MainViewModel();
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data


            //Shows the rate reminder message, according to the settings of the RateReminder.

        }

       

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            vm.listCategories = await QueryList.GetCategories();
            CategoriesListBox.ItemsSource = vm.listCategories;
            LoadIndicator.IsRunning = false;
        }

        private async void DataBoundListBox1_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            vm.returnCategories = CategoriesListBox.SelectedItem as Categories;
            categories_id = JsonConvert.SerializeObject(vm.returnCategories.Categories_id);
            var Announcing = await QueryList.GetAnnouncingFilter(categories_id);
           
        }

        
    }
}
