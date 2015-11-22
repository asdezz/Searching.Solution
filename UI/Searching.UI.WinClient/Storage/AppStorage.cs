using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;

namespace Searching.UI.WinClient.Storage
{
    public class AppStorage
    {
        public void Storage()
        {
            using (var appStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (appStorage.FileExists("LS.txt"))
                {
                    using (var file = appStorage.OpenFile("LS.txt", FileMode.Open))
                    {
                        using (var reader = new StreamReader(file))
                        {
                            //counter = int.Parse(reader.ReadLine()); message = reader.ReadLine();
                        }
                    }
                }
                else
                {
                    using (var file = appStorage.OpenFile("LS.txt", FileMode.Create))
                    {
                        using (var writer = new StreamWriter(file))
                        {
                            writer.WriteLine("0");
                            writer.WriteLine("No messages..!");
                        }
                    }
                }
            }
        }


   
    }
}
