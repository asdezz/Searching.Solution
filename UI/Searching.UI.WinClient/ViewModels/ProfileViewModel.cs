using Caliburn.Micro;
using Searching.UI.WinPhoneClient.Logics.Client;
using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinClient.ViewModels
{
   public class ProfileViewModel:Screen
    {
        INavigationService navigationService;
       private UserList _user = new UserList();
       private ReturnValue value = new ReturnValue();
        public ProfileViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            DisplayName = "Профиль";
        }

        public void GoToRegistration()
        {
            navigationService.UriFor<RegistrationViewModel>()
                .Navigate();
        }
            
        public UserList User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                NotifyOfPropertyChange(() => TakeLogin);
                NotifyOfPropertyChange(() => TakePassword);
            }
        }
        public string TakeLogin
        {
            get
            {
                return _user.Mail;
            }
            set
            {
                _user.Mail = value;
                NotifyOfPropertyChange(() => TakeLogin);
                NotifyOfPropertyChange(() => User);
            }
        }
        public string TakePassword
        {
            get
            {
               return _user.Password;
            }
            set
            {
                _user.Password = value;
                NotifyOfPropertyChange(() => TakePassword);
                NotifyOfPropertyChange(() => User);
            }
        }
        public async void Auth()
        {
            value = await QueryList.Auth(User);
            if (value.Code == true)
                User = await QueryList.GetUser(User.User_id);

        }
    }
}
