using SearchingLibrary;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Searching.BE.Service
{
    public class Notification
    {
        public static List<int> Subscribers { get; set; }
        public static List<Messages> Messages = new List<SearchingLibrary.Messages>();
        private object notifyAddLock = new object();
        public static void PushMsg(List<Messages>news_msg)
        {
            foreach(Messages msg in news_msg.AsParallel())
            {
                Messages.Add(msg);
            }
        }

        public List<Messages> Check(int id )
        {
            List<Messages> msgs = new List<SearchingLibrary.Messages>();
            foreach(Messages messg in msg.AsParallel())
            {
                if (messg.Recipient_id == id)
                    msgs.Add(messg);
            }
            return msgs;
        }

        public List<Messages> msg
        {
            get
            {
                lock (notifyAddLock)
                {
                    return Messages;
                }
            }
            set
            {
                lock (notifyAddLock)
                {
                    Messages = value;
                }
            }
        }


        public Notification( )
        {
            
        }

        public void Notify(int id)
        {
            Subscribers.Add(id);
        }
        public event EventHandler Changed;

        public void onChanged(EventArgs e)
        {
            EventHandler handler = Changed;
            if (handler != null) handler(this, e);
        }
    
    }
}