using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Searching.UI.WinClient
{
   partial  class MainPage
    {
        private  void HyperlinkButton_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Forms/RegistrationForm.xaml", UriKind.Relative));
        }
    }
}
