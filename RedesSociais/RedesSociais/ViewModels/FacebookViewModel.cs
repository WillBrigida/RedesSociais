﻿using RedesSociais.Models;
using RedesSociais.Services;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace RedesSociais.ViewModels
{
    public class FacebookViewModel : BaseViewModel
    {
        private FacebookUser _facebookUser;

        public FacebookUser FacebookUser
        {
            get { return _facebookUser; }
            set { _facebookUser = value; }
        }

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; }
        }

        readonly IFacebookService _facebookService;

        public FacebookViewModel()
        {
            // _facebookService = DependencyService.Get<IFacebookService>();
        }

        public ICommand FacebookLoginCommand => new Command (FacebookLogin);
        public ICommand FacebookLogoutCommand => new Command(FacebookLogout);




        private void OnLoginComplete(FacebookUser facebookUser, string message)
        {
            if (facebookUser != null)
            {
                FacebookUser = facebookUser;
                IsLoggedIn = true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", message, "Ok");
            }
        }

        private void FacebookLogin()
        {
            DependencyService.Get<IFacebookService>()?.Login(OnLoginCompleted);
        }
        private void FacebookLogout()
        {
            DependencyService.Get<IFacebookService>()?.Logout();
            IsLoggedIn = false;
        }

        private void OnLoginCompleted(FacebookUser facebookUser, Exception exception)
        {
            if (exception == null)
            {
                FacebookUser = facebookUser;
                IsLoggedIn = true;
                App.Current.MainPage.DisplayAlert("Resposta da API", $"Nome: {facebookUser.FirstName}\n {facebookUser.Id}", "OK");
            }
            else
            {
                Debug.WriteLine($"====={exception.Message}=====");
                App.Current.MainPage.DisplayAlert("Error", exception.Message, "OK");
            }
        }
    }
}