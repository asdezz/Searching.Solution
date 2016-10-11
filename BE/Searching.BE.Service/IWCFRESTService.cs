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
    [ServiceContract(Namespace = "Searching.BE.Service")]
    public interface IWCFRESTService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,UriTemplate ="GetCityForCountry")]
        //Возвращает список городов по заданной стране
        List<Cities> GetCityForCountry(int country_id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,UriTemplate ="GetCountryList")]
        //Возвращает список Стран
        List<Country> GetCountryList();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,UriTemplate ="GetCategories")]
        //Возвращает список категорий для объявлений
        List<Categories> GetCategories();

        [OperationContract]
        [WebInvoke(UriTemplate = "GetAnnouncingFilter", Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json)]
        //Возвращает список объявлений по заданным фильтрам
        List<Announcing> GetAnnouncingFilter(AnnFilter filter);

        [OperationContract]
        [WebInvoke(Method="POST",RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,UriTemplate ="GetAreasOfCity")]
        //Возвращает список районов по заданому городу 
        List<AreasOfCity> GetAreasOfCity(int City_id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //Возвращает список подписанных объявлений пользователя
        List<Announcing> GetFavoriteAnnuncing(int User_id);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //Возвращает список выбранных объявлений пользователя
        List<Announcing> GetSelectedAnnouncing(int User_id);

        [OperationContract]
        [WebInvoke(Method ="POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,UriTemplate ="GetForeignUser",BodyStyle =WebMessageBodyStyle.WrappedRequest)]
        //Возвращает иформацию по выбранному пользователю
        UserList GetForeignUser(int User_id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetMyUser",BodyStyle =WebMessageBodyStyle.WrappedRequest)]
        //Возвращает информацию о собственном аккаунте
        UserList GetMyUser(string mail);

        [OperationContract]
        [WebInvoke(UriTemplate ="TestFunction", Method = "POST",ResponseFormat =WebMessageFormat.Json,RequestFormat =WebMessageFormat.Json,BodyStyle =WebMessageBodyStyle.WrappedRequest)]
        string TestFunction(AnnFilter filter);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "Registration")]
        //Регистрирует пользователя (возвращает true or false)
        ReturnValue Registration(UserList user);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "Auth")]
        //Аутентификация пользователя (возвращает true or false)
        ReturnValue Auth(UserList user);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/EditProfile/")]
        //Изменяет профиль выбранного пользователя 
        UserList EditProfile(UserList user);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "AddAnnouncing", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //Добавляет объявление 
        ReturnValue AddAnnouncing(Announcing ann);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/EditAnnouncing/", BodyStyle = WebMessageBodyStyle.Wrapped)]
        //изменение объявления
        void EditAnnouncing(Announcing ann);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/DeleteAnnouncing/", BodyStyle = WebMessageBodyStyle.Wrapped)]
        //Удаляеет объявления
        void DeleteAnnouncing(string Announcing_id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "AddToSelected")]
        ReturnValue AddToSelected(Selected_Announcing ann);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "AddToFavorite")]
        ReturnValue AddToFavorite(Favorite_Announcing ann);

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

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "GetAnnouncingFull")]
        Announcing GetAnnouncingFull(string announcing_id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,UriTemplate = "AddMessage")]
        ReturnValue AddMessage(Messages message);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "GetMyAnnouncing")]
        List<Announcing> GetMyAnnouncing(int id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        ReturnValue CallCallBack(List<Messages> messageCallback);

        //[OperationContract(AsyncPattern = true)]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //IAsyncResult BeginMessage(int recipient_id, AsyncCallback callback, object state);

        //List<Messages> EndMessage(IAsyncResult asyncResult);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetSubscribers")]
        List<int> GetSubscribers();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,UriTemplate = "GetMessages")]
        List <Messages> GetMessages(int recipient_id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "TestWF")]
        ReturnValue TestWF(int id);


        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "GetTestWF")]
        List<int> GetTestWF();
    }

}