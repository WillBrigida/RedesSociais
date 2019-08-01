using RedesSociais.Models;
using RedesSociais.Services;
using System.Windows.Input;
using Xamarin.Forms;

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

        private string _teste;
        public string Teste
        {
            get { return _teste; }
            set {SetProperty(ref _teste , value); }
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
        #endregion

        #region CONSTRUTOR
        public MainViewModel()
        {
            _googleService = DependencyService.Get<IGoogleService>();
            _facebookService = DependencyService.Get<IFacebookService>();
            Init();
        }
        #endregion

        #region COMMANDS
        public ICommand GoogleLogoutCommand => new Command(OnGoogleLogout);
        public ICommand FacebookLogoutCommand => new Command(FacebookLogout);
        #endregion

        #region MÉTODOS
        private void Init()
        {
            MessagingCenter.Subscribe<Users>(this, "login", message =>
            {
                Users = message;
                IsLoggedIn = true;
            });
        }

        private void OnGoogleLogout()
        {
            _googleService?.Logout();
            IsLogedIn = false;
        }

        private void FacebookLogout()
        {
            _facebookService?.Logout();
            IsLoggedIn = false;
        }

        #endregion

    }
}
