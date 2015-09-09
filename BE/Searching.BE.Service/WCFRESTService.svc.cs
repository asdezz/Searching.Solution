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

namespace Searching.BE.Service
{
    public class WCFRESTService : IWCFRESTService
    {
        public string GetAnnouncingFilter(string json)
        {
            
            DataTable table = JsonConvert.DeserializeObject<DataTable>(json);
            //int country = table.Country_id;
            //int city = table.City_id;
            //int areas = table.Areas_id;
            //char Gender_user = table.Gender_user;
            //int Date_Bearthday = table.Date_Bearthday;
            table = AnnouncingFilter.GetAnnouncingFilter(table);
            throw new NotImplementedException();
        }

        public string GetAnnouncing()
        {
            DataTable table = AnnouncingFunction.GetAnnouncing();
            string json = JsonConvert.SerializeObject(table);
            return json;
        }
        
        public string GetAreasOfCity(int City_id)
        {
            DataTable table = Location.GetAreasOfCity(City_id);
            string json = JsonConvert.SerializeObject(table);
            return json;
        }

        public string GetCategories()
        {
            DataTable table = AnnouncingFilter.GetCategories();
            string json = JsonConvert.SerializeObject(table);
            return json;
        }

        //public string GetCityAll()
        //{
        //    DataTable table = SqlAccess.GetCityAll();
        //    string json = JsonConvert.SerializeObject(table);
        //    return json;

        //}

        public string GetCityForCountry(int Country_id)
        {
            DataTable table = Location.GetCityForCountry(Country_id);
            string json = JsonConvert.SerializeObject(table);
            return json;
        }

        public string GetCountryList()
        {
            DataTable table = Location.GetCountryList();
           string json = JsonConvert.SerializeObject(table);
            return json;
        }
        
        public string GetFavoriteAnnuncing(int User_id)
        {
            DataTable table = FavoriteAnnouncingFunction.GetFavoriteAnnouncing(User_id);
            string json = JsonConvert.SerializeObject(table);
            return json;
        }
        
        public string GetSelectedAnnouncing(int User_id)
        {
            DataTable table = SelectedAnnouncingFunction.GetSelectedAnnouncing(User_id);
            string json = JsonConvert.SerializeObject(table);
            return json;
        }
        
        public string GetUser(int User_id)
        {
            DataTable table = Profile.GetUser(User_id);
            string json = JsonConvert.SerializeObject(table);
            return json;
        }
        
        public string PostRegistration(string json)
        {
            DataTable table = new DataTable();
            table = JsonConvert.DeserializeObject<DataTable>(json);
            table = Profile.PostRegistration(table);
            json = JsonConvert.SerializeObject(table);
            return json;
        }
        //
        //public string UpdateUserInfo(int User_id,char? Mail = null, char? FIO = null, int? Phone = null, char? Gender_user = null, int? Date_Bearthday = null, char? pass = null, string info = null, int? Country_id = null, int? type_login = null, int? City_id = null)
        //{
        //    DataTable table = SqlAccess.GetCountryList();
        //    string json = JsonConvert.SerializeObject(table);
        //    return json;
        //}
    }
}
