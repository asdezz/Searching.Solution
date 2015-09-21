using Newtonsoft.Json;
using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinPhoneClient.Logics.Client
{
  public  class QueryList
    {
        public static async void GetCategories()
        {
            var result = await AccessService.ServiceCalled("GET", "GetCategories","");
            List<Categories> categories=JsonConvert.DeserializeObject<List<Categories>>(result);
            
        }

    }
}
