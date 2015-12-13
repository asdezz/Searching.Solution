using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinClient.Storage
{
    public class DBAdd
    {
        public void AddUser(UserList user)
        {
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                LUsers _user = new LUsers();
                _user.User_id = user.User_id;
                _user.City_id = _user.City_id;
                _user.Country_id = user.Country_id;
                _user.Date_Bearthday = user.Date_Bearthday;
                _user.FIO = user.Name;
                _user.Gender_user = user.Gender_user;
                _user.Info = user.Info;
                _user.Mail = user.Mail;
                _user.Password = user.Password;
                _user.Type_login = user.Type_login;
                context.User.InsertOnSubmit(_user);
                context.SubmitChanges();
            }
        }
    }
}