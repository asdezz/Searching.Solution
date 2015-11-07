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
                    listAnnonc.Add(new Announcing() {Announcing_id=annonc.Announcing_id,Name_Announcing=annonc.Name_Announcing,Name_City =annonc.Name_City });
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
