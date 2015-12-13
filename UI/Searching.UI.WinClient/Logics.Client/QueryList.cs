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
        public static async Task<List<Announcing>> GetAnnouncingFilter(AnnFilter json)
        {
            
            var result= await AccessService.ServiceCalledWithJson("GetAnnouncingFilter",json);
            List<Announcing> announcingForCategory = JsonConvert.DeserializeObject<List<Announcing>>(result);
            return announcingForCategory;
        }
        public static async Task<List<Cities>> GetCityForCountry(string country_id)
        {
            var result = await AccessService.ServiceCalled("POST", "GetCityForCountry", country_id);
            List<Cities> cities = JsonConvert.DeserializeObject<List<Cities>>(result);
            return cities;
        }

        public static async Task<List<AreasOfCity>> GetAreasOfCity(string city_id)
        {
            var result = await AccessService.ServiceCalled("POST", "GetAreasOfCity", city_id);
            List<AreasOfCity> areasList = JsonConvert.DeserializeObject<List<AreasOfCity>>(result);
            return areasList;
        }

        public static async Task<string> TestFunction()
        {
            var result = await AccessService.ServiceCalled("GET","TestFunction","");
            List<Announcing> announcingForCategory = JsonConvert.DeserializeObject<List<Announcing>>(result);
            return result;
        }

        public static async Task<Announcing> GetAnnouncingFull(string announcing_id)
        {
            var result = await AccessService.ServiceCalled("POST", "GetAnnouncingFull", announcing_id);
            Announcing ann = JsonConvert.DeserializeObject<Announcing>(result);
            return ann;
        }
       
    }
}
