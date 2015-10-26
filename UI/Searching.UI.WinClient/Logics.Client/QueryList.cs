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
        public static async Task<List<Categories>> GetCategories()
        {
            var result = await AccessService.ServiceCalled("GET", "GetCategories","");
            List<Categories> categories=JsonConvert.DeserializeObject<List<Categories>>(result);
            return categories;
        }
        public static async Task<List<Announcing>> GetAnnouncingFilter(string json)
        {
            var result= await AccessService.ServiceCalled("POST", "GetAnnouncingFilter", json);
            List<Announcing> announcingForCategory = JsonConvert.DeserializeObject<List<Announcing>>(result);
            return announcingForCategory;
        }
        public static async Task<string> TestFunction(string json)
        {
            var result = await AccessService.ServiceCalled("POST", "TestFunction", json);
            List<Announcing> announcingForCategory = JsonConvert.DeserializeObject<List<Announcing>>(result);
            return result;
        }
    }
}
