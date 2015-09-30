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
using Searching.UI.WInPhoneClient.ViewModels;
using Searching.UI.WinPhoneClient.Logics.Client;
using Newtonsoft.Json;
using SearchingLibrary;

namespace Searching.UI.WInPhoneClient
{
    public partial class MainPage : PhoneApplicationPage
    {
        public string categories_id;
        MainViewModel vm = new MainViewModel();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }


        private async void DataBoundListBox1_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            vm.returnCategories = DataBoundListBox1.SelectedItem as Categories;
            categories_id = JsonConvert.SerializeObject(vm.returnCategories.Categories_id);
            var Announcing = await QueryList.GetAnnouncingForCategory(categories_id);
            
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            vm.listCategories = await QueryList.GetCategories();
            DataBoundListBox1.ItemsSource = vm.listCategories;
           
        }
    }
}
