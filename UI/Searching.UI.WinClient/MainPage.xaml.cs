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
using Searching.UI.WinClient.Common;


namespace Searching.UI.WinClient
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            FilterFunction.callbackEventHandler = new FilterFunction.callbackEvent(this.Reload);
            InitializeComponent();
        }
        void Reload(Announcing param)
        {
            //Здесь чего нибудь делаем.
            //Это непосредственно то что выполнится по событию.
        }
    }
}
