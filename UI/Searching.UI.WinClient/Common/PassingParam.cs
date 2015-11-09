using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinClient
{
   public static class  CallBackMy
    {
            public delegate void callbackEvent(Announcing what);
            public static callbackEvent callbackEventHandler;
    }
}
