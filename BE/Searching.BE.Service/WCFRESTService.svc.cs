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



namespace Searching.BE.Service
{
    public class WCFRESTService : IWCFRESTService
    {
        public string GetAnnouncingFilter(string json)
        {
            
            DataTable table = JsonConvert.DeserializeObject<DataTable>(json);
            table = AnnouncingFilter.GetAnnouncingFilter(table);
            json = JsonConvert.SerializeObject(table);
            return json;
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
                string json= JsonConvert.SerializeObject(ListCategories);
            return ListCategories;
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

        public DataTable GetAnnouncingForCategory(string category_id)
        {
            int cat_id = int.Parse(category_id);
            DataTable table = AnnouncingFilter.GetAnnouncingForCategory(cat_id);
            return table;
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
