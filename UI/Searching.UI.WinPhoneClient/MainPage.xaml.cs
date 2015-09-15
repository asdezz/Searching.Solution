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
using Searching.UI.WinPhoneClient.ViewModels;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;
using System.IO;
using Searching.UI.WinPhoneClient.Logics.Client;
using System.Threading.Tasks;
using SearchingLibrary;

namespace Searching.UI.WinPhoneClient
{
    public partial class MainPage : PhoneApplicationPage
    {
        private MainViewModel _vm = new MainViewModel();

        // Constructor
        public MainPage()
        {

            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = _vm;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            //Shows the rate reminder message, according to the settings of the RateReminder.
            (App.Current as App).rateReminder.Notify();
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void CategoriesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected override async void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string json = "";
               // string test = await QueryList.GetStringValue();
               // string json1 = "{'Categories_id': '1', 'Name_Category': 'Спорт','Info_Category': 'Категория для любителей спорта'}";
               // Categories categories = JsonConvert.DeserializeObject<Categories>(json1);
               // string acc = JsonConvert.SerializeObject(categories);
               // string error = "{\"Categories_id\":1,\"Name_Category\":\"Спорт\",\"Info_Category\":\"Категория для любителей спорта\"}";
               // string json2 = await QueryList.GetCategories();
               //var obj = JsonConvert.DeserializeObject(json2).ToString();
               //Categories account2 = JsonConvert.DeserializeObject<Categories>(obj);
               //Categories accs = JsonConvert.DeserializeObject<Categories>(obj);
               json = await QueryList.GetCategories();
            Categories ca = new Categories();
            List<Categories> c = new List<Categories>();
            ca = JsonConvert.DeserializeObject<Categories>(json);
            

        }
    }
}