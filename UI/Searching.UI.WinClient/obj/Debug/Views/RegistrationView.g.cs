﻿#pragma checksum "C:\Repository\projects\Searching\Sourse Code\Searching.Solution\UI\Searching.UI.WinClient\Views\RegistrationView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "543E966629EDE3B9BA76B404A8960162"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Caliburn.Micro.BindableAppBar;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using Telerik.Windows.Controls;


namespace Searching.UI.WinClient.Views {
    
    
    public partial class RegistrationView : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Caliburn.Micro.BindableAppBar.BindableAppBar AppBar;
        
        internal Caliburn.Micro.BindableAppBar.BindableAppBarButton Registration;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal Telerik.Windows.Controls.RadTextBox TakeMail;
        
        internal System.Windows.Controls.TextBlock Eror;
        
        internal Telerik.Windows.Controls.RadPasswordBox TakePass;
        
        internal Telerik.Windows.Controls.RadPasswordBox CheckPass;
        
        internal Telerik.Windows.Controls.RadTextBox TakeName;
        
        internal Telerik.Windows.Controls.RadTextBox TakeLastName;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Searching.UI.WinClient;component/Views/RegistrationView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.AppBar = ((Caliburn.Micro.BindableAppBar.BindableAppBar)(this.FindName("AppBar")));
            this.Registration = ((Caliburn.Micro.BindableAppBar.BindableAppBarButton)(this.FindName("Registration")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.TakeMail = ((Telerik.Windows.Controls.RadTextBox)(this.FindName("TakeMail")));
            this.Eror = ((System.Windows.Controls.TextBlock)(this.FindName("Eror")));
            this.TakePass = ((Telerik.Windows.Controls.RadPasswordBox)(this.FindName("TakePass")));
            this.CheckPass = ((Telerik.Windows.Controls.RadPasswordBox)(this.FindName("CheckPass")));
            this.TakeName = ((Telerik.Windows.Controls.RadTextBox)(this.FindName("TakeName")));
            this.TakeLastName = ((Telerik.Windows.Controls.RadTextBox)(this.FindName("TakeLastName")));
        }
    }
}

