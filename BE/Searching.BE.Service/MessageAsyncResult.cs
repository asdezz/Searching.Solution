using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Searching.BE.Service
{
   public class MessageAsyncResult:IAsyncResult
    {
        public AsyncCallback Callback { get; set;}
        private readonly object accessLock = new object();
        private bool isCompleted = false;
        private WCFRESTService result;
        private int recipient_id;
        private object asyncState;
        public MessageAsyncResult(object state)
        {
            asyncState = state;
        }
        public int RecipientId
        {
            get
            {
                lock (accessLock) { 
                return recipient_id;
                }
            }
            set
            {
                lock (accessLock) { 
                recipient_id = value;
                }
            }
        }
        public WCFRESTService Result
        {
            get
            {
                lock (accessLock)
                {
                    return result;
                }
            }
            set
            {
                lock (accessLock)
                {
                    result = value;
                }
            }
        }
        public bool IsCompleted
        {
            get
            {
                lock (accessLock)
                {
                    return isCompleted;
                }
            }
            set
            {
                lock (accessLock) { 
                isCompleted = value;
                }
            }
        }
        public bool CompletedSynchronously
        {
            get
            {
                return false;

            }
        }
        public object AsyncState
        {
            get
            {
                return asyncState;
            }
        }
        public WaitHandle AsyncWaitHandle
        {
           get
            {
                return null;
            }
        }
    }
}
