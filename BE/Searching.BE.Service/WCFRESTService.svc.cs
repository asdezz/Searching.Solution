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


namespace Searching.BE.Service
{
    public class WCFRESTService : IWCFRESTService
    {
        
        public List<Announcing> GetAnnouncingFilter(AnnFilter filter)
        {
            List < Announcing > listAnnonc = new List<Announcing>();
            Announcing annonc = new Announcing();
            DataTable table = new DataTable();
            table = AnnouncingFilter.GetAnnouncingFilter(filter);
            foreach(DataRow row in table.Rows)
            {
                try
                {
                    annonc.Announcing_id = int.Parse(row["Announcing_id"].ToString());
                    annonc.Name_Announcing = row["Name_Announcing"].ToString();
                    annonc.Name_City = row["City_Name"].ToString();
                    annonc.Info_Announcing = row["Info_Announcing"].ToString();
                    listAnnonc.Add(new Announcing() {Announcing_id=annonc.Announcing_id,Name_Announcing=annonc.Name_Announcing,Name_City =annonc.Name_City,Info_Announcing=annonc.Info_Announcing });
                }
                catch (Exception ex)
                {
                    Logger.CreateLog(ex);
                    throw ex;
                }
            }
            return listAnnonc;
        }

        public string GetAnnouncing()
        {
            DataTable table = AnnouncingFunction.GetAnnouncing();
            string json = JsonConvert.SerializeObject(table);
            return json;
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

        //public string GetCityAll()
        //{
        //    DataTable table = SqlAccess.GetCityAll();
        //    string json = JsonConvert.SerializeObject(table);
        //    return json;

        //}

        public List<Cities> GetCityForCountry(int Country_id)
        {
            DataTable table = Location.GetCityForCountry(Country_id);
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
        
        public UserList GetUser(int User_id)
        {
            UserList _user = new UserList();
            List<UserList> _users = new List<UserList>(); 
            DataTable table = Profile.GetUser(User_id);
            foreach(DataRow row in table.Rows)
            {
                _user.FIO = row["FIO"].ToString();
                _user.Country_id = int.Parse(row["Country_id"].ToString());
                _user.Phone = byte.Parse(row["Phone"].ToString());
                _user.User_id = int.Parse(row["User_id"].ToString());
                _user.Gender_user = row["Gender_user"].ToString();
                _user.Date_Bearthday = DateTime.Parse(row["Date_Bearthday"].ToString());
                _user.Info = row["Info"].ToString();
                //_users.Add(new UserList() { FIO = _user.FIO, Country_id = _user.Country_id, Phone = _user.Phone,
                //    User_id = _user.User_id, Gender_user = _user.Gender_user, Date_Bearthday = _user.Date_Bearthday,Info=_user.Info});
            }
            return _user;
        }
        
        public string PostRegistration(string json)
        {
            DataTable table = new DataTable();
            table = JsonConvert.DeserializeObject<DataTable>(json);
            table = Profile.PostRegistration(table);
            json = JsonConvert.SerializeObject(table);
            return json;
        }

        public List<Announcing> GetAnnouncingForCategory(string category_id)
        {
            List<Announcing> listAnnonc =new List<Announcing>();
            Announcing annonc = new Announcing();
            int cat_id = int.Parse(category_id);
            DataTable table = AnnouncingFilter.GetAnnouncingForCategory(cat_id);
            foreach(DataRow row in table.Rows)
                {
                annonc.Announcing_id = int.Parse(row["Announcing_id"].ToString());
                annonc.Name_Announcing = row["Name_Announcing"].ToString();
                annonc.Phone_Announcing = int.Parse(row["Phone_Announcing"].ToString());
                annonc.Date_Announcing =DateTime.Parse( row["Date_Announcing"].ToString());
                annonc.Info_Announcing = row["info_Announcing"].ToString();
                annonc.Categories_id =  int.Parse(row["Categories_id"].ToString());
                annonc.User_id =int.Parse(row["User_id"].ToString());
                annonc.City_id = int.Parse(row["City_id"].ToString());
                annonc.Areas_id = int.Parse(row["Areas_id"].ToString());
                listAnnonc.Add(new Announcing() { Name_Announcing = annonc.Name_Announcing, Announcing_id = annonc.Announcing_id, Phone_Announcing = annonc.Phone_Announcing, Date_Announcing = annonc.Date_Announcing, Info_Announcing = annonc.Info_Announcing, Categories_id = annonc.Categories_id, User_id = annonc.User_id, City_id = annonc.City_id, Areas_id = annonc.Areas_id });
                }
               
                
            return listAnnonc;
                
            
        }

        public AnnFilter TestFunction(AnnFilter filter)
        {
            
            return filter;
        }       
    }
    
}
