using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;

namespace Searching.UI.WinClient.Common
{
   public class MyListDataSelector: DataTemplateSelector
    {
        public DataTemplate ListTemplate { get; set; }
        public DataTemplate FormTemplate { get; set; }


    }
}
