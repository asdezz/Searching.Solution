using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Searching.BE.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFRESTService" in both code and config file together.
    [ServiceContract]
    public interface IWCFRESTService
    {
        [OperationContract]
        [WebInvoke(Method ="GET",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        string GetCityForCountry(int Country_id);

        [OperationContract]
        [WebGet(RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        string GetCountryList();
        [OperationContract]
        [WebGet(UriTemplate ="GetCategories",ResponseFormat =WebMessageFormat.Json)]
        List<Categories> GetCategories();
        [OperationContract]
        [WebInvoke(Method="POST",RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetAnnouncingFilter(string json);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetAnnouncing();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetAreasOfCity(int City_id);
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetFavoriteAnnuncing(int User_id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetSelectedAnnouncing(int User_id);
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetUser(int User_id);

        //[OperationContract]
        //[WebInvoke(Method="POST",RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //string UpdateUserInfo(int User_id,char? Mail = null, char? FIO = null, int? Phone = null, char? Gender_user = null, int? Date_Bearthday = null, char? pass = null, string info = null, int? Country_id = null, int? type_login = null, int? City_id = null);

        [OperationContract]
        [WebInvoke(Method="POST",RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string PostRegistration(string json);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        DataTable GetAnnouncingForCategory(string category_id);





    }
    
}