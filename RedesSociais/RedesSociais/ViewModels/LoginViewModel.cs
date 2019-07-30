using RedesSociais.Models;
using RedesSociais.Services;
using RedesSociais.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RedesSociais.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        #region ATRIBUTOS & PROPRIEDADES

        private bool _isLogedIn;
        public bool IsLogedIn
        {
            get { return _isLogedIn; }
            set { SetProperty(ref _isLogedIn, value); }
        }

        private GoogleUser _googleUser;

        public GoogleUser GoogleUser
        {
            get { return _googleUser; }
            set { SetProperty(ref _googleUser, value); }
        }

        private FacebookUser _facebookUser;

        public FacebookUser FacebookUser
        {
            get { return _facebookUser; }
            set { SetProperty(ref _facebookUser, value); }
        }


        #endregion

        #region VARIÁVEIS GLOBAIS
        readonly IGoogleService _googleService;
        readonly IFacebookService _facebookService;
        MainViewModel mainViewModel;
        #endregion

        #region CONSTRUTOR
        public LoginViewModel()
        {
            _googleService = DependencyService.Get<IGoogleService>();
            _facebookService = DependencyService.Get<IFacebookService>();
            mainViewModel = new MainViewModel();


        }
        #endregion

        #region COMMANDS
        public ICommand GoogleLoginCommand => new Command(OnGoogleLogin);
        public ICommand GoogleLogoutCommand => new Command(OnGoogleLogout);
        public ICommand FacebookLoginCommand => new Command(FacebookLogin);
        public ICommand FacebookLogoutCommand => new Command(FacebookLogout);
        #endregion

        #region MÉTODOS
        private void OnGoogleLogin()
        {
            _googleService?.Login(OnLoginComplete);
        }

        private void OnGoogleLogout()
        {
            _googleService?.Logout();
            IsLogedIn = false;
        }

        private void OnLoginComplete(GoogleUser googleUser, string message)
        {
            if (googleUser != null)
            {
                GoogleUser = googleUser;
                IsLogedIn = true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", message, "Ok");
            }
        }

       

        private  void FacebookLogin()
        {
            _facebookService?.Login(mainViewModel.OnLoginCompleted);
        }

        private void FacebookLogout()
        {
            _facebookService?.Logout();
            IsLogedIn = false;
        }

        //private async void OnLoginCompleted(FacebookUser facebookUser, string exception)
        //{
        //    if (exception == null)
        //    {
        //        FacebookUser = facebookUser;
        //        IsLogedIn = true;
        //        await App.Current.MainPage.Navigation.PushAsync(new MainPage());
        //    }
        //    else
        //    {
        //        Debug.WriteLine($"====={exception}=====");
        //        await App.Current.MainPage.DisplayAlert("Error", exception, "OK");
        //    }
        //}
        #endregion

    }
}
