using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft;
using System.Diagnostics;
using Searching.DAL.Main;
using System.Data;
using System.Web.Script.Serialization;
using SearchingLibrary;
using System.IO;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.Net;

namespace Searching.BE.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(
    InstanceContextMode = InstanceContextMode.PerCall,
    ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class WCFRESTService : IWCFRESTService
    {
        
        public List<Announcing> GetAnnouncingFilter(AnnFilter filter)
        {
            var jsn = JsonConvert.SerializeObject(filter);
            Logger.WriteToFile_Json(jsn);
            List < Announcing > listAnnonc = new List<Announcing>();
            Announcing annonc = new Announcing();
            DataTable table = new DataTable();
            table = AnnouncingFilter.GetAnnouncingFilter(filter);
            foreach(DataRow row in table.Rows)
            {
                try
                {
                    annonc.Info_Announcing = row["Info_Announcing"].ToString();
                    annonc.Date_Announcing=DateTime.Parse(row["Date_Announcing"].ToString());
                    annonc.Announcing_id = int.Parse(row["Announcing_id"].ToString());
                    annonc.User_id = int.Parse(row["User_id"].ToString());
                    annonc.Name_Announcing = row["Name_Announcing"].ToString();
                    annonc.UserName = row["Name"].ToString();
                    annonc.UserLastName = row["LastName"].ToString();
                    listAnnonc.Add(new Announcing() {Info_Announcing=annonc.Info_Announcing,Date_Announcing=annonc.Date_Announcing,User_id=annonc.User_id, Announcing_id=annonc.Announcing_id,Name_Announcing=annonc.Name_Announcing,UserLastName=annonc.UserLastName,UserName=annonc.UserName });
                }
                catch (Exception ex)
                {
                    Logger.CreateLog(ex);
                    throw ex;
                }
            }
            return listAnnonc;
        }
        
        public List<AreasOfCity> GetAreasOfCity(int City_id)
        {
            AreasOfCity _district = new AreasOfCity();
            List<AreasOfCity> _areas = new List<AreasOfCity>();
            DataTable table = Location.GetAreasOfCity(City_id);
            foreach(DataRow row in table.Rows)
            {
                _district.Areas_id = int.Parse(row["Areas_id"].ToString());
                _district.Areas_name = row["Areas_name"].ToString();
                _areas.Add(new AreasOfCity() { Areas_id = _district.Areas_id, Areas_name = _district.Areas_name });
            }
            return _areas;
        }

        public List<Categories> GetCategories()
        {
            DataTable table = AnnouncingFilter.GetCategories();
            List<Categories> ListCategories = new List<Categories>();
            Categories c = new Categories();
            foreach (DataRow row in table.Rows)
            {
                c.Name_Category = row["Name_Category"].ToString();
                c.Categories_id = int.Parse(row["Categories_id"].ToString());
                 c.Info_Category = row["Info_Category"].ToString();
                ListCategories.Add(new Categories() { Name_Category = c.Name_Category, Categories_id = c.Categories_id, Info_Category = c.Info_Category });
            }
            return ListCategories;
        }

        public List<Cities> GetCityForCountry(int country_id)
        {
            DataTable table = Location.GetCityForCountry(country_id);
            Cities _city = new Cities();
            List<Cities> _cities = new List<Cities>();
            foreach(DataRow row in table.Rows)
            {
                _city.City_id = int.Parse(row["city_id"].ToString());
                _city.City_name = row["City_name"].ToString();
                _cities.Add(new Cities() {City_name=_city.City_name,City_id=_city.City_id });
            }
            return _cities;
        }

        public List<Country> GetCountryList()
        {
            DataTable table = Location.GetCountryList();
            Country _country = new  Country();
            List<Country> _countrys = new List<Country>();
            foreach(DataRow row in table.Rows)
            {
                _country.Country_id = int.Parse(row["Country_id"].ToString());
                _country.Name_country = row["Name_country"].ToString();
                _countrys.Add(new Country() { Name_country = _country.Name_country,Country_id=_country.Country_id });
            }
            return _countrys;
            
        }
        
        public List<Announcing> GetFavoriteAnnuncing(int User_id)
        {
            DataTable table = FavoriteAnnouncingFunction.GetFavoriteAnnouncing(User_id);
            Announcing _favorite = new Announcing();
            List<Announcing> _favorites = new List<Announcing>();
            foreach(DataRow row in table.Rows)
            {
                _favorite.Announcing_id = int.Parse(row["Announcing_id"].ToString());
                _favorite.Areas_id = int.Parse(row["Areas_id"].ToString());
                _favorite.Phone_Announcing = int.Parse(row["Phone_Announcing"].ToString());
                _favorite.Info_Announcing = row["Info_Announcing"].ToString();
                _favorite.Name_Announcing = row["Name_Announcing"].ToString();
                _favorites.Add(new Announcing() {Announcing_id = _favorite.Announcing_id, Areas_id=_favorite.Areas_id,
                    Phone_Announcing =_favorite.Phone_Announcing,Info_Announcing=_favorite.Info_Announcing,Name_Announcing=_favorite.Name_Announcing });
            }
            return _favorites;
        }
        
        public List<Announcing> GetSelectedAnnouncing(int User_id)
        {
            Announcing _select = new Announcing();
            List<Announcing> _selected = new List<Announcing>();
            DataTable table = SelectedAnnouncingFunction.GetSelectedAnnouncing(User_id);
            foreach(DataRow row in table.Rows)
            {
                _select.Announcing_id = int.Parse(row["Announcing_id"].ToString());
                _select.Areas_id = int.Parse(row["Areas_id"].ToString());
                _select.Phone_Announcing = int.Parse(row["Phone_Announcing"].ToString());
                _select.Info_Announcing = row["Info_Announcing"].ToString();
                _select.Name_Announcing = row["Name_Announcing"].ToString();
            }
            return _selected;
            
        }
        
        public UserList GetForeignUser(int User_id)
        {
            UserList _user = new UserList();
            List<UserList> _users = new List<UserList>(); 
            DataTable table = Profile.GetForeignUser(User_id);
            foreach(DataRow row in table.Rows)
            {
                _user.Name = row["Name"].ToString();
                _user.Country_id = int.Parse(row["Country_id"].ToString());
                _user.Phone = (row["Phone"].ToString());
                _user.User_id = int.Parse(row["User_id"].ToString());
                _user.Gender_user = row["Gender_user"].ToString();
                _user.Date_Bearthday = DateTime.Parse(row["Date_Bearthday"].ToString());
                _user.Info = row["Info"].ToString();
                //_users.Add(new UserList() { FIO = _user.FIO, Country_id = _user.Country_id, Phone = _user.Phone,
                //    User_id = _user.User_id, Gender_user = _user.Gender_user, Date_Bearthday = _user.Date_Bearthday,Info=_user.Info});
            }
            return _user;
        }

        public string TestFunction(AnnFilter filter)
        {
            string json = JsonConvert.SerializeObject(filter);
            return  json;
        }

        public ReturnValue Registration(UserList user)
        {
            UserList _user = new UserList();
            _user.City_id = 1;
            _user.Country_id = 1;
            var data = "12-10-22";
            _user.Date_Bearthday = DateTime.Parse(data);
            _user.Gender_user = "м";
            _user.Info = "Маньяк";
            _user.LastName = "Гитлер";
            _user.Mail = "Cp5dsa@mail1er.ru";
            _user.Name = "Адольфик";
            _user.Password = "Adolf123";
            _user.Phone = "2";
            _user.Type_login = 1;
            var result = Profile.PostRegistration(_user);
            
            return result;
        }

        public ReturnValue Auth(UserList user)
        {
          //  UserList _user = new UserList();
            //_user.Mail = "Cp5@mail1erda.ru";
            //_user.Password = "Adolf123";
            ReturnValue result = Profile.Auth(user);
            
            return result;
        }

        public UserList EditProfile(UserList user)
        {
            UserList _user = new UserList();
            var table = Profile.EditProfile(user);
            foreach (DataRow row in table.Rows)
            {
                _user.User_id = int.Parse(row["User_id"].ToString());
                _user.City_id = int.Parse(row["City_id"].ToString());
                _user.Date_Bearthday = DateTime.Parse(row["Date_Bearthday"].ToString());
                _user.Name = row["Name"].ToString();
                _user.Gender_user = row["Gender_user"].ToString();
                _user.Info = row["Info"].ToString();
                _user.Mail = row["Mail"].ToString();
                _user.Password = row["Password"].ToString();
                _user.Phone = (row["Phone"].ToString());
            }
            return _user;
        }

        public ReturnValue AddAnnouncing(Announcing ann)
        {
            //var data = "12-10-22";
            //Announcing TestAnn = new Announcing();
            //TestAnn.Announcing_id = 1;
            //TestAnn.Areas_id = 1;
            //TestAnn.Categories_id = ann.Categories_id;
            //TestAnn.City_id = 1;
            //TestAnn.Date_Announcing = DateTime.Parse(data);
            //TestAnn.Info_Announcing = ann.Info_Announcing;
            //TestAnn.Name_Announcing=ann.Name_Announcing;
            //TestAnn.Name_City = "Kiev";
            //TestAnn.Phone_Announcing = 12;
            //TestAnn.UserLastName = TestAnn.UserLastName;
            //TestAnn.UserName = ann.UserName;
            //TestAnn.User_id = ann.User_id;
            ReturnValue result = new ReturnValue();
            result= AnnouncingFunction.AddAnnoucing(ann);
            return result;
        }

        public void EditAnnouncing(Announcing ann)
        {
            AnnouncingFunction.EditAnnouncing(ann);
        }

        public void DeleteAnnouncing(string Announcing_id)
        {
            var _id = int.Parse(Announcing_id);
            AnnouncingFunction.DeleteAnnouncing(_id);
        }

        public ReturnValue AddToSelected(Selected_Announcing ann)
        {
            ReturnValue result = new ReturnValue();
           // var row_string = "";
            var cheker =SelectedAnnouncingFunction.CheckRecording(ann);
            var count = cheker.Rows.Count;
            if (count != 0)
            {
                result.Code = false;
                result.Message = "Запись уже добавлена!";
            }
            else
            {
                result = SelectedAnnouncingFunction.AddToSelected(ann);
            }
            //foreach(DataRow row in cheker.Rows)
            //{
            //    row_string = row["id"].ToString();
            //}
            //if (!String.IsNullOrEmpty(row_string))
            //{
            //    result.Code = false;
            //    result.Message = "Запись уже добавлена!";
            //}else
            //{
            //    result= SelectedAnnouncingFunction.AddToSelected(ann);
            //}
            return result;
        }

        public ReturnValue AddToFavorite(Favorite_Announcing ann)
        {
            ReturnValue result = new ReturnValue();
            var checker = FavoriteAnnouncingFunction.CheckRecording(ann);
            var count = checker.Rows.Count;
            if(count != 0)
            {
                result.Code = false;
                result.Message = "Запись уже добавлена!";
            }
            else
            {
                 result= FavoriteAnnouncingFunction.AddToFavorite(ann);
            }
            //Если Произошла ошибка при запросе
            //foreach (DataRow row in checker.Rows)
            //{
            //    row_string = row["id"].ToString();
            //}//Есть ли запись в таблице
            //if (!String.IsNullOrEmpty(row_string))
            //{
            //    result.Code = false;
            //    result.Message = "Запись уже добавлена!";
            //}//Если нету, то добавляем 
            //else
            //{ 
            //    result= FavoriteAnnouncingFunction.AddToFavorite(ann);
            //}
            return result;
        }

        public void DeleteSelectedAnnouncing(Selected_Announcing ann)
        {
            SelectedAnnouncingFunction.DeleteSelected(ann);
        }

        public void DeleteFavoriteAnnouncing(Favorite_Announcing ann)
        {
            FavoriteAnnouncingFunction.DeleteFavorite(ann);
        }

        public void AddSelectedUser(Selected_User user)
        {
            FollowersFunction.AddSelectedUser(user);
        }

        public void DeleteSelectedUser(Selected_User user)
        {
            FollowersFunction.DeleteSelectedUser(user);
        }

        public List<UserList> FollowersList(string user_id)
        {
            var _id = int.Parse(user_id);
            UserList _user = new UserList();
            List<UserList> _users = new List<UserList>();
            DataTable table = FollowersFunction.FollowersList(_id);
            return _users;
        }

        public Announcing GetAnnouncingFull(string announcing_id)
        {
            int ann_id = int.Parse(announcing_id);
            Announcing ann = new Announcing();
            DataTable table = DAL.Main.AnnouncingFilter.GetAnnouncingFull(ann_id);
            foreach(DataRow row in table.Rows)
            {
                ann.Announcing_id = int.Parse(row["Announcing_id"].ToString());
                ann.Name_Announcing = row["Name_Announcing"].ToString();
                ann.Phone_Announcing = int.Parse(row["Phone_Announcing"].ToString());
                ann.Date_Announcing = DateTime.Parse(row["Date_Announcing"].ToString());
                ann.UserName = row["Name"].ToString();
                ann.UserLastName = row["LastName"].ToString();
                ann.Name_City = row["City_Name"].ToString();
                ann.Info_Announcing = row["Info_Announcing"].ToString();
            }
             return ann;
        }

        public UserList GetMyUser(string mail)
        {
            UserList _user = new UserList();
            DataTable table = DAL.Main.Profile.GetMyUser(mail);
            foreach(DataRow row in table.Rows)
            {
                _user.User_id = int.Parse(row["User_id"].ToString());
                _user.Name = row["Name"].ToString();
                _user.LastName = row["LastName"].ToString();
                if (row["City_id"] !=DBNull.Value)
                {
                    _user.City_id = int.Parse(row["City_id"].ToString());
                }
                if (row["Date_Bearthday"] != DBNull.Value)
                {
                    _user.Date_Bearthday = DateTime.Parse(row["Date_Bearthday"].ToString());
                }
                if (row["Gender_user"] != DBNull.Value)
                {
                    _user.Gender_user = row["Gender_user"].ToString();
                }
                if (row["Info"] != DBNull.Value)
                {
                    _user.Info = row["Info"].ToString();
                }
                _user.Mail = row["Mail"].ToString();
                if (row["Phone"] != DBNull.Value)
                {
                    _user.Phone = (row["Phone"].ToString());
                }
            }
            return _user;
        }

        public ReturnValue AddMessage(Messages message)
        {
            message.Recipient_id = 1;
            message.Sender_id = 30;
            message.Type_id = 2;
            message.Status_id = 1;
            message.Message = "Попытка";
            message.Date_Message = DateTime.Now;
            ReturnValue result = new ReturnValue();
            result = DAL.Main.Logics.BD.MessagesFunction.AddMessages(message);
            return result;
        }

        //public IAsyncResult BeginMessage(TestClass asyncBegin)
        //{
        //    throw new NotImplementedException();
        //}

        //public WCFRESTService EndMessage(IAsyncResult result)
        //{
        //    throw new NotImplementedException();
        //}
    }
    
}
