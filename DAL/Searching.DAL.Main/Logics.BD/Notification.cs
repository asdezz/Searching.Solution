using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.DAL.Main.Logics.BD
{
   public static class Notification
    {
        public static List<Messages> GetNews()
        {
            List<Messages> msgs = new List<Messages>();
            Messages msg = new Messages();
            for(int i = 0; i < 10; i++)
            {
                msg.Announcing_id = i;
                msg.Categories_id = 1;
                msgs.Add(msg);
            }
            return msgs;

        }
    }
}
