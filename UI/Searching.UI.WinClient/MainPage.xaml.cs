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
using Searching.UI.WinPhoneClient.Logics.Client;
using SearchingLibrary;

namespace Searching.UI.WinClient
{
    public partial class MainPage : PhoneApplicationPage
    {
       // List<Categories> ListCategories;
        
        // Constructor
        MainViewModel vm = new MainViewModel();
        public MainPage()
        {
            InitializeComponent();
            
            // Set the data context of the listbox control to the sample data

        }

        //protected override async void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        //{

        //}

        
        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
           vm.listCategories = await QueryList.GetCategories();
            DataBoundListBox1.ItemsSource = vm.listCategories;
            
        }

        private void DataBoundListBox1_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
             vm.returnCategories = DataBoundListBox1.SelectedItem as Categories;
            
        }
    }
}

