using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Searching.UI.Client.Logics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Searching.UI.Client.Logics
{
   public class QueryList
    {
        public static async Task<DataTable> GetCityList()
        {
            string result = await AccessService.ServiceCalled("GET","GetCityAll","");
            DataTable table = new DataTable();
            table = JsonConvert.DeserializeObject<DataTable>(result);
            return table;
        }
    }
}
