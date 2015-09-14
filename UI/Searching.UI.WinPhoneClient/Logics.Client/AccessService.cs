using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinPhoneClient.Logics.Client
{
   public class AccessService
    {
        public static async Task<string> ServiceCalled(string MethodRequestType, string MethodName, string BodyParam = "")
        {
            string ServiceURI = GetServiceHost() + MethodName;
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(MethodRequestType == "GET" ? HttpMethod.Get : HttpMethod.Post, ServiceURI);
            //if (!string.IsNullOrEmpty(BodyParam))
            //{
            //    request.Content = new StringContent(BodyParam, Encoding.UTF8, "application/json");
            //}
            HttpResponseMessage response = await client.SendAsync(request);
            string returnValue = await response.Content.ReadAsStringAsync();
            return returnValue;
        }
        private static string GetServiceHost()
        {
            return "http://192.168.200.100/Searching.BE.Service//WCFRESTService.svc/";
        }
    }
}
