using Searching.UI.WinClient.Forms;
using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinClient.Common
{
    public  class FilterFunction:Filter
    {
        public delegate void callbackEvent(Announcing what);
        public static callbackEvent callbackEventHandler;
    }
}
