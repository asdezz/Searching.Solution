using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinPhoneClient.Logics.Client
{
  public  class QueryList
    {
        public static async Task<string> GetCategories()
        {
            var result = await AccessService.ServiceCalled("GET", "GetCategories","");
            return result;
        }

        public static async Task<string> GetStringValue()
        {
            var result = await AccessService.ServiceCalled("GET","GetStringValue","");
            return result;
        }
    }
}
