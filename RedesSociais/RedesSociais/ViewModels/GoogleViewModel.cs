using RedesSociais.Models;
using RedesSociais.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace RedesSociais.ViewModels
{
    public class GoogleViewModel : BaseViewModel
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

        #endregion

        #region VARIÁVEIS GLOBAIS
        readonly IGoogleService _googleService;
        #endregion

        #region CONSTRUTOR
        public GoogleViewModel()
        {
            _googleService = DependencyService.Get<IGoogleService>();
        }
        #endregion

        #region COMMANDS
        public ICommand GoogleLoginCommand => new Command(OnGoogleLogin);
        public ICommand GoogleLogoutCommand => new Command(OnGoogleLogout);
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
        #endregion

    }
}
