using RedesSociais.Models;
using RedesSociais.Services;
using RedesSociais.Views;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace RedesSociais.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        #region ATRIBUTOS & PROPRIEDADES

        #endregion

        #region VARIÁVEIS GLOBAIS
        readonly IGoogleService _googleService;
        readonly IFacebookService _facebookService;
        readonly IRedeSocialService _redeSocialService;
        MainViewModel mainViewModel;
        #endregion

        #region CONSTRUTOR
        public LoginViewModel()
        {
            _googleService = DependencyService.Get<IGoogleService>();
            _facebookService = DependencyService.Get<IFacebookService>();
            _redeSocialService = DependencyService.Get<IRedeSocialService>();
            mainViewModel = new MainViewModel();
        }
        #endregion

        #region COMMANDS
        public ICommand GoogleLoginCommand => new Command(OnGoogleLogin);
        public ICommand FacebookLoginCommand => new Command(FacebookLogin);


        #endregion

        #region MÉTODOS
        private void OnGoogleLogin()
        {
            _googleService?.Login(OnLoginComplete);
        }



        //private void OnLoginComplete(Users users, string message)
        //{
        //    if (users != null)
        //    {
        //        GoogleUser = googleUser;
        //        IsLogedIn = true;
        //    }
        //    else
        //    {
        //        App.Current.MainPage.DisplayAlert("Error", message, "Ok");
        //    }
        //}

        private void FacebookLogin()
        {
            _facebookService?.Login(OnLoginComplete);
        }


        private async void OnLoginComplete(Users users, string exception)
        {
            if (string.IsNullOrEmpty(exception))
            {
                IsLoggedIn = true;
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());

                Xamarin.Forms.MessagingCenter.Send(new Users(users.Id, users.Token, users.FirstName,
                                                                      users.LastName, users.Email, users.Picture)
                { Pic = users.Pic }, "login");
            }
            else
            {
                Debug.WriteLine($"====={exception}=====");
                await App.Current.MainPage.DisplayAlert("Error", exception, "OK");
            }
        }
        #endregion

    }
}
