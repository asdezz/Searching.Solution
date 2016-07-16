using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingLibrary
{
   public class MessageAsyncResult
    {
        public AsyncCallback Callback { get; set;}
        private readonly object accessLock = new object();
        private bool isCompleted=false;
    }
}
