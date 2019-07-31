using RedesSociais.Models;
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
            set {SetProperty(ref _facebookUser , value); }
        }

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set {SetProperty(ref _isLoggedIn , value); }
        }

        readonly IFacebookService _facebookService;

        public FacebookViewModel()
        {
             _facebookService = DependencyService.Get<IFacebookService>();
        }

        public ICommand FacebookLoginCommand => new Command (FacebookLogin);
        public ICommand FacebookLogoutCommand => new Command(FacebookLogout);

       

        private void FacebookLogin()
        {
            _facebookService?.Login(OnLoginComplete);
        }

        private void FacebookLogout()
        {
            _facebookService?.Logout();
            IsLoggedIn = false;
        }

        private void OnLoginComplete(FacebookUser facebookUser, string exception)
        {
            if (string.IsNullOrEmpty(exception))
            {
                FacebookUser = facebookUser;
                IsLoggedIn = true;
            }
            else
            {
                Debug.WriteLine($"====={exception}=====");
                App.Current.MainPage.DisplayAlert("Error", exception, "OK");
            }
        }
    }
}
