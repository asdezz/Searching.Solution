using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Cities> GetCityForCountry(int Country_id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Country> GetCountryList();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,UriTemplate ="GetCategories")]
        List<Categories> GetCategories();

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetAnnouncingFilter/", Method = "POST",ResponseFormat =WebMessageFormat.Json,BodyStyle =WebMessageBodyStyle.WrappedRequest,RequestFormat =WebMessageFormat.Json)]
        List<Announcing> GetAnnouncingFilter(AnnFilter filter);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetAnnouncing();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<AreasOfCity> GetAreasOfCity(int City_id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Announcing> GetFavoriteAnnuncing(int User_id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Announcing> GetSelectedAnnouncing(int User_id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserList GetUser(int User_id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Announcing> GetAnnouncingForCategory(string category_id);

        [OperationContract]
        [WebInvoke(UriTemplate ="TestFunction", Method = "GET",ResponseFormat =WebMessageFormat.Json,RequestFormat =WebMessageFormat.Json,BodyStyle =WebMessageBodyStyle.WrappedRequest)]
        string TestFunction();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Registration/")]
        UserList Registration(UserList user);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Auth/")]
        UserList Auth(UserList user);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditProfile/")]
        UserList EditProfile(UserList user);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAnnoncing/", BodyStyle = WebMessageBodyStyle.Wrapped)]
        void AddAnnouncing(Announcing ann);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/EditAnnouncing/", BodyStyle = WebMessageBodyStyle.Wrapped)]
        void EditAnnouncing(Announcing ann);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/DeleteAnnouncing/", BodyStyle = WebMessageBodyStyle.Wrapped)]
        void DeleteAnnouncing(string Announcing_id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AddToSelected/")]
        void AddToSelected(Selected_Announcing ann);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AddToFavorite/")]
        void AddToFavorite(Favorite_Announcing ann);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/DeleteSelectedAnnouncing")]
        void DeleteSelectedAnnouncing(Selected_Announcing ann);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/DeleteFavoriteAnnouncing")]
        void DeleteFavoriteAnnouncing(Favorite_Announcing ann);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AddSelectedUser/")]
        void AddSelectedUser(Selected_User user);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/DeleteSelectedUser/")]
        void DeleteSelectedUser(Selected_User user);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/FallowersList/", BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<UserList> FollowersList(string user_id);
    }

}