using Searching.UI.WinClient.Forms;
using Searching.UI.WinClient.Views;
using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinClient.Common
{
    public  class FilterFunction:FilterView
    {
        public delegate void callbackEvent(Announcing what);
        public static callbackEvent callbackEventHandler;
    }
}
