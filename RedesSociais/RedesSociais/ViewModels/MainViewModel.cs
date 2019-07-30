using RedesSociais.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedesSociais.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region ATRIBUTOS & PROPRIEDADES
        private Users _users;

        public Users Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        private static Users _user;

        public static Users MyProperty
        {
            get { return _user; }
            set { _user = value; }
        }


        private FacebookUser _facebookUser;

        public FacebookUser FacebookUser
        {
            get { return _facebookUser; }
            set { SetProperty(ref _facebookUser, value); }
        }
        #endregion
        public MainViewModel()
        {
            Init();
        }

        private void Init()
        {
            if (this.FacebookUser != null)
            {
                //FacebookUser = this.Users;

            }
        }

        public async void OnLoginCompleted(FacebookUser facebookUser, string message)
        {
            if (facebookUser != null)
            {
                Users.Picture = facebookUser.Picture;
                Users.Name = facebookUser.FirstName;
                Users.Email = facebookUser.Email;
                FacebookUser = facebookUser;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", message, "Ok");
            }
        }
    }
}
